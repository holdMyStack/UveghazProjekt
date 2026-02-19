namespace UveghazProjekt
{
	internal class NovenyKezelo
	{
		private Dictionary<string, NovenyFaj> novenyFajok;
		private UveghazRacs racs;

		public NovenyKezelo(UveghazRacs racs)
		{
			this.racs = racs;

			novenyFajok = new Dictionary<string, NovenyFaj>();
		}

		public void NovenyFajHozzaad(NovenyFaj faj)
		{
			novenyFajok[faj.Azonosito] = faj;
		}

		public bool Telepit(string fajAzonosito, int x, int y, int mennyiseg)
		{
			NovenyFaj faj = novenyFajok[fajAzonosito];
			return racs.Telepit(x, y, faj, mennyiseg);
		}
	}
}
