using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10.model
{
    class Edge
    {
        public String id;
        public Vertex source;
        public Vertex destination;
        public int weight;
        private string v;
        private int wezP;
        private int wezK;
        private int dlugosc;

        public Edge(String id, Vertex source, Vertex destination, int weight)
        {
            this.id = id;
            this.source = source;
            this.destination = destination;
            this.weight = weight;
        }

        public override string ToString()
        {
            return id;
        }

    }
}
