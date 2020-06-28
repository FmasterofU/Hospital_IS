using Model.Examination;
using Model.Roles;
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
        //private HashSet<string> refSet = new HashSet<string>();
        private HashSet<ReferralType> reffSet = new HashSet<ReferralType>();
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
            labAnalysisTypeLabel.Content = "Tip analize:";
            accessoryTypeLabel.Content = "Tip pomagala:";
            specialistTypeLabel.Content = "Tip specijaliste:";
            causeForLabGroup.Header = "Razlog upućivanja:";
            causeForAccessoryGroup.Header = "Razlog upućivanja:";
            causeForHospitalGroup.Header = "Razlog upućivanja:";
            causeForSpecialistGroup.Header = "Razlog upućivanja:";
        }

        private void ToEnglish()
        {
            backFromAddButton.Content = "Back";
            addReferralButton.Content = "Add";
            labAnalysisTypeLabel.Content = "Analysis type:";
            accessoryTypeLabel.Content = "Accessory type:";
            specialistTypeLabel.Content = "Specialist's type:";
            causeForLabGroup.Header = "Cause for referral:";
            causeForAccessoryGroup.Header = "Cause for referral:";
            causeForHospitalGroup.Header = "Cause for referral:";
            causeForSpecialistGroup.Header = "Cause for referral:";
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
            reffSet.Add(ReferralType.specialistExam);
            reffSet.Add(ReferralType.laboratory);
            reffSet.Add(ReferralType.medicalAccessory);
            if (EditProfilePage.getInstance().getUser().UserType == UserType.Specialist) reffSet.Add(ReferralType.stationaryCare);
            reffSet.ExceptWith(RefferalsPage.getInstance().getRefTypeSet());

            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian)
            {
                foreach(ReferralType s in reffSet)
                {
                    if (s == ReferralType.specialistExam) referralsCombo.Items.Add("Uput lekaru specijalisti");
                    else if (s == ReferralType.laboratory) referralsCombo.Items.Add("Uput za laboratoriju");
                    else if (s == ReferralType.medicalAccessory) referralsCombo.Items.Add("Uput za pomagalo");
                    else if (s == ReferralType.stationaryCare) referralsCombo.Items.Add("Uput za bolničko lečenje");
                }
            }
            else if (MainWindow.GetLanguage() == MainWindow.Language.English)
            {
                foreach (ReferralType s in reffSet)
                {
                    if (s == ReferralType.specialistExam) referralsCombo.Items.Add("Referral to specialist");
                    else if (s == ReferralType.laboratory) referralsCombo.Items.Add("Referral for laboratory");
                    else if (s == ReferralType.medicalAccessory) referralsCombo.Items.Add("Referral for accessory");
                    else if (s == ReferralType.stationaryCare) referralsCombo.Items.Add("Referral for hospital care");
                }
            }
            referralsCombo.SelectedIndex = -1;
        }

        private void referralsCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearEnteredData();
            if (referralsCombo.SelectedIndex >= 0)
            {
                string option = referralsCombo.SelectedItem.ToString();
                if (option.Contains("laborator")) laboratoryPanel.Visibility = Visibility.Visible;
                else if (option.Contains("pomagalo") || option.Contains("accessory")) accessoryPanel.Visibility = Visibility.Visible;
                else if (option.Contains("bolni") || option.Contains("hospital")) hospitalCarePanel.Visibility = Visibility.Visible;
                else if (option.Contains("speci")) specialistPanel.Visibility = Visibility.Visible;
            }
        }

        private void ClearEnteredData()
        {
            laboratoryPanel.Visibility = Visibility.Hidden;
            accessoryPanel.Visibility = Visibility.Hidden;
            hospitalCarePanel.Visibility = Visibility.Hidden;
            specialistPanel.Visibility = Visibility.Hidden;

            labAnalysisTypeTextBox.Text = "";
            causeForLabText.Text = "";

            accessoryTypeTextBox.Text = "";
            causeForAccessoryText.Text = "";

            causeForHospitalText.Text = "";

            specialistTypeTextBox.Text = "";
            causeForSpecialistText.Text = "";
        }

        private bool CanISaveReferral()
        {
            if (referralsCombo.SelectedIndex >= 0)
            {
                string option = referralsCombo.SelectedItem.ToString();
                if (option.Contains("laborator"))
                {
                    if (!labAnalysisTypeTextBox.Text.Trim().Equals("") && !causeForLabText.Text.Trim().Equals("")) return true;
                    else return false;
                }
                else if (option.Contains("pomagalo") || option.Contains("accessory"))
                {
                    if (!accessoryTypeTextBox.Text.Trim().Equals("") && !causeForAccessoryText.Text.Trim().Equals("")) return true;
                    else return false;
                }
                else if (option.Contains("bolni") || option.Contains("hospital"))
                {
                    if (!causeForHospitalText.Text.Trim().Equals("")) return true;
                    else return false;
                }
                else if (option.Contains("speci"))
                {
                    if (!specialistTypeTextBox.Text.Trim().Equals("") && !causeForSpecialistText.Text.Trim().Equals("")) return true;
                    else return false;
                }
                    return false;
            }
            return false;
        }

        private void InputTextChanged(object sender, TextChangedEventArgs e)
        {
            if (CanISaveReferral()) addReferralButton.IsEnabled = true;
            else addReferralButton.IsEnabled = false;
        }

        private ReferralType GetSelectedRefType()
        {
            string option = referralsCombo.SelectedItem.ToString();
            if (option.Contains("laborator")) return ReferralType.laboratory;
            else if (option.Contains("pomagalo") || option.Contains("accessory")) return ReferralType.medicalAccessory;
            else if (option.Contains("bolni") || option.Contains("hospital")) return ReferralType.stationaryCare;
            else return ReferralType.specialistExam;
            //return "";
        }

        private void addReferralButton_Click(object sender, RoutedEventArgs e)
        {
            string selected = referralsCombo.SelectedItem.ToString();
            ReferralType type = GetSelectedRefType();
            RefferalsPage r = RefferalsPage.getInstance();
            string cause = "";
            if (type == ReferralType.specialistExam) cause = causeForSpecialistText.Text;
            else if (type == ReferralType.medicalAccessory) cause = causeForAccessoryText.Text;
            else if (type == ReferralType.stationaryCare) cause = causeForHospitalText.Text;
            else if (type == ReferralType.laboratory) cause = causeForLabText.Text;
            Model.Examination.Referral rr = new Model.Examination.Referral(type, cause, type == ReferralType.medicalAccessory ? accessoryTypeTextBox.Text : "", null);
            r.AddReferralToSet(rr);
            reffSet.Remove(type);
            referralsCombo.Items.Remove(selected);
            /*if (refSet.Count == 0)
            {
                RefferalsPage.getInstance().disableAddButton();
                this.Close();
            }*/
        }
    }
}
