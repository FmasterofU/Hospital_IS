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
    /// Interaction logic for AddDrug.xaml
    /// </summary>
    public partial class AddDrug : Window
    {
        private HashSet<string> drugSet = new HashSet<string>();
        private int amount = 1;
        public AddDrug()
        {
            InitializeComponent();
            //TODO: load all medicaments in hospital
            drugSet.Add("Novi");
            drugSet.Add("Nnovi");
            drugSet.Add("Noovi");
            drugSet.Add("Novvi");
            drugSet.Add("Novii");
            drugSet.Add("Novio");
            drugSet.ExceptWith(DrugsPage.getInstance().getDrugSet());
            //foreach (string s in drugSet) addDrugsComboBox.Items.Add(s);
            //addDrugsComboBox.SelectedIndex = 0;
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) ToEnglish();
        }

        private void ToSerbian()
        {
            addDrugButton.Content = "Dodaj";
            backFromAddButton.Content = "Nazad";
            usageGroupBox.Header = "Upotreba:";
        }

        private void ToEnglish()
        {
            addDrugButton.Content = "Add";
            backFromAddButton.Content = "Back";
            usageGroupBox.Header = "Usage:";
        }

        private void backFromAddButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddDrugWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow.CenterDialog(this);
        }

        private void addDrugButton_Click(object sender, RoutedEventArgs e)
        {
            string item = addDrugsComboBox.SelectedItem.ToString();
            DrugsPage d = DrugsPage.getInstance();
            d.AddDrugToDict(item, amount);
            drugSet.Remove(item);
            addDrugsComboBox.Items.Remove(item);
            addDrugsComboBox.SelectedIndex = 0;
            amountText.Text = "1";
            minusButton.IsEnabled = false;
            usageTextBox.Text = "";
            if (drugSet.Count == 0)
            {
                DrugsPage.getInstance().disableAddButton();
                this.Close();
            }
            else if (addDrugsComboBox.Items.Count == 0) searchButton.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            string input = searchInput.Text.ToLower();
            addDrugsComboBox.Items.Clear();
            foreach (string s in drugSet)
            {
                if (s.ToLower().Contains(input)) addDrugsComboBox.Items.Add(s);
            }
            if (addDrugsComboBox.Items.Count != 0)
            {
                addDrugsComboBox.SelectedIndex = 0;
                if (!usageTextBox.Text.Trim().Equals("")) addDrugButton.IsEnabled = true;
                plusButton.IsEnabled = true;
                amountText.Text = "1";
                amountText.IsEnabled = true;
                usageTextBox.IsEnabled = true;
            }
            else
            {
                addDrugButton.IsEnabled = false;
                amountText.IsEnabled = false;
                plusButton.IsEnabled = false;
                minusButton.IsEnabled = false;
                usageTextBox.IsEnabled = false;
            }
        }

        private void searchInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Enter) searchButton.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        private void amountText_TextChanged(object sender, TextChangedEventArgs e)
        {
            addDrugButton.IsEnabled = false;
            plusButton.IsEnabled = false;
            minusButton.IsEnabled = false;
            usageTextBox.IsEnabled = false;

            if (Int32.TryParse(amountText.Text, out amount))
            {
                if (amount >= 1)
                {
                    if (!usageTextBox.Text.Trim().Equals("")) addDrugButton.IsEnabled = true;
                    plusButton.IsEnabled = true;
                    usageTextBox.IsEnabled = true;
                    if (amount > 1) minusButton.IsEnabled = true;
                }
            }
            /*if (Int32.TryParse(amountText.Text, out amount))
            {
                if(amount <= 0)
                {
                    addDrugButton.IsEnabled = false;
                    plusButton.IsEnabled = false;
                    minusButton.IsEnabled = false;
                }
                else if(amount == 1)
                {
                    addDrugButton.IsEnabled = true;
                    plusButton.IsEnabled = true;
                    minusButton.IsEnabled = false;
                }
                else
                {
                    addDrugButton.IsEnabled = true;
                    plusButton.IsEnabled = true;
                    minusButton.IsEnabled = true;
                }
            }
            else
            {
                addDrugButton.IsEnabled = false;
                plusButton.IsEnabled = false;
                minusButton.IsEnabled = false;
            }*/
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

        private void usageTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (usageTextBox.Text.Trim().Equals("") || addDrugsComboBox.SelectedIndex < 0) addDrugButton.IsEnabled = false;
            else addDrugButton.IsEnabled = true;
        }
    }
}
