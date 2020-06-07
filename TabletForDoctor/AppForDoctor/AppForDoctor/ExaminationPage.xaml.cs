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
        private Dictionary<string, int> addedDrugsDict = new Dictionary<string, int>();
        private DateTime? controlReviewDate = default;
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
            if (MainWindow.GetTheme() == MainWindow.Theme.Light) instance.ToLightTheme();
            else if (MainWindow.GetTheme() == MainWindow.Theme.Dark) instance.ToDarkTheme();
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

        public void ToLightTheme()
        {
            //this.Resources["foregroundColor"] = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            //MedHistory.getInstance().ToLightTheme();
        }

        public void ToDarkTheme()
        {
            //this.Resources["foregroundColor"] = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            //MedHistory.getInstance().ToDarkTheme();
        }

        private void historyButton_Click(object sender, RoutedEventArgs e)
        {
            if (MedHistory.getInstance() != null)
            {
                MedHistory.getInstance().Show();
                MedHistory.getInstance().Focus();
            }
        }

        private void menuFromExaminationButton_Click(object sender, RoutedEventArgs e)
        {
            MedHistory.getInstance().toClose = true;
            MedHistory.getInstance().Close();
            DrugsPage.clearInstance();
            RefferalsPage.clearInstance();
            instance = null;
            MainWindow w = MainWindow.getInstance();
            w.changePage(1);
        }

        private void saveDiagnosisButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: save history in data base
            string toHistory = diagnosis + "\n" + DictToString(addedDrugsDict) + "\n" + controlReviewDate.ToString();
            MedHistory.getInstance().historyText.Text = toHistory;
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

        public void saveAddedDrugs(Dictionary<string, int> d)
        {
            if (d.Count != addedDrugsDict.Count || d.Except(addedDrugsDict).Any())
            {
                addedDrugsDict.Clear();
                saveDiagnosisButton.IsEnabled = true;
                foreach (KeyValuePair<string, int> pair in d)
                {
                    addedDrugsDict.Add(pair.Key, pair.Value);
                }
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

        public static string DictToString(Dictionary<string, int> input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, int> pair in input)
            {
                sb.Append(pair.Key);
                sb.Append(" *");
                sb.Append(pair.Value.ToString());
                sb.Append(", ");
            }
            if (sb.Length > 2) return sb.ToString(0, sb.Length - 2);
            else
            {
                return "";
            }
        }
    }
}
