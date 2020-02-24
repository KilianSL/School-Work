using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{ 
    class PriorityQueue
    {
        public double Count { get; set; }
        private Node Head;

        protected class Node
        {
            public string Data;
            public Node Next;
            public double Priority;

            public Node(string data, double priority = 0, Node next = null)
            {
                Data = data;
                Priority = priority;
                Next = next;
            }
        }

        public PriorityQueue()
        {
            Count = 0;
            Head = new Node(default, -1, null);
        }

        public bool IsEmpty()
        {
            if (Head.Next == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void EnQueue(string item, double priority=0)
        {
            Node n = Head;
            while (n.Next != null)
            {
                if (n.Next.Priority > priority)
                {
                    break;
                }
                n = n.Next;
            }
            if (n.Next == null)
            {
                n.Next = new Node(item, priority);
            }
            else
            {
                Node next_n = n.Next;
                n.Next = new Node(item, priority, next_n);
            }
            Count++;
        }

        public void EnQueue(IEnumerable<string> items, double priority = 0)
        {
            foreach (var item in items)
            {
                EnQueue(item, priority);
            }
        } //overload to enqueue collection of items

        public string DeQueue() //returns and removes the first item in the queue
        {
            if(!IsEmpty())
            {
                string ret = Head.Next.Data;
                Head.Next = Head.Next.Next;
                return ret;
            }
            else
            {
                throw new Exception("Queue Empty");
            }
        }

        public string Peek() //returns the top item on the queue without removing it
        {
            if(!IsEmpty())
            {
                return Head.Next.Data;
            }
            else
            {
                throw new Exception("Queue Empty");
            }
        }

        public override string ToString()
        {
            string str = "";
            Node n = Head;
            while (n.Next != null)
            {
                n = n.Next;
                str = str + $"[P:{n.Priority}  :  {n.Data}]";
                str = str + Environment.NewLine;
            }
            return str;
        }
    }
}
