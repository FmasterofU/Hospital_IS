using ManagingDirectorMobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ManagingDirectorMobile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            //DataContext = new DefaultBarViewModel();
            cntrlZ1.Content = new DefaultNotificationViewModel();

        }

        public void ClearAllUserControls()
        {
            cntrlZ1.Content = null;
            cntrlZ2.Content = null;
            cntrlZ3.Content = null;
            cntrlZ4.Content = null;
        }

        public void ClearFromFirstUserControlUp()
        {
            cntrlZ2.Content = null;
            cntrlZ3.Content = null;
            cntrlZ4.Content = null;
        }
        public void ClearFromSecondUserControlUp()
        {
            cntrlZ3.Content = null;
            cntrlZ4.Content = null;
        }
        public void ClearFromThirdUserControlUp()
        {
            cntrlZ4.Content = null;
        }
    }
}
