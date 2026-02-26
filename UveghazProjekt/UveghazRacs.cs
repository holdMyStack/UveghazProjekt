namespace UveghazProjekt
{
	internal class UveghazRacs
	{
		private int meret;
		private Cella[,] racs;

		public UveghazRacs(int meret)
		{
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

		public bool Telepit(int x, int y, NovenyFaj faj, int mennyiseg)
		{
			Cella cella = CellaLekerdez(x, y);
			return cella.Telepit(faj, mennyiseg);
		}

		public void Noveles(int x, int y, int mennyiseg)
		{
			Cella cella = CellaLekerdez(x, y);
			cella.Noveles(mennyiseg);
		}

		public void Csokkentes(int x, int y, int mennyiseg)
		{
			Cella cella = CellaLekerdez(x, y);
			cella.Csokkentes(mennyiseg);
		}

		public void CellaUrit(int x, int y)
		{
			Cella cella = CellaLekerdez(x, y);
			cella.Urit();
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

		public void TerkepKiir()
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

			Console.WriteLine(string.Join('\n', vegso));
		}
	}
}
