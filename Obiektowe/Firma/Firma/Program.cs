using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma
{
    class Program
    {
        static void Main(string[] args)
        {
            //lista  pracowników (można rozszerzyć na 20, etc)
            List<Pracownik> pracownicy = new List<Pracownik>();
            pracownicy.Add(new Pracownik("Jan", "Kowalski", typKontraktu.etat, 2100));
            pracownicy.Add(new Pracownik("Nina", "Kowalska", typKontraktu.staż, 2150));
            pracownicy.Add(new Pracownik("Jan", "Nowak", typKontraktu.etat, 3200));
            pracownicy.Add(new Pracownik("Tomasz", "Słoneczny"));
            pracownicy.Add(new Pracownik("Zofia", "Słoneczna"));

            Console.WriteLine("Lista po utworzeniu");
            foreach(var element in pracownicy)
            {
                Console.WriteLine(element.ToString());
            }

            pracownicy.Sort();

            Console.WriteLine("Lista po sortowaniu po nazwisku");
            foreach (var element in pracownicy)
            {
                Console.WriteLine(element.ToString());
            }

            //kopiujemy pracownika o indeksie nr 2 (trzeci na liście po numeracja od zera)
            pracownicy.Add(pracownicy[2].GlebokaKopia());

            Console.WriteLine("Lista po skopiowaniu");
            foreach (var element in pracownicy)
            {
                Console.WriteLine(element.ToString());
            }

            //zmiana danych
            pracownicy.Last().ZmienDane("Kuba", "Matematyczny");
            pracownicy.Last().ZmienPodstawe(4000);

            Console.WriteLine("Lista po zmianie danych");
            foreach (var element in pracownicy)
            {
                Console.WriteLine(element.ToString());
            }

            //druga kopia do polecenia 7
            pracownicy.Add(pracownicy[4].GlebokaKopia());
            

            //tworzymy nową listę aby przechowywać elementy łącznie z pensją zakładając, że liczba nadgodzin to 15 (to nie jest jedyne rozwiązanie)
            List<Tuple<Pracownik, double>> pracownicy2 = new List<Tuple<Pracownik, double>>();

            foreach(var element in pracownicy)
            {
                pracownicy2.Add(Tuple.Create(element, element.PokazPensje()));
            }
            //sortowanie z określeniem sortowanie po pensji
            pracownicy2.Sort((x, y) => y.Item2.CompareTo(x.Item2));

            Console.WriteLine("Lista po sortwaniu po pensji przy 15 nadgodzinach");
            foreach (var element in pracownicy2)
            {
                Console.WriteLine(element.Item1.ToString()+", Pensja: " +element.Item1.PokazPensje(15));
            }
            
            Console.ReadKey();
        }
    }
}
