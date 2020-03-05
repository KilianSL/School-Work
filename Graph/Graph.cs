using System;
using DataStructures;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class Graph
    {
        public Graph() { AdjacencyList = new Dictionary<string, Dictionary<string, float>>(); Count = 0; }

        private Dictionary<string, Dictionary<string, float>> AdjacencyList;
        public int Count { get; set; }
        public void AddVertex(string Item) {
            try
            {
                AdjacencyList.Add(Item, new Dictionary<string, float>());
            }
            catch (Exception)
            {
                Console.WriteLine("Error - Node already included in graph");
            }
        }

        public bool ValidateGraphCompletedness() //returns true if the graph is valid i.e. every node is listed in the adjacency list and there are no erroneous connections
        {
            foreach (var node in AdjacencyList.Keys)
            {
                foreach (var child in AdjacencyList[node].Keys)
                {
                    if (!AdjacencyList.ContainsKey(child))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void AddConnections(string node_from, params ValueTuple<string, float>[] nodes_to) {
            if (AdjacencyList.ContainsKey(node_from))
            {
                var connections = AdjacencyList[node_from];
                foreach (var node in nodes_to)
                {
                    if (connections.ContainsKey(node.Item1))
                    {
                        Console.WriteLine("WARNING - Existing edge will be overwritten");
                        connections.Remove(node.Item1);
                    }
                    connections.Add(node.Item1, node.Item2);
                }
            }
            else
            {
                Console.WriteLine("Target node does not exist");
            }
        }

        public string[] Neighbours(string Node)
        {
            return new List<string>(AdjacencyList[Node].Keys).ToArray();
        }

        private PriorityQueue BuildShortestPathQueue(string start)
        {
            PriorityQueue queue = new PriorityQueue();
            foreach (var node in AdjacencyList.Keys)
            {
                queue.EnQueue(node, float.PositiveInfinity);
            }
            queue.UpdatePriority(start, 0);
            return queue;
        }
        public (string[], float) GetShortestPath(string start, string end)
        {
            if (!ValidateGraphCompletedness()){ throw new Exception("Graph Incomplete Error"); }

            PriorityQueue queue = BuildShortestPathQueue(start);
            bool done = false;
            


            return default;
        }

        public override string ToString()
        {
            string str = "";
            foreach (var node in AdjacencyList.Keys)
            {
                str = str + $"{node} => ";
                foreach (var child_node in AdjacencyList[node].Keys)
                {
                    str = str + $"[{child_node} : {AdjacencyList[node][child_node]}] ";
                }
                str = str + Environment.NewLine;
            }
            return str;
        }
    }
}
