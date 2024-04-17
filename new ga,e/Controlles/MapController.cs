using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace new_ga_e.Controlles
{
    public static class MapController
    {
        public const int mapHeight = 20;
        public const int mapWidth = 20;
        public static int cellSize = 31;
        public static int[,] map = new int[mapHeight, mapWidth];
        public static Image spriteSheet;

        public static void Init()
        {

            map = GetMap();
            spriteSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "sprites\\backSheet.png"));

        }

        public static void SeedMap(Graphics g)
        {
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (map[i, j] == 10)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize*2)), 193, 160, 45, 90, GraphicsUnit.Pixel);

                    }
                    if (map[i, j] == 11)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 273, 176, 32, 34, GraphicsUnit.Pixel);
                    }
                    if (map[i, j] == 12)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 208, 128, 32, 34, GraphicsUnit.Pixel);
                    }
                }
            }
        }
        public static int[,] GetMap()
        {
            return new int[,]
            {
                {1,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,2},
                {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                {5,0,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                {5,0,0,0,0,0,0,0,12,12,0,0,0,0,11,0,0,0,0,7},
                {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                {5,0,0,0,12,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                {5,0,0,0,0,0,0,0,10,0,0,0,0,0,0,0,0,0,0,7},
                {5,0,0,0,0,0,0,0,10,0,0,0,0,0,0,0,0,0,0,7},
                {5,0,0,0,12,0,0,0,10,0,0,0,0,12,0,0,0,0,0,7},
                {5,0,0,0,0,0,0,0,10,0,0,0,0,0,0,0,0,0,0,7},
                {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                {5,0,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,10,7},
                {5,0,0,0,11,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,7},
                {5,0,0,0,0,0,0,0,0,0,0,0,11,0,0,0,0,0,0,7},
                {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7},
                {3,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,4},


            };
        }

        public static void DrawMap(Graphics g)
        {
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    
                    if (map[i, j] == 1)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 0, 35, 15, 15, GraphicsUnit.Pixel);

                    }
                    else
                    if (map[i, j] == 2)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 45, 35, 15, 15, GraphicsUnit.Pixel);

                    }
                    else
                    if (map[i, j] == 3)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 0, 64, 15, 15, GraphicsUnit.Pixel);

                    }
                    else
                    if (map[i, j] == 4)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 45, 64, 15, 15, GraphicsUnit.Pixel);

                    }
                    else
                    if (map[i, j] == 5)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 0, 45, 15, 15, GraphicsUnit.Pixel);

                    }
                    else
                    if (map[i, j] == 6)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 15, 32, 15, 15, GraphicsUnit.Pixel);

                    }
                    else
                    if (map[i, j] == 7)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 45, 45, 15, 15, GraphicsUnit.Pixel);

                    }
                    else
                    if (map[i, j] == 8)
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 11, 64, 4, 15, GraphicsUnit.Pixel);

                    }
                    else
                    
                    {
                        g.DrawImage(spriteSheet, new Rectangle(new Point(j * cellSize, i * cellSize), new Size(cellSize, cellSize)), 15, 55, 15, 15, GraphicsUnit.Pixel);

                    }
                }
            }
            SeedMap(g);

        }

        public static int GetWidth()
        {
            return cellSize*(mapWidth)+15;
        }
        public static int GetHeight()
        {
            return cellSize*(mapHeight+1)+10;
        }

    }
}
