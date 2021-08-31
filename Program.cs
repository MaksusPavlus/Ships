using System;

namespace Ships
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($" There are: {ShipsCounter.Count()} ships on the field.");

            Console.ReadKey();
        }
    }

    public class ShipsCounter
    {
        static int[,] ships = {
         {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
         {0, 1, 0, 0, 0, 0, 0, 1, 0, 0},
         {0, 1, 0, 1, 1, 0, 0, 0, 0, 0},
         {0, 1, 0, 1, 1, 0, 0, 1, 1, 1},
         {0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
         {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
         {1, 1, 1, 1, 0, 1, 0, 0, 0, 0},
         {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
         {1, 1, 0, 0, 0, 0, 0, 1, 0, 0},
         {1, 1, 0, 0, 0, 0, 0, 0, 0, 1}
        };

        static bool[,] field = new bool[ships.Length, ships.Length];


        static public int Count()
        {
            int amount = 0;

            for (int i = 0; i < ships.GetLength(0); i++)
            {
                int pre = 0;

                for (int j = 0; j < ships.GetLength(1); j++)
                {
                    if (ships[i,j] == 1 && pre == 0)
                    {
                        amount++;
                    }
                    pre = ships[i, j];
                }
            }

            return amount - CountBool();
        }

        static private void BoolMap()
        {
            for (int i = 0; i < ships.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < ships.GetLength(1); j++)
                {
                    if (ships[i, j] == ships[i + 1, j] && ships[i + 1, j] == 1)
                    {
                        field[i, j] = true;
                    }
                }
            }
        }

        static private int CountBool()
        {
            bool pre = false;

            int amount = 0;

            BoolMap();

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == true && pre != true)
                    {
                        amount++;
                    }
                    pre = field[i, j];
                }
            }
            return amount;
        }
    }

}
