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
    /// Interaction logic for ControlReview.xaml
    /// </summary>
    public partial class ControlReview : Window
    {
        private DateTime? selDate;

        public ControlReview()
        {
            InitializeComponent();
            if (MainWindow.GetTheme() == MainWindow.Theme.Light) ToLightTheme();
            else if (MainWindow.GetTheme() == MainWindow.Theme.Dark) ToDarkTheme();
        }

        private void ToLightTheme()
        {
            ControlReviewWindow.Background = Brushes.White;
            calendar.Background = Brushes.White;
        }

        private void ToDarkTheme()
        {
            ControlReviewWindow.Background = Brushes.Black;
            calendar.Background = Brushes.Black;
        }

        private void ControlReviewWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow w = MainWindow.getInstance();
            this.Left = w.Left + (w.Width - this.ActualWidth) / 2;
            this.Top = w.Top + (w.Height - this.ActualHeight) / 2;
        }

        private void backFromControlButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveControlButton_Click(object sender, RoutedEventArgs e)
        {
            if(!selDate.ToString().Equals(""))  ExaminationPage.getInstance().setControlDate(selDate);
            this.Close();
        }

        private void calendar_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            selDate = calendar.SelectedDate;
            if (!saveControlButton.IsEnabled) saveControlButton.IsEnabled = true;
        }

        public void setInitialDate(DateTime? initial)
        {
            calendar.SelectedDate = initial;
            saveControlButton.IsEnabled = true;
        }
    }
}
