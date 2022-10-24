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

namespace spirolCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CalcClass calc;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                calc = new CalcClass();
                naczyniaPresety.ItemsSource = calc.data.Utensils;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd przy ładowaniu JSON: "+e.Message);
            }

        }

        private void naczyniaPresety_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Utensil choosen = (Utensil)naczyniaPresety.SelectedItem;
            spirolePresety.ItemsSource = calc.GetExampleAlcohols(choosen.ToString());
        }
    }
}
