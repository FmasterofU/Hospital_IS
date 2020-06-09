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
    /// Interaction logic for MedHistoryPage.xaml
    /// </summary>
    public partial class MedHistoryPage : Page
    {
        private static MedHistoryPage instance = null;
        private MedHistoryPage()
        {
            InitializeComponent();
        }

        public static MedHistoryPage getInstance()
        {
            if (instance == null) instance = new MedHistoryPage();
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) instance.ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) instance.ToEnglish();
            return instance;
        }

        private void ToSerbian()
        {
            examinationFromHistoryButton.Content = "Nazad";
        }

        private void ToEnglish()
        {
            examinationFromHistoryButton.Content = "Back";
        }

        private void examinationFromHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = MainWindow.getInstance();
            w.changePage(2);
        }

        public static void clearInstance()
        {
            instance = null;
        }
    }
}
