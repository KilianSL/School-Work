using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public double Data { get; set; }

        public Node(double data, Node left = null, Node right = null)
        {
            Data = data;
            Left = left;
            Right = right;
        }

        public bool IsLeaf() //returns true if node has no children
        {
            if (Left==null & Right==null)
            {
                return true;
            }
            return false;
        }
    }
    class BinaryTree
    {
        public Node Root { get; set; }

        public BinaryTree(double[] numbers)
        {
            Root = new Node(numbers[0]);
            PopulateTree(numbers);
        }

        private void PopulateTree(double[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                var current_node = Root;
                var n = numbers[i];
                while ((current_node.Left != null & n <= current_node.Data) | (current_node.Right != null & n > current_node.Data))
                {
                    if (n <= current_node.Data)
                    {
                        current_node = current_node.Left;
                    }
                    else
                    {
                        current_node = current_node.Right;
                    }
                }
                if (n <= current_node.Data)
                {
                    current_node.Left = new Node(n);
                }
                else
                {
                    current_node.Right = new Node(n);
                }
            }
        }

        public bool SearchTree(double n)
        {
            var current_node = Root;
            while (current_node.Data != n & current_node != null)
            {
                if (current_node.Data > n)
                {
                    current_node = current_node.Left;
                }
                else
                {
                    current_node = current_node.Right;
                }
            }
            if (current_node != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
