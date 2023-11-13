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
    /// Логика взаимодействия для PageAddSotr.xaml
    /// </summary>
    public partial class PageAddSotr : Page
    {
        Employee employee = new Employee();
        public PageAddSotr()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            employee.FullName = TbxF.Text;
            employee.Login = TbxL.Text;
            employee.Pass = TbxP.Text;
            employee.IDRole = 2;
            ClassConnect.Ent.Employee.Add(employee);
            ClassConnect.Ent.SaveChanges();
            MessageBox.Show("Сотрудник добавлен!");
            TbxF.Text = "";
            TbxL.Text = "";
            TbxP.Text = "";
        }
    }
}
