namespace UveghazProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UveghazRacs racs = new UveghazRacs(5);
            Adattar tar = new Adattar(racs);

            NovenyFaj tulipan = new NovenyFaj("tulipán", 100, 20, 1, 2, 10);

            racs.Telepit(2, 2, tulipan, 1);
        }
    }
}
