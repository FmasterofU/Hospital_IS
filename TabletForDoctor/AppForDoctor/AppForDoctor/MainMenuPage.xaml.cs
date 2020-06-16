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
            return instance;
        }

        private void ToSerbian()
        {
            appointmentsButton.Content = "Pregled termina";
            pausesButton.Content = "Rukovanje pauzama";
            reportsButton.Content = "Generiši izveštaje";
            examinationButton.Content = "Pristupi pregledu";
        }

        private void ToEnglish()
        {
            appointmentsButton.Content = "Appointments";
            pausesButton.Content = "Check pauses";
            reportsButton.Content = "Generate reports";
            examinationButton.Content = "Go to examination";
        }

        private void pausesButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = MainWindow.getInstance();
            w.changePage(8);
        }

        private void blogButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = MainWindow.getInstance();
            w.changePage(7);
        }

        public static void clearInstance()
        {
            instance = null;
        }

        private void reportsButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = MainWindow.getInstance();
            w.GenerateReports(EditProfilePage.getInstance().getReportsSrb(), EditProfilePage.getInstance().getReportsEng());
        }

        private void examinationButton_Click(object sender, RoutedEventArgs e)
        {
            OpenExamination o = new OpenExamination();
            o.ShowDialog();
        }
    }
}
