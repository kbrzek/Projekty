using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10
{
    class Wezel
    {
        public int id;
        public double wspx;
        public double wspy;

        public Wezel(int nr, double x, double y)
        {
            id = nr;
            wspx = x;
            wspy = y;
        }

        public override string ToString()
        {
            return id + " " + wspx + " " + " " + wspy + " " ;
        }


    }
}
