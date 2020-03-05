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
        public void Add(string Item) {
            try
            {
                AdjacencyList.Add(Item, new Dictionary<string, float>());
            }
            catch (Exception)
            {
                Console.WriteLine("Error - Node already included in graph");
            }
        }

        public void AddConnections(params ValueTuple<string,string,float>[] connections) {
            foreach (var connection in connections)
            {
                if (AdjacencyList.ContainsKey(connection.Item1))
                {
                    if (AdjacencyList[connection.Item1].ContainsKey(connection.Item2))
                    {
                        AdjacencyList[connection.Item1].Remove(connection.Item2);
                        Console.WriteLine("WARNING - Previous Edge will be Overwritten");
                    }
                    AdjacencyList[connection.Item1].Add(connection.Item2, connection.Item3);
                }
                else
                {
                    Console.WriteLine("Target Node does not exist");
                }
            }
        }

        public string[] Neighbours(string Node)
        {
            return new List<string>(AdjacencyList[Node].Keys).ToArray();
        }
    }
}
