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
    /// Interaction logic for MedEquipmentView.xaml
    /// </summary>
    public partial class MedEquipmentView : UserControl, IRemoveSelection
    {
        public MedEquipmentView()
        {
            InitializeComponent();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).ClearFromFirstUserControlUp();
            ((MainWindow)Application.Current.MainWindow).cntrlZ2.Content = new MenuViewModel();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).cntrlZ2.Content = new MedEquipmentItemAddViewModel();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).cntrlZ2.Content = new MedEquipmentAddViewModel();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).cntrlZ2.Content = new RemovalViewModel("Ultrazvuk" + " iz upotrebe", this);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MedEqTypesListDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void RemoveSelectedItem()
        {
            throw new NotImplementedException();
        }
    }
}
