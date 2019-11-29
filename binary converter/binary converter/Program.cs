using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_converter
{
    class Program
    {
        static string toBinary(int a)
        {
            string[] bin = new string[8];
            for (int i = 7; i > -1; i--)
            {
                if (a >= Math.Pow(2,i))
                {
                    bin[7 - i] = "1";
                    a = a - Convert.ToInt32(Math.Pow(2, i));
                }
                else
                {
                    bin[7 - i] = "0";
                }
            }
            string bin1 = "";
            for (int i = 0; i < 8; i++)
            {
                bin1 = bin1 + bin[i];
            }
            return bin1;

        }

        static string toHex(int a)
        {
            Dictionary<int, string> dict = new Dictionary<int, string> {{10,"A"},{11,"B"},{12,"C"},{13,"D"},{14,"E"},{15,"F"}};
            string hex = "";
            int b = a / 16;
            if (b>9)
            {
                hex = hex + dict[b];
            }
            else
            {
                hex = hex + b.ToString();
            }
            a = a - b * 16;
            if (a > 9)
            {
                hex = hex + dict[a];
            }
            else
            {
                hex = hex + a.ToString();
            }
            return hex;


        }
        
        static bool verifyInput(int input)
        {
            if (input < 0 || input > 255)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static void Main(string[] args)
        {
            int n = 0;
            while (n != -1)
            {
                Console.WriteLine("Enter number between 0 and 255");
                n = int.Parse(Console.ReadLine());
                while (verifyInput(n) == false)
                {
                    Console.WriteLine("Enter number between 0 and 255");
                    n = int.Parse(Console.ReadLine());
                }
                int conv = 3;
                while (conv != 1 && conv != 2)
                {
                    Console.WriteLine("Enter number system to convert to");
                    Console.WriteLine("1. Binary");
                    Console.WriteLine("2. Hexidecimal");
                    conv = int.Parse(Console.ReadLine());
                    if (conv == 1)
                    {
                        Console.WriteLine("Result: {0}", toBinary(n));
                        Console.ReadLine();
                    }
                    else if (conv == 2)
                    {
                        Console.WriteLine("Result: {0}", toHex(n));
                        Console.ReadLine();
                    }
                }
            
            }
        }
    }
}
