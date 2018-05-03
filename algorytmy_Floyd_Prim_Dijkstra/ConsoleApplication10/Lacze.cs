using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10
{
    class Lacze
    {
        public int id;
        public double dlugosc;
        public Wezel WezP;
        public Wezel WezK;

        public int wezP;
        public int wezK;

        public Lacze(int id1, Wezel wp, Wezel wk)
        {
            id = id1;
            WezP = wp;
            WezK = wk;
            wezP = WezP.id;
            wezK = WezK.id;
            dlugosc = Dlugosc(WezP, WezK);

        }

        public Lacze(int id1, int wp, int wk)
        {
            id = id1;
            wezP = wp;
            wezK = wk;
        }


        public double Dlugosc(Wezel wp, Wezel wk)
        {
            return dlugosc = Math.Sqrt(Math.Pow(Math.Abs(WezP.wspx - WezK.wspx), 2) + Math.Pow(Math.Abs(WezP.wspy - WezK.wspy), 2));
        }
    }
}
