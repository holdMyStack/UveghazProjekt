namespace UveghazProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UveghazRacs racs = new UveghazRacs(5);
            Adattar tar = new Adattar(racs);

            NovenyFaj tulipan = new NovenyFaj("Tulipán", 10, 10, 1, 2, 10);

            racs.Telepit(2, 2, tulipan, 3);
            racs.TerkepKiir();

            Console.ReadKey();
            Console.Clear();

            racs.Csokkentes(2, 2, 1);
			racs.TerkepKiir();
		}
    }
}
