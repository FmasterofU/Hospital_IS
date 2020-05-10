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
        private MedHistory history = null;
        public ExaminationPage()
        {
            InitializeComponent();
        }

        private void historyButton_Click(object sender, RoutedEventArgs e)
        {
            if (history == null) history = new MedHistory();
            history.Show();
        }

        private void menuFromExaminationButton_Click(object sender, RoutedEventArgs e)
        {
            if (history != null)
            {
                history.Close();
                history = null;
            }
            MainWindow w = MainWindow.getInstance();
            w.changePage(1);
        }
    }
}
