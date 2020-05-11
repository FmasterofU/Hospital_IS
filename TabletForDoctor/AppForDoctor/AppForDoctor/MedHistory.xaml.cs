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
using System.Windows.Shapes;

namespace AppForDoctor
{
    /// <summary>
    /// Interaction logic for MedHistory.xaml
    /// </summary>
    public partial class MedHistory : Window
    {
        private static MedHistory instance = null;
        public bool toClose = false;
        private MedHistory()
        {
            InitializeComponent();
        }

        /*private void MedHistoryWindow_Closed(object sender, EventArgs e)
        {
            //TODO: save history in data base
            ExaminationPage.closeHistory();
        }*/

        public static MedHistory getInstance()
        {
            if (instance == null) instance = new MedHistory();
            return instance;
        }

        public void ToLightTheme()
        {
            historyText.Foreground = Brushes.Black;
            historyText.Background = Brushes.White;
        }

        public void ToDarkTheme()
        {
            historyText.Foreground = Brushes.White;
            historyText.Background = Brushes.Black;
        }

        private void MedHistoryWindow_Loaded(object sender, RoutedEventArgs e)
        {
                MainWindow w = MainWindow.getInstance();
                this.Left = w.Left + (w.Width - this.ActualWidth) / 2;
                this.Top = w.Top + (w.Height - this.ActualHeight) / 2;
        }

        private void MedHistoryWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //TODO: save history in data base
            ExaminationPage.closeHistory();
            if (!toClose)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
            {
                e.Cancel = false;
                instance = null;
            }
        }
    }
}
