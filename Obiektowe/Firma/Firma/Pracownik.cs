using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma
{
    class Pracownik :IComparable<Pracownik>
    {
        private string imie;
        private string nazwisko;
        private Kontrakt kontrakt;
        
        public Pracownik()
        {
            kontrakt = new Kontrakt();

        }
        public Pracownik(string imie, string nazwisko, typKontraktu typ, double podstawa)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            kontrakt = new Kontrakt(typ, podstawa);
        }

        public Pracownik(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            kontrakt = new Kontrakt(typKontraktu.staż, 2000); //tworzy obiekt dla pola kontakt i ustawiamy mu już typ i podstawę zgodnie z poleceniem
        }

        //metoda na zmianę typu kontraktu dla pracownika
        public void ZmienKontrakt(typKontraktu nowyTyp)
        {
            kontrakt.ZmienTyp(nowyTyp);
        }

        //metoda na zmianę podstawy wynagrodzenia dla pracownika
        public void ZmienPodstawe(double nowaPodstawa)
        {
            kontrakt.ZmienPodst(nowaPodstawa);
        }

        public double PokazPensje()
        {
            //załóżmy tu że nadgodzin nie ma
            return kontrakt.Pensja(0);
        }
        public double PokazPensje(double nadgodziny)
        {
            return kontrakt.Pensja(nadgodziny);
        }

        public override string ToString()
        {
            return String.Format("Imie: {0}, nazwisko: {1}, podstawa: {2}", imie, nazwisko,PokazPensje()); 
        }

        public int CompareTo(Pracownik innyPracownik)
        {
            return this.nazwisko.CompareTo(innyPracownik.nazwisko);
        }

        public Pracownik GlebokaKopia()
        {
            Pracownik tymczasowy = new Pracownik();
            tymczasowy.imie = this.imie;
            tymczasowy.nazwisko = this.nazwisko;
            tymczasowy.kontrakt = new Kontrakt();
            tymczasowy.kontrakt.ZmienTyp(this.kontrakt.getTypKontraktu());
            tymczasowy.kontrakt.ZmienPodst(this.kontrakt.getPodstawa());
            return tymczasowy;
        }

        public void ZmienDane(string noweImie, string noweNaz)
        {
            this.imie = noweImie;
            this.nazwisko = noweNaz;
        }
    }
}
