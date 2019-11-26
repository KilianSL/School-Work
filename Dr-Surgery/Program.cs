using System;

namespace Dr_Surgery
{

    class Queue<T>
    {
        public int maxSize { get; set; }
        public int front = 0;
        public int rear = -1;
        private int size = 0;
        public T[] data;

        public Queue(int maxsize)
        {
            maxSize = maxsize;
            data = new T[maxsize];
        }

        public void EnQueue(T item)
        {
            if (!IsFull())
            {
                rear = (rear + 1) % maxSize;
                data[rear] = item;
                size += 1;
            }
            else
            {
                Console.WriteLine("Error - Queue Full");
            }
        }

        public void EnQueue(T[] items)
        {
            foreach (var item in items)
            {
                if (!IsFull())
                {
                    rear = (rear + 1) % maxSize;
                    data[rear] = item;
                    size += 1;
                }
                else
                {
                    Console.WriteLine("Error - Queue Full");
                }
            }
        }

        public void DeQueue()
        {
            if (!IsEmpty())
            {
                front += 1;
                size -= 1;
            }
            else
            {
                Console.WriteLine("Error - Queue Empty");
            }

        }

        public bool IsFull()
        {
            if (size == maxSize)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsEmpty()
        {
            if (size == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("< Appointment Booker >");
            Console.WriteLine();
            var waitingRoom = new Queue<string>(5);  //creates a new instance of queue to simulate the doctors waiting list
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Check in");
                Console.WriteLine("2. Check out");
                Console.Write("Enter Selection: ");
                string s = Console.ReadLine();
                switch (s)
                {
                    case "1":
                        Console.Write("Enter Name: ");
                        waitingRoom.EnQueue(Console.ReadLine());
                        break;
                    case "2":
                        waitingRoom.DeQueue();
                        break;
                    default:
                        Console.WriteLine("Invalid Selection - Try Again");
                        break;
                }
            }
        }
    }
}
