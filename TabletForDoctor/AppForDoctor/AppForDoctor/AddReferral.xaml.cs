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
    /// Interaction logic for AddReferral.xaml
    /// </summary>
    public partial class AddReferral : Window
    {
        //TODO: read isSpecialist from database
        private bool isSpecialist = true;
        public AddReferral()
        {
            InitializeComponent();

            AddAlowedReferrals();
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) ToEnglish();
        }

        private void ToSerbian()
        {
            backFromAddButton.Content = "Nazad";
            addReferralButton.Content = "Dodaj";
        }

        private void ToEnglish()
        {
            backFromAddButton.Content = "Back";
            addReferralButton.Content = "Add";
        }

        private void AddReferralWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow.CenterDialog(this);
        }

        private void backFromAddButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddAlowedReferrals()
        {
            if(MainWindow.GetLanguage() == MainWindow.Language.Serbian)
            {
                referralsCombo.Items.Add("Uput lekaru specijalisti");
                referralsCombo.Items.Add("Uput za laboratoriju");
                referralsCombo.Items.Add("Uput za pomagalo");
                if (isSpecialist) referralsCombo.Items.Add("Uput za bolnicko lecenje");
            }
            else if (MainWindow.GetLanguage() == MainWindow.Language.English)
            {
                referralsCombo.Items.Add("Referral to specialist");
                referralsCombo.Items.Add("Referral for laboratory");
                referralsCombo.Items.Add("Referral for accessory");
                if (isSpecialist) referralsCombo.Items.Add("Referral for hospital care");
            }
            referralsCombo.SelectedIndex = 0;
        }
    }
}
