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

        public static MedHistory getInstance()
        {
            if (instance == null) instance = new MedHistory();
            instance.centerHistoryToParent();
            return instance;
        }

        public void ToLightTheme()
        {
        }

        public void ToDarkTheme()
        {
        }

        private void MedHistoryWindow_Loaded(object sender, RoutedEventArgs e)
        {
            centerHistoryToParent();
        }

        private void centerHistoryToParent()
        {
            MainWindow.CenterDialog(this);
        }

        private void MedHistoryWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //TODO: save history in data base
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
