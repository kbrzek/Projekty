using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10
{
    class Floyd
    {
        public Wezel[] wezly;
        public Lacze[] lacza;
        public Siec siec;
        public int liczbawezlow;
        public int liczbalaczy;

        //opiera sie na dwoch tablicach: odleglosci (jesli nie ma krawedzi miedzy wezlami to 0) 
        //i przejsc (zawiera id wezla przez ktory trzeba przejsc, zeby dojsc do wezla koncowego)
        public void GenerateFloyd()
        {
            for (int i = 0; i < liczbawezlow; i++)
                for (int j = 0; j < liczbawezlow; j++)
                    siec.tablica_przejsc_Floyd[i, j] = 0; //ustawiamy na poczatku cala macierz przejsc na 0

            for (int i = 0; i < liczbalaczy; i++)
            {
                siec.tablica_przejsc_Floyd[lacza[i].wezP - 1, lacza[i].wezK - 1] = lacza[i].wezK;// w dwie strony, bo nieskierowane krawedzie
                siec.tablica_przejsc_Floyd[lacza[i].wezK - 1, lacza[i].wezP - 1] = lacza[i].wezP;
            }


            for (int k = 0; k < liczbawezlow; k++)/// k to jest ten pośredni wezel, przez ktory moze isc sciezka
            {
                for (int i = 0; i < liczbawezlow; i++)
                {
                    for (int j = 0; j < liczbawezlow; j++)
                    {
                        if (siec.tablica_odl[i, k] + siec.tablica_odl[k, j] < siec.tablica_odl[i, j])
                        {
                            siec.tablica_odl[i, j] = siec.tablica_odl[i, k] + siec.tablica_odl[k, j];
                            siec.tablica_przejsc_Floyd[i, j] = k + 1;
                        }
                    }
                }
            }
        }

        public string sciezka(int u, int v)
        {
            string sciezka = "Ścieżka z " + u.ToString() + " do " + v.ToString() + " nie istnieje";
            if ((siec.tablica_przejsc_Floyd[u - 1, v - 1] != 0)) //jesli to byloby zerem to sciezka nie istnieje
            {
                sciezka = "Ścieżka z " + u.ToString() + " do " + v.ToString() + ": " + u.ToString();
                int przejsciowy = u;
                while ((przejsciowy != v) && (przejsciowy != 0))/// warunek: przejsciowy nie jest koncowym i nie jest zerem
                {
                    przejsciowy = siec.tablica_przejsc_Floyd[przejsciowy - 1, v - 1];//na poczatku wartosci macierzy przejsc dla u i v, a poźniej dla wezla przejsciowego i v
                    sciezka += "->" + przejsciowy.ToString();
                }
            }
            Pokaz(sciezka, siec.tablica_odl[u - 1, v - 1]);
            return sciezka;

        }

        private void Pokaz(string sciezka, double odleglosc)
        {
            Console.Write(sciezka);
            Console.Write("   " + odleglosc);
            Console.WriteLine();

        }
    }
}
