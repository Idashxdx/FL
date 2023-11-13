using FlowerSmell.Class;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для PageChangeAssort.xaml
    /// </summary>
    public partial class PageChangeAssort : Page
    {
        List<Brend> brend = new List<Brend>();
        List<Volume> volume = new List<Volume>();
        List<TypeParfume> type = new List<TypeParfume>();

        private bool isEdit;
        private Range editrange;
        Range range = new Range();
        byte[] rangeArray;

        Brend brendAdd = new Brend();
        public PageChangeAssort()
        {
            InitializeComponent();
            ClassConnect.Ent = new Entities();
            type = ClassConnect.Ent.TypeParfume.ToList();
            CmbType.ItemsSource = type;
            CmbType.SelectedIndex = 0;
            volume = ClassConnect.Ent.Volume.ToList();
            CmbVol.ItemsSource = volume;
            CmbVol.SelectedIndex = 0;
            brend = ClassConnect.Ent.Brend.ToList();
            CmbBr.ItemsSource = brend;
            CmbBr.SelectedIndex = 0;
        }
        public PageChangeAssort(Range range)
        {
            isEdit = true;
            InitializeComponent();
            editrange = range;
            CmbType.ItemsSource = ClassConnect.Ent.TypeParfume.ToList();
            CmbType.DisplayMemberPath = "Gender";
            CmbBr.ItemsSource = ClassConnect.Ent.Brend.ToList();
            CmbBr.DisplayMemberPath = "Title";
            CmbVol.ItemsSource = ClassConnect.Ent.Volume.ToList();
            CmbVol.DisplayMemberPath = "Volume1";
            TbxName.Text = range.Title;
            CmbType.SelectedIndex = (int)(range.ID_TypePerfume - 1);
            CmbBr.SelectedIndex = (int)(range.ID_Brend - 1);
            CmbVol.SelectedIndex = (int)(range.ID_Volume - 1);
            TbxCoun.Text = range.Country.ToString();
            TbxPr.Text = range.Price.ToString();
            TbxAm.Text = range.Amount.ToString();
            TbxOpis.Text = range.Description;
            MemoryStream stream = new MemoryStream(range.Image);
            Img.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
           
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(TbxName.Text))
                mes += "Введите Название!\n";
            if (string.IsNullOrWhiteSpace(CmbType.Text))
                mes += "Выберите тип!\n";
            if (string.IsNullOrWhiteSpace(CmbBr.Text))
                mes += "Выберите Бренд!\n";
            if (string.IsNullOrWhiteSpace(CmbVol.Text))
                mes += "Выберите объем!\n";
            if (string.IsNullOrWhiteSpace(TbxCoun.Text))
                mes += "Введите Страну!\n";
            if (string.IsNullOrWhiteSpace(TbxPr.Text))
                mes += "Введите Стоимость!\n";
            if (string.IsNullOrWhiteSpace(TbxAm.Text))
                mes += "Введите количество\n";

            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }

            else if (!isEdit)
            {
                Range addm = new Range();
                addm.Title = TbxName.Text;
                addm.ID_TypePerfume = CmbType.SelectedIndex + 1;
                addm.ID_Brend = CmbBr.SelectedIndex + 1;
                addm.ID_Volume = CmbVol.SelectedIndex + 1;
                addm.Country = TbxCoun.Text;
                addm.Amount = Convert.ToInt32(TbxAm.Text);
                addm.Price = Convert.ToDecimal(TbxPr.Text);
                addm.Description = TbxOpis.Text;
                addm.Image = rangeArray;
                ClassConnect.Ent.Range.Add(addm);
                ClassConnect.Ent.SaveChanges();
                MessageBox.Show("Данные добавлены!");
                ClassFrame.Frm.Navigate(new Assort());
            }
            else if (isEdit)
            {
                editrange.Title = TbxName.Text;
                editrange.ID_TypePerfume = CmbType.SelectedIndex + 1;
                editrange.ID_Brend = CmbBr.SelectedIndex + 1;
                editrange.ID_Volume = CmbVol.SelectedIndex + 1;
                editrange.Country = TbxCoun.Text;
                editrange.Amount = Convert.ToInt32(TbxAm.Text);
                editrange.Price = Convert.ToDecimal(TbxPr.Text);
                editrange.Description = TbxOpis.Text;
                ClassConnect.Ent.SaveChanges();
                MessageBox.Show("Данные изменены!");
                ClassFrame.Frm.Navigate(new Assort());
          
            }
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.Frm.Navigate(new Assort());
        }

        private void AddImg_Click(object sender, RoutedEventArgs e)
        {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.ShowDialog();

                foreach (var image in fileDialog.FileNames)
                {
                     rangeArray = File.ReadAllBytes(image);
                     range.Image = rangeArray;
                     MemoryStream stream = new MemoryStream(range.Image);
                     Img.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                }
                if (isEdit)
                {
                    editrange.Image = rangeArray;
                    ClassConnect.Ent.SaveChanges();
                }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddBrend br = new AddBrend();
            br.Show();
            brend = ClassConnect.Ent.Brend.ToList();
            CmbBr.ItemsSource = brend;
            CmbBr.SelectedIndex = 0;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            brend = ClassConnect.Ent.Brend.ToList();
            CmbBr.ItemsSource = brend;
            CmbBr.SelectedIndex = 0;
        }

    
    }
}
