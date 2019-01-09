using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class MapHelp
    {
        public static string PrintMap(Snake snake)
        {
            string print = "";

            for (int i = 0; i < snake.Map.GetLength(1) + 2; i++)
            {
                print += "# ";
            }

            print += "\n";

            for (int h = 0; h < snake.Map.GetLength(0); h++)
            {
                print += "# ";

                for (int w = 0; w < snake.Map.GetLength(1); w++)
                {
                    print += $" {snake.Map[h, w].ToString()}";
                }

                print += "# \n";
            }

            for (int i = 0; i < snake.Map.GetLength(1) + 2; i++)
            {
                print += "# ";
            }

            return print;
        }
    }
}
