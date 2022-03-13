namespace KonsollApp.Exercise;

public static class ArrrayExercises
{
    public static void Run()
    {
        Console.WriteLine(IsArraySorted(new int[] {1, 2, 3, 4}, 4));
    }

    private static bool IsArraySorted(int[] numArray, int elementCount)
    {
        int lastValue = 0;
        for (int i = 0; i < elementCount; i++)
        {
            if (lastValue+1 == numArray[i])
            {
                lastValue = numArray[i];
                continue;
            }
            return false;
        }

        return true;
    }
}