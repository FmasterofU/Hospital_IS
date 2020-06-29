using Model.Examination;
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
        private HashSet<Model.Examination.Referral> reffSet = new HashSet<Model.Examination.Referral>();
        public DeleteReferral()
        {
            InitializeComponent();
            AddReferralsToCombo();
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
            reffSet = RefferalsPage.getInstance().getRefSet();
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian)
            {
                foreach (Model.Examination.Referral r in reffSet)
                {
                    if (r.Type == ReferralType.specialistExam) referralsCombo.Items.Add("Uput lekaru specijalisti");
                    else if (r.Type == ReferralType.laboratory) referralsCombo.Items.Add("Uput za laboratoriju");
                    else if (r.Type == ReferralType.medicalAccessory) referralsCombo.Items.Add("Uput za pomagalo");
                    else if (r.Type == ReferralType.stationaryCare) referralsCombo.Items.Add("Uput za bolničko lečenje");
                }
            }
            else if (MainWindow.GetLanguage() == MainWindow.Language.English)
            {
                foreach (Model.Examination.Referral r in reffSet)
                {
                    if (r.Type == ReferralType.specialistExam) referralsCombo.Items.Add("Referral to specialist");
                    else if (r.Type == ReferralType.laboratory) referralsCombo.Items.Add("Referral for laboratory");
                    else if (r.Type == ReferralType.medicalAccessory) referralsCombo.Items.Add("Referral for accessory");
                    else if (r.Type == ReferralType.stationaryCare) referralsCombo.Items.Add("Referral for hospital care");
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
            if (option.Contains("laborator")) return ReferralType.laboratory.ToString();
            else if (option.Contains("pomagalo") || option.Contains("accessory")) return ReferralType.medicalAccessory.ToString();
            else if (option.Contains("bolni") || option.Contains("hospital")) return ReferralType.stationaryCare.ToString();
            else if (option.Contains("speci")) return ReferralType.specialistExam.ToString();
            return "";
        }

        private void deleteReferralButton_Click(object sender, RoutedEventArgs e)
        {
            string selected = referralsCombo.SelectedItem.ToString();
            string type = GetSelectedRefType();
            RefferalsPage r = RefferalsPage.getInstance();
            r.DeleteReferralFromSet(type);
            Model.Examination.Referral del = null;
            foreach(Model.Examination.Referral rr in reffSet)
            {
                if(rr.Type.ToString().Equals(type))
                {
                    del = rr;
                    break;
                }
            }
            if (del != null) reffSet.Remove(del);
            referralsCombo.Items.Remove(selected);
            if (reffSet.Count == 0)
            {
                RefferalsPage.getInstance().disableDeleteButton();
                this.Close();
            }
        }
    }
}
