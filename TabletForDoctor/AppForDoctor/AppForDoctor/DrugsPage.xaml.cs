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
        private static DeleteDrug delete = null;
        private static AddDrug add = null;
        private static List<String> drugList = new List<String>();
        private static DrugsPage instance = null;
        private DrugsPage()
        {
            InitializeComponent();
            //TODO: load drugs from database
            drugListBox.Items.Add("Prvi");
            drugListBox.Items.Add("Drugi");
            drugListBox.Items.Add("Treci");
            drugListBox.Items.Add("Cetvrti");
            for (int i = 0; i < drugListBox.Items.Count; i++)
            {
                drugList.Add(drugListBox.Items[i].ToString());
            }
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) ToEnglish();
            if (MainWindow.GetTheme() == MainWindow.Theme.Light) ToLightTheme();
            else if (MainWindow.GetTheme() == MainWindow.Theme.Dark) ToDarkTheme();
        }

        public static DrugsPage getInstance()
        {
            if (instance == null) instance = new DrugsPage();
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
        }

        public void addDrugToList(string adding)
        {
            drugList.Add(adding);
            drugListBox.Items.Add(adding);
        }

        public static List<String> getDrugList()
        {
            return drugList;
        }

        public static void closeDeletion()
        {
            delete = null;
        }

        public static void closeAdding()
        {
            add = null;
        }

        private void examinationFromDrugsButton_Click(object sender, RoutedEventArgs e)
        {
            instance = null;
            MainWindow w = MainWindow.getInstance();
            w.changePage(2);
        }

        private void drugListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TODO: implement selection
        }

        private void deleteDrugButton_Click(object sender, RoutedEventArgs e)
        {
            delete = new DeleteDrug();
            delete.ShowDialog();
        }

        private void addDrugButton_Click(object sender, RoutedEventArgs e)
        {
            add = new AddDrug();
            add.ShowDialog();
        }
    }
}
