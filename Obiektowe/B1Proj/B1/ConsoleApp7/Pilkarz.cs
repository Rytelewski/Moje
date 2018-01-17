using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    abstract class Pilkarz
    {
        protected string imie;
        protected string nazwisko;
        protected int numerNaKoszulce;

        public override string ToString()
        {
            return String.Format("Imie: {0}, nazwisko: {1}, Numer na koszulce: {2}", imie, nazwisko, numerNaKoszulce);
        }
    }
}
