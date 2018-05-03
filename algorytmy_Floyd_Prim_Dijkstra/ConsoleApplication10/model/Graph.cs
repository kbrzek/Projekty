using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10.model
{
    class Graph
    {
        public  List<Vertex> vertexes;
        public List<Edge> edges;

        public Graph(List<Vertex> vertexes, List<Edge> edges)
        {
            this.vertexes = vertexes;
            this.edges = edges;
        }
    }
}
