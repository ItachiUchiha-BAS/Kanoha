using System;
using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json;
using System.IO;

namespace Lab3_var7
{
    public class GraphicsCompile
    {
        public readonly List<Figure> FigureList = new List<Figure>();

        public static void PrintSquare(List<Figure> FigureList, int position)
        {
            string top = "";
            string side = "* ";
            if ((FigureList[position].Width > Console.WindowWidth) || (FigureList[position].Height > Console.WindowHeight))
            {
                Console.WriteLine("Ошибка!Фигура,которую вы хотите вывести больше чем размер консоли");

            }
            else
            {
                for (int i = 0; i < FigureList[position].Width; i++)
                {
                    top = top + "* ";
                }
                for (int i = 1; i < FigureList[position].Width - 1; i++)
                {
                    side = side + "  ";
                }
                side += "*";
                Console.SetCursorPosition(Console.WindowWidth / 2 - FigureList[position].Width / 2,
                Console.WindowHeight / 2);
                Console.Write(top);
                int j = 1;
                while (j < FigureList[position].Height - 1)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - FigureList[position].Width / 2,
                    Console.WindowHeight / 2 + j);
                    Console.Write(side);
                    j += 1;
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - FigureList[position].Width / 2,
                Console.WindowHeight / 2 + FigureList[position].Height - 1);
                Console.Write(top);
                Console.SetCursorPosition(0, Console.WindowHeight);

            }
        }
        public static void PrintCircle(List<Figure> FigureList, int position)
        {
            double a = FigureList[position].Width;
            double b = FigureList[position].Height;
            double equal;
            double x;
            double y;
            int roof = -1;
            if ((FigureList[position].Width > Console.WindowWidth) || (FigureList[position].Height > Console.WindowHeight))
            {
                Console.WriteLine("Ошибка!Фигура,которую вы хотите вывести больше чем размер консоли");
            }
            else
            {
                for (int i = 0; i < FigureList[position].Width + 1; i++)
                {
                    for (int j = 0; j < FigureList[position].Height - roof; j++)
                    {
                        x = i;
                        y = j;
                        equal = Math.Abs(((x * x) / (a * a)) + ((y * y) / (b * b)) - 1);
                        if (equal < 0.03)
                        {
                            Console.SetCursorPosition(Console.WindowWidth / 2 - 2 * i, Console.WindowHeight / 2 - j);
                            Console.Write("*");
                            Console.SetCursorPosition(Console.WindowWidth / 2 + 2 * i, Console.WindowHeight / 2 - j);
                            Console.Write("*");
                            Console.SetCursorPosition(Console.WindowWidth / 2 - 2 * i, Console.WindowHeight / 2 + j);
                            Console.Write("*");
                            Console.SetCursorPosition(Console.WindowWidth / 2 + 2 * i, Console.WindowHeight / 2 + j);
                            Console.Write("*");
                            roof++;
                        }
                    }
                }
                Console.SetCursorPosition(0, Console.WindowHeight);
            }
        }
        public void ToJson(string fileName)
        {
            File.WriteAllText(fileName,
                JsonConvert.SerializeObject(FigureList, Formatting.Indented,
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }));
        }
        public static GraphicsCompile FromJson(string fileName)
        {
            var Graphic = new GraphicsCompile();
            var figures = JsonConvert.DeserializeObject<List<Figure>>(File.ReadAllText(fileName), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            if (figures != null)
            {
                
                Graphic.FigureList.AddRange(figures);
            }
            return Graphic;
        }
       

    }
}