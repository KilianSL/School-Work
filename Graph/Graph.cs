using System;
using DataStructures;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class Vertex
    {
        public string Data;
        public DataStructures.LinkedList<int> Connections;

        public Vertex(string data, int[] c)
        {
            Data = data;
            Connections = new DataStructures.LinkedList<int>(c);
        }
    }
    class Graph
    {
        //fields
        public int Size; //number of nodes in the graph
        public DataStructures.LinkedList<Vertex> verticies;

        //classes
        

        public Graph()
        {
            Size = 0;
            verticies = new DataStructures.LinkedList<Vertex>();
        }

        //Methods
        public void AddVertex(string data, params int[] connections)  //adds a vertex to the graph
        {
            verticies.Add(new Vertex(data, connections));
            Size++;
        }

        public void AddConnections(string data, params int[] connections)  //adds connections to the specified vertex
        {
            int i = 0;
            var v = verticies[i];
            while (v.Data != data && i < verticies.Count)
            {
                v = verticies[i];
                i++;
            }
            v.Connections.AddRange(connections);
        }

        public override string ToString()
        {
            string str = "";
            foreach (var vertex in verticies.ToArray())
            {
                str = str + $"{vertex.Data} --> ";
                for (int i = 0; i < vertex.Connections.Count; i++)
                {
                    str = str + verticies[vertex.Connections[i]].Data + " ";
                }
                str = str + Environment.NewLine;
            }
            return str;
        }
    }
}
