using ManagingDirectorMobile.ViewModel;
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

namespace ManagingDirectorMobile.View
{
    /// <summary>
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : UserControl
    {
        public ReportView()
        {
            InitializeComponent();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).ClearFromFirstUserControlUp();
            ((MainWindow)Application.Current.MainWindow).cntrlZ2.Content = new MenuViewModel();
        }

        private void DrugsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DoctorsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StaffButton_Click(object sender, RoutedEventArgs e)
        {
            ReportViewModel.DrugsReport();
        }

        private void RoomsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EquipmentButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
