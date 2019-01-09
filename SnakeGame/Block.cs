using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Block
    {
        public int LastHeight { get; private set; }
        public int LastWidth { get; private set; }
        public char Icon { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        public Block(char icon, int heigth, int width)
        {
            Icon = icon;
            Height = heigth;
            Width = width;
        }

        public Block(Block nextBlock, char icon)
        {
            Icon = icon;
            Height = nextBlock.LastHeight;
            Width = nextBlock.LastWidth;
        }

        public Block(char icon, char[,] map, Block head, List<Block> body)
        {
            bool review = true;

            while (review)
            {
                Random random = new Random();

                Height = random.Next(0, map.GetLength(0));
                Width = random.Next(0, map.GetLength(1));

                if ((head.Height != Height && head.Width != Width) &&
                    (head.Height != Height + 1 && head.Width != Width + 1) &&
                    (head.Height != Height + 1 && head.Width != Width - 1) &&
                    (head.Height != Height - 1 && head.Width != Width + 1) &&
                    (head.Height != Height - 1 && head.Width != Width - 1))
                {
                    if(body.Count == 0)
                    {
                        Icon = icon;
                        review = false;
                    }
                    else
                    {
                        int contError = 0;

                        foreach (Block piese in body)
                        {
                            if ((piese.Height == Height && piese.Width == Width) ||
                            (piese.Height == Height + 1 && piese.Width == Width + 1) ||
                            (piese.Height == Height + 1 && piese.Width == Width - 1) ||
                            (piese.Height == Height - 1 && piese.Width == Width + 1) ||
                            (piese.Height == Height - 1 && piese.Width == Width - 1))
                            {
                                contError++;
                            }
                        }

                        if (contError == 0)
                        {
                            Icon = icon;
                            review = false;
                        }
                    }
                }
            }
        }

        public void GoUp(bool side)
        {
            LastHeight = Height;
            LastWidth = Width;

            if (side)
            {
                Height--;
            }
            else
            {
                Height++;
            }
        }

        public void GoRigth(bool side)
        {
            LastHeight = Height;
            LastWidth = Width;

            if (side)
            {
                Width++;
            }
            else
            {
                Width--;
            }
        }

        public void MakeLastLocation()
        {
            LastHeight = Height;
            LastWidth = Width;
        }

        public void ChangeLocation(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }
}
