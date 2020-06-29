using Controller;
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
        //private HashSet<string> drugSet = new HashSet<string>();
        private HashSet<Model.Medicine.Drug> druggSet = new HashSet<Model.Medicine.Drug>();
        private int amount = 1;
        public AddDrug()
        {
            InitializeComponent();
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
            Model.Medicine.Drug adding = null;
            foreach (Model.Medicine.Drug dd in druggSet)
            {
                if (dd.Name.Equals(item))
                {
                    adding = dd;
                    break;
                }
            }
            DrugsPage d = DrugsPage.getInstance();
            d.AddDrugToDict(new Model.Examination.Prescription((uint)amount, usageTextBox.Text, adding));
            druggSet.Clear();
            this.Close();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            druggSet.Clear();
            string input = searchInput.Text.ToLower();
            addDrugsComboBox.Items.Clear();

            DrugController c = new DrugController();
            List<Model.Medicine.Drug> drugs = c.SearchDrugs(input);
            if(drugs.Count != 0)
            {
                HashSet<string> set = DrugsPage.getInstance().geDrugNameSet();
               foreach (Model.Medicine.Drug drug in drugs)
                {
                    if (!set.Contains(drug.Name))
                    {
                        druggSet.Add(drug);
                        addDrugsComboBox.Items.Add(drug.Name);
                    }
                }
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
