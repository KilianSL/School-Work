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
            Graph wallingford = BuildGraph();
            Console.WriteLine(wallingford.ToString());
            wallingford.FindShortestPath("school", "market");
        }
    }
}
