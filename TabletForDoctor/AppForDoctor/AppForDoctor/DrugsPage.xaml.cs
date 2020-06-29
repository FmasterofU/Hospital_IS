using Model.Medicalrecord;
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
        private Dictionary<Model.Examination.Prescription, uint> prescriptionDict = new Dictionary<Model.Examination.Prescription, uint>();
        private static DrugsPage instance = null;
        private DrugsPage()
        {
            InitializeComponent();
            foreach(KeyValuePair<Model.Examination.Prescription, uint> pair in prescriptionDict)
            {
                drugListBox.Items.Add(pair.Key.drug.Name + " *" + pair.Value);
            }
            MedicalRecord mr = ExaminationPage.getInstance().getMedRecord();
            HashSet<string> drugs = new HashSet<string>();

            foreach(Model.Examination.Examination e in mr.Examination)
            {
                foreach(Model.Examination.Prescription p in e.Prescription)
                {
                    drugs.Add(p.drug.Name);
                }
            }

            foreach (string s in drugs) oldDrugsListBox.Items.Add(s);
        }

        public static DrugsPage getInstance()
        {
            if (instance == null) instance = new DrugsPage();
            if (instance.prescriptionDict.Count == 0)
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

        private void ToSerbian()
        {
            drugsLabel.Content = "Prepisani lekovi:";
            addDrugButton.Content = "Dodaj lek";
            deleteDrugButton.Content = "Obriši lek";
            changeAmountButton.Content = "Izmeni količinu";
            examinationFromDrugsButton.Content = "Nazad";
            oldDrugsLabel.Content = "Ranije korišćeni lekovi:";
        }

        private void ToEnglish()
        {
            drugsLabel.Content = "Prescribed drugs:";
            addDrugButton.Content = "Add drug";
            deleteDrugButton.Content = "Delete drug";
            changeAmountButton.Content = "Change amount";
            examinationFromDrugsButton.Content = "Back";
            oldDrugsLabel.Content = "Drugs used before:";
        }

        private void ToLightTheme()
        {
            //this.Resources["foregroundColor"] = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }

        private void ToDarkTheme()
        {
            //this.Resources["foregroundColor"] = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        public void DeleteDrugFromDict(string item)
        {
            //drugDict.Remove(item);
            Model.Examination.Prescription deleting = null;
            foreach (Model.Examination.Prescription p in prescriptionDict.Keys)
            {
                if(p.drug.Name.Equals(item))
                {
                    deleting = p;
                    break;
                }
            }
            if (deleting == null) return;
            prescriptionDict.Remove(deleting);
            foreach (string s in drugListBox.Items)
            {
                if (s.Contains(item + " *"))
                {
                    drugListBox.Items.Remove(s);
                    break;
                }
            }
            //drugListBox.Items.Remove(item);
            if (prescriptionDict.Count == 0)
            {
                deleteDrugButton.IsEnabled = false;
                changeAmountButton.IsEnabled = false;
            }
            if (!addDrugButton.IsEnabled) addDrugButton.IsEnabled = true;
        }

        public void AddDrugToDict(Model.Examination.Prescription item)
        {
            prescriptionDict.Add(item, item.Number);
            drugListBox.Items.Add(item.drug.Name + " *" + item.Number);
            deleteDrugButton.IsEnabled = true;
            changeAmountButton.IsEnabled = true;
        }

        public void ChangeDrugAmount(Model.Examination.Prescription old, uint amount)
        {
            string changed = old.drug.Name + " *" + prescriptionDict[old];
            int index = drugListBox.Items.IndexOf(changed);
            old.Number = amount;
            drugListBox.Items.Remove(changed);
            drugListBox.Items.Insert(index, old.drug.Name + " *" + amount);
            prescriptionDict.Remove(old);
            old.Number = amount;
            prescriptionDict.Add(old, old.Number);
        }

        public HashSet<string> geDrugNameSet()
        {
            HashSet<string> ret = new HashSet<string>();
            foreach (Model.Examination.Prescription s in prescriptionDict.Keys)
            {
                ret.Add(s.drug.Name);
            }
            return ret;
        }

        public HashSet<Model.Medicine.Drug> geDrugSet()
        {
            HashSet<Model.Medicine.Drug> ret = new HashSet<Model.Medicine.Drug>();
            foreach (Model.Examination.Prescription s in prescriptionDict.Keys)
            {
                ret.Add(s.drug);
            }
            return ret;
        }

        public Dictionary<Model.Examination.Prescription, uint> getDrugDict()
        {
            return prescriptionDict;
        }

        private void examinationFromDrugsButton_Click(object sender, RoutedEventArgs e)
        {
            ExaminationPage.getInstance().saveAddedDrugs(prescriptionDict);
            MainWindow w = MainWindow.getInstance();
            w.changePage(2);
        }

        private void drugListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TODO: implement selection
        }

        private void deleteDrugButton_Click(object sender, RoutedEventArgs e)
        {
            if(prescriptionDict.Count != 0)
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
