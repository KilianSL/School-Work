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
            g.AddConnections("hospital", ("hall", 5), ("cinema", 2), ("post", 1.5f));
            g.AddConnections("post", ("hospital", 1.5f), ("cinema", 1));
            g.AddConnections("cinema", ("hall", 6),("school", 3),("market", 0.5f),("post", 1),("hospital", 2));
            g.AddConnections("market", ("cinema", 0.5f), ("school", 2));
            g.AddConnections("hall", ("cinema", 6),("school", 4),("hospital", 5));
            g.AddConnections("school", ("hall", 4),("cinema", 3),("market", 2));

            return g;
        }
        static void Main(string[] args)
        {
            Graph wallingford = BuildGraph();
            Console.WriteLine(wallingford.ValidateGraphCompletedness());
            Console.WriteLine(wallingford.ToString());
            wallingford.GetShortestPath("hospital", "b");
// wallingford.FindShortestPath("school", "market");
        }
    }
}
