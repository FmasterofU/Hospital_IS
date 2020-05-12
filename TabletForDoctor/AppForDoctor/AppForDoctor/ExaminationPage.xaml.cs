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
        //private static MedHistory history = new MedHistory();
        //private static bool historyOpened = false;
        private static ExaminationPage instance = null;
        private static string diagnosis = "";
        private ExaminationPage()
        {
            InitializeComponent();
        }

        public static void closeHistory()
        {
            //history = null;
        }

        public static ExaminationPage getInstance()
        {
            if (instance == null) instance = new ExaminationPage();
            instance.diagnosisText.Text = diagnosis;
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
            saveDiagnosisButton.Content = "Sacuvaj";
            menuFromExaminationButton.Content = "Meni";
        }

        public void ToEnglish()
        {
            historyButton.Content = "Check medical history";
            diagnosisBox.Header = "Diagnosis:";
            drugsButton.Content = "Check drugs";
            refferalButton.Content = "Check refferals";
            controlReviewButton.Content = "Schedule control review";
            saveDiagnosisButton.Content = "Save";
            menuFromExaminationButton.Content = "Menu";
        }

        public void ToLightTheme()
        {
            patientName.Foreground = Brushes.Black;
            historyButton.BorderBrush = Brushes.Black;
            diagnosisBox.BorderBrush = Brushes.Black;
            diagnosisBox.Background = Brushes.White;
            diagnosisBox.Foreground = Brushes.Black;
            diagnosisText.Background = Brushes.White;
            diagnosisText.Foreground = Brushes.Black;
            drugsButton.BorderBrush = Brushes.Black;
            refferalButton.BorderBrush = Brushes.Black;
            controlReviewButton.BorderBrush = Brushes.Black;
            saveDiagnosisButton.BorderBrush = Brushes.Black;
            menuFromExaminationButton.BorderBrush = Brushes.Black;
            MedHistory.getInstance().ToLightTheme();
        }

        public void ToDarkTheme()
        {
            patientName.Foreground = Brushes.White;
            historyButton.BorderBrush = Brushes.White;
            diagnosisBox.BorderBrush = Brushes.White;
            diagnosisBox.Background = Brushes.Black;
            diagnosisBox.Foreground = Brushes.White;
            diagnosisText.Background = Brushes.Black;
            diagnosisText.Foreground = Brushes.White;
            drugsButton.BorderBrush = Brushes.White;
            refferalButton.BorderBrush = Brushes.White;
            controlReviewButton.BorderBrush = Brushes.White;
            saveDiagnosisButton.BorderBrush = Brushes.White;
            menuFromExaminationButton.BorderBrush = Brushes.White;
            MedHistory.getInstance().ToDarkTheme();
        }

        private void historyButton_Click(object sender, RoutedEventArgs e)
        {
            //if (history == null)    history = new MedHistory();
            //history.Show();
            if (MedHistory.getInstance() != null)
            {
                MedHistory.getInstance().Show();
                MedHistory.getInstance().Focus();
            }
        }

        private void menuFromExaminationButton_Click(object sender, RoutedEventArgs e)
        {
            //if (history != null)    history.Close();
            MedHistory.getInstance().toClose = true;
            MedHistory.getInstance().Close();
            instance = null;
            diagnosis = "";
            MainWindow w = MainWindow.getInstance();
            w.changePage(1);
        }

        private void saveDiagnosisButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: save history in data base
            //if (history != null)    
            MedHistory.getInstance().historyText.Text += diagnosis;
        }

        private void drugsButton_Click(object sender, RoutedEventArgs e)
        {
            //instance = null;
            diagnosis = instance.diagnosisText.Text;
            MainWindow w = MainWindow.getInstance();
            w.changePage(3);
        }

        private void diagnosisText_TextChanged(object sender, TextChangedEventArgs e)
        {
            diagnosis = diagnosisText.Text;
        }
    }
}
