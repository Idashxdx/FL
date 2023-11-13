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
    /// Логика взаимодействия для Capcha.xaml
    /// </summary>
    public partial class Capcha : Window
    {
        public Capcha()
        {
            InitializeComponent();
            LBtext.Content = GetCapcha();
        }
        string GetCapcha()
        {
            Random random = new Random();
            string str = string.Empty;
            string getstring = string.Empty;
            str = "1234567890";
            for (int i = 65; i < 91; i++)
            {
                str += (char)i;
            }
            for (int i = 0; i < 4; i++)
            {
                getstring += str[random.Next(36)];
            }
            return getstring;
        }
        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            LBtext.Content = GetCapcha();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TBText.Text.Equals(LBtext.Content))
            {
                MessageBox.Show("Успешно!");
                Home home = new Home();
                home.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Повторите попытку");
                TBText.Text = "";
                LBtext.Content = GetCapcha();
            }
        }
    }
}
