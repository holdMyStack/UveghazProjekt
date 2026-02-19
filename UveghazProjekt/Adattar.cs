namespace UveghazProjekt
{
	internal class Adattar
	{
		private UveghazRacs racs;
		private List<Kezelo> kezelok;
		private List<Szenzor> szenzorok;
		private List<Riasztas> riasztasok;

		public Adattar(UveghazRacs racs)
		{
			this.racs = racs;

			kezelok = new List<Kezelo>();
			szenzorok = new List<Szenzor>();
			riasztasok = new List<Riasztas>();
		}

		public UveghazRacs Racs { get => racs; }
		public List<Kezelo> Kezelok { get => kezelok; }
		public List<Szenzor> Szenzorok { get => szenzorok; }
		public List<Riasztas> Riasztasok { get => riasztasok; }


	}
}
