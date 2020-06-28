using Model.Medicalrecord;
using Model.Roles;
using Repository.Roles;
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
    /// Interaction logic for ExaminationPage.xaml
    /// </summary>
    public partial class ExaminationPage : Page
    {
        // load history from database
        private static ExaminationPage instance = null;
        private string diagnosis = "";
        //private HashSet<string> addedDrugs = new HashSet<string>();
        //private Dictionary<string, int> addedDrugsDict = new Dictionary<string, int>();
        private Dictionary<Model.Examination.Prescription, uint> prescriptionDict = new Dictionary<Model.Examination.Prescription, uint>();
        //private HashSet<string> addedReferralsSet = new HashSet<string>();
        private HashSet<Model.Examination.Referral> referallSet = new HashSet<Model.Examination.Referral>();
        private DateTime? controlReviewDate = default;
        private MedicalRecord medRecord = null;
        private ExaminationPage()
        {
            InitializeComponent();
        }

        public static ExaminationPage getInstance()
        {
            if (instance == null) instance = new ExaminationPage();
            //instance.diagnosisText.Text = instance.diagnosis;
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) instance.ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) instance.ToEnglish();
            return instance;
        }

        public static ExaminationPage getInstance(MedicalRecord mr)
        {
            instance = getInstance();
            instance.medRecord = mr;
            instance.patientName.Content = mr.patient.Name + " " + mr.patient.Surname + ", ID = " + mr.patient.Jmbg;
            return instance;
        }

        public void ToSerbian()
        {
            historyButton.Content = "Pogledaj istoriju bolesti";
            diagnosisBox.Header = "Dijagnoza:";
            drugsButton.Content = "Pregled lekova";
            refferalButton.Content = "Pregled uputa";
            controlReviewButton.Content = "Zakazivanje kontrole";
            saveDiagnosisButton.Content = "Sačuvaj";
            menuFromExaminationButton.Content = "Meni";
        }

        public void ToEnglish()
        {
            historyButton.Content = "Check medical history";
            diagnosisBox.Header = "Diagnosis:";
            drugsButton.Content = "Check drugs";
            refferalButton.Content = "Check referrals";
            controlReviewButton.Content = "Schedule control review";
            saveDiagnosisButton.Content = "Save";
            menuFromExaminationButton.Content = "Menu";
        }

        private void historyButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = MainWindow.getInstance();
            w.changePage(6);
        }

        private void menuFromExaminationButton_Click(object sender, RoutedEventArgs e)
        {
            SaveExamination ee = new SaveExamination();
            ee.ShowDialog();
            /*MedHistoryPage.clearInstance();
            DrugsPage.clearInstance();
            RefferalsPage.clearInstance();
            instance = null;
            MainWindow w = MainWindow.getInstance();
            w.changePage(1);*/
        }

        private void saveDiagnosisButton_Click(object sender, RoutedEventArgs e)
        {
            //string toHistory = diagnosis + "\n" + DictToString(addedDrugsDict) + "\n" + HashsetToString(addedReferralsSet) + "\n" + controlReviewDate.ToString();
            //MedHistoryPage.getInstance().historyText.Text = toHistory + MedHistoryPage.getInstance().getHistory().ToString();
            saveDiagnosisButton.IsEnabled = false;
        }

        private void drugsButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = MainWindow.getInstance();
            w.changePage(3);
        }

        private void diagnosisText_TextChanged(object sender, TextChangedEventArgs e)
        {
            diagnosis = diagnosisText.Text;
            saveDiagnosisButton.IsEnabled = true;
        }

        public void saveAddedDrugs(Dictionary<Model.Examination.Prescription, uint> d)
        {
            if (d.Count != prescriptionDict.Count || d.Except(prescriptionDict).Any())
            {
                prescriptionDict.Clear();
                saveDiagnosisButton.IsEnabled = true;
                foreach (KeyValuePair<Model.Examination.Prescription, uint> pair in d)
                {
                    prescriptionDict.Add(pair.Key, pair.Value);
                }
            }
        }

        public void saveAddedReferrals(HashSet<Model.Examination.Referral> set)
        {
            /*if(!addedReferralsSet.SetEquals(set))
            {
                addedReferralsSet.Clear();
                saveDiagnosisButton.IsEnabled = true;
                foreach(string s in set)
                {
                    addedReferralsSet.Add(s);
                }
            }*/
            if(!referallSet.SetEquals(set))
            {
                referallSet.Clear();
                saveDiagnosisButton.IsEnabled = true;
                foreach (Model.Examination.Referral r in set) referallSet.Add(r);
            }
        }

        private void controlReviewButton_Click(object sender, RoutedEventArgs e)
        {
            ControlReview r = new ControlReview();
            if (controlReviewDate != default) r.setInitialDate(controlReviewDate);
            r.ShowDialog();
        }

        private void refferalButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = MainWindow.getInstance();
            w.changePage(5);
        }

        public void setControlDate(DateTime? input)
        {
            if (input != controlReviewDate)
            {
                controlReviewDate = input;
                saveDiagnosisButton.IsEnabled = true;
            }
        }

        public static string DictToString(Dictionary<string, uint> input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, uint> pair in input)
            {
                sb.Append("\t");
                sb.Append(pair.Key);
                sb.Append(" *");
                sb.Append(pair.Value.ToString());
                sb.Append("\n");
            }
            if (sb.Length > 2) return sb.ToString();
            else
            {
                return "";
            }
        }

        public static string HashsetToString(HashSet<string> input)
        {
            if (input.Count == 0) return "";
            StringBuilder sb = new StringBuilder();
            foreach (string s in input)
            {
                sb.Append(s);
                sb.Append(", ");
            }
            if (sb.Length > 2) return sb.ToString(0, sb.Length - 2);
            else
            {
                return "";
            }
        }

        public static void clearInstance()
        {
            instance = null;
        }

        public MedicalRecord getMedRecord()
        {
            return medRecord;
        }

        public string getDiagnosis()
        {
            return diagnosisText.Text;
        }

        public Dictionary<Model.Examination.Prescription, uint> getRecipes()
        {
            return prescriptionDict;
        }
    }
}
