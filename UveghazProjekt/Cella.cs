namespace UveghazProjekt
{
	internal class Cella
	{
		private int x;
		private int y;
		private int egyedSzam;
		private int talajNedvesseg;

		private NovenyFaj novenyFaj;
		private List<Szenzor> szenzorok;
		private List<Riasztas> riasztasok;

		public Cella(int x, int y)
		{
			this.x = x;
			this.y = y;
			this.egyedSzam = 0;
			this.novenyFaj = null;
			this.szenzorok = new List<Szenzor>();
			this.riasztasok = new List<Riasztas>();
		}

		public int X { get => x; }
		public int Y { get => y; }
		public int Egyedszam { get => egyedSzam; }
        public int TalajNedvesseg { get => talajNedvesseg; }
        public NovenyFaj NovenyFaj { get => novenyFaj; }
		public List<Szenzor> Szenzorok { get => szenzorok; }
		public List<Riasztas> Riasztasok { get => riasztasok; }

		public bool Ures { get => egyedSzam <= 0; }

		public bool Telepit(NovenyFaj faj, int mennyiseg)
		{
			if (Ures || novenyFaj == faj)
			{
				novenyFaj = faj;
				egyedSzam += mennyiseg;

				return true;
			}

			return false;
		}

		public void Ontoz(int szazalek)
		{
			talajNedvesseg = szazalek;
		}

		public void Noveles(int mennyiseg)
		{
			egyedSzam += mennyiseg;
		}

		public void Csokkentes(int mennyiseg)
		{
			egyedSzam -= mennyiseg;

			if (egyedSzam <= 0)
			{
				Urit();
			}
		}

		public void Urit()
		{
			egyedSzam = 0;
			novenyFaj = null;
		}

		public override string ToString()
		{
			if (Ures)
			{
				return " üres ";
			}

			return $"{novenyFaj.Nev} x{egyedSzam}";
		}

		public int KornyezetIdealissag()
		{
			if (Ures)
			{
				return 0;
			}

			return novenyFaj.KornyezetIdealissag(egyedSzam, 10, 10);
		}

		public void KiirInformaciok(Logger logger)
		{
            logger.WriteLine($"Ágyás növénye a(z) {novenyFaj.Nev}, egészségi index: {KornyezetIdealissag()}");
		}
	}
}
