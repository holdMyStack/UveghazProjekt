namespace UveghazProjekt
{
    internal class UveghazRacs
    {
        private int meret;
        private int homerseklet;
        private Cella[,] racs;
        private Logger logger;

        public int Homerseklet { get => homerseklet; }

        public UveghazRacs(Logger logger, int meret)
        {
            this.logger = logger;
            this.meret = meret;
            this.racs = new Cella[meret, meret];

            Parcellaz();
        }

        private void Parcellaz()
        {
            for (int i = 0; i < meret; i++)
            {
                for (int j = 0; j < meret; j++)
                {
                    this.racs[i, j] = new Cella(i, j);
                }
            }
        }

        public int Meret { get => meret; }

        public Cella CellaLekerdez(int x, int y)
        {
            return racs[y, x];
        }

        public void Telepit(int x, int y, NovenyFaj faj, int mennyiseg)
        {
            Cella cella = CellaLekerdez(x, y);
            bool siker = cella.Telepit(faj, mennyiseg);

            if (siker)
            {
                logger.WriteLine($"({x + 1}; {y + 1}) A növény sikeresen települt.");
            }
            else
            {
                logger.WriteLine($"({x + 1}; {y + 1}) A növény telepítése sikertelen.");
            }
        }

        public void Noveles(int x, int y, int mennyiseg)
        {
            Cella cella = CellaLekerdez(x, y);


            logger.BeginGroup($"({x + 1}; {y + 1})");
            if (!cella.Ures)
            {
                logger.WriteLine("A cella sikeresen növelve!");
                cella.Noveles(mennyiseg);
                cella.KiirInformaciok(logger);
            }
            else
            {
                logger.WriteLine("Ez a cella üres!");
            }
            logger.EndGroup();
        }

        public void Csokkentes(int x, int y, int mennyiseg)
        {
            Cella cella = CellaLekerdez(x, y);

            logger.BeginGroup($"({x + 1}; {y + 1})");
            if (!cella.Ures)
            {
                logger.WriteLine("A cella sikeresen csökkentve!");
                cella.Csokkentes(mennyiseg);
                cella.KiirInformaciok(logger);
            }
            else
            {
                logger.WriteLine("Ez a cella üres!");
            }
            logger.EndGroup();
        }

        public void CellaUrit(int x, int y)
        {
            Cella cella = CellaLekerdez(x, y);
            cella.Urit();
        }

        public void Ontoz(int x, int y, int szazalek)
        {
            Cella cella = CellaLekerdez(x, y);

            logger.BeginGroup($"({x + 1}; {y + 1})");
            if (!cella.Ures)
            {
                logger.WriteLine("A cella sikeresen öntözve!");
                cella.Ontoz(szazalek);
                cella.KiirInformaciok(logger);
            }
            else
            {
                logger.WriteLine("Ez a cella üres!");
            }
            logger.EndGroup();
        }

        public List<Cella> Szomszedok(int x, int y)
        {
            List<Cella> szomszedok = new List<Cella>();

            if (x - 1 >= 0) szomszedok.Add(CellaLekerdez(x - 1, y));
            if (x + 1 < meret) szomszedok.Add(CellaLekerdez(x + 1, y));

            if (y - 1 >= 0) szomszedok.Add(CellaLekerdez(x, y - 1));
            if (y + 1 < meret) szomszedok.Add(CellaLekerdez(x, y + 1));

            return szomszedok;
        }

        private int[] OszlopMaxNevHossz()
        {
            int[] oszlopHosszak = new int[meret];

            for (int x = 0; x < meret; x++)
            {
                oszlopHosszak[x] = 1;

                for (int y = 0; y < meret; y++)
                {
                    Cella cella = CellaLekerdez(x, y);
                    oszlopHosszak[x] = Math.Max(oszlopHosszak[x], cella.ToString().Length);
                }
            }

            return oszlopHosszak;
        }

        public string TerkepRajzol()
        {
            int[] maxHossz = OszlopMaxNevHossz();
            string[] vegso = new string[4 * meret];

            for (int y = 0; y < vegso.Length; y++)
            {
                vegso[y] = "";
            }

            for (int x = 0; x < meret; x++)
            {
                string res = new string(' ', maxHossz[x] + 2);
                string szegely = new string('═', maxHossz[x] + 2);

                for (int y = 0; y < meret; y++)
                {
                    Cella cella = CellaLekerdez(x, y);
                    string tartalom = cella.ToString();

                    string balOldal = new string(' ', (maxHossz[x] - tartalom.Length) / 2);
                    string jobbOldal = new string(' ', maxHossz[x] - tartalom.Length - balOldal.Length);

                    vegso[y * 4 + 0] += res;
                    vegso[y * 4 + 1] += $" {balOldal}{tartalom}{jobbOldal} ";
                    vegso[y * 4 + 2] += res;
                    vegso[y * 4 + 3] += szegely;
                }

                if (x < meret - 1)
                {
                    for (int y = 0; y < vegso.Length; y++)
                    {
                        vegso[y] += "║";
                    }

                    for (int y = 3; y < vegso.Length; y += 4)
                    {
                        vegso[y] = vegso[y].Substring(0, vegso[y].Length - 1) + "╬";
                    }
                }
            }

            vegso[vegso.Length - 1] = "";

            return string.Join('\n', vegso);
        }

        public void TerkepKiir()
        {
            Console.WriteLine(TerkepRajzol());
        }
    }
}
