using System;
using NUnit.Framework;
using WaterProgram;

namespace WaterTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test01WaterAt20Degrees()
    {
        var water = new Water(50, 20);
        Assert.AreEqual(WaterState.Fluid, water.State);
        Assert.AreEqual(20, water.Temperature);
        Assert.AreEqual(50, water.Amount);
    }
    
    [Test]
    public void Test02WaterAtMinus20Degrees()
    {
        var water = new Water(50, -20);
        Assert.AreEqual(WaterState.Ice, water.State);
        Assert.AreEqual(-20, water.Temperature);
    }
    
    [Test]
    // Tester om tilstanden blir gass ved 120 grader
    public void Test03WaterAt120Degrees()
    {
        var water = new Water(50, 120);
        Assert.AreEqual(WaterState.Gas, water.State);
        Assert.AreEqual(120, water.Temperature);
    }
    
    [Test]
    public void Test04WaterAt100DegreesWithoutProportion()
    {
        var exception = Assert.Throws<ArgumentException>(() =>
        {
            new Water(50, 100);
        });

        Assert.That(exception?.Message, Is.EqualTo("When temperature is 0 or 100, you must provide a value for proportion"));
    }
    
    [Test]
    // Sjekker at vi får miks av flytende og gass, med 30% av det første
    public void Test05WaterAt100Degrees()
    {
        var water = new Water(50, 100, 0.3);
        Assert.AreEqual(WaterState.FluidAndGas, water.State);
        Assert.AreEqual(100, water.Temperature);
        Assert.AreEqual(0.3, water.ProportionFirstState);
    }
    
    [Test]
    // Tester at når vi tilfører energi, så stiger temperaturen med riktig antall grader
    public void Test06AddEnergy1()
    {
        var water = new Water(4, 10);
        water.AddEnergy(10);
        Assert.AreEqual(12.5, water.Temperature);
    }
    
    [Test]        
    public void Test07AddEnergy2()
    {
        var water = new Water(4, -10);
        water.AddEnergy(10);
        Assert.AreEqual(-7.5, water.Temperature);
    }
    
    [Test]
    // Tester at vann under 0 grader både varmes til 0 og så smeltes om vi tilfører nok energi.
    // Tester også at temperaturen stopper på 0 grader om vi ikke har nok energi til å smelte alt.
    public void Test08AddEnergy3()
    {
        var water = new Water(4, -10);
        water.AddEnergy(168);
        Assert.AreEqual(0, water.Temperature);
        Assert.AreEqual(WaterState.IceAndFluid, water.State);
        Assert.AreEqual(0.6, water.ProportionFirstState);
    }
    
    [Test]
    public void Test09AddEnergy4()
    {
        var water = new Water(4, -10);
        water.AddEnergy(360);
        Assert.AreEqual(0, water.Temperature);
        Assert.AreEqual(WaterState.Fluid, water.State);
    }
    
    [Test]
    // Tester at overflødig energi etter smelting går til oppvarming med riktig antall grader.
    public void Test10AddEnergy5()
    {
        var water = new Water(4, -10);
        water.AddEnergy(400);
        Assert.AreEqual(10, water.Temperature);
        Assert.AreEqual(WaterState.Fluid, water.State);
    }
    
    [Test]
    public void Test11FluidToGasA()
    {
        var water = new Water(10, 70);
        water.AddEnergy(900);
        Assert.AreEqual(100, water.Temperature);
        Assert.AreEqual(WaterState.FluidAndGas, water.State);
        Assert.AreEqual(0.9, water.ProportionFirstState);
    }
    
    [Test]
    public void Test12FluidToGasB()
    {
        var water = new Water(10, 70);
        water.AddEnergy(6300);
        Assert.AreEqual(100, water.Temperature);
        Assert.AreEqual(WaterState.Gas, water.State);
    }
    
    [Test]
    public void Test13FluidToGasC()
    {
        var water = new Water(10, 70);
        water.AddEnergy(6400);
        Assert.AreEqual(110, water.Temperature);
        Assert.AreEqual(WaterState.Gas, water.State);
    }
    
    [Test]
    public void Test13IceToGasA()
    {
        var water = new Water(4, -10);
        water.AddEnergy(3160);
        Assert.AreEqual(100, water.Temperature);
        Assert.AreEqual(WaterState.Gas, water.State);
    }    



}