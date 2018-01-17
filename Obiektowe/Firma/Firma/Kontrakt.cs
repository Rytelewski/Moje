using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma
{
    enum typKontraktu { staż, etat }

    class Kontrakt
    {
        private double podstawaWynagrodzenia;
        private typKontraktu typ;

        public double getPodstawa()
        {
            return podstawaWynagrodzenia;
        }
        public typKontraktu getTypKontraktu()
        {
            return typ;
        }

        public Kontrakt()
        {
            this.typ = typKontraktu.staż;
            this.podstawaWynagrodzenia = 2000;
        }


        public Kontrakt(typKontraktu typ, double podstawa)
        {
            this.typ = typ;
            this.podstawaWynagrodzenia = podstawa;
        }
        public double Pensja()
        {        
                return podstawaWynagrodzenia;
            
        }
        public double Pensja(double nadgodziny)
        {
            return podstawaWynagrodzenia + nadgodziny * (podstawaWynagrodzenia / 160);
        }

        //metoda pomocnicza do zmiany kontraktu dla pracowników
        public void ZmienTyp(typKontraktu nowy)
        {
            this.typ = nowy;
        }

        //metoda pomocnicza na zmianę pensji
        public void ZmienPodst(double nowa)
        {
            this.podstawaWynagrodzenia = nowa;
        }
    }
    
   
}
