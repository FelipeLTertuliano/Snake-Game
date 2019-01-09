using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Snake snake = new Snake(10,10);

            while (snake.Walk(Console.ReadKey()))
            {
                Console.Clear();
                Console.WriteLine(MapHelp.PrintMap(snake));
            }
        }
    }
}
