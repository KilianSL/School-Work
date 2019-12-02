using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run_Length_Encoding_NEA
{
    class Program
    {
        static bool checkMenuInput(string input)
        {
            int i;
            if (!int.TryParse(input, out i))
            {
                Console.WriteLine("Input a number 1-5");
                return false;
            }
            else if (int.Parse(input) > 5 || int.Parse(input) < 0)
            {
                Console.WriteLine("Input a number 1-5");
                return false;
            }
            else
            {
                return true;
            }
        }  //validates the input from the menu

        static int displayMenu(int arg = 0)
        {
            if (arg == 0)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Enter RLE");
                Console.WriteLine("2. Display ASCII art");
                Console.WriteLine("3. Convert to ASCII art");
                Console.WriteLine("4. Convert to RLE");
                Console.WriteLine("5. Quit");
            }
            Console.Write("Enter selection <1-5>");
            string selection = Console.ReadLine();
            if (!checkMenuInput(selection))
            {
                displayMenu(1);
            }
            return int.Parse(selection);
        }  //displays the menu

        static void decodeASCII(string[] rle)  //displays ascii for a line-separated rle array
        {
            foreach (string line in rle)  //loops though each line of the ASCII pattern
            {
                for (int i = 0; i < line.Length; i = i+3)  //loops through each set of 3 characters
                {
                    int num;
                    if (!int.TryParse(line[i].ToString() + line[i + 1].ToString(), out num))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Error - Malformed RLE");
                        displayMenu();
                    }
                    string character = "";
                    try
                    {
                        character = line[i + 2].ToString();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Error - Malformed RLE");
                        displayMenu();
                    }
                    
                    for (int j = 0; j < num; j++)
                    {
                        Console.Write(character);
                    }
                }
                Console.WriteLine();
            }
        }

        static void enterRLE()  //lets the user enter their own RLE sequence
        {
            Console.Write("Enter number of lines: ");
            int linenumber;
            if (!int.TryParse(Console.ReadLine(), out linenumber) || linenumber < 2)
            {
                Console.WriteLine("Enter a number greater than 2");
                enterRLE();
            }

            string[] rle = new string[linenumber]; //array to hold each line of RLE code
            for (int i = 0; i < linenumber; i++)
            {
                Console.Write("Enter Line {0}: ", i + 1);
                rle[i] = Console.ReadLine();
            }
            decodeASCII(rle);
        }

        static void readRLEFromFile(string path) //reads each line of a RLE file to an array of string
        {
            using (var file = new System.IO.StreamReader(path))
            {
                List<string> lines = new List<string>();
                while (!file.EndOfStream)
                {
                    lines.Add(file.ReadLine());
                }
                decodeASCII(lines.ToArray());
            }
        }  

        static void displayASCII(string path)
        {
            using (var file = new System.IO.StreamReader(path))
            {
                while (!file.EndOfStream)
                {
                    Console.WriteLine(file.ReadLine());
                }
            }
        }  //prints a text file line b yline

        static void calculateCompression(string[] lines, string[] RLElines)
        {
            double lineCount = 0;
            double RLECount = 0;
            foreach (string line in lines)
            {
                lineCount += line.Length;
            }
            foreach (string line in RLElines)
            {
                RLECount += line.Length;
            }
            Console.WriteLine("{0} characters saved", lineCount - RLECount);
            Console.WriteLine("Compression ratio - {0}%", (RLECount / lineCount) * 100);
            Console.WriteLine();
        }  //calculates the percentage size difference between the original and the compressed file

        static void convertToRLE(string path)  
        {
            List<string> RLELines = new List<string>();
            using (var ascii = new System.IO.StreamReader(path))   //reads lines of ASCII From file to array 
            {
                List<string> lineList = new List<string>();
                while (!ascii.EndOfStream)
                {
                    lineList.Add(ascii.ReadLine());
                }
                ascii.Close();
                string[] lines = lineList.ToArray();
                foreach (string line in lines)  //loops through each line of ascii and adds the RLE to a list
                {
                    string RLELine = "";
                    int count = 1;
                    char lastchar = line[0];
                    bool oneCharLine = true;
                    Console.WriteLine(line);
                    if (line.Length != 1)
                    {
                        for (int i = 1; i < line.Length; i++)
                        {
                            Console.WriteLine(line[i]);
                            if (line[i] == lastchar)
                            {
                                count = count + 1;
                            }
                            else
                            {
                                oneCharLine = false;
                                if (count < 10)
                                {
                                    RLELine = RLELine + "0" + count.ToString() + lastchar;
                                }
                                else
                                {
                                    RLELine = RLELine + count.ToString() + lastchar;
                                }
                                lastchar = line[i];
                                count = 1;
                            }
                        }
                    }
                    if (oneCharLine)
                    {
                        if (count < 10)
                        {
                            RLELine = RLELine + "0" + count.ToString() + lastchar;
                        }
                        else
                        {
                            RLELine = RLELine + count.ToString() + lastchar;
                        }
                    }
                    if (RLELine[RLELine.Length - 1] != lastchar)
                    {
                         if (count < 10)
                        {
                            RLELine = RLELine + "0" + count.ToString() + lastchar;
                        }
                        else
                        {
                            RLELine = RLELine + count.ToString() + lastchar;
                        }
                    }
                    Console.WriteLine(RLELine);
                    RLELines.Add(RLELine);
                }
                calculateCompression(lines.ToArray(), RLELines.ToArray());
                saveRLE(@"C:\Users\seifk007.319\Documents\School-Work\Run Length Encoding NEA\Run Length Encoding NEA\sRLE.txt", RLELines.ToArray());
            }
        }

        static void saveRLE(string path, string[] RLE)  //saves the RLE code to a text
        {
            using (var writer = new System.IO.StreamWriter(path))
            {
                foreach (var line in RLE)
                {
                    writer.WriteLine(line);
                }
                writer.Close();
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                int selection = displayMenu();
                string p1 = @"C:\Users\seifk007.319\Documents\School-Work\Run Length Encoding NEA\Run Length Encoding NEA\art.txt";
                switch (selection)
                {
                    case 1:
                        enterRLE();
                        break;
                    case 2:
                        
                        displayASCII(p1);
                        break;
                    case 3:
                        string path = @"C:\Users\seifk007.319\Documents\School-Work\Run Length Encoding NEA\Run Length Encoding NEA\sRLE.txt";
                        readRLEFromFile(path);
                        break;
                    case 4:
                        convertToRLE(p1);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
