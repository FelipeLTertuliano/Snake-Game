using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Snake
    {
        public char[,] Map { get; private set; }
        public Block Head { get; private set; }
        public List<Block> Body { get; private set; } 
        public ConsoleKeyInfo Direction { get; private set; }
        public Block Food { get; private set; }

        public Snake(int mapH, int mapW)
        {
            Map = new char[mapH, mapW];

            for(int h = 0; h < Map.GetLength(0); h++)
            {
                for(int w = 0; w < Map.GetLength(1); w++)
                {
                    Map[h, w] = ' ';
                }
            }

            Head = new Block('0', Map.GetLength(0) / 2, Map.GetLength(1) / 2);
            Body = new List<Block>();
            Food = new Block('*', Map, Head, Body);
        }

        public void AddMapIcon(char icon, int height, int width)
        {
            Map[height, width] = icon;
        }

        private void GenerateMap()
        {
            for (int h = 0; h < Map.GetLength(0); h++)
            {
                for (int w = 0; w < Map.GetLength(1); w++)
                {
                    char blockPrint = ' ';

                    if (Food.Height == h && Food.Width == w)
                    {
                        blockPrint = Food.Icon;
                    }

                    if (Head.Height == h && Head.Width == w)
                    {
                        blockPrint = Head.Icon;
                    }

                    foreach (Block body in Body)
                    {
                        if (body.Height == h && body.Width == w)
                        {
                            blockPrint = body.Icon;
                        }
                    }

                    AddMapIcon(blockPrint, h, w);
                }
            }
        }


        private void TryEat()
        {
           if (Head.Height == Food.Height && Head.Width == Food.Width)
            {
                if(Body.Count == 0)
                {
                    Body.Add(new Block(Head,'o'));
                }
                else
                {
                    Body.Add(new Block(Body[Body.Count - 1],'o'));
                }
                Food = new Block('*', Map, Head, Body);
            }
        }

        public bool Walk(ConsoleKeyInfo direction)
        {
            _referencial(direction);
            
            Folow();

            bool result = true;

            foreach (Block block in Body)
            {
                if (block.Height == Head.Height && block.Width == Head.Width)
                {
                    result = false;
                }
            }

            if ((Head.Width < 0 || Head.Width >= Map.GetLength(1)) ||
                (Head.Height < 0 || Head.Height >= Map.GetLength(0)))
            {
                result = false;
            }

            if (result)
            {
                TryEat();
                GenerateMap();
            }

            return result;
        }

        public bool Walk()
        {
            _referencial(Direction);

            Folow();

            bool result = true;

            foreach (Block block in Body)
            {
                if (block.Height == Head.Height && block.Width == Head.Width)
                {
                    result = false;
                }
            }

            if ((Head.Width < 0 || Head.Width >= Map.GetLength(1)) ||
                (Head.Height < 0 || Head.Height >= Map.GetLength(0)))
            {
                result = false;
            }

            if (result)
            {
                TryEat();
                GenerateMap();
            }

            return result;
        }

        public void Folow()
        {
            for (int i = 0; i < Body.Count; i++)
            {
                if(i != 0)
                {
                    Body[i].MakeLastLocation();
                    Body[i].ChangeLocation(Body[i - 1].LastHeight, Body[i - 1].LastWidth);
                }
                else
                {
                    Body[i].MakeLastLocation();
                    Body[i].ChangeLocation(Head.LastHeight, Head.LastWidth);
                }
            }
        }

        private void _referencial(ConsoleKeyInfo direction)
        {
            if (_canMove(direction))
            {
                switch (direction.Key)
                {
                    case ConsoleKey.UpArrow:

                        Head.GoUp(true);

                        break;

                    case ConsoleKey.RightArrow:

                        Head.GoRigth(true);

                        break;

                    case ConsoleKey.DownArrow:

                        Head.GoUp(false);

                        break;

                    case ConsoleKey.LeftArrow:

                        Head.GoRigth(false);

                        break;
                }
                Direction = direction;
            }
        }

        private bool _canMove(ConsoleKeyInfo direction)
        {
            switch (direction.Key)
            {
                case ConsoleKey.UpArrow:

                    if(!(Direction.Key == ConsoleKey.DownArrow))
                    {
                        return true;
                    }

                    break;

                case ConsoleKey.RightArrow:

                    if (!(Direction.Key == ConsoleKey.LeftArrow))
                    {
                        return true;
                    }

                    break;

                case ConsoleKey.DownArrow:

                    if (!(Direction.Key == ConsoleKey.UpArrow))
                    {
                        return true;
                    }

                    break;

                case ConsoleKey.LeftArrow:

                    if (!(Direction.Key == ConsoleKey.RightArrow))
                    {
                        return true;
                    }

                    break;
            }
            return false;
        }
    }

}
