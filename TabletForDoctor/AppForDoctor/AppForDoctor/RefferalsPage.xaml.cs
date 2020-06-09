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
        public static RefferalsPage instance = null;
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
        }

        private void ToEnglish()
        {
            referralsBefore.Content = "Current referrals:";
            referralsNow.Content = "Added referrals:";
            addRefferalButton.Content = "Add referral";
            deleteRefferalButton.Content = "Delete referral";
            examinationFromRefferalsButton.Content = "Back";
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
    }
}
