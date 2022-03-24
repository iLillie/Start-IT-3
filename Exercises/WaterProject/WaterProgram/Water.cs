namespace WaterProgram;

public class Water
{
    private const int ENERGY_TO_MELT_ICE = 80;
    private const int ENERGY_TO_EVAPORATE_WATER = 600;
    public WaterState State { get; set; }
    public int Amount { get; set; }
    public double Temperature { get; set; }
    public double Energy { get; set; }
    public double ProportionFirstState { get; set; }

    public Water(int amount, double temperature)
    {
        if (temperature is 0 or 100)
            throw new ArgumentException("When temperature is 0 or 100, you must provide a value for proportion");
        Amount = amount;
        Temperature = temperature;
        ProportionFirstState = 1;
        State = GetState();
    }

    public Water(int amount, double temperature, double proportionFirstState)
    {
        Amount = amount;
        Temperature = temperature;
        ProportionFirstState = proportionFirstState;
        State = GetState();
    }

    private WaterState GetState()
    {
        var isNotChangingState = !(ProportionFirstState < 1);
        if (isNotChangingState)
            return Temperature switch
            {
                >= 100 => WaterState.Gas,
                < 0 => WaterState.Ice,
                _ => WaterState.Fluid
            };
        return Temperature switch
        {
            100 => WaterState.FluidAndGas,
            0 => WaterState.IceAndFluid,
            _ => WaterState.Fluid
        };
    }

    public void AddEnergy(double energy)
    {
        Energy += energy;
        Calculate();
    }

    private void IncreaseTemperature(double energy)
    {
        if (Energy < energy) return;
        Energy -= energy;
        Temperature += (energy / Amount);
    }

    private void IncreaseTemperaturesToZeroIfPossible()
    {
        var energyRequiredToHitZero = Math.Abs(Temperature) * Amount;
        if (Energy >= energyRequiredToHitZero)
        {
            IncreaseTemperature(energyRequiredToHitZero);
        }
    }

    private void IncreaseTempeaturesTo100IfPossible()
    {
        var energyToHit100 = (100 - Temperature) * Amount;
        if (Energy > energyToHit100)
        {
            IncreaseTemperature(energyToHit100);
        }
    }

    private void TryChangeState(int energyRequired, int requiredTemp)
    {
        if (Temperature != requiredTemp) return;
        var energyToChangeState = (energyRequired * Amount);
        var Proportion = Energy / energyToChangeState;
        if (Proportion >= 1.0)
        {
            ProportionFirstState = 1.0;
            Energy -= energyToChangeState;
        }
        else
        {
            ProportionFirstState = 1.0 - Proportion;
            Energy -= energyToChangeState * Proportion;
        }
    }

    private void Calculate()
    {
        if (Temperature < 0)
        {
            IncreaseTemperaturesToZeroIfPossible();
            TryChangeState(ENERGY_TO_MELT_ICE, 0);
        }

        if (Temperature is < 100 and >= 0)
        {
            IncreaseTempeaturesTo100IfPossible();
            TryChangeState(ENERGY_TO_EVAPORATE_WATER, 100);
        }

        IncreaseTemperature(Energy);
        State = GetState();
    }
}

public enum WaterState
{
    Fluid,
    Gas,
    Ice,
    FluidAndGas,
    IceAndFluid
}