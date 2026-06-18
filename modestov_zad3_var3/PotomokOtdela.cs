using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace modestov_zad3_var3
{
   public class PotomokOtdela : Otdel
    {
        public double VrednostP { get; set; }
        public string FioRukovoditelya { get; set; }
     //конструктор потомка
        public PotomokOtdela (string nazvanie, double bazoviOklad, double koefficient, string korpus, int kolvosotrudnikov, double vrednostP, string fioRukovoditelya)
            : base (nazvanie, bazoviOklad,koefficient,korpus, kolvosotrudnikov)
        {
            VrednostP = vrednostP;
            FioRukovoditelya = fioRukovoditelya;
        }

        //перекрытие метода из родителя 
        public override double KachestvoQ()
        {
            double q = base.KachestvoQ();
            if ( VrednostP == 0)
            {
                return q;
            }
            else
            {
                return q + q / VrednostP;
            }

        }

        public override string VivodInfo()
        {
            return $"[Рук : { FioRukovoditelya} {Nazvnie} | оклад {BazoviyOklad}, вредность  P: {VrednostP}, Q : {KachestvoQ():F2} ";
        }

    }
}
