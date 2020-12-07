using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.IO;
using System.Threading.Tasks;

namespace Lab3_var7
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            GraphicsCompile edit = new GraphicsCompile();
            FigureCompare comparer = new FigureCompare();
            Console.WriteLine("Графический редактор");
            int Choose;
            while (true)
            {
                Console.WriteLine("____________________________________\n" +
                "|Меню:                             |\n" +
                "|1.Добавить квадрат                |\n" +
                "|2.Добавить прямоугольник          |\n" +
                "|3.Добавить круг                   |\n" +
                "|4.Добавить элипс                  |\n" +
                "|5.Вывести все фигуры на экран     |\n" +
                "|6.Вывести первые 3 фигуры на экран|\n" +
                "|7.Нарисовать фигуру в консоли     |\n" +
                "|0.Закрыть программу               |\n" +
                "|__________________________________|\n");
                Console.WriteLine("Введите цифру от 0 до 7: ");
                try
                {
                    Choose = Convert.ToInt32(Console.ReadLine());
                    if (Choose == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Введите ширину стороны квадрата");
                        int menu_width = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите высоту стороны квадрата ");
                        int menu_height = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите ширину рамки");
                        int menu_frame = Convert.ToInt32(Console.ReadLine());
                        if (menu_height != menu_width)
                        {
                            Console.WriteLine("Ты же вводишь квадрат,а не прямоугольник!!!");
                            
                        }
                        else
                        {
                            edit.FigureList.Add(new Square
                            {
                                NameOfFigure = "Квадрат",
                                Height = menu_height,
                                Width = menu_width,
                                Frame = menu_frame
                            });
                            edit.FigureList[edit.FigureList.Count - 1].GetArea();
                            Console.Clear();
                        }

                    }
                    else if (Choose == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Введите ширину стороны прямоугольника");
                        int menu_width = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите высоту стороны прямоугольника ");
                        int menu_height = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите ширину рамки");
                        int menu_frame = Convert.ToInt32(Console.ReadLine());
                       edit.FigureList.Add(new Rectangle
                        {
                            NameOfFigure = "Прямоугольник",
                            Height = menu_height,
                            Width = menu_width,
                            Frame = menu_frame
                        });
                        edit.FigureList[edit.FigureList.Count - 1].GetArea();
                        Console.Clear();
                    }
                    else if (Choose == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Введите радиус круга");
                        int menu_width = Convert.ToInt32(Console.ReadLine());
                        int menu_height = menu_width;
                        Console.WriteLine("Введите ширину рамки");
                        int menu_frame = Convert.ToInt32(Console.ReadLine());
                        edit.FigureList.Add(new Circle
                        {
                            NameOfFigure = "Круг",
                            Height = menu_height,
                            Width = menu_width,
                            Frame = menu_frame
                        });
                        edit.FigureList[edit.FigureList.Count - 1].GetArea();
                        Console.Clear();
                    }
                    else if (Choose == 4)
                    {
                        Console.Clear();
                        Console.WriteLine("Введите малый радиус эллипса");
                        int menu_width = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите большой радиус эллипса ");
                        int menu_height = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите ширину рамки");
                        int menu_frame = Convert.ToInt32(Console.ReadLine());
                        edit.FigureList.Add(new Ellipse
                        {
                            NameOfFigure = "Эллипс",
                            Height = menu_height,
                            Width = menu_width,
                            Frame = menu_frame
                        });
                        edit.FigureList[edit.FigureList.Count - 1].GetArea();

                        Console.Clear();

                    }
                    else if (Choose == 5)
                    {
                        Console.Clear();
                        const string filename = @"C:\Users\user\source\repos\Lab3_var7\Lab3_var7\path.txt";
                        edit.ToJson(filename);
                        try
                        {
                            var MyNewFigureList = GraphicsCompile.FromJson(filename);
                            foreach (var figure in MyNewFigureList.FigureList)
                            {
                                Console.WriteLine($"Название фигуры: {figure.NameOfFigure}");
                                Console.WriteLine($"Площадь: {figure.Area}");
                                Console.WriteLine($"Ширина рамки: {figure.Frame}");
                                Console.WriteLine();
                            }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine($"Ошибка:{ex.Message}");
                        }
                        
                        
                    }
                    else if (Choose == 6)
                    {
                        Console.Clear();
                        edit.FigureList.Sort(comparer);
                        if (edit.FigureList.Count >= 3)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                Console.WriteLine(edit.FigureList[i].NameOfFigure);
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Ошибка!В списке меньше 3 фигур.Вернитесь в меню и добавьте в список еще фигур");
                        }


                    }
                    else if (Choose == 7)
                    {
                        Console.Clear();
                       edit.FigureList.Sort(comparer);
                        Console.WriteLine("Введите название фигуры,которую хотите нарисовать  в консоль");
                        string name = Console.ReadLine();
                        bool set = true;
                        for (int i = 0; i < edit.FigureList.Count; i++)
                        {
                            if (name == edit.FigureList[i].NameOfFigure)
                            {
                                Console.Clear();
                                set = false;
                                if ((edit.FigureList[i].NameOfFigure == "Эллипс") || (edit.FigureList[i].NameOfFigure == "Круг"))
                                {
                                    GraphicsCompile.PrintCircle(edit.FigureList, i);
                             
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else if ((edit.FigureList[i].NameOfFigure == "Квадрат") || (edit.FigureList[i].NameOfFigure == "Прямоугольник"))
                                {
                                    GraphicsCompile.PrintSquare(edit.FigureList, i);
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                 
                        }
                        if (set == true)
                        {
                            Console.WriteLine("Такой фигуры нет в списке.Возможно вы не умеете писать и ввели неправильно название фигуры)))");
                        }


                    }
                    else if (Choose == 0)
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("В меню нет такого символа");
                    }


                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка!Скорее всего вы ввели что-то не так.Запомните,что ширина,ширина рамки и высота фигур это целые числа, ");
                }
            }

        }
    }
}