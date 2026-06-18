using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace modestov_zad3_var3
{
  public class Dannie
    {
        //2 Колекции
        public List<Otdel> _vspomogatelniySpisok = new List<Otdel>();

        public ObservableCollection<Otdel> SpisokOtdelov { get; set; } = new ObservableCollection<Otdel>();
        
        public void Dobavit ( Otdel otdel) // +по обекетку
        {
            if (otdel == null) return;
            SpisokOtdelov.Add(otdel);
            _vspomogatelniySpisok.Add(otdel);

         }

        public void Dobavit(string nazvanie, double bazoviOklad, double koefficient, string korpus, int kolvosotrudnikov) //+ по параметрам
        {
            var noviyOtdel = new Otdel (nazvanie, bazoviOklad, koefficient, korpus, kolvosotrudnikov);
           Dobavit(noviyOtdel);
        }
        
        public bool Udalit(Otdel otdel) // - по ссылке
        {
            if (otdel == null) return false;
            _vspomogatelniySpisok.Remove(otdel);
            return SpisokOtdelov.Remove(otdel);
        }
        public bool Udalit(string nazvanie) // - по названию (поиск по названию )
        {
            var nadeyniyOtdel = SpisokOtdelov.FirstOrDefault(o => o.Nazvnie.Equals(nazvanie, StringComparison.OrdinalIgnoreCase)); //ищет первый подходящий или возвращает null (сравнение по байтам(игнор регистра)

            if (nadeyniyOtdel != null)
            {
                _vspomogatelniySpisok.Remove(nadeyniyOtdel);
                return SpisokOtdelov.Remove(nadeyniyOtdel);
            }
            return false;
            
        }
        //фильтр linq  филтруем колекцию оставляем только то где оклад > заданого 
        public List <Otdel> LinqFiltrOklada(double minimalniyOklad)
        {
            return SpisokOtdelov.Where(o => o.BazoviyOklad >= minimalniyOklad).ToList();
        }


    }
}
