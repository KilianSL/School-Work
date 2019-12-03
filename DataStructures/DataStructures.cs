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

    class LinkedList<T>  //Simple linked list
    {

        //c in all instances is a temporary variable used to indicate the Currrent node that the method is processing

        public int Count { get; set; }  //amount of nodes in the list
        private Node head;  //first node in the list
        public LinkedList()   //default constructor 
        {
            head = new Node(default);  //head stores no data (default T) - merely the beginning of the list
            Count = 0;
        }

        public LinkedList(IEnumerable<T> collection) //creates a new instance of list filled with the specified collection
        {
            head = new Node(default);
            Count = 0;
            AddRange(collection);
        }
        private class Node  //Node in the list, stores data and a pointer to the next node. 
        {
            public T Data { get; set; }
            public Node Next { get; set; }

            public Node(T data, Node next = null)
            {
                Data = data;
                Next = next;
            }
        }

        public void Add(T item)  //adds an item to the end of the list
        {
            Node n = head;
            while (n.Next != null)  //iterates until the last node in the list is found
            {
                n = n.Next;
            }
            n.Next = new Node(item);
            Count += 1;
        }

        public void AddRange(IEnumerable<T> collection)  //adds a collection of items to the list
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public void InsertAt(int index, T item)  //inserts an item in the specified position in the list (index from 0)
        {
            if (index <= Count)
            {
                Node c = head;
                for (int i = 0; i < index; i++)
                {
                    c = c.Next;  //cycles to the node before the index to be replaced
                }
                c.Next = new Node(item, c.Next);  //inserts a new node between c and c.next
                Count += 1;
            }
            else
            {
                Console.WriteLine("Null pointer exception - Cannot insert beyond last node");
            }
        }

        public void InsertCollection(int index, IEnumerable<T> collection) //inserts a collection of items at the specified index
        {
            if (index <= Count)
            {
                Node c = head;
                for (int i = 0; i < index; i++)
                {
                    c = c.Next;  //cycles to the node before the index to be replaced
                }
                foreach (var item in collection)
                {
                    c.Next = new Node(item, c.Next);  //inserts a new node between c and c.next
                    Count += 1;
                    c = c.Next;
                }
            }
            else
            {
                Console.WriteLine("Null pointer exception - Cannot insert beyond last node");
            }
        }

        public void RemoveAt(int index)  //deletes an item at the specified position (index from 0)
        {
            if (index < Count)
            {
                Node c = head;
                for (int i = 0; i < index; i++)  //iterates until the node before the node to be removed
                {
                    c = c.Next;
                }
                c.Next = c.Next.Next;  //removes the next node from the chain, changing the link to the node after it
                Count -= 1;
            }
            else
            {
                Console.WriteLine("Null Pointer Exception - No item at {0}", index);
            }
        }

        public void Remove(T item)  //removes the first instance of the specified item
        {
            Node c = head;
            for (int i = 0; i <= Count; i++)
            {
                if (c.Next.Data.Equals(item))
                {
                    c.Next = c.Next.Next;
                    Count -= 1;
                    break;
                }
                c = c.Next;
            }
        }

        public void RemoveAll(T item) //removes all instances of the specified item
        {
            Node c = head;
            do
            {
                c = c.Next;
                if (c.Next.Data.Equals(item))
                {
                    c.Next = c.Next.Next;
                    Count -= 1;
                }

            } while (c.Next != null);

        }

        public void RemoveRange(int start, int end) //removes all items between the two specified indicies (inclusive)
        {
            getNodeAt(start - 1).Next = getNodeAt(end + 1);
        }

        public T[] ToArray() //returns an array of T
        {
            T[] arr = new T[Count];
            Node c = head.Next;
            for (int i = 0; i < Count; i++)
            {
                arr[i] = c.Data;
                c = c.Next;
            }
            return arr;
        }

        public void Clear() //removes every item from the list
        {
            head.Next = null;
        }

        public bool Contains(T item)  //checks if the list contains a specified item
        {
            Node c = head.Next;
            do
            {
                if (c.Data.Equals(item))
                {
                    return true;
                }
                c = c.Next;
            } while (c.Next != null);
            return false;
        }

        public T GetItemAt(int index) //gets the data at a specified index
        {
            Node c = head;
            for (int i = 0; i <= index; i++)
            {
                c = c.Next;
            }
            return c.Data;
        }

        private Node getNodeAt(int index)
        {
            Node c = head;
            for (int i = 0; i <= index; i++)
            {
                c = c.Next;
            }
            return c;
        }
        public int IndexOf(T item)  //returns the 0-based index of the specified item (-1 if not found)
        {
            Node c = head;
            for (int i = 0; i <= Count; i++)
            {
                if (c.Data.Equals(item))
                {
                    return i - 1;
                }
                else
                {
                    c = c.Next;
                }
            }
            return -1;
        }

        public void DisplayList()
        {
            Node c = head.Next;
            while (c.Next != null)
            {
                Console.Write(c.Data + " ");
                c = c.Next;
            }
            Console.WriteLine(c.Data + " ");

        }
    }
}
