namespace UveghazProjekt
{
	internal class Kezelo
	{
		public enum KezeloSzerepkor {
			KERTESZ,
			TECHNIKUS,
			ADMIN
		}

		private string nev;
		private string azonosito;
		private KezeloSzerepkor szerepkor;

		public Kezelo(string nev, string azonosito, KezeloSzerepkor szerepkor)
		{
			this.nev = nev;
			this.azonosito = azonosito;
			this.szerepkor = szerepkor;
		}

		public string Nev { get => nev; }
		public string Azonosito { get => azonosito; }
		public KezeloSzerepkor Szerepkor { get => szerepkor; }
	}
}
