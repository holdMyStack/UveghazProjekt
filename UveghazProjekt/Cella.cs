namespace UveghazProjekt
{
	internal class Cella
	{
		private int x;
		private int y;
		private int egyedszam;
		private int egeszsegAllapot;

		private NovenyFaj novenyFaj;
		private List<Szenzor> szenzorok;
		private List<Riasztas> riasztasok;

		public Cella(int x, int y)
		{
			this.x = x;
			this.y = y;
			this.egyedszam = 0;
			this.novenyFaj = null;
			this.szenzorok = new List<Szenzor>();
			this.riasztasok = new List<Riasztas>();
		}

		public int X { get => x; }
		public int Y { get => y; }
		public NovenyFaj NovenyFaj { get => novenyFaj; }
		public int Egyedszam { get => egyedszam; }
		public int EgeszsegAllapot { get => egeszsegAllapot; }
		public List<Szenzor> Szenzorok { get => szenzorok; }
		public List<Riasztas> Riasztasok { get => riasztasok; }

		public bool Ures { get => egyedszam <= 0; }

		public bool Telepit(NovenyFaj faj, int mennyiseg)
		{
			if (Ures || novenyFaj == faj)
			{
				if (Ures)
				{
					egeszsegAllapot = 5;
				}

				novenyFaj = faj;
				egyedszam += mennyiseg;

				return true;
			}

			return false;
		}

		public void Noveles(int mennyiseg)
		{
			egyedszam += mennyiseg;
		}

		public void Csokkentes(int mennyiseg)
		{
			egyedszam -= mennyiseg;

			if (egyedszam <= 0)
			{
				Urit();
			}
		}

		public void Urit()
		{
			egeszsegAllapot = 0;
			egyedszam = 0;
			novenyFaj = null;
		}

		public override string ToString()
		{
			if (Ures)
			{
				return " üres ";
			}

			return $"{novenyFaj.Nev} x{egyedszam}";
		}
	}
}
