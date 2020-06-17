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
    /// Interaction logic for DrugsAddView.xaml
    /// </summary>
    public partial class DrugsAddView : UserControl
    {
        public DrugsAddView()
        {
            InitializeComponent();
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).ClearFromFirstUserControlUp();
        }

        private void PanelGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int num;
            if (NameTextBox.Text.Length != 0 && Int32.TryParse(ThresholdTextBox.Text, out num))
            {
                DrugsAddViewModel.Add(NameTextBox.Text, num);
                ((MainWindow)Application.Current.MainWindow).ClearFromFirstUserControlUp();
            }
            else
            {
                if(NameTextBox.Text.Length != 0)
                    NameTextBox.BorderBrush = Brushes.Red;
                if(Int32.TryParse(ThresholdTextBox.Text, out num))
                    ThresholdTextBox.BorderBrush = Brushes.Red;
            }
        }
    }
}
