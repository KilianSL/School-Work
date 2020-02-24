using System;

namespace student_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            GCSEStudent s1 = new GCSEStudent("Mike");
            ALevelStudent s2 = new ALevelStudent("Steve");
            Console.WriteLine(s1.ToString());
            Console.WriteLine(s2.ToString());
        }
    }
}
