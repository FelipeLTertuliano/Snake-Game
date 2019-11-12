using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace SnakeGame
{
    class Program
    {

        static void Main(string[] args)
        {
            Snake snake = new Snake(10,10);
            bool start = true;
            bool end = false;

            while (!end)
            {
                try
                {
                    if (start)
                    {
                        end = !snake.Walk(Console.ReadKey());
                        start = false;
                    }
                    else
                    {
                        end = !snake.Walk(Reader.ReadKey(500));
                    }
                }
                catch
                {
                    end = !snake.Walk();
                }
                Console.Clear();
                Console.WriteLine(MapHelp.PrintMap(snake));
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}
