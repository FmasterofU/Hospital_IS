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
    /// Interaction logic for MedHistoryPage.xaml
    /// </summary>
    public partial class MedHistoryPage : Page
    {
        private static MedHistoryPage instance = null;
        private StringBuilder history = new StringBuilder();
        private MedHistoryPage()
        {
            InitializeComponent();
            MedicalRecord mr = ExaminationPage.getInstance().getMedRecord();
            history = new StringBuilder();
            /*foreach(Examination e in mr.Examinations)
            {
                if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) history.Append("Anamneza: ");
                else if (MainWindow.GetLanguage() == MainWindow.Language.English) history.Append("Anamnesis: ");
                history.Append(e.Anamnesis + "\n");

                if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) history.Append("Lekovi: ");
                else if (MainWindow.GetLanguage() == MainWindow.Language.English) history.Append("Drugs: ");

                foreach (Prescription p in e.Prescriptions)
                {
                    history.Append(p.Drug.Name + " *" + p.Drug.Amount + " : " + p.Usage + "\n");
                }

                if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) history.Append("Uputi: \n");
                else if (MainWindow.GetLanguage() == MainWindow.Language.English) history.Append("Referrals: \n");

                foreach(Referral r in e.Referrals)
                {
                    history.Append(r.RefType + " : " + r.Note + "\n");
                }
                history.Append("**********************************\n\n");
            }*/
            foreach(Model.Examination.Examination e in mr.Examination)
            {
                if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) history.Append("Dijagnoza: ");
                else if (MainWindow.GetLanguage() == MainWindow.Language.English) history.Append("Diagnosis: ");
                history.Append(e.Diagnosis + "\n");

                if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) history.Append("Lekovi: ");
                else if (MainWindow.GetLanguage() == MainWindow.Language.English) history.Append("Drugs: ");

                foreach(Model.Examination.Prescription p in e.Prescription) history.Append(p.drug.Name + " *" + p.Number + " : " + p.Usage + "\n");

                if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) history.Append("Uputi: \n");
                else if (MainWindow.GetLanguage() == MainWindow.Language.English) history.Append("Referrals: \n");

                foreach (Model.Examination.Referral r in e.Referral) history.Append(r.Type + " : " + r.Note + "\n");

                history.Append("**********************************\n\n");
            }

            historyText.Text = history.ToString();
        }

        public static MedHistoryPage getInstance()
        {
            if (instance == null) instance = new MedHistoryPage();
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) instance.ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) instance.ToEnglish();
            return instance;
        }

        private void ToSerbian()
        {
            examinationFromHistoryButton.Content = "Nazad";
        }

        private void ToEnglish()
        {
            examinationFromHistoryButton.Content = "Back";
        }

        private void examinationFromHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = MainWindow.getInstance();
            w.changePage(2);
        }

        public static void clearInstance()
        {
            instance = null;
        }

        public StringBuilder getHistory()
        {
            return history;
        }
    }
}
