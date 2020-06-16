using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppForDoctor
{
    /// <summary>
    /// Interaction logic for OpenExamination.xaml
    /// </summary>
    public partial class OpenExamination : Window
    {
        public OpenExamination()
        {
            InitializeComponent();
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) ToEnglish();
        }

        private void ToSerbian()
        {
            nameLabel.Content = "Ime";
            cancelButton.Content = "Otkaži";
            acceptButton.Content = "Nastavi";
            mainLabel.Content = "Izaberite pacijenta";
        }

        private void ToEnglish()
        {
            nameLabel.Content = "Name";
            cancelButton.Content = "Cancel";
            acceptButton.Content = "Continue";
            mainLabel.Content = "Choose patient";
        }

        private void OpenExaminationWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow.CenterDialog(this);
        }

        private void idSearchButton_Click(object sender, RoutedEventArgs e)
        {
            patientsComboBox.Items.Clear();
            patientsComboBox.SelectedIndex = -1;
            MedRecord mr = MedRecordList.getMedHistory(idText.Text);
            if (mr == null) return;
            User patient = UserList.getByID(mr.PatientID);
            patientsComboBox.Items.Add(patient.Name + " " + patient.Surname + "\nID = " + patient.PatientID);
            patientsComboBox.SelectedIndex = 0;
        }

        private void nameSearchButton_Click(object sender, RoutedEventArgs e)
        {
            patientsComboBox.Items.Clear();
            patientsComboBox.SelectedIndex = -1;
            List<User> users = UserList.getPatientByName(nameText.Text);
            if (users.Count == 0) return;
            
            foreach(User u in users)
                patientsComboBox.Items.Add(u.Name + " " + u.Surname + "\nID = " + u.PatientID);
            patientsComboBox.SelectedIndex = 0;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void nameText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Enter) nameSearchButton.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        private void idText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Enter) idSearchButton.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            string[] parts = patientsComboBox.SelectedItem.ToString().Split('=');
            string id = parts[1].Trim();
            MedRecord mr = MedRecordList.getMedHistory(id);
            if (mr == null) return;
            MainMenuPage.clearInstance();
            ExaminationPage.getInstance(mr);
            MainWindow w = MainWindow.getInstance();
            w.changePage(2);
            this.Close();
        }

        private void patientsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (patientsComboBox.SelectedIndex >= 0) acceptButton.IsEnabled = true;
            else acceptButton.IsEnabled = false;
        }
    }
}
