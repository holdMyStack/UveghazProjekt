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

		// Haldoklik -> Ideális
		// -3 -> +3
		public int KornyezetIdealissag(int egyedSzam, int homerseklet, int talajNedvesseg)
		{
			int idealitas = 0;

			if (egyedSzam < minSuruseg) return -3;
			if (egyedSzam > maxSuruseg) return -3;

			idealitas += (egyedSzam != optimalisSuruseg) ? -1 : 1;
			idealitas += (homerseklet != idealHomerseklet) ? -1 : 1;
			idealitas += (talajNedvesseg != idealTalajnedvesseg) ? -1 : 1;

			return idealitas;
		}
	}
}
