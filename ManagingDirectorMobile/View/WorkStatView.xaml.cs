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
    /// Interaction logic for WorkStatView.xaml
    /// </summary>
    public partial class WorkStatView : UserControl
    {
        public WorkStatView()
        {
            InitializeComponent();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).ClearFromFirstUserControlUp();
            ((MainWindow)Application.Current.MainWindow).cntrlZ2.Content = new MenuViewModel();
        }

        private void Report_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DoctorsListDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
