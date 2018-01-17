using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kasa_Fiskalna
{
    class Koszyk
    {
        private List<Produkt> Zakupy;

        public Koszyk()
        {
            Zakupy = new List<Produkt>();
        }

        public void Clone()
        {
            Zakupy.Add(Zakupy.Last());
            Console.WriteLine("Ostatnio dodany element został skopiowany.");
        }

        public void Add()
        {
            bool czyPoprawna = false;
            string nazwa;
            int ilosc=0;
            double cena=0;

            Console.WriteLine("Podaj nazwe produkty: ");
            nazwa = Console.ReadLine();

            Console.WriteLine("Podaj cenę produktu: ");
            while(!czyPoprawna)
            {
                czyPoprawna = true;

                try
                {
                    Console.Write(": :: : ");
                    cena = Convert.ToDouble(Console.ReadLine());
                }
                catch(Exception)
                {
                    Console.WriteLine("Wystapił błąd przy pobieraniu danych.");
                    czyPoprawna = false;
                }
            }

            czyPoprawna = false;

            Console.WriteLine("Podaj ilość produktu: ");
            while (!czyPoprawna)
            {
                czyPoprawna = true;

                try
                {
                    Console.Write(": :: : ");
                    ilosc = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Wystapił błąd przy pobieraniu danych.");
                    czyPoprawna = false;
                }
            }

            Zakupy.Add(new Produkt(nazwa, cena, ilosc));
            Console.WriteLine("Produkt został dodany.");
        }

        public void wypiszKoszyk()
        {
            foreach(var prod in Zakupy)
            {
                prod.wypiszProdukt();
            }
            Console.WriteLine("W sumie do zapłaty: " + podajSume());
        }

        public double podajSume()
        {
            double suma = 0;
            foreach(var prod in Zakupy)
            {
                suma += prod.podajCene();
            }
            return suma;
        }

        public void skasujProdukt()
        {
            bool czyPoprawny = false;
            int doUsuniecia = -1;

            while(!czyPoprawny)
            {
                czyPoprawny = true;
                try
                {
                    doUsuniecia = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception)
                {
                    Console.WriteLine("Pojawił się problem przy pobieraniu danych.");
                    czyPoprawny = false;
                }
            }
            try
            {
                Zakupy.RemoveAt(doUsuniecia);
                Console.WriteLine("Usunięto");
            }
            catch(Exception)
            {
                Console.WriteLine("Pojawił się błąd przy próbie usunięcia danego elemntu.\nSprawdz indeks!");
            }
        }

        public void wyczysc()
        {
            Zakupy.Clear();
        }

        public void zapiszParagon()
        {
            string Day = DateTime.Now.Day.ToString();
            string Month = DateTime.Now.Month.ToString();
            string Year = DateTime.Now.Year.ToString();
            string Hour = DateTime.Now.Hour.ToString();
            string Minute = DateTime.Now.Minute.ToString();
            string Second = DateTime.Now.Second.ToString();
            string name = Day+Month+Year+Hour+Minute+Second+".txt";
            string line;

            FileStream fs = new FileStream(name, FileMode.CreateNew);
            using(StreamWriter sw = new StreamWriter(fs))
            {
                foreach(var prod in Zakupy)
                {
                    line = prod.podajProdukt();
                    sw.WriteLine(line);
                }
                sw.WriteLine("W sumie do zapłaty: " + podajSume());
                wyczysc();
            }
        }
    }
}
