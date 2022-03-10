namespace KonsollApp.Tasks;

internal static class Task8
{
    public static void Run()
    {
        TriangleFigure();
        StarFigure();
        CrossFigure();
    }

    private static void TriangleFigure()
    {
        for (var i = 0; i < 4; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                var isWithinTriangleRange = j >= i && j < 8 - i;
                if (isWithinTriangleRange)
                {
                    Console.Write("#");
                    continue;
                }

                Console.Write(" ");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    private static void StarFigure()
    {
        for (var i = 0; i < 4; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                if (j >= 4 - (i + 1) && j < 8 - (3 - i))
                {
                    Console.Write("#");
                    continue;
                }

                Console.Write(" ");
            }

            Console.WriteLine();
        }

        for (var i = 0; i < 4; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                if (j >= i && j < 8 - i)
                {
                    Console.Write("#");
                    continue;
                }

                Console.Write(" ");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    private static void CrossFigure()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                // up left part
                if (j >= i && j <= i * 2)
                {
                    Console.Write("#");
                    continue;
                }
                // up right part
                if (j >= 13 - (i * 2) && j <= 13 - i)
                {
                    Console.Write("#");
                    continue;
                }
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                // up left part
                int downValue = 3 - i;
                if (j >= downValue && j <= downValue * 2)
                {
                    Console.Write("#");
                    continue;
                }
                // up right part
                if (j >= 13 - (downValue * 2) && j <= 13 - downValue)
                {
                    Console.Write("#");
                    continue;
                }
                Console.Write(" ");
            }
            Console.WriteLine();
            
        }
    }
}