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
        }

        public static MainMenuPage getInstance()
        {
            if (instance == null) instance = new MainMenuPage();
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) instance.ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) instance.ToEnglish();
            if (MainWindow.GetTheme() == MainWindow.Theme.Light) instance.ToLightTheme();
            else if (MainWindow.GetTheme() == MainWindow.Theme.Dark) instance.ToDarkTheme();
            return instance;
        }

        private void ToSerbian()
        {
            patientID.Content = "Identifikacioni broj pacijenta:";
            acceptID.Content = "Potvrdi";
            appointmentsButton.Content = "Pregled termina";
            pausesButton.Content = "Rukovanje pauzama";
        }

        private void ToEnglish()
        {
            patientID.Content = "Patient identification number:";
            acceptID.Content = "Accept";
            appointmentsButton.Content = "Appointments";
            pausesButton.Content = "Check pauses";
        }

        private void ToLightTheme()
        {
            //this.Resources["foregroundColor"] = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }

        private void ToDarkTheme()
        {
            //this.Resources["foregroundColor"] = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void acceptID_Click(object sender, RoutedEventArgs e)
        {
            //TODO: validation
            instance = null;
            MainWindow w = MainWindow.getInstance();
            w.changePage(2);
        }

        private void pausesButton_Click(object sender, RoutedEventArgs e)
        {
            Pauses p = new Pauses();
            p.ShowDialog();
        }
    }
}
