using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication10
{
    class lab
    {
       public Wezel[] wezly;
       public  Lacze[] lacza;

        public Lacze[] lacza1;
        Prim prim;
        Siec siec = new Siec();
        double[,] tablica_wag;
        static int k = 4;
        static int N = 10;//liczba wezlow
        int T = N * (N - 1) / 2;//liczba laczy

    
        public lab()
        {
            Random rand = new Random();
            wezly = new Wezel[N];
            lacza = new Lacze[T];
            for (int i = 0; i < N; i++)
            {
                wezly[i] = new Wezel(i + 1, rand.Next(0, 100), rand.Next(0, 100));
            }

            int nr = 1;
            for (int i = 0; i < N; i++)
                for (int j = i + 1; j < N; j++)
                {
                    {
                        lacza[nr - 1] = new Lacze(nr, wezly[i], wezly[j]);
                        nr++;
                    }
                }
            #region Tworzenie Sieci
            siec.tablica_wag = new double[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    siec.tablica_wag[i, j] = 0;
                }
            }

            for (int i = 0; i < T; i++)
            {
                siec.tablica_wag[lacza[i].wezP - 1, lacza[i].wezK - 1] = lacza[i].dlugosc;
                siec.tablica_wag[lacza[i].wezK - 1, lacza[i].wezP - 1] = lacza[i].dlugosc;

            }

            #endregion

            Prim[] tab_prim = new Prim[k];
            int[,] result = new int[k, N];//dwuwymiarowa tablica wyników MST, każda iteracja-nowy wiersz
            for (int c = 0; c < k; c++)
            {
                tab_prim[c] = new Prim();
                tab_prim[c].lacza = lacza;
                tab_prim[c].wezly = wezly;
                tab_prim[c].liczbalaczy = T;
                tab_prim[c].liczbawezlow = N;
                tab_prim[c].siec = siec;
                int[] res = tab_prim[c].GeneratePrim();
                for (int w = 0; w < N; w++)
                {
                    result[c, w] = res[w];
                }

                T = T - (N - 1);

                nr = 1;
                for (int i = 0; i < N; i++)
                    for (int j = i + 1; j < N; j++)
                    {

                        bool ok = false;
                        foreach (Lacze lacze in tab_prim[c].lacza)
                            if ((lacze.wezP - 1 == i && lacze.wezK - 1 == j) || (lacze.wezK - 1 == i && lacze.wezP - 1 == j))
                                ok = true;

                        if (j != res[i] && res[j] != i && ok)
                        {
                            lacza[nr - 1] = new Lacze(nr, wezly[i], wezly[j]);
                            nr++;
                        }
                    }

                for (int i = 0; i < N - 1; i++)
                {
                    siec.tablica_wag[res[i + 1], i + 1] = 0; ////zerowanie wag łączy użytych już w MST, żeby algorytm ich nie używał
                    siec.tablica_wag[i + 1, res[i + 1]] = 0;//// w następnej iteracji
                }

                for (int i = 0; i < T; i++)
                {
                    Console.Write(lacza[i].id + "  ");
                    Console.Write(lacza[i].wezP + "  ");
                    Console.Write(lacza[i].wezK + "  ");
                    Console.Write(lacza[i].dlugosc);
                    Console.WriteLine();
                }
            }



            lacza1 = new Lacze[k * (N - 1)]; ///tablica krawedzi wykorzystywanych do MST
            nr = 1;
            for (int i = 0; i < k; i++)
            {
                for (int j = 1; j < N; j++)
                {
                    lacza1[nr - 1] = new Lacze(nr, wezly[result[i, j]], wezly[j]);
                    nr++;
                }
                Console.WriteLine();
            }
            for (int i = 0; i < lacza1.Length; i++)
            {
                Console.Write(lacza1[i].id + "  ");
                Console.Write(lacza1[i].wezP + "  ");
                Console.Write(lacza1[i].wezK + "  ");
                Console.Write(lacza1[i].dlugosc);
                Console.WriteLine();
            }
            #region Zapis do pliku
            FileStream fs = new FileStream("testtest.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < N; i++)
            {
                sw.Write(wezly[i].id + "  ");
                sw.Write(wezly[i].wspx + "  ");
                sw.Write(wezly[i].wspy + "  ");
                sw.WriteLine();
            }

          
            sw.Close();
            FileStream fss = new FileStream("testtest2.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter ssw = new StreamWriter(fss);
          
            for (int i = 0; i < lacza1.Length; i++)
            {
               // ssw.Write(lacza1[i].id + "  ");
                ssw.Write(lacza1[i].wezP + "  ");
                ssw.Write(lacza1[i].wezK + "  ");
               // ssw.Write(lacza1[i].dlugosc);
                ssw.WriteLine();
            }
            ssw.Close();

            Console.ReadLine();

            #endregion
        }
    }
    
}