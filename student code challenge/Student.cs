using System;
using System.Collections.Generic;
using System.Text;

namespace student_code_challenge
{
    abstract class Student
    {
        public string[] Classes { get; set; }
        public string Name { get; set; }

        public Student(string name, string[] classes)
        {
            Classes = classes;
            Name = name;
        }

        public override string ToString()
        {
            string str = "";
            str = str + "Name: " + Name + Environment.NewLine;
            str = str + "Classes: " + Environment.NewLine;
            foreach (var c in Classes)
            {
                str = str + c + Environment.NewLine;
            }
            return str;
        }
    }

    class GCSEStudent : Student
    {
        static string[] ChooseClasses()
        {
            string[] classes = new string[] { "Maths", "English", "Science", "", "", "", "" };
            for (int i = 3; i < classes.Length; i++)
            {
                Console.Write("Enrol in class: ");
                classes[i] = Console.ReadLine();
            }
            return classes;
        }
        public GCSEStudent(string name) : base(name, ChooseClasses()) { }
    }

    class ALevelStudent : Student
    {
        static string[] ChooseClasses()
        {
            string[] classes = new string[] {"", "", "", "" };
            for (int i = 0; i < classes.Length; i++)
            {
                Console.Write("Enrol in class: ");
                classes[i] = Console.ReadLine();
            }
            return classes;
        }

        public ALevelStudent(string name) : base(name, ChooseClasses()) { }
    }
}
