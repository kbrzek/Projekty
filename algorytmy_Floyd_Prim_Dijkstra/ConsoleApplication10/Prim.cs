using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10
{
    class Prim
    {
        public Wezel[] wezly;
        public Lacze[] lacza;
        public Siec siec;
        public int liczbawezlow;
        public int liczbalaczy;
        double suma = 0;

        // fukcja znajduje min wartosc klucza wierzcholka spośród
        // tych jeszcze niezawartych w MST
        private int MinKlucz(double[] klucz, bool[] zestaw, int liczbawezlow)
        {
            int minIndex = 0;
            double min = int.MaxValue;

            for (int v = 0; v < liczbawezlow; v++)
            {
                if (zestaw[v] == false && klucz[v] < min)
                {
                    min = klucz[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        //funkcja pokazuje zbudowane MST przechowywane w tablicy poprzedni[]
        private void Pokaz(int[] poprzedni, double[,] tablica_wag, int liczbawezlow)
        {
            Console.WriteLine("Lacze     Waga");
            for (int i = 1; i < liczbawezlow; i++)
            {
                Console.WriteLine("{0} - {1}    {2}", poprzedni[i] + 1, i + 1, siec.tablica_wag[i, poprzedni[i]]);
                suma += siec.tablica_wag[i, poprzedni[i]];
            }
            Console.WriteLine("Suma wag krawedzi MST: " + suma);

        }

        // funkcja konstruujaca MST z użyciem macierzy wag
        public int[] GeneratePrim()
        {
            int[] poprzedni = new int[liczbawezlow];     // tablica przechowuje budowane MST
            double[] klucz = new double[liczbawezlow];    // wartosci klucza uzyte do znalezienia min wagi lacza
            bool[] mstZest = new bool[liczbawezlow];   // zwraca false gdy wierzcholek nie jest jeszcze w MST

            for (int i = 0; i < liczbawezlow; i++)
            {
                klucz[i] = int.MaxValue; // wszystkie klucze ustawione na nieskonczonosc
                mstZest[i] = false;
            }

            // pierwszy wierzcholek jest zawsze zawarty w MST
            klucz[0] = 0; //
            poprzedni[0] = -1; // pierwszy wezel jest korzeniem MST 


            for (int c = 0; c < liczbawezlow - 1; c++)
            {
                // znajdowanie indeksu wierzcholka niezawartego jeszcze w MST o min wartosci klucza  
                int u = MinKlucz(klucz, mstZest, liczbawezlow);
                // dodaj znaleziony wierzcholek do MST
                mstZest[u] = true;

                // uaktualnienie klucza i poprzednika wierzcholkow sasiadujacych znalezionego wierzcholka 
                // ropatrujemy tylko wierzcholki niezawarte w MST
                for (int v = 0; v < liczbawezlow; v++)
                {
                    // graf[u,v] jest zerowy jesli nie ma krawedzi miedzy wierzcholkami
                    // Convert.ToBoolean(graf[u, v]) zwraca false {tzn nie wchodzi do ifa}, gdy graf[u, v]==0

                    if (Convert.ToBoolean(siec.tablica_wag[u, v]) && mstZest[v] == false && siec.tablica_wag[u, v] < klucz[v])
                    {
                        poprzedni[v] = u;
                        klucz[v] = siec.tablica_wag[u, v];
                    }
                }
            }

            Pokaz(poprzedni, siec.tablica_wag, liczbawezlow);
            return poprzedni;

        }
    }
}
