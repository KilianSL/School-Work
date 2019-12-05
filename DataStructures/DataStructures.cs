using System;
using System.Collections.Generic;

namespace DataStructures
{
    /// <summary>
    /// Static-Length Queue Datastructure
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Queue<T>
    {
        public int MaxSize;
        protected int front;
        protected int rear;
        protected int size;
        protected T[] data;

        /// <summary>
        /// Creates a new instance of the Queue datastructure
        /// </summary>
        /// <param name="maxsize">Maximum amount of elements that the Queue can hold</param>
        public Queue(int maxsize)
        {
            MaxSize = maxsize;
            data = new T[maxsize];
            front = 0;
            rear = -1;
            size = 0;

        }
        /// <summary>
        /// Adds a specified item to the end of the queue.
        /// </summary>
        /// <param name="item">Item to enqueue</param>
        public void EnQueue(T item)
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
        /// <summary>
        /// Adds a collection of items to the end of the queue.
        /// </summary>
        /// <param name="items">Collection of items to enqueue</param>
        public void EnQueue(IEnumerable<T> items)
        {
            foreach (T item in items)
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
        /// <summary>
        /// Returns the item at the front of the queue.
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return data[front];
        }
        /// <summary>
        /// Returns the item at the front of the queue, then removes it from the queue.
        /// </summary>
        /// <returns></returns>
        public T DeQueue()
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
        /// <summary>
        /// Checks if the queue is full.
        /// </summary>
        /// <returns>Returns true if the queue is full.</returns>
        public bool IsFull()
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
        /// <summary>
        /// Checks if the queue is empty.
        /// </summary>
        /// <returns>Returns true if the queue is empty.</returns>
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
        /// <summary>
        /// Getter function for the current size of the queue
        /// </summary>
        /// <returns></returns>
        public int GetSize()
        {
            return size;
        }
        /// <summary>
        /// Returns the data held in the queue as an array.
        /// </summary>
        /// <param name="verbose">True: Outputs queue to the console. Default false.</param>
        /// <returns></returns>
        public T[] GetData(bool verbose = false)  //returns ALL data held in the array, regardless of pointers (WIP). Outputs data is verbose = true
        {
            List<T> ts = new List<T>();
                if (front <= rear)
                {
                    for (int i = front; i <= rear; i++)
                    {
                        if (verbose)
                        {
                            Console.Write(data[i] + " , ");
                        }
                        ts.Add(data[i]);
                    }
                }
                else
                {
                    for (int i = front; i < MaxSize; i++)
                    {
                        if (verbose)
                        {
                            Console.Write(data[i] + " , ");
                        }
                        ts.Add(data[i]);
                    }
                    for (int i = 0; i <= rear; i++)
                    {
                        if (verbose)
                        {
                            Console.Write(data[i] + " , ");
                        }                       
                        ts.Add(data[i]);
                    }
                }
                Console.WriteLine();
            return ts.ToArray();
            
        }
    }

    /// <summary>
    /// Sub-Class of Queue that allows for priority items to enter at the front of the queue.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PriorityQueue<T> : Queue<T> //static-length queue data structure, with the option to have items jump to the front of the queue
    {
        /// <summary>
        /// Creates a new instance of the PriorityQueue datastructure.
        /// </summary>
        /// <param name="maxsize">Maximum amount of elements that the queue can hold</param>
        public PriorityQueue(int maxsize) : base(maxsize)
        { }

        /// <summary>
        /// Adds a specified item to the queue
        /// </summary>
        /// <param name="item">Item to enqueue</param>
        /// <param name="priority">If True, places the item at the front of the queue. Default False.</param>
        public void EnQueue(T item, bool priority = false)
        {
            if (priority) 
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

        /// <summary>
        /// Adds a collection of items to the queue
        /// </summary>
        /// <param name="items">Collection to enqueue</param>
        /// <param name="priority">If True, places the items at the front of the queue. Default False.</param>
        public void EnQueue(IEnumerable<T> items, bool priority = false)  //enqueues an array of items, set to true to add to front of queue
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

    /// <summary>
    /// Static-Length Stack Datastructure
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Stack<T>
    {
        private T[] data;
        private int top;
        private int size;
        public int MaxSize;
        
        /// <param name="maxsize">Maximum size of the stack.</param>
        public Stack(int maxsize)
        {
            MaxSize = maxsize;
            data = new T[MaxSize];
            top = -1;
            size = 0;
        }

        /// <summary>
        /// Pushes a specified item on top of the stack.
        /// </summary>
        /// <param name="item">Item to push.</param>
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

        /// <summary>
        /// Pushes a collection of items onto the stack.
        /// </summary>
        /// <param name="items">Collection to push.</param>
        public void Push(IEnumerable<T> items)
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

        /// <summary>
        /// Returns the top item on the stack.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Returns the top item on the stack, then removes it.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Returns True if the stack is full.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Returns True if the stack is empty.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Returns the data held in the stack as an array.
        /// </summary>
        /// <param name="verbose">True: Outputs queue to the console. Default false.</param>
        /// <returns></returns>
        public T[] GetData(bool verbose = false)
        {
            List<T> ts = new List<T>();
            
                for (int i = 0; i <= top; i++)
                {
                    if (verbose)
                    {
                        Console.Write(data[i] + " , ");
                    }
                    ts.Add(data[i]);
                }
            
            Console.WriteLine();
            return ts.ToArray();
        }
    }

    /// <summary>
    /// Dynamic-Length Single Linked List Datastructure
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T>  //Simple linked list
    {

        //c in all instances is a temporary variable used to indicate the Currrent node that the method is processing
        /// <summary>
        /// Gets the number of items contained in the list.
        /// </summary>
        public int Count { get; set; }  //amount of nodes in the list
        private Node head;  //first node in the list
        
        /// <summary>
        /// Initializes a new empty instance of LinkedList.
        /// </summary>
        public LinkedList()   //default constructor 
        {
            head = new Node(default);  //head stores no data (default T) - merely the beginning of the list
            Count = 0;
        }

        /// <summary>
        /// Initializes a new instance of LinkedList that contains elements copied from the specified collection.
        /// </summary>
        /// <param name="collection">The collection who's elements are copied to the new list.</param>
        public LinkedList(IEnumerable<T> collection) 
        {
            List<T> ts = new List<T>();
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

        /// <summary>
        /// Adds an object to the end of the list.
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            Node n = head;
            while (n.Next != null)  //iterates until the last node in the list is found
            {
                n = n.Next;
            }
            n.Next = new Node(item);
            Count += 1;
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the list.
        /// </summary>
        /// <param name="collection"></param>
        public void AddRange(IEnumerable<T> collection)  //adds a collection of items to the list
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Inserts an element into the list at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, T item)  //inserts an item in the specified position in the list (index from 0)
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

        /// <summary>
        /// Inserts the elements of a collection into the List at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="collection"></param>
        public void InsertRange(int index, IEnumerable<T> collection)
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
		
		public bool IsEmpty()
		{
			if (head.Next == null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

        /// <summary>
        /// Removes the element at the specified index of the list.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index) 
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

        /// <summary>
        ///Removes the first occurrence of a specific object from the List.
        /// </summary>
        /// <param name="item"></param>
        public void Remove(T item)
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

        /// <summary>
        /// Remove all occurrences of a specific object from the List.
        /// </summary>
        /// <param name="item"></param>
        public void RemoveAll(T item)
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

        /// <summary>
        /// Removes a range of elements from the List.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void RemoveRange(int start, int end) //removes all items between the two specified indicies (inclusive)
        {
            getNodeAt(start - 1).Next = getNodeAt(end + 1);
        }

        /// <summary>
        /// Copies the elements of the List to a new array.
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
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

        /// <summary>
        /// Removes all elements from the list.
        /// </summary>
        public void Clear()
        {
            head.Next = null;
        }

        /// <summary>
        /// Determines whether an element is in the list.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the element at a specific index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetItemAt(int index)
        {
            Node c = head;
            for (int i = 0; i <= index; i++)
            {
                c = c.Next;
            }
            return c.Data;
        }

        private Node getNodeAt(int index) //returns the node at a specific index
        {
            Node c = head;
            for (int i = 0; i <= index; i++)
            {
                c = c.Next;
            }
            return c;
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire List.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Displays the list in the Console.
        /// </summary>
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
