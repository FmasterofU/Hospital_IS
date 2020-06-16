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
    /// Interaction logic for MedEquipmentItemAddView.xaml
    /// </summary>
    public partial class MedEquipmentItemAddView : UserControl
    {
        public MedEquipmentItemAddView()
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

        private void RoomListDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
