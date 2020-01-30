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

        public void EnQueue(string item, int priority)
        {
            Node n = Head;
            while (n.Next != null)
            {
                n = n.Next;
            }
            n.Next = new Node("");
        }
    }
}
