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
            pausesButton.Content = "Rukovanje pauzama";
        }

        public void ToEnglish()
        {
            patientID.Content = "Patient identification number:";
            acceptID.Content = "Accept";
            appointmentsButton.Content = "Appointments";
            commentsButton.Content = "See patient's comments";
            pausesButton.Content = "Check pauses";
        }

        public void ToLightTheme()
        {
            //this.Resources["foregroundColor"] = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            patientIDText.BorderBrush = Brushes.Black;
            patientIDText.Background = Brushes.White;
        }

        public void ToDarkTheme()
        {
            //this.Resources["foregroundColor"] = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            patientIDText.BorderBrush = Brushes.White;
            patientIDText.Background = Brushes.Black;
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
