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
    /// Interaction logic for MySchedulePage.xaml
    /// </summary>
    public partial class MySchedulePage : Page
    {
        private static MySchedulePage instance = null;
        private MySchedulePage()
        {
            InitializeComponent();
            calendar.SelectedDate = DateTime.Now;
        }

        public static MySchedulePage getInstance()
        {
            if (instance == null) instance = new MySchedulePage();
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) instance.ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) instance.ToEnglish();
            return instance;
        }

        private void ToSerbian()
        {
            menuFromSchedule.Content = "Meni";
            ChangeErrorMessage(true);
        }

        private void ToEnglish()
        {
            menuFromSchedule.Content = "Menu";
            ChangeErrorMessage(false);
        }

        private void menuFromSchedule_Click(object sender, RoutedEventArgs e)
        {
            instance = null;
            MainWindow w = MainWindow.getInstance();
            w.changePage(1);
        }

        public static void clearInstance()
        {
            instance = null;
        }

        private void calendar_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            appointmentsList.Items.Clear();
            DateTime? date = calendar.SelectedDate;
            DateTime selDate;
            if (date == null) return;
            selDate = date.Value;
            List<Appointment> list = AppointmentList.getByDate(selDate);
            if (list.Count == 0)
            {
                if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) appointmentsList.Items.Add("Nemate zakazanih pregleda za odabrani datum.");
                else if (MainWindow.GetLanguage() == MainWindow.Language.English) appointmentsList.Items.Add("You don't have scheduled appointments for selected date.");
                return;
            }
            foreach(Appointment a in list)
            {
                User u = UserList.getByID(a.PatientID);
                appointmentsList.Items.Add(a.Date.ToString() + "\t" + a.Room + "\t" + u.Name + " " + u.Surname);
            }
        }

        private void ChangeErrorMessage(bool isSerbian)
        {
            if(isSerbian && appointmentsList.Items.GetItemAt(0).ToString().Contains("scheduled"))
            {
                appointmentsList.Items.Clear();
                appointmentsList.Items.Add("Nemate zakazanih pregleda za odabrani datum.");
            }
            else if(!isSerbian && appointmentsList.Items.GetItemAt(0).ToString().Contains("Nemate"))
            {
                appointmentsList.Items.Clear();
                appointmentsList.Items.Add("You don't have scheduled appointments for selected date.");
            }
        }
    }
}
