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

namespace AppForDoctor
{
    /// <summary>
    /// Interaction logic for DrugsPage.xaml
    /// </summary>
    public partial class DrugsPage : Page
    {
        private HashSet<string> drugSet = new HashSet<string>();
        private static DrugsPage instance = null;
        private DrugsPage()
        {
            InitializeComponent();
            //TODO: load drugs from database
            foreach(string s in drugSet)
            {
                drugListBox.Items.Add(s);
            }
        }

        public static DrugsPage getInstance()
        {
            if (instance == null) instance = new DrugsPage();
            if (instance.drugSet.Count == 0) instance.deleteDrugButton.IsEnabled = false;
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) instance.ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) instance.ToEnglish();
            if (MainWindow.GetTheme() == MainWindow.Theme.Light) instance.ToLightTheme();
            else if (MainWindow.GetTheme() == MainWindow.Theme.Dark) instance.ToDarkTheme();
            return instance;
        }

        public void ToSerbian()
        {
            drugsLabel.Content = "Prepisani lekovi:";
            addDrugButton.Content = "Dodaj lek";
            deleteDrugButton.Content = "Obrisi lek";
            examinationFromDrugsButton.Content = "Nazad";
        }

        public void ToEnglish()
        {
            drugsLabel.Content = "Prescribed drugs:";
            addDrugButton.Content = "Add drug";
            deleteDrugButton.Content = "Delete drug";
            examinationFromDrugsButton.Content = "Back";
        }

        public void ToLightTheme()
        {
            //this.Resources["foregroundColor"] = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }

        public void ToDarkTheme()
        {
            //this.Resources["foregroundColor"] = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        public void deleteDrugFromSet(string item)
        {
            drugSet.Remove(item);
            drugListBox.Items.Remove(item);
            if (drugSet.Count == 0) deleteDrugButton.IsEnabled = false;
            if(!addDrugButton.IsEnabled)    addDrugButton.IsEnabled = true;
        }

        public void addDrugToSet(string adding)
        {
            drugSet.Add(adding);
            drugListBox.Items.Add(adding);
            if (!deleteDrugButton.IsEnabled) deleteDrugButton.IsEnabled = true;
        }

        public HashSet<string> getDrugSet()
        {
            return drugSet;
        }

        private void examinationFromDrugsButton_Click(object sender, RoutedEventArgs e)
        {
            ExaminationPage.getInstance().saveAddedDrugs(drugSet);
            MainWindow w = MainWindow.getInstance();
            w.changePage(2);
        }

        private void drugListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TODO: implement selection
        }

        private void deleteDrugButton_Click(object sender, RoutedEventArgs e)
        {
            if(drugSet.Count != 0)
            {
                DeleteDrug delete = new DeleteDrug();
                delete.ShowDialog();
            }
        }

        private void addDrugButton_Click(object sender, RoutedEventArgs e)
        {
            AddDrug add = new AddDrug();
            add.ShowDialog();
        }

        public static void clearInstance()
        {
            instance = null;
        }

        public void disableAddButton()
        {
            addDrugButton.IsEnabled = false;
        }
    }
}
