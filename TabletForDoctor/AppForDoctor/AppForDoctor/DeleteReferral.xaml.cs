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
            AddReferralsToCombo();
            //refSet = RefferalsPage.getInstance().getRefSet();
            //foreach (string s in refSet) referralsCombo.Items.Add(s);
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

        private void AddReferralsToCombo()
        {
            refSet = RefferalsPage.getInstance().getRefSet();
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian)
            {
                foreach (string s in refSet)
                {
                    if (s.Equals("specialist")) referralsCombo.Items.Add("Uput lekaru specijalisti");
                    else if (s.Equals("lab")) referralsCombo.Items.Add("Uput za laboratoriju");
                    else if (s.Equals("accessory")) referralsCombo.Items.Add("Uput za pomagalo");
                    else if (s.Equals("hospital")) referralsCombo.Items.Add("Uput za bolničko lečenje");
                }
            }
            else if (MainWindow.GetLanguage() == MainWindow.Language.English)
            {
                foreach (string s in refSet)
                {
                    if (s.Equals("specialist")) referralsCombo.Items.Add("Referral to specialist");
                    else if (s.Equals("lab")) referralsCombo.Items.Add("Referral for laboratory");
                    else if (s.Equals("accessory")) referralsCombo.Items.Add("Referral for accessory");
                    else if (s.Equals("hospital")) referralsCombo.Items.Add("Referral for hospital care");
                }
            }
            referralsCombo.SelectedIndex = -1;
        }

        private void referralsCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (referralsCombo.SelectedIndex >= 0) deleteReferralButton.IsEnabled = true;
            else deleteReferralButton.IsEnabled = false;
        }

        private string GetSelectedRefType()
        {
            string option = referralsCombo.SelectedItem.ToString();
            if (option.Contains("laborator")) return "lab";
            else if (option.Contains("pomagalo") || option.Contains("accessory")) return "accessory";
            else if (option.Contains("bolni") || option.Contains("hospital")) return "hospital";
            else if (option.Contains("speci")) return "specialist";
            return "";
        }

        private void deleteReferralButton_Click(object sender, RoutedEventArgs e)
        {
            string selected = referralsCombo.SelectedItem.ToString();
            string type = GetSelectedRefType();
            RefferalsPage r = RefferalsPage.getInstance();
            r.DeleteReferralFromSet(type, selected);
            refSet.Remove(type);
            referralsCombo.Items.Remove(selected);
            if (refSet.Count == 0)
            {
                RefferalsPage.getInstance().disableDeleteButton();
                this.Close();
            }
        }
    }
}
