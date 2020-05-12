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
    /// Interaction logic for DrugsView.xaml
    /// </summary>
    public partial class DrugsView : UserControl
    {
        public DrugsView()
        {
            InitializeComponent();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).ClearFromFirstUserControlUp();
            ((MainWindow)Application.Current.MainWindow).cntrlZ2.Content = new MenuViewModel();
        }

        private void OptionsButton_Click(object sender, RoutedEventArgs e)
        {
            if (OptionsPanel.Visibility != Visibility.Visible)
                OptionsPanel.Visibility = Visibility.Visible;
            else OptionsPanel.Visibility = Visibility.Hidden;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SupplyButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowHistoricalDataButton_Click(object sender, RoutedEventArgs e)
        {
            DrugsViewModel.Drug drug = DrugListDG.SelectedItem as DrugsViewModel.Drug;
            ((MainWindow)Application.Current.MainWindow).cntrlZ2.Content = new DrugsHistoryViewModel(DrugListDG.SelectedItem as DrugsViewModel.Drug);
        }

        private void DrugListDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as DataGrid).SelectedItem != null) ShowHistoricalDataButton.IsEnabled = true;
            else ShowHistoricalDataButton.IsEnabled = false;
        }

        private void OptionsButton_LostFocus(object sender, RoutedEventArgs e)
        {
            if(Report.IsFocused != true && SpecReport.IsFocused != true)
                OptionsPanel.Visibility = Visibility.Hidden;
        }

        private void BackgroundGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            OptionsPanel.Visibility = Visibility.Hidden;
        }

        private void OptionsPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }
    }
}
