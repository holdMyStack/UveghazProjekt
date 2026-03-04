using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UveghazProjekt
{
    internal class MenuSegito
    {
        public static int ValasztasLista(string[] opciok)
        {
            return ValasztasLista(opciok.ToList());
        }

        public static int ValasztasLista(List<string> opciok)
        {
            int valasztas = 0;
            bool vege = false;

            while (!vege)
            {
                for (int i = 0; i < opciok.Count(); i++)
                {
                    string before = valasztas == i ? "> " : "  ";

                    Console.WriteLine($"{before}{opciok[i]}");
                }

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        valasztas = Math.Max(0, valasztas - 1);
                        break;

                    case ConsoleKey.DownArrow:
                        valasztas = Math.Min(opciok.Count() - 1, valasztas + 1);
                        break;

                    case ConsoleKey.Enter:
                        vege = true;
                        break;
                }

                Console.Write($"\r\x1B[{opciok.Count()}A");
            }

            for (int i = 0; i < opciok.Count(); i++)
            {
                Console.Write($"\r\x1B[2K\n");
            }

            Console.Write($"\r\x1B[{opciok.Count()}A");


            return valasztas;
        }

        public static int ValasztSzam(string kerdes, int min, int max)
        {
            string valasz;

            bool elso;
            bool helyes;
            int szam;

            elso = true;
            szam = 0;

            do
            {
                if (!elso)
                {
                    Console.Write("\r\u001b[1A\x1B[K");
                }

                elso = false;

                Console.Write(kerdes);

                valasz = Console.ReadLine();
                helyes = int.TryParse(valasz, out szam);
            } while (!helyes || szam < min || szam > max);

            return szam;
        }

        public static (int, int) ValasztKordinata(string kerdes, int maxX, int maxY)
        {
            string[] felek;
            string valasz;

            bool elso;

            int balKordinata;
            int jobbKordinata;

            bool balHelyes;
            bool jobbHelyes;

            elso = true;
            balKordinata = 0;
            jobbKordinata = 0;

            do
            {
                if (!elso)
                {
                    Console.Write("\r\u001b[1A\x1B[K");
                }

                elso = false;

                Console.Write(kerdes);
                valasz = Console.ReadLine();
                felek = valasz.Split("x");

                balHelyes = false;
                jobbHelyes = false;

                if (felek.Count() == 2)
                {
                    balHelyes = int.TryParse(felek[0], out balKordinata);
                    jobbHelyes = int.TryParse(felek[1], out jobbKordinata);

                    balHelyes = balHelyes && balKordinata > 0 && balKordinata <= maxX;
                    jobbHelyes = jobbHelyes && jobbKordinata > 0 && jobbKordinata <= maxY;
                }
            } while (felek.Count() != 2 || !balHelyes || !jobbHelyes);

            return (balKordinata, jobbKordinata);
        }
    }
}
