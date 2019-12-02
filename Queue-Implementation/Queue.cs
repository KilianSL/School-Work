using System;

namespace QueueClass
{

    class Queue<T>
    {
        public int MaxSize;
        protected int front;
        protected int rear;
        protected int size;
        public T[] data;

        public Queue(int maxsize)
        {
            MaxSize = maxsize;
            data = new T[maxsize];
            front = 0;
            rear = -1;
            size = 0;

        }

        public void EnQueue(T item)  //adds a single item to the end of the queue
        {
            if (!IsFull())
            {
                rear = (rear + 1) % MaxSize;
                data[rear] = item;
                size += 1;
            }
            else
            {
                Console.WriteLine("Error - Queue Full");
            }
        }

        public void EnQueue(T[] items)  //adds an array of items to the back of the queue, until queue is full;
        {
            foreach (var item in items)
            {
                if (!IsFull())
                {
                    rear = (rear + 1) % MaxSize;
                    data[rear] = item;
                    size += 1;
                }
                else
                {
                    Console.WriteLine("Error - Queue Full");
                    break;
                }
            }
        }

        public T Peek()  //returns the item at the front of the queue, without modifying the queue
        {
            return data[front];
        }

        public T DeQueue()   //returns the item at the front of the queue and then removes it
        {
            if (!IsEmpty())
            {
                
                front += 1;
                size -= 1;
                return data[front - 1];
            }
            else
            {
                Console.WriteLine("Error - Queue Empty");
                return default(T);
            }
            
        }

        public bool IsFull()  //checks if the queue is full
        {
            if (size == MaxSize)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsEmpty()   //checks if the queue is empty
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

        public int GetSize() //returns the current size of the queue
        {
            return size;
        }

        public void OutputData()  //outputs the data in the queue, in order
        {
            if (front <= rear)
            {
                for (int i = front; i <= rear; i++)
                {
                    Console.Write(data[i] + " , ");
                }
            }
            else
            {
                for (int i = front; i < MaxSize; i++)
                {
                    Console.Write(data[i] + " , ");
                }
                for (int i = 0; i <= rear; i++)
                {
                    Console.Write(data[i] + " , ");
                }
            }
            Console.WriteLine();
        }
    }

    class JumperQueue<T> : Queue<T>
    {
        public JumperQueue(int maxsize) : base(maxsize)
        { }

        public void EnQueue(T item, bool priority = false)  //enqueues a new item, set to true to add to the front of the queue
        {
            if (priority)  //places an item at the front of the queue
            {
                if (!IsFull())
                {
                    if (front == 0)
                    {
                        front = MaxSize - 1;
                        data[front] = item;
                        size += 1;
                    }
                    else
                    {
                        front -= 1;
                        data[front] = item;
                        size += 1;
                    }
                }
                else
                {
                    Console.WriteLine("Error - Queue Full");
                }
            }
            else  //places item at rear of queue
            {
                base.EnQueue(item);
            }
        }

        public void EnQueue(T[] items, bool priority = false)  //enqueues an array of items, set to true to add to front of queue
        {
            if (priority)
            {
                foreach (T item in items)
                {
                    if (!IsFull())
                    {
                        if (front == 0)
                        {
                            front = MaxSize - 1;
                            data[front] = item;
                            size += 1;
                        }
                        else
                        {
                            front -= 1;
                            data[front] = item;
                            size += 1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error - Queue Full");
                        break;
                    }
                }
            }
            else
            {
                base.EnQueue(items);
            }
        }
    }
    class AuxCode
    {
        static void Main(string[] args)
        {
            var q = new JumperQueue<int>(5);
            q.EnQueue(3);
            q.EnQueue(4);
            q.EnQueue(2, true);
            q.EnQueue(1, true);
            q.OutputData();
            q.DeQueue();
            q.EnQueue(5);
            q.EnQueue(0, true);
            q.DeQueue();
            int[] a = { 7, 8, 9 };
            q.EnQueue(a, true);
            q.OutputData();
        }
    }
}
