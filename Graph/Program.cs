using System;

namespace Graph
{
    class Program
    {
        static Graph BuildGraph()  //helper function to load the graph needed into memory
        {
            var g = new Graph();
            //verticies
            g.AddVertex("hospital");
            g.AddVertex("post");
            g.AddVertex("cinema");
            g.AddVertex("hall");
            g.AddVertex("market");
            g.AddVertex("school");
            
            //connections
            g.AddConnection("hospital", "hall", 5);
            g.AddConnection("hospital", "cinema", 2);
            g.AddConnection("hospital", "post", 1.5);
            
            g.AddConnection("post", "hospital", 1.5);
            g.AddConnection("post", "cinema", 1);

            g.AddConnection("cinema", "hall", 6);
            g.AddConnection("cinema", "school", 3);
            g.AddConnection("cinema", "market", 0.5);
            g.AddConnection("cinema", "post", 1);
            g.AddConnection("cinema", "hospital", 2);

            g.AddConnection("market", "cinema", 0.5);
            g.AddConnection("market", "school", 2);

            g.AddConnection("hall", "cinema", 6);
            g.AddConnection("hall", "school", 4);
            g.AddConnection("hall", "hospital", 5);

            g.AddConnection("school", "hall", 4);
            g.AddConnection("school", "cinema", 3);
            g.AddConnection("school", "market", 2);

            return g;
        }
        static void Main(string[] args)
        {
            //Graph g = new Graph();   //simple graph with 3 nodes. Structure [A-->B:1,C:3], [B-->C:2], [C-->B:2]
            //g.AddVertex("a");
            //g.AddVertex("b");
            //g.AddVertex("c");
            //g.AddConnection("a", "b", 1);
            //g.AddConnection("a", "c", 3);
            //g.AddConnection("b", "c", 2);
            //g.AddConnection("c", "b", 2);
            //Console.WriteLine(g.ToString());

            //Graph wallingford = BuildGraph();
            //Console.WriteLine(wallingford.ToString());

            //Priority Queue Testing
            PriorityQueue q = new PriorityQueue();
            
            q.EnQueue("a", 1);
            Console.WriteLine(q.IsEmpty());
        }
    }
}
