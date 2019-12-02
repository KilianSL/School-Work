using System;
using System.Collections.Generic;

namespace SameLetterPatterns
{
    class Program
    {

        static bool SameLetterPattern(string a, string b)
        {
            bool match = false;
            if (a.Length == b.Length)
            {
                int[,] strings = new int[2, a.Length];
                List<char> usedChars = new List<char>();
                int count = 0;
                foreach (var item in a)
                {
                    if (usedChars.Contains(item))
                    {
                        strings[0, count] = usedChars.IndexOf(item);
                    }
                    else
                    {
                        usedChars.Add(item);
                        strings[0, count] = usedChars.IndexOf(item);
                    }
                    count += 1;
                }
                usedChars.Clear();
                count = 0;
                foreach (var item in b)
                {
                    if (usedChars.Contains(item))
                    {
                        strings[1, count] = usedChars.IndexOf(item);
                    }
                    else
                    {
                        usedChars.Add(item);
                        strings[1, count] = usedChars.IndexOf(item);
                    }
                    count += 1;
                }
                match = true;
                for (int i = 0; i < strings.GetLength(1); i++)
                {
                    if (strings[0,i] != strings[1,i])
                    {
                        match = false;
                    }
                }
                return match;
            }
            else
            {
                return match;
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("S1: ");
                string s1 = Console.ReadLine();
                Console.Write("S2: ");
                string s2 = Console.ReadLine();
                Console.WriteLine(SameLetterPattern(s1, s2));
            }
            
        }
    }
}
