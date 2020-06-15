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
    /// Interaction logic for RefferalsPage.xaml
    /// </summary>
    public partial class RefferalsPage : Page
    {
        private static RefferalsPage instance = null;
        private HashSet<string> refSet = new HashSet<string>();
        private RefferalsPage()
        {
            InitializeComponent();
        }

        public static RefferalsPage getInstance()
        {
            if (instance == null) instance = new RefferalsPage();
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) instance.ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) instance.ToEnglish();
            return instance;
        }

        private void ToSerbian()
        {
            referralsBefore.Content = "Dosadašnji uputi:";
            referralsNow.Content = "Dodati uputi:";
            addRefferalButton.Content = "Dodaj uput";
            deleteRefferalButton.Content = "Obriši uput";
            examinationFromRefferalsButton.Content = "Nazad";
            ChangeLanguageInList(true);
        }

        private void ToEnglish()
        {
            referralsBefore.Content = "Current referrals:";
            referralsNow.Content = "Added referrals:";
            addRefferalButton.Content = "Add referral";
            deleteRefferalButton.Content = "Delete referral";
            examinationFromRefferalsButton.Content = "Back";
            ChangeLanguageInList(false);
        }

        private void examinationFromRefferalsButton_Click(object sender, RoutedEventArgs e)
        {
            ExaminationPage.getInstance().saveAddedReferrals(refSet);
            MainWindow w = MainWindow.getInstance();
            w.changePage(2);
        }

        public static void clearInstance()
        {
            instance = null;
        }

        private void addRefferalButton_Click(object sender, RoutedEventArgs e)
        {
            AddReferral a = new AddReferral();
            a.ShowDialog();
        }

        public void AddReferralToSet(string refType, string refName)
        {
            refSet.Add(refType);
            referralsNowListBox.Items.Add(refName);
            deleteRefferalButton.IsEnabled = true;
        }

        public void disableAddButton()
        {
            addRefferalButton.IsEnabled = false;
        }

        public HashSet<string> getRefSet()
        {
            return refSet;
        }

        private void deleteRefferalButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteReferral d = new DeleteReferral();
            d.ShowDialog();
        }

        private void ChangeLanguageInList(bool toSerbian)
        {
            if(toSerbian)
            {
                int iLab = referralsNowListBox.Items.IndexOf("Referral for laboratory");
                int iAccessory = referralsNowListBox.Items.IndexOf("Referral for accessory");
                int iSpec = referralsNowListBox.Items.IndexOf("Referral to specialist");
                int iHospital = referralsNowListBox.Items.IndexOf("Referral for hospital care");
                if(iLab >= 0)
                {
                    referralsNowListBox.Items.RemoveAt(iLab);
                    referralsNowListBox.Items.Insert(iLab, "Uput za laboratoriju");
                }
                if(iAccessory >= 0)
                {
                    referralsNowListBox.Items.RemoveAt(iAccessory);
                    referralsNowListBox.Items.Insert(iAccessory, "Uput za pomagalo");
                }
                if(iSpec >= 0)
                {
                    referralsNowListBox.Items.RemoveAt(iSpec);
                    referralsNowListBox.Items.Insert(iSpec, "Uput lekaru specijalisti");
                }
                if(iHospital >= 0)
                {
                    referralsNowListBox.Items.RemoveAt(iHospital);
                    referralsNowListBox.Items.Insert(iHospital, "Uput za bolničko lečenje");
                }
            }
            else
            {
                int iLab = referralsNowListBox.Items.IndexOf("Uput za laboratoriju");
                int iAccessory = referralsNowListBox.Items.IndexOf("Uput za pomagalo");
                int iSpec = referralsNowListBox.Items.IndexOf("Uput lekaru specijalisti");
                int iHospital = referralsNowListBox.Items.IndexOf("Uput za bolničko lečenje");
                if (iLab >= 0)
                {
                    referralsNowListBox.Items.RemoveAt(iLab);
                    referralsNowListBox.Items.Insert(iLab, "Referral for laboratory");
                }
                if (iAccessory >= 0)
                {
                    referralsNowListBox.Items.RemoveAt(iAccessory);
                    referralsNowListBox.Items.Insert(iAccessory, "Referral for accessory");
                }
                if (iSpec >= 0)
                {
                    referralsNowListBox.Items.RemoveAt(iSpec);
                    referralsNowListBox.Items.Insert(iSpec, "Referral to specialist");
                }
                if (iHospital >= 0)
                {
                    referralsNowListBox.Items.RemoveAt(iHospital);
                    referralsNowListBox.Items.Insert(iHospital, "Referral for hospital care");
                }
            }
        }
    }
}
