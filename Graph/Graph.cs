using System;
using DataStructures;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class Vertex
    {
        public string Data;
        public Dictionary<int, double> Connections;  //Maps graph edges in format Destination : Weight

        public Vertex(string data)
        {
            Data = data;
            Connections = new Dictionary<int, double>();
        }
    }
    class Graph
    {
        //fields
        public int Size; //number of nodes in the graph
        public DataStructures.LinkedList<Vertex> verticies;  //Linked list holding all the verticies that make up the graph

        //classes
        

        public Graph()
        {
            Size = 0;
            verticies = new DataStructures.LinkedList<Vertex>();
        }

        //Methods
        public void AddVertex(string data)  //adds a vertex to the graph
        {
            verticies.Add(new Vertex(data));
            Size++;
        }

        public void AddConnection(string from, string to, double weight)  //adds a connection to the specified vertex. 
        {
            int i = 0;
            var v = verticies[i];
            while (v.Data != from && i < verticies.Count)
            {
                v = verticies[i];
                i++;
            }
            v.Connections.Add(GetVertexIndex(to), weight);
        }

        public int GetVertexIndex(string data) //returns the index in verticies of a given piece of data
        {
            int index = -1;
            for (int i = 0; i < verticies.Count; i++)
            {
                if (verticies[i].Data == data)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public void FindShortestPath(string from, string to)  //dijkstas SPF algorithm, returns shortest path between 2 nodes
        {

        }

        public override string ToString()  //Outputs a string representation of the graph in format {Vertex} --> [{Vertex} : {Weight}]
        {
            string str = "";
            foreach (var vertex in verticies.ToArray())
            {
                str = str + $"{vertex.Data} --> ";
                foreach (var subVertex in vertex.Connections.Keys)
                {
                    str = str + $" [{verticies[subVertex].Data} : {vertex.Connections[subVertex]}] ";
                }
                str = str + Environment.NewLine;
            }
            return str;
        }
    }
}
