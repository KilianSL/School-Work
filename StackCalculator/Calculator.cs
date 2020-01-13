using System; 

namespace StackCalculator
{
    class Calculator
    {

        static void GetInput(Stack numbers)
        {
            
            string input = "";
            Console.Write(">");
            input = Console.ReadLine();
            ParseInput(input, numbers);
        }

        static void ParseInput(string input, Stack numbers)
        {
            double x;
            if (double.TryParse(input, out x))
            {
                numbers.Push(x);
            }
            else
            {
                switch (input)
                {
                    case "+":
                        try
                        {
                            var num1 = numbers.Pop();
                            var num2 = numbers.Pop();
                            numbers.Push(num1 + num2);
                            Console.WriteLine(numbers.Peek());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Not enough numbers in memory");
                        }
                        break;
                    case "-":
                        try
                        {
                            var num1 = numbers.Pop();
                            var num2 = numbers.Pop();
                            numbers.Push(num2 - num1);
                            Console.WriteLine(numbers.Peek());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Not enough numbers in memory");
                        }
                        break;
                    case "*":
                        try
                        {
                            var num1 = numbers.Pop();
                            var num2 = numbers.Pop();
                            numbers.Push(num1 * num2);
                            Console.WriteLine(numbers.Peek());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Not enough numbers in memory");
                        }
                        break;
                    case "/":
                        try
                        {
                            var num1 = numbers.Pop();
                            var num2 = numbers.Pop();
                            numbers.Push(num2 / num1);
                            Console.WriteLine(numbers.Peek());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Not enough numbers in memory");
                        }
                        break;
                    case "clear":
                        Console.WriteLine("Memory Cleared");
                        numbers.Clear();
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Syntax Error");
                        break;
                }
            }
            GetInput(numbers);
        }

        static void Main(string[] args)
        {
            Stack numbers = new Stack();
            GetInput(numbers);
        }
    }
}
