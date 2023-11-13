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
using System.Windows.Shapes;

namespace FlowerSmell
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
            if(Application.Current.Resources["Role"].ToString() != "1")
            {
                BtnAdd.Visibility = Visibility.Hidden;
            }
            ClassFrame.Frm = Frm;
            NameLb.Content = Application.Current.Resources["FullName"].ToString();
          
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.Frm.Navigate(new ClientsPage());
        }

        private void Assort_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.Frm.Navigate(new Assort());
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.Frm.Navigate(new Orders());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mn = new MainWindow();
            mn.Show();
            Close();
        }

        private void Analitic_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.Frm.Navigate(new PageAnalitic());
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            ClassFrame.Frm.Navigate(new PageAddSotr());
        }
    }
}
