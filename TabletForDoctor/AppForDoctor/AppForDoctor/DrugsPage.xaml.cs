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
        //private HashSet<string> drugSet = new HashSet<string>();
        private Dictionary<string, int> drugDict = new Dictionary<string, int>();
        private static DrugsPage instance = null;
        private DrugsPage()
        {
            InitializeComponent();
            //TODO: load drugs from database
            foreach(KeyValuePair<string, int> pair in drugDict)
            {
                drugListBox.Items.Add(pair.Key + " *" + pair.Value);
            }
        }

        public static DrugsPage getInstance()
        {
            if (instance == null) instance = new DrugsPage();
            if (instance.drugDict.Count == 0)
            {
                instance.deleteDrugButton.IsEnabled = false;
                instance.changeAmountButton.IsEnabled = false;
            }
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
            changeAmountButton.Content = "Izmeni kolicinu";
            examinationFromDrugsButton.Content = "Nazad";
        }

        public void ToEnglish()
        {
            drugsLabel.Content = "Prescribed drugs:";
            addDrugButton.Content = "Add drug";
            deleteDrugButton.Content = "Delete drug";
            changeAmountButton.Content = "Change amount";
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

        public void DeleteDrugFromDict(string item)
        {
            drugDict.Remove(item);
            foreach (string s in drugListBox.Items)
            {
                if (s.Contains(item + " *"))
                {
                    drugListBox.Items.Remove(s);
                    break;
                }
            }
            //drugListBox.Items.Remove(item);
            if (drugDict.Count == 0)
            {
                deleteDrugButton.IsEnabled = false;
                changeAmountButton.IsEnabled = false;
            }
            if (!addDrugButton.IsEnabled) addDrugButton.IsEnabled = true;
        }

        public void AddDrugToDict(string adding, int amount)
        {
            drugDict.Add(adding, amount);
            drugListBox.Items.Add(adding + " *" + amount);
            deleteDrugButton.IsEnabled = true;
            changeAmountButton.IsEnabled = true;
        }

        public void ChangeDrugAmount(string drug, int amount)
        {
            string changed = drug + " *" + drugDict[drug];
            int index = drugListBox.Items.IndexOf(changed);
            drugDict[drug] = amount;
            drugListBox.Items.Remove(changed);
            drugListBox.Items.Insert(index, drug + " *" + amount);
        }

        public HashSet<string> getDrugSet()
        {
            HashSet<string> ret = new HashSet<string>();
            foreach (string s in drugDict.Keys) ret.Add(s);
            return ret;
        }

        public Dictionary<string, int> getDrugDict()
        {
            return drugDict;
        }

        private void examinationFromDrugsButton_Click(object sender, RoutedEventArgs e)
        {
            ExaminationPage.getInstance().saveAddedDrugs(drugDict);
            MainWindow w = MainWindow.getInstance();
            w.changePage(2);
        }

        private void drugListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TODO: implement selection
        }

        private void deleteDrugButton_Click(object sender, RoutedEventArgs e)
        {
            if(drugDict.Count != 0)
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

        private void changeAmountButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeDrugAmount c = new ChangeDrugAmount();
            c.ShowDialog();
        }
    }
}
