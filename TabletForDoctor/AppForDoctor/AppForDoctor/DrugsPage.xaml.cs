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
        private static List<string> drugList = new List<string>();
        private static DrugsPage instance = null;
        private DrugsPage()
        {
            InitializeComponent();
            //TODO: load drugs from database
            for (int i = 0; i < drugList.Count; i++)
            {
                drugListBox.Items.Add(drugList[i]);
            }
        }

        public static DrugsPage getInstance()
        {
            if (instance == null) instance = new DrugsPage();
            if (drugList.Count == 0) instance.deleteDrugButton.IsEnabled = false;
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
            drugsLabel.Foreground = Brushes.Black;
            drugListBox.Background = Brushes.White;
            drugListBox.Foreground = Brushes.Black;
            addDrugButton.BorderBrush = Brushes.Black;
            deleteDrugButton.BorderBrush = Brushes.Black;
            examinationFromDrugsButton.BorderBrush = Brushes.Black;
            MedHistory.getInstance().ToLightTheme();
        }

        public void ToDarkTheme()
        {
            drugsLabel.Foreground = Brushes.White;
            drugListBox.Background = Brushes.Black;
            drugListBox.Foreground = Brushes.White;
            addDrugButton.BorderBrush = Brushes.White;
            deleteDrugButton.BorderBrush = Brushes.White;
            examinationFromDrugsButton.BorderBrush = Brushes.White;
            MedHistory.getInstance().ToDarkTheme();
        }

        public void deleteDrugFormList(int index)
        {
            drugList.RemoveAt(index);
            drugListBox.Items.RemoveAt(index);
            if (drugList.Count == 0) deleteDrugButton.IsEnabled = false;
        }

        public void addDrugToList(string adding)
        {
            drugList.Add(adding);
            drugListBox.Items.Add(adding);
            if (drugList.Count != 0) deleteDrugButton.IsEnabled = true;
        }

        public static List<string> getDrugList()
        {
            return drugList;
        }

        private void examinationFromDrugsButton_Click(object sender, RoutedEventArgs e)
        {
            ExaminationPage.getInstance().saveAddedDrugs(drugList);
            MainWindow w = MainWindow.getInstance();
            w.changePage(2);
        }

        private void drugListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TODO: implement selection
        }

        private void deleteDrugButton_Click(object sender, RoutedEventArgs e)
        {
            if (drugList.Count != 0)
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
            drugList = new List<String>();
        }
    }
}
