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
    /// Логика взаимодействия для PageChangeOrders.xaml
    /// </summary>
    public partial class PageChangeOrders : Page
    {
        List<Clients> client = new List<Clients>(); //для комбобоксов при изменении
        List<Range> range = new List<Range>();
        List<Delivery> del = new List<Delivery>();
        List<Type> type = new List<Type>();
        private bool isEdit;
        private Sales editrange;
        Sales sales = new Sales();
        public PageChangeOrders()
        {
            InitializeComponent();
            ClassConnect.Ent = new Entities();
            isEdit = false;
            type = ClassConnect.Ent.Type.ToList();
            CmbType.ItemsSource = type;
            CmbType.SelectedIndex = 0;
            client = ClassConnect.Ent.Clients.ToList();
            CmbCl.ItemsSource = client;
            CmbCl.SelectedIndex = 0;
            range = ClassConnect.Ent.Range.ToList();
            CmbAss.ItemsSource = range;
            CmbAss.SelectedIndex = 0;
            del = ClassConnect.Ent.Delivery.ToList();
            CmbD.ItemsSource = del;
            CmbD.SelectedIndex = 0;
        }

        public PageChangeOrders(Sales sales)
        {
            isEdit = true;
            InitializeComponent();
            editrange = sales;
            CmbType.ItemsSource = ClassConnect.Ent.Type.ToList();
            CmbType.DisplayMemberPath = "Title";
            CmbCl.ItemsSource = ClassConnect.Ent.Clients.ToList();
            CmbCl.DisplayMemberPath = "FullName";
            CmbAss.ItemsSource = ClassConnect.Ent.Range.ToList();
            CmbAss.DisplayMemberPath = "Title";
            CmbD.ItemsSource = ClassConnect.Ent.Delivery.ToList();
            CmbD.DisplayMemberPath = "Title";
            TbxAm.Text = sales.Amount.ToString();
            TbxDate.Text = sales.DateOfSale.ToString();
            CmbType.SelectedIndex = (int)(sales.ID_Type - 1);
            CmbCl.SelectedIndex = (int)(sales.ID_Client - 1);
            CmbAss.SelectedIndex = (int)(sales.ID_Range - 1);
            CmbD.SelectedIndex = (int)(sales.ID_Delivery - 1);
            if (isEdit == true)
            {
                Delete.Visibility = Visibility.Visible;

            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(CmbType.Text))
                mes += "Выберите тип!\n";
            if (string.IsNullOrWhiteSpace(CmbAss.Text))
                mes += "Выберите Товар!\n";
            if (string.IsNullOrWhiteSpace(CmbD.Text))
                mes += "Выберите Тип доставки!\n";
            if (string.IsNullOrWhiteSpace(TbxAm.Text))
                mes += "Введите количество!\n";
            if (string.IsNullOrWhiteSpace(TbxDate.Text))
                mes += "Введите Дату!\n";
            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }
            else if (!isEdit)
            {
                Sales addm = new Sales();
                addm.ID_Type = CmbType.SelectedIndex + 1;

                addm.ID_Client = CmbCl.SelectedIndex + 1;
                addm.ID_Range = CmbAss.SelectedIndex + 1;
                addm.ID_Delivery = CmbD.SelectedIndex + 1;
                addm.Amount = Convert.ToInt32(TbxAm.Text);
                addm.DateOfSale = Convert.ToDateTime(TbxDate.Text);
                ClassConnect.Ent.Sales.Add(addm);
                ClassConnect.Ent.SaveChanges();
                MessageBox.Show("Данные добавлены!");
                ClassFrame.Frm.Navigate(new Orders());
            }

             else if (isEdit)
            {

                editrange.ID_Type = CmbType.SelectedIndex + 1;
                editrange.ID_Client = CmbCl.SelectedIndex + 1;
                editrange.ID_Range = CmbAss.SelectedIndex + 1;
                editrange.ID_Delivery = CmbD.SelectedIndex + 1;
                editrange.Amount = Convert.ToInt32(TbxAm.Text);
                editrange.DateOfSale = Convert.ToDateTime(TbxDate.Text);
                ClassConnect.Ent.SaveChanges();
                MessageBox.Show("Данные изменены!");
                ClassFrame.Frm.Navigate(new Orders());
            }
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.Frm.Navigate(new Orders());
        }

        private void Delete_Click(object sender, RoutedEventArgs e)//удаление
        {
            if (MessageBox.Show("Вы точно хотите удалить данный заказ?", "Внимание!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                ClassConnect.Ent.Sales.Remove(editrange);
                ClassConnect.Ent.SaveChanges();
                MessageBox.Show("Данные Удалены!");
                ClassFrame.Frm.Navigate(new Orders());
            }

        }
    }
}