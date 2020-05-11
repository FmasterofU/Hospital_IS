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
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        private static MainMenuPage instance = null;
        private MainMenuPage()
        {
            InitializeComponent();
            if(MainWindow.GetLanguage() == MainWindow.Language.Serbian)  ToSerbian();
            else if(MainWindow.GetLanguage() == MainWindow.Language.English) ToEnglish();
            if(MainWindow.GetTheme() == MainWindow.Theme.Light)    ToLightTheme();
            else if(MainWindow.GetTheme() == MainWindow.Theme.Dark) ToDarkTheme();
            instance = this;
        }

        public static MainMenuPage getInstance()
        {
            if (instance == null) instance = new MainMenuPage();
            return instance;
        }

        public void ToSerbian()
        {
            patientID.Content = "Identifikacioni broj pacijenta:";
            acceptID.Content = "Potvrdi";
            appointmentsButton.Content = "Pregled termina";
            commentsButton.Content = "Pregled komentara pacijenata";
            commentsButton.Width = 480;
            pausesButton.Content = "Rukovanje pauzama";
            pausesButton.Width = 330;
        }

        public void ToEnglish()
        {
            patientID.Content = "Patient identification number:";
            acceptID.Content = "Accept";
            appointmentsButton.Content = "Appointments";
            commentsButton.Content = "See patient's comments";
            commentsButton.Width = 395;
            pausesButton.Content = "Check pauses";
            pausesButton.Width = 230;
        }

        public void ToLightTheme()
        {
            patientID.Foreground = Brushes.Black;
            patientIDText.BorderBrush = Brushes.Black;
            patientIDText.Foreground = Brushes.Black;
            patientIDText.Background = Brushes.White;
            acceptID.BorderBrush = Brushes.Black;
            appointmentsButton.BorderBrush = Brushes.Black;
            commentsButton.BorderBrush = Brushes.Black;
            pausesButton.BorderBrush = Brushes.Black;
        }

        public void ToDarkTheme()
        {
            patientID.Foreground = Brushes.White;
            patientIDText.BorderBrush = Brushes.White;
            patientIDText.Foreground = Brushes.White;
            patientIDText.Background = Brushes.Black;
            acceptID.BorderBrush = Brushes.White;
            appointmentsButton.BorderBrush = Brushes.White;
            commentsButton.BorderBrush = Brushes.White;
            pausesButton.BorderBrush = Brushes.White;
        }

        private void acceptID_Click(object sender, RoutedEventArgs e)
        {
            //TODO: validation
            instance = null;
            MainWindow w = MainWindow.getInstance();
            w.changePage(2);
        }
    }
}
