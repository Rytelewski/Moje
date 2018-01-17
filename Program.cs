using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace LLL13012018
{
    public abstract class Osoba
    {
        protected string imie;
        protected string nazwisko;
        public Osoba(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
        public override string ToString()
        {
            return this.imie + " " + this.nazwisko;
        }
    }
    public class Pacjent:Osoba
    {
        private string choroba;
        private int wiek;
        public Pacjent(string imie,string nazwisko,int wiek,string choroba):base(imie,nazwisko)
        {
            this.choroba = choroba;
            this.wiek = wiek;
        }
        public override string ToString()
        {
            return this.imie + " " + this.nazwisko + " " + this.wiek + " " + this.choroba;
        }
    }
    public class Lekarz:Osoba
    {
        private string specjalnosc;
        public Lekarz(string imie,string nazwisko,string specjalnosc):base(imie,nazwisko)
        {
            this.specjalnosc = specjalnosc;
        }
        public override string ToString()
        {
            return this.imie + " " + this.nazwisko + " " + this.specjalnosc;
        }
    }

    public class Przychodnia:IPrzychodnia
    {
        private Lekarz lekarz;
        private Queue<Pacjent> pacjenci = new Queue<Pacjent>();//miejsce przechowywania pacjentow
        public int CzasOczekiwania()
        {
            int czas;
            czas = pacjenci.Count() / 4; // dzieli liczbe pacj. na 4, daje dlugosc i czas oczekiwania
            return czas;
        }

        public void DodajDoKolejki(string imie, string nazwisko, int wiek, string choroba)
        {
            pacjenci.Enqueue(new Pacjent(imie, nazwisko, wiek, choroba));// wykorzystanie funkcji Enque
        }

        public void GenerujRaport()
        {
            FileStream plik = new FileStream("Raport.txt", FileMode.CreateNew, FileAccess.Write);
            Console.WriteLine(lekarz);
            foreach (var element in pacjenci)
            {
                Console.WriteLine(element);
            }
        }
        public override string ToString()
        {
            return  lekarz.ToString() + "\n" + "Pacjent:" + pacjenci.ToString() + " " + CzasOczekiwania();

        }

        public string WykonajBadanie()
        {

            return "Wykonano badanie !!" + pacjenci.Peek().ToString();//WYPISANIE TEKSTU I PACJENTA (IMIE, NAZWISKO,CHOROBA)
            
        }

        public string WykonajPorade()
        {
            return "Wykonano porade !!" + pacjenci.Dequeue();// wywalenie z kolejki
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Przychodnia nowa = new Przychodnia();
            int wybor;

            do//obsluga użytkownika ./// interfejs//
            {
                Console.WriteLine("1.DODAJ LEKARZA \n 2.PODAJ DANE PACJENTA \n 3.GENERUJ RAPORT\n 4.WYKONAJ BADANIE\n 5.WYKONAJ PORADE");
                wybor = int.Parse(Console.ReadLine());
                string imie, nazwisko, specjalnosc;
                string imiep, nazwiskop, choroba;
                int wiek;
                switch (wybor)
                {
                    case 1:

                        Console.WriteLine("Podaj imie");
                        imiep = Console.ReadLine();
                        Console.WriteLine("Podaj nazwisko");
                        nazwiskop = Console.ReadLine();
                        Console.WriteLine("Podaj specjalnosc");
                        specjalnosc = Console.ReadLine();
                        nowa.UstawLekarza(imiep, nazwiskop, specjalnosc);
                        break;
                    case 2:

                        Console.WriteLine("Podaj imie");
                        imie = Console.ReadLine();
                        Console.WriteLine("Podaj nazwisko");
                        nazwisko = Console.ReadLine();
                        Console.WriteLine("Wiek:");
                        try//obsluga wyjatkow dla wczytania pacjenta
                        {
                            wiek = int.Parse(Console.ReadLine());
                            Console.WriteLine("Choroba");
                            choroba = Console.ReadLine();
                            nowa.DodajDoKolejki(imie, nazwisko, wiek, choroba);
                            
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 3:
                        nowa.GenerujRaport();
                        break;
                    case 4:
                        string info = nowa.WykonajBadanie();
                        Console.WriteLine(info);
                        break;
                    case 5:
                        string info1 = nowa.WykonajPorade();
                        Console.WriteLine(info1);
                        break;
                    default:
                        Console.WriteLine("PODALES BLEDNY WYBOR !!!! SPROBUJ JESZCZE RAZ");
                        break;
                }
            
            }
            while (wybor!=6);
            Console.ReadKey();
        }
    }
}

