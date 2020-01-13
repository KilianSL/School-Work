using System;
using System.Collections.Generic;
using System.Text;

namespace StackCalculator
{
    class Stack
    {
        //Attributes
        private double[] Data;
        private int Top;
        private int Size;


        //Constructor
        public Stack()
        {
            Top = -1;
            Data = new double[16];
            Size = 0;
        }

        //Methods

        public bool IsEmpty()
        {
            if (Top == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFull()
        {
            if (Top == Data.Length - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetSize()
        {
            return Size;
        }

        public void Push(double item)
        {
            if (!IsFull())
            {
                Top += 1;
                Data[Top] = item;
            }
            else
            {
                Console.WriteLine("Stack Overflow Error");
            }
        }

        public double Pop()
        {
            if (!IsEmpty())
            {
                Top -= 1;
                return Data[Top + 1];
            }
            else
            {
                throw new Exception("Stack Underflow Error");
            }
        }

        public void Clear()
        {
            Top = -1;
        }
        public double Peek()
        {
            if (!IsEmpty())
            {
                return Data[Top];
            }
            else
            {
                Console.WriteLine("No item to peek at");
                return default;
            }
        }
    }
}
