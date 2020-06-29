using Model.Examination;
using Model.Medicalrecord;
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
        //private HashSet<string> refSet = new HashSet<string>();
        private HashSet<Model.Examination.Referral> referallSet = new HashSet<Model.Examination.Referral>();
        private RefferalsPage()
        {
            InitializeComponent();
            AddOldReferrals();
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
            referralsBefore.Content = "Previous referrals:";
            referralsNow.Content = "Added referrals:";
            addRefferalButton.Content = "Add referral";
            deleteRefferalButton.Content = "Delete referral";
            examinationFromRefferalsButton.Content = "Back";
            ChangeLanguageInList(false);
        }

        private void examinationFromRefferalsButton_Click(object sender, RoutedEventArgs e)
        {
            ExaminationPage.getInstance().saveAddedReferrals(referallSet);
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

        public void AddReferralToSet(Model.Examination.Referral referral)
        {
            referallSet.Add(referral);
            referralsNowListBox.Items.Add(referral.Type.ToString());
            deleteRefferalButton.IsEnabled = true;
        }

        public void disableAddButton()
        {
            addRefferalButton.IsEnabled = false;
        }

        public void disableDeleteButton()
        {
            deleteRefferalButton.IsEnabled = false;
        }

        public HashSet<Model.Examination.Referral> getRefSet()
        {
            return referallSet;
        }

        public HashSet<ReferralType> getRefTypeSet()
        {
            HashSet<ReferralType> ret = new HashSet<ReferralType>();
            foreach(Model.Examination.Referral r in referallSet)
            {
                ret.Add(r.Type);
            }
            return ret;
        }

        private void AddOldReferrals()
        {
            //HashSet<string> old = new HashSet<string>();
            HashSet<ReferralType> refs = new HashSet<ReferralType>();
            MedicalRecord mr = ExaminationPage.getInstance().getMedRecord();

            /*foreach(Examination e in mr.Examinations)
            {
                foreach (Referral r in e.Referrals) old.Add(r.RefType);
            }*/
            foreach(Model.Examination.Examination e in mr.Examination)
            {
                foreach (Model.Examination.Referral r in e.Referral) refs.Add(r.Type);
            }

            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian)
            {
                foreach (ReferralType s in refs)
                {
                    if (s == ReferralType.specialistExam) referralsBeforeListBox.Items.Add("Uput lekaru specijalisti");
                    else if (s == ReferralType.laboratory) referralsBeforeListBox.Items.Add("Uput za laboratoriju");
                    else if (s == ReferralType.medicalAccessory) referralsBeforeListBox.Items.Add("Uput za pomagalo");
                    else if (s == ReferralType.stationaryCare) referralsBeforeListBox.Items.Add("Uput za bolničko lečenje");
                }
            }
            else if (MainWindow.GetLanguage() == MainWindow.Language.English)
            {
                foreach (ReferralType s in refs)
                {
                    if (s == ReferralType.specialistExam) referralsBeforeListBox.Items.Add("Referral to specialist");
                    else if (s == ReferralType.laboratory) referralsBeforeListBox.Items.Add("Referral for laboratory");
                    else if (s == ReferralType.medicalAccessory) referralsBeforeListBox.Items.Add("Referral for accessory");
                    else if (s == ReferralType.stationaryCare) referralsBeforeListBox.Items.Add("Referral for hospital care");
                }
            }
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

                int oILab = referralsBeforeListBox.Items.IndexOf("Referral for laboratory");
                int oIAccessory = referralsBeforeListBox.Items.IndexOf("Referral for accessory");
                int oISpec = referralsBeforeListBox.Items.IndexOf("Referral to specialist");
                int oIHospital = referralsBeforeListBox.Items.IndexOf("Referral for hospital care");

                if (iLab >= 0)
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
                if (oILab >= 0)
                {
                    referralsBeforeListBox.Items.RemoveAt(oILab);
                    referralsBeforeListBox.Items.Insert(oILab, "Uput za laboratoriju");
                }
                if (oIAccessory >= 0)
                {
                    referralsBeforeListBox.Items.RemoveAt(oIAccessory);
                    referralsBeforeListBox.Items.Insert(oIAccessory, "Uput za pomagalo");
                }
                if (oISpec >= 0)
                {
                    referralsBeforeListBox.Items.RemoveAt(oISpec);
                    referralsBeforeListBox.Items.Insert(oISpec, "Uput lekaru specijalisti");
                }
                if (oIHospital >= 0)
                {
                    referralsBeforeListBox.Items.RemoveAt(oIHospital);
                    referralsBeforeListBox.Items.Insert(oIHospital, "Uput za bolničko lečenje");
                }
            }
            else
            {
                int iLab = referralsNowListBox.Items.IndexOf("Uput za laboratoriju");
                int iAccessory = referralsNowListBox.Items.IndexOf("Uput za pomagalo");
                int iSpec = referralsNowListBox.Items.IndexOf("Uput lekaru specijalisti");
                int iHospital = referralsNowListBox.Items.IndexOf("Uput za bolničko lečenje");

                int oILab = referralsBeforeListBox.Items.IndexOf("Uput za laboratoriju");
                int oIAccessory = referralsBeforeListBox.Items.IndexOf("Uput za pomagalo");
                int oISpec = referralsBeforeListBox.Items.IndexOf("Uput lekaru specijalisti");
                int oIHospital = referralsBeforeListBox.Items.IndexOf("Uput za bolničko lečenje");

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
                if (oILab >= 0)
                {
                    referralsBeforeListBox.Items.RemoveAt(oILab);
                    referralsBeforeListBox.Items.Insert(oILab, "Referral for laboratory");
                }
                if (oIAccessory >= 0)
                {
                    referralsBeforeListBox.Items.RemoveAt(oIAccessory);
                    referralsBeforeListBox.Items.Insert(oIAccessory, "Referral for accessory");
                }
                if (oISpec >= 0)
                {
                    referralsBeforeListBox.Items.RemoveAt(oISpec);
                    referralsBeforeListBox.Items.Insert(oISpec, "Referral to specialist");
                }
                if (oIHospital >= 0)
                {
                    referralsBeforeListBox.Items.RemoveAt(oIHospital);
                    referralsBeforeListBox.Items.Insert(oIHospital, "Referral for hospital care");
                }
            }
        }

        public void DeleteReferralFromSet(string refType)
        {
            //refSet.Remove(refType);
            //referralsNowListBox.Items.Remove(refName);
            Model.Examination.Referral del = null;
            foreach(Model.Examination.Referral r in referallSet)
            {
                if(r.Type.ToString().Equals(refType))
                {
                    del = r;
                    break;
                }
            }
            if(del != null)
            {
                referallSet.Remove(del);
                referralsNowListBox.Items.Remove(del.Type.ToString());
            }
            addRefferalButton.IsEnabled = true;
        }
    }
}
