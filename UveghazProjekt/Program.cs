namespace UveghazProjekt
{
    internal class Program
    {
        enum MenuOldal
        {
            FO,
            TELEPITES,
            NOVELES,
            CSOKKENTES,
            ONTOZES,
        }

        static void Main(string[] args)
        {
            Logger logger = new Logger(10);

            UveghazRacs racs = new UveghazRacs(logger, 5);
            NovenyKezelo novenyKezelo = new NovenyKezelo(racs);
            Adattar tar = new Adattar(racs);

            novenyKezelo.NovenyFajHozzaad(new NovenyFaj("Tulipán", 80, 20, 1, 4, 8));
            novenyKezelo.NovenyFajHozzaad(new NovenyFaj("Rózsa", 80, 20, 1, 4, 8));
            novenyKezelo.NovenyFajHozzaad(new NovenyFaj("Muskátli", 70, 25, 1, 6, 12));

            int opcio;
            bool kilepes = false;
            MenuOldal oldal = MenuOldal.FO;

            string[] foMenuOpciok = { "Telepítés", "Növelés", "Csökkentés", "Öntözés", "Kilépés" };

            do
            {
                Console.Clear();
                Console.WriteLine(StringSegito.Osszefuz(racs.TerkepRajzol(), logger.Output, "  "));

                switch (oldal)
                {
                    case MenuOldal.FO:
                        opcio = MenuSegito.ValasztasLista(foMenuOpciok);

                        switch (opcio)
                        {
                            case 0:
                                oldal = MenuOldal.TELEPITES;
                                break;

                            case 1:
                                oldal = MenuOldal.NOVELES;
                                break;

                            case 2:
                                oldal = MenuOldal.CSOKKENTES;
                                break;

                            case 3:
                                oldal = MenuOldal.ONTOZES;
                                break;

                            case 4:
                                kilepes = true;
                                break;
                        }
                        break;

                    case MenuOldal.TELEPITES:
                        oldal = MenuOldal.FO;
                        opcio = MenuSegito.ValasztasLista(novenyKezelo.FajNevek);

                        string valasztottFaj = novenyKezelo.FajAzonositok[opcio];
                        (int telepitX, int telepitY) = MenuSegito.ValasztKordinata($"Pozíció ({racs.Meret}x{racs.Meret} rácsban) (AxB formátum): ", racs.Meret, racs.Meret);
                        int telepitSzam = MenuSegito.ValasztSzam("Adja meg a telepíteni kivánt mennyiséget: ", 1, 100);

                        novenyKezelo.Telepit(valasztottFaj, telepitX - 1, telepitY - 1, telepitSzam);

                        break;

                    case MenuOldal.NOVELES:
                        oldal = MenuOldal.FO;
                        (int novelX, int novelY) = MenuSegito.ValasztKordinata($"Pozíció ({racs.Meret}x{racs.Meret} rácsban) (AxB formátum): ", racs.Meret, racs.Meret);
                        int novelSzam = MenuSegito.ValasztSzam("Adja meg hány növénnyel növelné a számot: ", 1, 100);

                        racs.Noveles(novelX - 1, novelY - 1, novelSzam);

                        break;

                    case MenuOldal.CSOKKENTES:
                        oldal = MenuOldal.FO;
                        (int csokkentX, int csokkentY) = MenuSegito.ValasztKordinata($"Pozíció ({racs.Meret}x{racs.Meret} rácsban) (AxB formátum): ", racs.Meret, racs.Meret);
                        int csokkentSzam = MenuSegito.ValasztSzam("Adja meg hány növénnyel csökkentené a számot: ", 1, 100);

                        racs.Csokkentes(csokkentX - 1, csokkentY - 1, csokkentSzam);

                        break;

                    case MenuOldal.ONTOZES:
                        oldal = MenuOldal.FO;
                        (int ontozX, int ontozY) = MenuSegito.ValasztKordinata($"Pozíció ({racs.Meret}x{racs.Meret} rácsban) (AxB formátum): ", racs.Meret, racs.Meret);
                        int ontozSzazalek = MenuSegito.ValasztSzam("Adja meg hány százalékosra öntözné a cellát: ", 0, 100);

                        racs.Ontoz(ontozX - 1, ontozY - 1, ontozSzazalek);

                        break;
                }
            } while (!kilepes);
        }
    }
}
