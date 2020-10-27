using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Lab1
{
    class MainProgram
    {
        static void Main(String[] args)
        {
            var studentGroup = new StudentGroup();
            studentGroup.AddStudent("Беляев Артем Сергеевич", "19", "2", "24.02.2001");
            studentGroup.AddStudent("Невзоров Евгений Алексанрович", "19", "2", "18.02.2001");

            Boolean UserDecioun = true;
            while (UserDecioun == true)
            {
                Console.WriteLine("------------------------------------ MENU ---------------------------------");
                Console.WriteLine("Введите 1,если хотите добавить студента в таблицу");
                Console.WriteLine("Введите 2,если хотите удалить студента из таблицы");
                Console.WriteLine("Введите 3,если хотите вывести таблицу студентов на экран");
                Console.WriteLine("Введите 4,если хотите найти студента по ID номеру");
                Console.WriteLine("Введите 5,если хотите отсортировать список");
                Console.WriteLine("Введите 6,если хотите выйти из программы");
                int Decioun = Convert.ToInt32(Console.ReadLine());
                if (Decioun == 1)
                {
                    Console.Clear();
                    Console.Write("Введите ФИО: ");
                    string fio = Console.ReadLine();
                    Console.Write("Введите возраст студента: ");
                    string age = Console.ReadLine();
                    Console.Write("Введите курс студента: ");
                    string course = Console.ReadLine();
                    Console.WriteLine("Введите дату рождения студента: ");
                    string birthday = Console.ReadLine();
                    studentGroup.AddStudent(fio, age, course, birthday);
                    Console.Clear();
                    Console.WriteLine("Студент успешно добавлен");
                }
                else if (Decioun == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Введите id студента,которого хотите удалить: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    studentGroup.RemoveStudent(id);
                    Console.WriteLine("Студент успешно удален");

                }
                else if (Decioun == 3)
                {
                    Console.Clear();
                    studentGroup.ShowAllStudents();
                }
                else if (Decioun == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Введите id студента ,которого хотите найти:  ");
                    int id1 = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine(studentGroup.GetStudent(id1));
                }
                else if (Decioun == 5)
                {
                    studentGroup.ItachiUchiha();
                    Console.Clear();
                    Console.WriteLine("Список успешно отсортирован");

                }
                else if (Decioun == 6)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка!Попробуйте ввести другое значение");
                }
                
            }
        }
 }
    class GFG : IComparer<Student>
    {
        public int Compare(Student xStudent, Student yStudent)
        {
            if (xStudent.Fio == null || yStudent.Fio == null)
            {
                return 0;
            }
            return xStudent.CompareTo(yStudent);
        }
    }
     public class Student
    {
        public Student(string fio,string age,string course,string birthday)
        {
            Fio = fio;
            Age = age;
            Course = course;
            Birthday = birthday;
        }
        public string Fio { get; set; }
        public string Age { get; set; }
        public string Course { get; set; }
        public string Birthday { get; set; }

        public int CompareTo(Student that)
        {
            return String.Compare(Fio, that.Fio, System.StringComparison.Ordinal);
        }
    }
    class StudentGroup 
    {
        List<Student> students = new List<Student>();
        public void AddStudent(string fio, string age, string course, string birthday)
        {
            Student student = new Student(fio, age, course, birthday);
            students.Add(student);
        }
        public void RemoveStudent(int id)
        {
            if (id >= students.Count)
            {
                throw new Exception("Студента с таким ID НЕТ");
            }
            students.RemoveAt(id);
           
        }
        public void ShowAllStudents()
        {

            Console.WriteLine("-------------------------------- STUDENTS INFO --------------------------------");
            Console.WriteLine("---------- FIO -------------------- Age --------- Course --------- Birthday-----");
            foreach (var student in students)
            {
                string str = String.Format("|{0,25}\t{1,6}\t{2,14}\t{3,20}|", student.Fio.ToUpper(),student.Age,student.Course,student.Birthday);
                Console.WriteLine(str);
            }
        }
        public string GetStudent(int id1)
        {
            if (id1 >= students.Count)
            {
                throw new Exception("Студента с таким ID НЕТ");
            }
            return "|"+ students[id1].Fio + " | " + students[id1].Age + " | " + students[id1].Course + " | " + students[id1].Birthday +"|";
        }
        public Student FindStudentFIO(string key)
        {
            int i = 0;
            for (i = 0; i < students.Count; i++)
            {
                if (students[i].Fio == key)
                {
                    return students[i];
                }
            }
            return students[i];
        }
        public void ItachiUchiha()
        {
            GFG gg = new GFG();
            students.Sort(gg);

        }
    }
}