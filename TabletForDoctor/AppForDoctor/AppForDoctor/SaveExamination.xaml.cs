using Model.Medicalrecord;
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
    /// Interaction logic for SaveExamination.xaml
    /// </summary>
    public partial class SaveExamination : Window
    {
        public SaveExamination()
        {
            InitializeComponent();
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) ToEnglish();
        }

        private void ToSerbian()
        {
            label.Content = "Da li želite da sačuvate\nsve promene?";
            cancelSavingButton.Content = "Otkaži";
            noSavingButton.Content = "Ne";
            saveButton.Content = "Da";
        }

        private void ToEnglish()
        {
            label.Content = "Do you want to save all\nchanges?";
            cancelSavingButton.Content = "Cancel";
            noSavingButton.Content = "No";
            saveButton.Content = "Yes";
        }

        private void SaveExaminationWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow.CenterDialog(this);
        }

        private void cancelSavingButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            List<StringBuilder> reports = GetReportFromExamination();
            EditProfilePage.getInstance().AddReportSrb(reports[0]);
            EditProfilePage.getInstance().AddReportEng(reports[1]);
            MedHistoryPage.clearInstance();
            DrugsPage.clearInstance();
            RefferalsPage.clearInstance();
            ExaminationPage.clearInstance();
            MainWindow w = MainWindow.getInstance();
            w.changePage(1);
            this.Close();
        }

        private void noSavingButton_Click(object sender, RoutedEventArgs e)
        {
            MedHistoryPage.clearInstance();
            DrugsPage.clearInstance();
            RefferalsPage.clearInstance();
            ExaminationPage.clearInstance();
            MainWindow w = MainWindow.getInstance();
            w.changePage(1);
            this.Close();
        }

        private List<StringBuilder> GetReportFromExamination()
        {
            ExaminationPage e = ExaminationPage.getInstance();
            MedicalRecord mr = e.getMedRecord();
            Patient patient = mr.patient;
            Doctor doctor = EditProfilePage.getInstance().getUser();

            StringBuilder retEng = new StringBuilder();
            StringBuilder retSrb = new StringBuilder();

            retSrb.Append("Pregled održan: ");
            retEng.Append("Examination: ");
            retSrb.Append(DateTime.Now.ToString() + "\n");
            retEng.Append(DateTime.Now.ToString() + "\n");

            retSrb.Append("Pacijent: ");
            retEng.Append("Patient: ");
            //retSrb.Append(patient.Name + " " + patient.Surname + ", star(a) " + patient.Age + " godina.\n");
            //retEng.Append(patient.Name + " " + patient.Surname + ", age " + patient.Age + "\n");

            retSrb.Append("Dijagnoza: ");
            retEng.Append("Diagnosis: ");
            retSrb.Append(e.getDiagnosis() + "\n");
            retEng.Append(e.getDiagnosis() + "\n");

            retSrb.Append("Prepisani lekovi: \n");
            retEng.Append("Prescribed drugs: \n");
            retSrb.Append(ExaminationPage.DictToString(e.getRecipes()) + "\n");
            retEng.Append(ExaminationPage.DictToString(e.getRecipes()) + "\n");

            retSrb.Append("Pregled obavio/la: ");
            retEng.Append("By: ");
            retSrb.Append(doctor.Name + " " + doctor.Surname + "\n");
            retEng.Append(doctor.Name + " " + doctor.Surname + "\n");

            List<StringBuilder> ret = new List<StringBuilder>();
            ret.Add(retSrb);
            ret.Add(retEng);

            return ret;
        }
    }
}
