using ManagingDirectorMobile.Model;
using ManagingDirectorMobile.ViewModel;
using Model.Medicine;
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
    public partial class DrugsView : UserControl, IRemoveSelection
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


        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            DrugListDG.ItemsSource = null;
            if (SearchTexBox.Text.Equals(""))
                ((DrugsViewModel)this.DataContext).Search();
            else
                ((DrugsViewModel)this.DataContext).Search(SearchTexBox.Text);
            DrugListDG.ItemsSource = ((DrugsViewModel)this.DataContext).drugs;
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).cntrlZ2.Content = new RemovalViewModel("Hydroxychloroquine" + " iz upotrebe", this);
        }

        public void RemoveSelectedItem()
        {
            ((DrugsViewModel)this.DataContext).Remove(DrugListDG.SelectedItem as Drug);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).cntrlZ2.Content = new DrugsAddViewModel();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).cntrlZ2.Content = new DrugsChangeViewModel(DrugListDG.SelectedItem as Drug);
        }

        private void SupplyButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ShowHistoricalDataButton_Click(object sender, RoutedEventArgs e)
        {
            Drug drug = DrugListDG.SelectedItem as Drug;
            ((MainWindow)Application.Current.MainWindow).cntrlZ2.Content = new DrugsHistoryViewModel(drug);
        }

        private void DrugListDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as DataGrid).SelectedItem != null)
            {
                ShowHistoricalDataButton.IsEnabled = true;
                EditButton.IsEnabled = true;
                RemoveButton.IsEnabled = true;
            }
            else
            {
                ShowHistoricalDataButton.IsEnabled = false;
                EditButton.IsEnabled = false;
                RemoveButton.IsEnabled = false;
            }
        }


        private void Report_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //;
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            ReportViewModel.DrugsReport();
        }
    }
}
