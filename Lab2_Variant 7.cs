using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Lab2_7
{
    class Set
    {
        public HashSet<int> MyArray;

        public Set CreateSet()
        {
            this.MyArray = new HashSet<int>();
            return this;
        }

        public void PrintSet(Set set)
        {
            if(set.MyArray == null)
            {
                Console.WriteLine("Список пуст");
            }
            else {
                foreach (int item in set.MyArray)
                {
                    Console.WriteLine(item);
                }
            }
            
        }

        public static Set operator ++(Set set)
        {
            Console.WriteLine("Введите ЦЕЛОЕ число, которое хотите добавить в список: ");
            try
            {
                int value = Convert.ToInt32(Console.ReadLine());
                set.MyArray.Add(value);
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка!Возможно вы ввели не то число");
            }
            return set;
        }
        public static Set operator --(Set set)
        {
            Console.WriteLine("Введите ЦЕЛОЕ число, которое хотите удалить из списка: ");
            try
            {
                int value = Convert.ToInt32(Console.ReadLine());
                set.MyArray.Remove(value);
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка!Возможно вы ввели не то число");
            }
            return set;
        }
        public static Set operator <(Set set1, Set set2)
        {
            Set set3 = new Set();
            set3.CreateSet();
            foreach (var item in set2.MyArray)
            {
                if (!set1.MyArray.Contains(item))
                {
                    set3.MyArray.Add(item);
                }
            }
           
                return set3;
            
        }
        public static Set operator >(Set set1,Set set2)
        {
            Set set3 = new Set();
            set3.CreateSet();
            foreach (var item in set1.MyArray)
            {
                if (!set2.MyArray.Contains(item))
                {
                    set3.MyArray.Add(item);
                }
            }
            
            
                return set3;
            
        }

        public static bool operator %(Set set1,Set set2)
        {
            bool result = set1.Equals(set2);
            return result;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Set set1 = new Set();
            set1.CreateSet();
            Console.WriteLine("Для начала давайте сразу добавим пару ЦЕЛЫХ чисел для дальнейшей работы!");
            set1++;
            set1++;
            set1++;
            Console.Clear();

            int Choose1;
            int Choose2;
            while (true)
            {
                Console.WriteLine("_________________________________________\n" +
                              "|Меню:				      |\n" +
                              "|1.Добавить элемент в список	      |\n" +
                              "|2.Удалить элемент из списка          |\n" +
                              "|3.Создать второй список              |\n" +
                              "|4.Вывести список на экран            |\n" +
                              "|5.Закрыть программу                  |\n" +
                              "|_____________________________________|\n");
                Console.WriteLine("Введите цифру от 1 до 5: ");
                try
                {
                    Choose1 = Convert.ToInt32(Console.ReadLine());
                    if (Choose1 == 1)
                    {
                        set1++;
                        Console.Clear();
                    }
                    else if (Choose1 == 4)
                    {
                        Console.Clear();
                        set1.PrintSet(set1);
                    }
                    else if (Choose1 == 5)
                    {
                        break;
                    }
                    else if (Choose1 == 2)
                    {
                        set1--;
                        Console.Clear();
                    }
                    else if (Choose1 == 3)
                    {
                        Set set2 = new Set();
                        set2.CreateSet();
                        Console.WriteLine("Вы успешно создали второй список!Теперь вам доступны новые функции.");
                        Console.WriteLine("Также сразу добавим пару элементов во второй список");
                        set2++;
                        set2++;
                        set2++;
                        Console.Clear();
                        while (true)
                        {
                            Console.WriteLine("___________________________________________\n" +
                                  "|Меню:				                     |\n" +
                                  "|1. Добавить элемент во второй список		|\n" +
                                  "|2. Удалить элемент из второго списка		|\n" +
                                  "|3. Вывести второй список на экран		|\n" +
                                  "|4. Найти разность 1 и 2 списка                  |\n" +
                                  "|5.Найти разность 2 и 1 списка                           |\n" +
                                  "|6.Сравнить списки                        |\n" +
                                  "|7.Закончить программу                    |\n"+
                                  "|_____________________________________________|\n");
                            Console.WriteLine("Введите число от 1-6");
                            Choose2 = Convert.ToInt32(Console.ReadLine());
                            if (Choose2 == 1)
                            {
                                set2++;
                                Console.Clear();
                            }
                            else if (Choose2 == 2)
                            {
                                set2--;
                                Console.Clear();
                            }
                            else if (Choose2 == 3)
                            {
                                Console.Clear();
                                set2.PrintSet(set2);
                            }
                            else if (Choose2 == 4)
                            {
                                Set set3 = new Set();
                                set3.CreateSet();
                                set3 = set2 < set1;
                                Console.Clear();
                                if (set3.MyArray == null)
                                {
                                    Console.WriteLine("Разности нет");
                                }
                                else
                                {
                                    set3.PrintSet(set3);
                                }
                            }
                            else if (Choose2 == 5)
                            {
                                Set set3 = new Set();
                                set3.CreateSet();
                                set3 = set2 > set1;
                                Console.Clear();
                                if (set3.MyArray == null)
                                {
                                    Console.WriteLine("Разности нет");
                                }
                                else
                                {
                                    set3.PrintSet(set3);
                                }
                            }
                            else if (Choose2 == 6)
                            {
                                bool result;
                                result = set1 % set2;
                                if (result == true)
                                {
                                    Console.WriteLine("Списки равны");
                                }
                                else
                                {
                                    Console.WriteLine("Списки не равны");
                                }

                            }
                            else if (Choose2 == 7)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Вы ввели не то значение");
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Ошибка!");
                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Ошибка!Возможно вы случайно ввели другое значение");
                }
                
            }
        }
    }
}