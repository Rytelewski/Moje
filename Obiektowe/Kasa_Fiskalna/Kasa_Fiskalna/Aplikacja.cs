using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Char;

namespace Kasa_Fiskalna
{
    class Aplikacja
    {
        private static char klawisz;
        private static Koszyk Zakupy = new Koszyk();

        private static void WczytajKlawisz()
        {
            Console.WriteLine("Dzień dobry!");
            Console.WriteLine("Co chcesz zrobić? Nacisnij odpowiedni klawisz.");
            Console.WriteLine("Legenda:");
            Console.WriteLine("P - dodaj produkt do koszyka");
            Console.WriteLine("K - skopiuj ostatnio wprowadzony produkt");
            Console.WriteLine("Z - pokaż zawartość koszyka");
            Console.WriteLine("S - pokaż sumę do zapłaty");
            Console.WriteLine("X - skasuj produkt z listy (musisz znać wcześniej numer na liście)");
            Console.WriteLine("W - wydrukuj paragon");
            Console.WriteLine("N - dodaj nowy koszyk");
            Console.WriteLine("E - zakończ działanie programu");

            char[] wybor = {'P','p','K','k','Z','z','S','s','X','x','W','w','N','n','E','e'};
            bool czyPoprawny = false;

            while(!czyPoprawny)
            {
                czyPoprawny = true;

                try
                {
                    Console.Write(": :: : ");
                    klawisz = Convert.ToChar(Console.ReadLine());
                }
                catch(Exception)
                {
                    Console.WriteLine("Wystąpił błąd przy pobieraniu klawisza.");
                    czyPoprawny = false;
                }

                if (!wybor.Contains(klawisz))
                    czyPoprawny = false;
            }
            Console.Clear();
        }

        public static void WykonajDzialanie()
        {
            while (true)
            {
                WczytajKlawisz();

                if (klawisz == 'P' || klawisz == 'p')
                {
                    Zakupy.Add();
                    Continue();
                }

                if (klawisz == 'K' || klawisz == 'k')
                {
                    Zakupy.Clone();
                    Continue();
                }

                if (klawisz == 'Z' || klawisz == 'z')
                {
                    Zakupy.wypiszKoszyk();
                    Continue();
                }

                if (klawisz == 'S' || klawisz == 's')
                {
                    Console.WriteLine("W sumie do zapłaty: " +Zakupy.podajSume());
                    Continue();
                }

                if (klawisz == 'X' || klawisz == 'x')
                {
                    Console.WriteLine("Podaj numer pozycji do skasowania.");
                    Zakupy.skasujProdukt();
                    Continue();
                }

                if (klawisz == 'W' || klawisz == 'w')
                {
                    Zakupy.zapiszParagon();
                    Console.WriteLine("Paragon został zapisany.");
                    Continue();
                }

                if (klawisz == 'N' || klawisz == 'n')
                {
                    Zakupy.wyczysc();
                    Console.WriteLine("Koszyk został wyczyszczony.");
                }

                if (klawisz == 'E' || klawisz == 'e')
                    return;
            }

        }

        private static void Continue()
        {
            Console.WriteLine("Wciśnij dowolny klawisz aby kontynuować...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
