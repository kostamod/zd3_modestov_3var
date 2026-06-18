using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace modestov_zad3_var3
{
    public class Otdel
    {
        public  string Nazvnie { get; set; }
        public double BazoviyOklad { get; set; }
        public double Koefficient { get; set; } 
        public string Korpus { get; set; }
        public int KolvoSotrudnikov { get; set; }


        //консруктор 
        public Otdel (string nazvanie, double bazoviOklad,double koefficient, string korpus, int kolvosotrudnikov)
        {
            Nazvnie = nazvanie;
            BazoviyOklad = bazoviOklad;
            Koefficient = koefficient;
            Korpus = korpus;
            KolvoSotrudnikov = kolvosotrudnikov;
        }
        public virtual Double KachestvoQ()
        {
            return BazoviyOklad * (100 + Koefficient);
        }
        public virtual string VivodInfo()
        {
            return $"{Nazvnie} ({Korpus}) | оклад {BazoviyOklad}, коэф {Koefficient},Q : {KachestvoQ() :F2} ";
        }
        public string Informaciya => VivodInfo();

    }
}
