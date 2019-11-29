using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace morseCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> morse = new Dictionary<string, string>() { 
                {"A",".- "},{"B","-... "},{"C","-.-. "},{"D","-.. "},{"E",". "},{"F","..-. "},{"G","--. "},{"H",".... "},{"I",".. "},{"J", ".--- "},{"K", "-.- "},{"L", ".-.. "},{"M","-- "},{"N","-. "},{"O","--- "},{"P",".--. "},{"Q","--.- "},{"R",".-. "},{"S","... "},{"T","- "},{"U","..- "},{"V","...- "},{"W",".-- "},{"X","-..- "},{"Y","-.-- "},{"Z", "--.. "},{" ", "|"}
            };
            Console.WriteLine("Enter string to convert");
            string str = Console.ReadLine().ToUpper();
            for (int i = 0; i < str.Length; i++)
            {
                string t = str[i].ToString();
                Console.Write(morse[t]);
            }
        }
    }
}
