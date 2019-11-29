using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twos_Complement
{
    class Program
    {

        static void getInput(ref string n1, ref string n2, ref string op)
        {
            Console.WriteLine("Enter 2 8-bit binary numbers:");
            Console.Write("Enter n1: ");
            n1 = Console.ReadLine();
            Console.Write("Enter n2: ");
            n2 = Console.ReadLine();
                if (n1.Length != 8 || n2.Length != 8)
                {
                    Console.WriteLine("Number more than 8 bits");
                    getInput(ref n1, ref n2, ref op);
                }
                foreach (char digit in n1)
                {
                    if (digit != '0' && digit != '1')
                    {
                        Console.WriteLine("Enter valid digits: 1 or 0");
                        getInput(ref n1, ref n2, ref op);
                    }
                }
                foreach (char digit in n1)
                {
                    if (digit != '0' && digit != '1')
                    {
                        Console.WriteLine("Enter valid digits: 1 or 0");
                        getInput(ref n1, ref n2, ref op);
                    }
                }
                Console.WriteLine("1: Subtraction");
                Console.WriteLine("2: Multiplication");
                Console.WriteLine("3: Addition");
                op = Console.ReadLine();
        }

        static string binaryAdd(string b1, string b2)  //adds two binary numbers
        {
            int cBit = 0;  
            string[] output = new string[9];
            for (int i = 7; i >= 0; i--) 
            {
                if (cBit == 0)
                {
                    if (b1[i] == '0' && b2[i] == '0')
                    {
                        output[i] = "0";
                        cBit = 0;
                    }
                    else if (b1[i] == '0' && b2[i] == '1' || b1[i] == '1' && b2[i] == '0')
                    {
                        output[i] = "1";
                        cBit = 0;
                    }
                    else
                    {
                        output[i] = "0";
                        cBit = 1;
                    }
                }
                else
                {
                    if (b1[i] == '0' && b2[i] == '0')
                    {
                        output[i] = "1";
                        cBit = 0;
                    }
                    else if (b1[i] == '0' && b2[i] == '1' || b1[i] == '1' && b2[i] == '0')
                    {
                        output[i] = "0";
                        cBit = 1;
                    }
                    else
                    {
                        output[i] = "1";
                        cBit = 1;
                    }
                }
                
            }
            if (cBit == 1)  //adds an overflow bit if there is one
            {
                output[8] = "1";
            }
            string result = "";
            foreach (var item in output)  //turns the output array into a returnable string
            {
                result += item; 
            }
            return result;
        }
        
        static string binarySubtract(string b1, string b2)
        {
            b2 = twoComplement(b2);
            string result = binaryAdd(b1, b2);
            result = binaryAdd(result, "00000001");
            return result;
        }

        static string twoComplement(string b)
        {
            int[] c = new int[8];
            for (int i = 0; i < b.Length; i++)
			{
                if (b[i] == '0')
                {
                    c[i] = 1;
                }
                else
	            {
                    c[i] = 0;
	            }
			}
            string output = "";
            foreach (var item in c)
            {
                output += item.ToString();
            }
            return output;
            
        }

        static string binaryMultiply(string b1, string b2)
        {
            return "Work in Progress";
        }
        static void Main(string[] args)
        {
            while (true)
            {
                string n1 = "";
                string n2 = "";
                string op = "";
                getInput(ref n1, ref n2, ref op);
                switch (op)
                {
                    case "3":
                        Console.WriteLine("{0} + {1}", n1, n2);
                        Console.WriteLine(binaryAdd(n1, n2));
                        break;
                    case "1":
                        Console.WriteLine("{0} - {1}", n1, n2);
                        Console.WriteLine(binarySubtract(n1, n2));
                        break;
                    case "2":
                        Console.WriteLine("{0} * {1}", n1, n2);
                        Console.WriteLine(binaryMultiply(n1, n2));
                        break;
                    default:
                        break;
                }
            }
            
            
            Console.ReadLine();
        }
    }
}
