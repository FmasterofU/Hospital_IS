using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppForDoctor
{
    /// <summary>
    /// Interaction logic for ChangeDrugAmount.xaml
    /// </summary>
    public partial class ChangeDrugAmount : Window
    {
        private Dictionary<string, int> drugDict = new Dictionary<string, int>();
        private int amount = 1;
        public ChangeDrugAmount()
        {
            InitializeComponent();
            amountText.Text = "1";
            drugDict = DrugsPage.getInstance().getDrugDict();
            foreach (string s in drugDict.Keys) changeAmountComboBox.Items.Add(s);
            changeAmountComboBox.SelectedIndex = 0;
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) ToEnglish();
        }

        private void ToSerbian()
        {
            changeAmountButton.Content = "Promeni";
            backFromChangeAmountButton.Content = "Nazad";
        }

        private void ToEnglish()
        {
            changeAmountButton.Content = "Change";
            backFromChangeAmountButton.Content = "Back";
        }

        private void ChangeDrugAmountWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow w = MainWindow.getInstance();
            this.Left = w.Left + (w.Width - this.ActualWidth) / 2;
            this.Top = w.Top + (w.Height - this.ActualHeight) / 2;
        }

        private void backFromChangeAmountButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void changeAmountButton_Click(object sender, RoutedEventArgs e)
        {
            string choice = changeAmountComboBox.SelectedItem.ToString();
            DrugsPage.getInstance().ChangeDrugAmount(choice, amount);
            drugDict[choice] = amount;
            changeAmountButton.IsEnabled = false;
        }

        private void changeAmountComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!changeAmountComboBox.Items.IsEmpty)
            {
                string choice = changeAmountComboBox.SelectedItem.ToString();
                amountText.Text = drugDict[choice].ToString();
            }
            else amountText.Text = "0";
        }

        private void searchInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Enter) searchButton.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            string input = searchInput.Text.ToLower();
            changeAmountComboBox.Items.Clear();
            foreach (string s in drugDict.Keys)
            {
                if (s.ToLower().Contains(input)) changeAmountComboBox.Items.Add(s);
            }
            if (changeAmountComboBox.Items.Count != 0)
            {
                changeAmountComboBox.SelectedIndex = 0;
                changeAmountButton.IsEnabled = true;
            }
            else changeAmountButton.IsEnabled = false;
        }

        private void amountText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Int32.TryParse(amountText.Text, out amount))
            {
                if (amount <= 0)
                {
                    changeAmountButton.IsEnabled = false;
                    plusButton.IsEnabled = false;
                    minusButton.IsEnabled = false;
                }
                else if (amount == 1)
                {
                    changeAmountButton.IsEnabled = true;
                    plusButton.IsEnabled = true;
                    minusButton.IsEnabled = false;
                }
                else
                {
                    changeAmountButton.IsEnabled = true;
                    plusButton.IsEnabled = true;
                    minusButton.IsEnabled = true;
                }
            }
            else
            {
                changeAmountButton.IsEnabled = false;
                plusButton.IsEnabled = false;
                minusButton.IsEnabled = false;
            }
        }

        private void plusButton_Click(object sender, RoutedEventArgs e)
        {
            amountText.Text = (++amount).ToString();
            minusButton.IsEnabled = true;
        }

        private void minusButton_Click(object sender, RoutedEventArgs e)
        {
            amountText.Text = (--amount).ToString();
            if (amount == 1) minusButton.IsEnabled = false;
        }
    }
}
