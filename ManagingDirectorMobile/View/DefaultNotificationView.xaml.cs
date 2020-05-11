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

namespace ManagingDirectorMobile.View
{
    /// <summary>
    /// Interaction logic for DefaultNotificationView.xaml
    /// </summary>
    public partial class DefaultNotificationView : UserControl
    {
        public DefaultNotificationView()
        {
            InitializeComponent();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            //DataContext = new MenuViewModel();
            ((MainWindow)Application.Current.MainWindow).cntrlZ2.Content = new MenuViewModel();
        }

        private void NotificationListDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            Notification not = dg.SelectedItem as Notification;
            Trace.WriteLine(DataContext);
            (DataContext as DefaultNotificationViewModel).addNotification();
        }
    }
}
