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
    /// Interaction logic for DeleteReferral.xaml
    /// </summary>
    public partial class DeleteReferral : Window
    {
        private HashSet<String> refSet = new HashSet<string>();
        public DeleteReferral()
        {
            InitializeComponent();
            refSet = RefferalsPage.getInstance().getRefSet();
            foreach (string s in refSet) referralsCombo.Items.Add(s);
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) ToEnglish();
        }

        private void ToSerbian()
        {
            backFromDeleteButton.Content = "Nazad";
            deleteReferralButton.Content = "Obriši";
        }

        private void ToEnglish()
        {
            backFromDeleteButton.Content = "Back";
            deleteReferralButton.Content = "Delete";
        }

        private void DeleteReferralWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow.CenterDialog(this);
        }

        private void backFromDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
