using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication10.model;

namespace ConsoleApplication10
{
    class Application
    {
        private static List<Vertex> nodes;
        private static List<Edge> edges;

        static void Main()
        {
            
            nodes = new List<Vertex>();
            edges = new List<Edge>();
            for (int i = 0; i < 5; i++)
            {
                Vertex location = new Vertex("Node_" + i, "Node_" + i);
                nodes.Add(location);
            }

            addLane("Edge_0", 0, 1, 4);
            addLane("Edge_1", 0, 2, 2);
            addLane("Edge_2", 1, 2, 3);
            addLane("Edge_3", 2, 1, 1);
            addLane("Edge_4", 1, 3, 2);
            addLane("Edge_5", 1, 4, 3);
            addLane("Edge_6", 2, 3, 4);
            addLane("Edge_7", 2, 4, 5);
            addLane("Edge_8", 4, 3, 1);
            

            // Lets check from location Loc_1 to Loc_10
            Graph graph = new Graph(nodes, edges);
            DijkstraAlgorithm dijkstra = new DijkstraAlgorithm(graph);
            dijkstra.execute(nodes[0]);
            List<Vertex> path = dijkstra.getPath(nodes[3]);


            foreach (Vertex vertex in path)
            {
                System.Console.WriteLine(vertex);
            }
            System.Console.ReadKey();
            
        }

        private static void addLane(String laneId, int sourceLocNo, int destLocNo,
                        int duration)
        {
            Edge lane = new Edge(laneId, nodes[sourceLocNo], nodes[destLocNo], duration);
            edges.Add(lane);
        }
    }
}
