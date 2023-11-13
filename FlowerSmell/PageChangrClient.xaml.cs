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
    /// Логика взаимодействия для PageChangrClient.xaml
    /// </summary>
    public partial class PageChangrClient : Page
    {
        private bool isEdit;
        private Clients editclient;


        public PageChangrClient()
        {
            InitializeComponent();
            isEdit = false;
        }
        public PageChangrClient(Clients client)
        {
            isEdit = true;
            InitializeComponent();
            editclient = client;

            TbxName.Text = client.FullName;
            TbxPhone.Text = client.Phone.ToString();
            TbxEmail.Text = client.Email.ToString();
            TbxAddress.Text = client.Address.ToString();

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {

            ClassFrame.Frm.Navigate(new ClientsPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(TbxName.Text))
                mes += "Введите ФИО!\n";
            if (string.IsNullOrWhiteSpace(TbxPhone.Text))
                mes += "Введите Телефон!\n";

            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }
           else if (!isEdit)
            {
                Clients addm = new Clients();
                addm.FullName = TbxName.Text;
                addm.Phone = TbxPhone.Text;
                addm.Email = TbxEmail.Text;
                addm.Address = TbxAddress.Text;
                ClassConnect.Ent.Clients.Add(addm);
                ClassConnect.Ent.SaveChanges();
                MessageBox.Show("Данные добавлены!");
                ClassFrame.Frm.Navigate(new ClientsPage());
            }

           else if (isEdit)
            {
                editclient.FullName = TbxName.Text;
                editclient.Phone = TbxPhone.Text;
                editclient.Email = TbxEmail.Text;
                editclient.Address = TbxAddress.Text;
                ClassConnect.Ent.SaveChanges();
                MessageBox.Show("Данные изменены!");
                ClassFrame.Frm.Navigate(new ClientsPage());

            }

        }
    }
}
