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
    /// Логика взаимодействия для Assort.xaml
    /// </summary>
    public partial class Assort : Page
    {
        List<Range> asort = new List<Range>();//заполнение листа
        List<Brend> brend = new List<Brend>();//фильтрация 
        List<TypeParfume> type = new List<TypeParfume>();


        public Assort()
        {
            InitializeComponent();
            asort = ClassConnect.Ent.Range.ToList();
            brend = ClassConnect.Ent.Brend.ToList();
            brend.Insert(0, new Brend { Title = "Не выбрано" });

            type = ClassConnect.Ent.TypeParfume.ToList();
            type.Insert(0, new TypeParfume { Gender = "Не выбрано" });

            Cmb2.SelectedIndex = 0;
            Cmb2.ItemsSource = brend;

            Cmb1.ItemsSource = type;
            Cmb1.SelectedIndex = 0;

            Load();
            Load2();

        }
      
        private void Load2()//поиск
        {
            asort = ClassConnect.Ent.Range.ToList();
            if (Tbx1.Text != string.Empty)
            {
                if (Tbx1.Text != "Введите для поиска")
                {
                    Load();
                    asort = asort.Where(x => x.Title.ToLower().Contains(Tbx1.Text.ToLower())).ToList();
                    LBox.ItemsSource = asort;
                    if (asort.Count == 0)
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
                Load();

                TblNo.Visibility = Visibility.Hidden;
            }
        }
        private void Load()//фильтрация
        {
            asort = ClassConnect.Ent.Range.ToList();
            if (Cmb2.SelectedIndex != 0)
            {
                asort = asort.Where(i => i.ID_Brend == Cmb2.SelectedIndex).ToList();

            }
            if (Cmb1.SelectedIndex != 0)
            {
                asort = asort.Where(i => i.ID_TypePerfume == Cmb1.SelectedIndex).ToList();

            }
            LBox.ItemsSource = asort;
        }


        private void Tbx1_GotFocus(object sender, RoutedEventArgs e)//свойство у поиска
        {
            if (Tbx1.Text == "Введите для поиска")
            {
                Tbx1.Text = string.Empty;
            }
        }
        private void Tbx1_LostFocus(object sender, RoutedEventArgs e)//свойство у поиска
        {
            if (Tbx1.Text == string.Empty)
            {
                Tbx1.Text = "Введите для поиска";
            }
        }

        private void Cmb2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Load();
        }

        private void Cmb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Load();
        }


        private void Tbx1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Load2();
        }
        private void LBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)//переход для изменения
        {
          
            ClassFrame.Frm.Navigate(new PageChangeAssort(LBox.SelectedItem as Range));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)//кнопка для добавления
        {
            ClassFrame.Frm.Navigate(new PageChangeAssort());

        }

      
    }

}
