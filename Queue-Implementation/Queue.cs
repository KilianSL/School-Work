using System;

namespace QueueClass
{

    class Queue<T>
    {
        public int maxSize { get; set; }
        private int front = 0;
        private int rear = -1;
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
    class AuxCode
    {
        static void Main(string[] args)
        {
            var q = new Queue<int>(4);
            int[] a = { 1, 2, 3 };
            q.EnQueue(a);
            q.EnQueue(4);
            q.DeQueue();
            q.EnQueue(5);
            Console.WriteLine(q.IsFull().ToString());
            q.DeQueue();
            foreach (var item in q.data)
            {
                Console.Write(item + " ");
            }
        }
    }
}
