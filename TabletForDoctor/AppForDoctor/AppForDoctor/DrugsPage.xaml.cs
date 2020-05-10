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

namespace AppForDoctor
{
    /// <summary>
    /// Interaction logic for DrugsPage.xaml
    /// </summary>
    public partial class DrugsPage : Page
    {
        private static DeleteDrug delete = null;
        private static List<String> drugList = new List<String>();
        private static DrugsPage instance = null;
        public DrugsPage()
        {
            InitializeComponent();
            //TODO: load drugs from database
            drugListBox.Items.Add("Prvi");
            drugListBox.Items.Add("Drugi");
            drugListBox.Items.Add("Treci");
            drugListBox.Items.Add("Cetvrti");
            for (int i = 0; i < drugListBox.Items.Count; i++)
            {
                drugList.Add(drugListBox.Items[i].ToString());
            }
            instance = this;
        }

        public static DrugsPage getInstance()
        {
            return instance;
        }

        public void deleteDrugFormList(int index)
        {
            drugList.RemoveAt(index);
            drugListBox.Items.RemoveAt(index);
        }

        public static List<String> getDrugList()
        {
            return drugList;
        }

        public static void closeDeletion()
        {
            delete = null;
        }

        private void examinationFromDrugsButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = MainWindow.getInstance();
            w.changePage(2);
        }

        private void drugListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TODO: implement selection
        }

        private void deleteDrugButton_Click(object sender, RoutedEventArgs e)
        {
            delete = new DeleteDrug();
            delete.ShowDialog();
        }

        private void addDrugButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: implement adding new drug to patient
        }
    }
}
