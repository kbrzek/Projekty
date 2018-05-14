using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication10.model;
using System.IO;

namespace ConsoleApplication10
{
    class Application
    {
        private static List<Vertex> nodes;
        private static List<Edge> edges;
        

        static void Main()
        {
            lab nowy = new lab();

            nodes = new List<Vertex>();
            edges = new List<Edge>();

            int x;
            int y;
            System.Console.WriteLine("podaj wezel poczatkowy");
            x = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("podaj wezel koncowy");
            y = Convert.ToInt32(Console.ReadLine());


            foreach (Wezel i in nowy.wezly)
            {
                nodes.Add(from(i));
                Console.WriteLine("------------------------");
                Console.WriteLine(i);
                Console.WriteLine(from(i));
                Console.WriteLine("--------uuuuuuuuuuuuu---");

            }


            foreach (Lacze i in nowy.lacza1)
            {
                edges.Add(from(i));
                Console.WriteLine("------------------------");
                Console.WriteLine(i);
                Console.WriteLine(from(i));
                Console.WriteLine("--------uuuuuuuuuuuuu---");

            }


            Graph graph = new Graph(nodes, edges);

            DijkstraAlgorithm dijkstra = new DijkstraAlgorithm(graph);
            dijkstra.execute(nodes[x]);
            List<Vertex> path = dijkstra.getPath(nodes[y]);


            System.Console.WriteLine("------------");
            foreach (Vertex vertex in path)
            {
                System.Console.WriteLine(vertex);
            }
            System.Console.ReadKey();

        }

        private static void addLane(String laneId, int sourceLocNo, int destLocNo)
        {
            Vertex start = null;
            Vertex end = null;

            foreach (Vertex v in nodes)
            {

                if (v.id.Equals(sourceLocNo.ToString()))
                {
                    System.Console.WriteLine(start);
                    start = v;
                }
                if (v.id.Equals(destLocNo.ToString()))
                    end = v;
            }

            double weight = Math.Sqrt(Math.Pow(Math.Abs(start.x - end.x), 2) + Math.Pow(Math.Abs(start.y - end.y), 2));

            Edge lane = new Edge(laneId, nodes[sourceLocNo - 1], nodes[destLocNo - 1], Convert.ToInt32(weight));
            edges.Add(lane);
        }

        public static Vertex from(Wezel w)
        {
            return new Vertex(w.id.ToString(),w.id.ToString(), (int)w.wspx, (int)w.wspy);
        }

        private static Edge from(Lacze l)
        {

            Vertex s = null;
            Vertex d = null;

            foreach (Vertex v in  nodes)
            {
              
        
                if(v.id ==l.wezP.ToString())
                {
                    s = v;
                }

                if (v.id == l.wezK.ToString())
                {
                    d = v;
                }

            }

            return new Edge(l.id.ToString(),s,d,(int)l.dlugosc);
        }

    }
}
