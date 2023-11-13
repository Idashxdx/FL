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
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        List<Clients> client = new List<Clients>();
        public ClientsPage()
        {
            InitializeComponent();
            client = ClassConnect.Ent.Clients.ToList();
            LBox.ItemsSource = client;
            Load2();
        }
        private void Load2()
        {
            client = ClassConnect.Ent.Clients.ToList();
            if (Tbx1.Text != string.Empty)
            {
                if (Tbx1.Text != "Введите для поиска")
                {

                    client = client.Where(x => x.FullName.ToLower().Contains(Tbx1.Text.ToLower())).ToList();
                    LBox.ItemsSource = client;
                    if (client.Count == 0)
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
                LBox.ItemsSource = client;
                TblNo.Visibility = Visibility.Hidden;
            }


        }

        private void Tbx1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Load2();
        }

        private void Tbx1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Tbx1.Text == "Введите для поиска")
            {
                Tbx1.Text = string.Empty;
            }
        }

        private void Tbx1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Tbx1.Text == string.Empty)
            {
                Tbx1.Text = "Введите для поиска";
            }
        }

        private void LBox_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            ClassFrame.Frm.Navigate(new PageChangrClient(LBox.SelectedItem as Clients));
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.Frm.Navigate(new PageChangrClient());
        }
    }
}

