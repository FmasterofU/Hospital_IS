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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void KreirajNalogClick(object sender, RoutedEventArgs e)
        {
            Dialogs.KreirajNalogDialog dijalog = new Dialogs.KreirajNalogDialog(true);
            dijalog.ShowDialog();
        }
        private void BtnSviPacijenti(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).FullMainWindow.Content = new AllPatients();
        }

        private void BtnZaposleni_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).FullMainWindow.Content = new AllStaff();
        }

        private void BtnTermini_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).FullMainWindow.Content = new Terms();
        }
    }
}
