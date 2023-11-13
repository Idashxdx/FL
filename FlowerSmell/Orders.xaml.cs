using FlowerSmell.Class;
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

namespace FlowerSmell
{
    /// <summary>
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : Page
    {
        List<Sales> sales = new List<Sales>();
        List<Clients> client = new List<Clients>();
        //сортировка
        private List<string> listsort = new List<string>()
        {
            "Дата продажи",
            "По Возрастанию",
            "По Убыванию"
        };
        public Orders()
        {
            InitializeComponent();
            sales = ClassConnect.Ent.Sales.ToList();
            LBox.ItemsSource = sales;
            CmbSort.ItemsSource = listsort;
            CmbSort.SelectedIndex = 0;
            Load2();
            Load();
        }
        private void Load()
        {
            sales = ClassConnect.Ent.Sales.ToList();
            switch (CmbSort.SelectedIndex)
            {
                case 0:
                    sales = ClassConnect.Ent.Sales.ToList();//все 
                    break;
                case 1:
                    sales = sales.OrderBy(i => i.DateOfSale).ToList();//по возрастанию имени
                    break;
                case 2:
                    sales = sales.OrderByDescending(i => i.DateOfSale).ToList();//по убыванию имени
                    break;
            }
            LBox.ItemsSource = sales;
        }
        private void Load2()
        {
            sales = ClassConnect.Ent.Sales.ToList();
            if (Tbx1.Text != string.Empty)
            {
                if (Tbx1.Text != "Введите ФИО")
                {

                    sales = sales.Where(x => x.Clients.FullName.ToLower().Contains(Tbx1.Text.ToLower())).ToList();
                    LBox.ItemsSource = sales;
                    if (sales.Count == 0)
                    {
                        TblNo.Visibility = Visibility.Visible;
                    }
                    else
                    {

                        TblNo.Visibility = Visibility.Hidden;
                    }
                }

            }
            else
            {
                LBox.ItemsSource = sales;
                TblNo.Visibility = Visibility.Hidden;
            }


        }

        private void Tbx1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Load2();
        }

        private void Tbx1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Tbx1.Text == "Введите ФИО")
            {
                Tbx1.Text = string.Empty;
            }
        }

        private void Tbx1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Tbx1.Text == string.Empty)
            {
                Tbx1.Text = "Введите ФИО";
            }
        }

        private void Cmb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Load();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.Frm.Navigate(new PageChangeOrders());
        }

        private void LBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            ClassFrame.Frm.Navigate(new PageChangeOrders(LBox.SelectedItem as Sales));
        }
    }
}


