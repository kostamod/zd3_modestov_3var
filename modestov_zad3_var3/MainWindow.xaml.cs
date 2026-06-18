using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace modestov_zad3_var3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dannie _menedjer = new Dannie();
        public MainWindow()
        {
            InitializeComponent();
            // Напрямую связываем ListBox с ObservableCollection из класса Dannie
            LstDepartments.ItemsSource = _menedjer.SpisokOtdelov;
        }

        // Логика переключения видимости полей для класса-потомка
        private void ChkIsDetailed_Changed(object sender, RoutedEventArgs e)
        {
            if (PanelDetailed == null) return;
            PanelDetailed.Visibility = ChkIsDetailed.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            TxtStatus.Text = string.Empty; 

            string nazvanie = TxtName.Text.Trim();
            string korpus = TxtLocation.Text.Trim();

        
            if (string.IsNullOrEmpty(nazvanie) || string.IsNullOrEmpty(korpus))
            {
                TxtStatus.Text = "Заполните текстовые поля!";
                return;
            }

            if (!double.TryParse(TxtSalary.Text, out double oklad) || oklad < 0 ||
                !double.TryParse(TxtCoefficient.Text, out double koef) ||
                !int.TryParse(TxtCount.Text, out int kolvo) || kolvo < 0)
            {
                TxtStatus.Text = "Некорректные числовые параметры!";
                return;
            }

            if (ChkIsDetailed.IsChecked == true)
            {
                string rukovoditel = TxtHead.Text.Trim();
                if (string.IsNullOrEmpty(rukovoditel))
                {
                    TxtStatus.Text = "Укажите руководителя!";
                    return;
                }

                if (!double.TryParse(TxtHazard.Text, out double vrednostP) || vrednostP < 0 || vrednostP > 3)
                {
                    TxtStatus.Text = "Вредность P должна быть от 0 до 3!";
                    return;
                }

             
                _menedjer.Dobavit(new PotomokOtdela(nazvanie, oklad, koef, korpus, kolvo, vrednostP, rukovoditel));
            }
            else
            {
                _menedjer.Dobavit(nazvanie, oklad, koef, korpus, kolvo);
            }

            OchistitVvod(); 
        }

    
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LstDepartments.SelectedItem is Otdel vibranniy)
            {
                _menedjer.Udalit(vibranniy);
            }
            else
            {
                TxtStatus.Text = "Выберите отдел из списка для удаления!";
            }
        }

        private void BtnFilter_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TxtMinSalary.Text, out double minOklad))
            {
              
                var otfiltrovano = _menedjer.LinqFiltrOklada(minOklad);

                string otchet = $"Результаты фильтрации LINQ (Оклад >= {minOklad}):\n\n";
                foreach (var item in otfiltrovano)
                {
                    otchet += $"{item.VivodInfo()}\n";
                }

                MessageBox.Show(otfiltrovano.Count > 0 ? otchet : "Ничего не найдено", "Фильтр LINQ");
            }
            else
            {
                MessageBox.Show("Введите корректное число для фильтра!", "Ошибка");
            }
        }


        private void OchistitVvod()
        {
            TxtName.Clear();
            TxtSalary.Clear();
            TxtCoefficient.Clear();
            TxtLocation.Clear();
            TxtCount.Clear();
            TxtHazard.Clear();
            TxtHead.Clear();
            ChkIsDetailed.IsChecked = false;
        }
    }
}