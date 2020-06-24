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

namespace HCIProjekat.Pages
{
    /// <summary>
    /// Interaction logic for LogPage.xaml
    /// </summary>
    public partial class LogPage : Page
    {
        public LogPage()
        {
            InitializeComponent();
        }

        private void BtnClickPrijaviSe(object sender, RoutedEventArgs e)
        {
            UserControls.LoginUC lguc = new UserControls.LoginUC();
            LoginView.Children.Clear();
            LoginView.Children.Add(lguc);
            
        }

        private void HyperlinkKreirajNalog_Click(object sender, RoutedEventArgs e)
        {
            Dialogs.KreirajNalogDialog dijalog = new Dialogs.KreirajNalogDialog(false);
            dijalog.ShowDialog();
        }
    }
}
