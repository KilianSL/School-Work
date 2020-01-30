using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{ 
    class PriorityQueue
    {
        public int Count { get; set; }
        private Node Head;

        protected class Node
        {
            public string Data;
            public Node Next;
            public int Priority;

            public Node(string data, int priority = 0, Node next = null)
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

        public void EnQueue(string item, int priority=0)
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

        public void EnQueue(IEnumerable<string> items, int priority = 0)
        {
            foreach (var item in items)
            {
                EnQueue(item, priority);
            }
        } //overload to enqueue collection of items

        public string DeQueue()

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
