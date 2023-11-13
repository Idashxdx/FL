using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlowerSmell.Class;

namespace FlowerSmell
{
    /// <summary>
    /// Логика взаимодействия для PageAnalitic.xaml
    /// </summary>
    public partial class PageAnalitic : Page
    {
        List<CountAsDate> countAsDates = new List<CountAsDate>();
        public PageAnalitic()
        {
            InitializeComponent();
            countAsDates = ClassConnect.Ent.CountAsDate.ToList();
            ((LineSeries)MainChart.Series[0]).ItemsSource = countAsDates;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if ((bool)printDialog.ShowDialog())
            {
                printDialog.PrintVisual(MainGrid, "desc");
            }
            MessageBox.Show("Документ успешно сохранён/распечатан");
        }
    }
}
