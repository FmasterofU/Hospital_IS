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
    /// Interaction logic for DeleteDrug.xaml
    /// </summary>
    public partial class DeleteDrug : Window
    {
        private HashSet<String> drugSet = new HashSet<string>();
        public DeleteDrug()
        {
            InitializeComponent();
            drugSet = DrugsPage.getInstance().getDrugSet();
            foreach (string s in drugSet) deleteDrugsComboBox.Items.Add(s);
            deleteDrugsComboBox.SelectedIndex = 0;
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) ToEnglish();
            if (MainWindow.GetTheme() == MainWindow.Theme.Light) ToLightTheme();
            else if (MainWindow.GetTheme() == MainWindow.Theme.Dark) ToDarkTheme();
        }

        private void ToSerbian()
        {
            deleteDrugButton.Content = "Obriši";
            backFromDeleteButton.Content = "Nazad";
        }

        private void ToEnglish()
        {
            deleteDrugButton.Content = "Delete";
            backFromDeleteButton.Content = "Back";
        }

        private void ToLightTheme()
        {
        }

        private void ToDarkTheme()
        {
        }

        private void backFromDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DeleteDrugWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow.CenterDialog(this);
        }

        private void deleteDrugButton_Click(object sender, RoutedEventArgs e)
        {
            string item = deleteDrugsComboBox.SelectedItem.ToString();
            deleteDrugsComboBox.Items.Remove(item);
            DrugsPage d = DrugsPage.getInstance();
            d.DeleteDrugFromDict(item);
            drugSet.Remove(item);
            deleteDrugsComboBox.SelectedIndex = 0;
            if (drugSet.Count == 0) this.Close();
            else if (deleteDrugsComboBox.Items.Count == 0) deleteDrugButton.IsEnabled = false;
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            string input = searchInput.Text.ToLower();
            deleteDrugsComboBox.Items.Clear();
            foreach (string s in drugSet)
            {
                if (s.ToLower().Contains(input)) deleteDrugsComboBox.Items.Add(s);
            }
            if (deleteDrugsComboBox.Items.Count != 0)
            {
                deleteDrugsComboBox.SelectedIndex = 0;
                deleteDrugButton.IsEnabled = true;
            }
            else deleteDrugButton.IsEnabled = false;
        }

        private void searchInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Enter) searchButton.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }
    }
}
