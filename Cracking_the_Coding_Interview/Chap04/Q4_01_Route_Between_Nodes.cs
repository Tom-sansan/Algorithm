using System;
using System.Collections.Generic;
using Ctci.Library;

namespace ExChapter04
{
    public class Q4_01_Route_Between_Nodes
    {
        public class Graph
        {
            public static int MAX_VERTICES = 6;
            private Node[] vertices;
            public int count;

            public Graph()
            {
                vertices = new Node[MAX_VERTICES];
                count = 0;
            }

            public void AddNode(Node x)
            {
                if (count < vertices.Length)
                {
                    vertices[count] = x;
                    count++;
                }
                else Console.WriteLine("Graph full");
            }

            public Node[] GetNodes()
            {
                return vertices;
            }
        }

        public class Node
        {
            private Node[] adjacent;
            public int AdjacentCount;
            private string vertex;
            public State State;

            public Node(string vertex, int adjacentLength)
            {
                this.vertex = vertex;
                AdjacentCount = 0;
                adjacent = new Node[adjacentLength];
            }

            public void AddAdjacent (Node x)
            {
                if (AdjacentCount < adjacent.Length)
                {
                    this.adjacent[AdjacentCount] = x;
                    AdjacentCount++;
                }
                else Console.WriteLine("No more adjacent can be added");
            }

            public Node[] GetAdjacent()
            {
                return adjacent;
            }

            public string GetVertex()
            {
                return vertex;
            }
        }

        public enum State
        {
            Unvisited,
            Visited,
            Visiting,
        }

        public static Graph CreateNewGraph()
        {
            Graph g = new Graph();
            Node[] temp = new Node[6];
            temp[0] = new Node("a", 3);
            temp[1] = new Node("b", 0);
            temp[2] = new Node("c", 0);
            temp[3] = new Node("d", 1);
            temp[4] = new Node("e", 1);
            temp[5] = new Node("f", 0);

            temp[0].AddAdjacent(temp[1]);
            temp[0].AddAdjacent(temp[2]);
            temp[0].AddAdjacent(temp[3]);
            temp[3].AddAdjacent(temp[4]);
            temp[4].AddAdjacent(temp[5]);
            for (int i = 0; i < 6; i++)
            {
                g.AddNode(temp[i]);
            }
            return g;
        }

        public static bool Search(Graph g, Node start, Node end)
        {
            LinkedList<Node> q = new LinkedList<Node>();
            foreach (Node u in g.GetNodes())
            {
                u.State = State.Unvisited;
            }
            start.State = State.Visited;
            q.AddLast(start);
            Node node;
            while (!(q.Count == 0))
            {
                node = q.First.Value;
                q.RemoveFirst();
                if (node != null)
                {
                    foreach (Node v in node.GetAdjacent())
                    {
                        if (v.State == State.Unvisited)
                        {
                            if (v == end) return true;
                            else
                            {
                                v.State = State.Visiting;
                                q.AddLast(v);
                            }
                        }
                    }
                    node.State = State.Visited;
                }
                
            }
            return false;
        }

        public static void Q04_01_Run()
        {
            Graph g = CreateNewGraph();
            Node[] n = g.GetNodes();
            Node start = n[3];
            Node end = n[5];
            Console.WriteLine(Search(g, start, end));
        }
    }
}