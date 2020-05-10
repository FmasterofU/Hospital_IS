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
    /// Interaction logic for DeleteDrug.xaml
    /// </summary>
    public partial class DeleteDrug : Window
    {
        public DeleteDrug()
        {
            InitializeComponent();
            List<String> drugList = DrugsPage.getDrugList();
            for(int i = 0; i < drugList.Count; i++) deleteDrugsComboBox.Items.Add(drugList[i]);
            deleteDrugsComboBox.SelectedIndex = 0;
        }

        private void DeleteDrugWindow_Closed(object sender, EventArgs e)
        {
            this.Close();
            DrugsPage.closeDeletion();
        }

        private void deleteDrugButton_Click(object sender, RoutedEventArgs e)
        {
            int index = deleteDrugsComboBox.SelectedIndex;
            deleteDrugsComboBox.Items.RemoveAt(index);
            DrugsPage d = DrugsPage.getInstance();
            d.deleteDrugFormList(index);
            deleteDrugsComboBox.SelectedIndex = 0;
            if (deleteDrugsComboBox.Items.Count == 0)   this.Close();
        }
    }
}
