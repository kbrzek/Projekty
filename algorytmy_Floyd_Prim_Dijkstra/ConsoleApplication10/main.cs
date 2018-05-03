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


            //Console.WriteLine("wklej wezly");

            //string line;
            //while ((line = Console.ReadLine()) != null)
            //{
            //    if (line.Length == 0)
            //    {
            //        break;
            //    }

            //    String[] vertexes = line.Split(' ');
            //    Vertex location = new Vertex(vertexes[0], vertexes[0], Convert.ToInt32(vertexes[1]), Convert.ToInt32(vertexes[2]));
            //    nodes.Add(location);

            //}
            //Console.WriteLine("Wklej lacza");
            //while ((line = Console.ReadLine()) != null)
            //{
            //    if (line.Length == 0)
            //    {
            //        break;
            //    }

            //    String[] vertexes = line.Split(' ');
            //    addLane(vertexes[0], Convert.ToInt32(vertexes[1]), Convert.ToInt32(vertexes[2]));

            //}

            
           


          int x;
            int y;
            System.Console.WriteLine("podaj wezel poczatkowy");
            x = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("podaj wezel koncowy");
            y = Convert.ToInt32(Console.ReadLine());


            //Wezel[] wezly = new Wezel[6];
            //wezly[0] = new Wezel(1, 1, 1);
            //wezly[1] = new Wezel(2, 3, 1);
            //wezly[2] = new Wezel(3, 2, 2);
            //wezly[3] = new Wezel(4, 1, 2);
            //wezly[4] = new Wezel(5, 3, 2);
            //wezly[5] = new Wezel(6, 2, 3);

            foreach (Wezel i in nowy.wezly)
            {
                nodes.Add(from(i));
                Console.WriteLine("------------------------");
                Console.WriteLine(i);
                Console.WriteLine(from(i));
                Console.WriteLine("--------uuuuuuuuuuuuu---");

            }

            //Lacze[] lacza1 = new Lacze[6];
            //lacza1[0] = new Lacze(1, 1, 2);
            //lacza1[1] = new Lacze(2, 2, 3);
            //lacza1[2] = new Lacze(3, 2, 4);
            //lacza1[3] = new Lacze(4, 4, 6);
            //lacza1[4] = new Lacze(5, 3, 6);
            //lacza1[5] = new Lacze(6, 6, 5);

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
