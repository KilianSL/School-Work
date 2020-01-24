using System;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph();
            g.AddVertex("a", 1, 2);
            g.AddVertex("b", 0);
            g.AddVertex("c", 0, 1);
            Console.WriteLine(g.ToString());
        }
    }
}
