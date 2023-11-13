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
    /// Логика взаимодействия для AddBrend.xaml
    /// </summary>
    public partial class AddBrend : Window
    {
        Brend brend = new Brend();
        public AddBrend()
        {
            InitializeComponent();
          
        }

        private void AddBr_Click(object sender, RoutedEventArgs e)
        {
            brend.Title = TB1.Text;
            ClassConnect.Ent.Brend.Add(brend);
            ClassConnect.Ent.SaveChanges();
            MessageBox.Show("Бренд добавлен!");
            Close();
        }
    }
}
