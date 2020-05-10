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
        private static MedHistory history = null;
        public ExaminationPage()
        {
            InitializeComponent();
        }

        public static void closeHistory()
        {
            history = null;
        }

        private void historyButton_Click(object sender, RoutedEventArgs e)
        {
            if (history == null)    history = new MedHistory();
            history.Show();
        }

        private void menuFromExaminationButton_Click(object sender, RoutedEventArgs e)
        {
            if (history != null)    history.Close();
            MainWindow w = MainWindow.getInstance();
            w.changePage(1);
        }

        private void saveDiagnosisButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: save history in data base
            if (history != null)    history.historyText.Text += diagnosisText.Text;
            MessageBox.Show("Sve izmene su sacuvane!");
        }

        private void drugsButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = MainWindow.getInstance();
            w.changePage(3);
        }
    }
}
