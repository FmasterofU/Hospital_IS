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
    /// Interaction logic for AddDrug.xaml
    /// </summary>
    public partial class AddDrug : Window
    {
        public AddDrug()
        {
            InitializeComponent();
            //TODO: load all medicaments in hospital
            addDrugsComboBox.Items.Add("Novi");
            addDrugsComboBox.Items.Add("Nnovi");
            addDrugsComboBox.Items.Add("Noovi");
            addDrugsComboBox.Items.Add("Novvi");
            addDrugsComboBox.Items.Add("Novii");
            addDrugsComboBox.Items.Add("Novio");
            addDrugsComboBox.SelectedIndex = 0;
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) ToEnglish();
            if (MainWindow.GetTheme() == MainWindow.Theme.Light) ToLightTheme();
            else if (MainWindow.GetTheme() == MainWindow.Theme.Dark) ToDarkTheme();
        }

        private void ToSerbian()
        {
            addDrugButton.Content = "Dodaj";
            backFromAddButton.Content = "Nazad";
        }

        private void ToEnglish()
        {
            addDrugButton.Content = "Add";
            backFromAddButton.Content = "Back";
        }

        private void ToLightTheme()
        {
            AddDrugWindow.Background = Brushes.White;
            addDrugButton.BorderBrush = Brushes.Black;
            backFromAddButton.BorderBrush = Brushes.Black;
        }

        private void ToDarkTheme()
        {
            AddDrugWindow.Background = Brushes.Black;
            addDrugButton.BorderBrush = Brushes.White;
            backFromAddButton.BorderBrush = Brushes.White;
        }

        private void backFromAddButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddDrugWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow w = MainWindow.getInstance();
            this.Left = w.Left + (w.Width - this.ActualWidth) / 2;
            this.Top = w.Top + (w.Height - this.ActualHeight) / 2;
        }

        private void addDrugButton_Click(object sender, RoutedEventArgs e)
        {
            int index = addDrugsComboBox.SelectedIndex;
            DrugsPage d = DrugsPage.getInstance();
            d.addDrugToList(addDrugsComboBox.Items[index].ToString());
            addDrugsComboBox.Items.RemoveAt(index);
            addDrugsComboBox.SelectedIndex = 0;
            if (addDrugsComboBox.Items.Count == 0) this.Close();
        }
    }
}
