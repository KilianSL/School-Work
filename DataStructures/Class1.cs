using System;

namespace DataStructures
{
    class Queue<T>  //standard static-length queue data structure
    {
        public int MaxSize;
        protected int front;
        protected int rear;
        protected int size;
        protected T[] data;

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
        public T[] GetData(bool verbose = false)  //returns ALL data held in the array, regardless of pointers (WIP). Outputs data is verbose = true
        {
            if (verbose)
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
            return data;
            
        }
    }

    class PriorityQueue<T> : Queue<T> //static-length queue data structure, with the option to have items jump to the front of the queue
    {
        public PriorityQueue(int maxsize) : base(maxsize)
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

    class Stack<T>  //standard static-length LIFO stack
    {
        private T[] data;
        private int top;
        private int size;
        public int MaxSize;

        public Stack(int maxsize)
        {
            MaxSize = maxsize;
            data = new T[MaxSize];
            top = -1;
            size = 0;
        }

        public void Push(T item)
        {
            if (!IsFull())
            {
                top += 1;
                size += 1;
                data[top] = item;
            }
            else
            {
                Console.WriteLine("Error - Stack Overflow");
            }
        }

        public void Push(T[] items)
        {
            foreach (T item in items)
            {
                if (!IsFull())
                {
                    top += 1;
                    size += 1;
                    data[top] = item;
                }
                else
                {
                    Console.WriteLine("Error - Stack Overflow");
                    break;
                }
            }
        }

        public T Peek()
        {
            if (!IsEmpty())
            {
                return data[top];
            }
            else
            {
                Console.WriteLine("Error - Stack Empty");
                return default;
            }
        }

        public T Pop()
        {
            if (!IsEmpty())
            {
                top -= 1;
                size -= 1;
                return data[top + 1];
            }
            else
            {
                Console.WriteLine("Error - stack empty");
                return default;
            }
        }

        private bool IsFull()
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

        private bool IsEmpty()
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

        public T[] GetData(bool verbose = false)
        {
            if (verbose)
            {
                for (int i = 0; i <= top; i++)
                {
                    Console.Write(data[i] + " , ");
                }
            }
            Console.WriteLine();
            return data;
        }
    }
}
