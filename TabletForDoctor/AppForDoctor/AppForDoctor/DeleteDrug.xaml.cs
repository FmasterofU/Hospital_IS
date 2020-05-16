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
using System.Windows.Shapes;

namespace AppForDoctor
{
    /// <summary>
    /// Interaction logic for DeleteDrug.xaml
    /// </summary>
    public partial class DeleteDrug : Window
    {
        public DeleteDrug()
        {
            InitializeComponent();
            HashSet<string> drugSet = DrugsPage.getInstance().getDrugSet();
            foreach (string s in drugSet) deleteDrugsComboBox.Items.Add(s);
            deleteDrugsComboBox.SelectedIndex = 0;
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) ToEnglish();
            if (MainWindow.GetTheme() == MainWindow.Theme.Light) ToLightTheme();
            else if (MainWindow.GetTheme() == MainWindow.Theme.Dark) ToDarkTheme();
        }

        private void ToSerbian()
        {
            deleteDrugButton.Content = "Obrisi";
            backFromDeleteButton.Content = "Nazad";
        }

        private void ToEnglish()
        {
            deleteDrugButton.Content = "Delete";
            backFromDeleteButton.Content = "Back";
        }

        private void ToLightTheme()
        {
            DeleteDrugWindow.Background = Brushes.White;
            deleteDrugButton.BorderBrush = Brushes.Black;
            backFromDeleteButton.BorderBrush = Brushes.Black;
        }

        private void ToDarkTheme()
        {
            DeleteDrugWindow.Background = Brushes.Black;
            deleteDrugButton.BorderBrush = Brushes.White;
            backFromDeleteButton.BorderBrush = Brushes.White;
        }

        private void deleteDrugButton_Click(object sender, RoutedEventArgs e)
        {
            string item = deleteDrugsComboBox.SelectedItem.ToString();
            deleteDrugsComboBox.Items.Remove(item);
            DrugsPage d = DrugsPage.getInstance();
            d.deleteDrugFromSet(item);
            deleteDrugsComboBox.SelectedIndex = 0;
            if (deleteDrugsComboBox.Items.Count == 0)   this.Close();
        }

        private void backFromDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DeleteDrugWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow w = MainWindow.getInstance();
            this.Left = w.Left + (w.Width - this.ActualWidth) / 2;
            this.Top = w.Top + (w.Height - this.ActualHeight) / 2;
        }
    }
}
