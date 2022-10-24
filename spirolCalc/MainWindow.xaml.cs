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

        private void dodajPresetyButton_Click(object sender, RoutedEventArgs e)
        {
            if (naczyniaPresety.SelectedIndex != -1 && spirolePresety.SelectedIndex != -1)
            {
                Alcohol choosenAlcohol = (Alcohol)spirolePresety.SelectedItem;
                Utensil choosenUtensil = (Utensil)naczyniaPresety.SelectedItem;
                WielkoscNaczyniaTextBox.Text = choosenUtensil.Size.ToString();
                ZawartoscSpirytusuTextBox.Text = choosenAlcohol.ABV.ToString();

            }
        }

        private void ZawartoscSpirytusuTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void obliczButton_Click(object sender, RoutedEventArgs e)
        {
            double size;
            double abv;
            double amount;
            if (Double.TryParse(WielkoscNaczyniaTextBox.Text, out size) && Double.TryParse(ZawartoscSpirytusuTextBox.Text, out abv) && Double.TryParse(IloscNaczynTextBox.Text, out amount))
            {

                objetoscSpirolaTextBox.Text = Math.Round(CalcClass.Calculate(size, abv, amount) * 100) / 100 + "ml";
                objetoscNapojuTextBox.Text = Math.Round(amount * size * 100) / 100 + "ml";

            }
            else {
                MessageBox.Show("Podano nieprawidłowe dane!");
            }
        }
    }
}
