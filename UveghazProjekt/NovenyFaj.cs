namespace UveghazProjekt
{
	internal class NovenyFaj
	{
		private int idealTalajnedvesseg;
		private int idealHomerseklet;
		private int optimalisSuruseg;
		private int minSuruseg;
		private int maxSuruseg;

		private string nev;

		public NovenyFaj(string nev, int idealTalajnedvesseg, int idealHomerseklet, int minSuruseg, int optimalisSuruseg, int maxSuruseg)
		{
			this.nev = nev;
			this.idealTalajnedvesseg = idealTalajnedvesseg;
			this.idealHomerseklet = idealHomerseklet;
			this.minSuruseg = minSuruseg;
			this.maxSuruseg = maxSuruseg;
			this.optimalisSuruseg = optimalisSuruseg;
		}

		public string Azonosito { get => nev.Substring(0, 3); }
		public string Nev { get => nev; }

		public int IdealTalajnedvesseg { get => idealTalajnedvesseg; }
		public int IdealHomerseklet { get => idealHomerseklet; }
		public int OptimalisSuruseg { get => optimalisSuruseg; }
		public int MinSuruseg { get => minSuruseg; }
		public int MaxSuruseg { get => maxSuruseg; }
	}
}
