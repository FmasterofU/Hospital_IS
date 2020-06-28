using Class_Diagram.Model.Appointments;
using Controller;
using Model.Rooms;
using Repository.Roomsninventory;
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
    /// Interaction logic for ControlReview.xaml
    /// </summary>
    public partial class ControlReview : Window
    {
        private DateTime selDate;
        private DateTime selTime;

        public ControlReview()
        {
            InitializeComponent();
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) ToEnglish();
            if (MainWindow.GetTheme() == MainWindow.Theme.Light) ToLightTheme();
            else if (MainWindow.GetTheme() == MainWindow.Theme.Dark) ToDarkTheme();
        }

        private void ToSerbian()
        {
            saveControlButton.Content = "Sačuvaj";
            backFromControlButton.Content = "Nazad";
        }

        private void ToEnglish()
        {
            saveControlButton.Content = "Save";
            backFromControlButton.Content = "Back";
        }

        private void ToLightTheme()
        {
        }

        private void ToDarkTheme()
        {
        }

        private void ControlReviewWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow.CenterDialog(this);
        }

        private void backFromControlButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveControlButton_Click(object sender, RoutedEventArgs e)
        {
            selDate = selDate.AddTicks(selTime.TimeOfDay.Ticks);
            if (!selDate.ToString().Equals(""))  ExaminationPage.getInstance().setControlDate(selDate);
            this.Close();
            //AppointmentController c = new AppointmentController();
            //c.SetStrategy("doctor");
            //c.AddAppointment(new Model.Appointments.Appointment(selDate, selDate.AddMinutes(30), ExaminationPage.getInstance().getMedRecord().GetId(), EditProfilePage.getInstance().getUser()), 
            //Model.Rooms.RoomType.examRoom, EditProfilePage.getInstance().getUser());
            //Model.Appointments.Appointment a =  new Model.Appointments.Appointment(selDate, selDate.AddMinutes(30), ExaminationPage.getInstance().getMedRecord().GetId());
            //c.AddAppointment(ref a, Model.Rooms.RoomType.examRoom, EditProfilePage.getInstance().getUser());
            //List<Term> free = c.RecommendAppointments(selDate, selDate.AddHours(30), EditProfilePage.getInstance().getUser());
            //foreach (Term t in free) Console.WriteLine(t.StartTime);
        }

        private void calendar_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? date = calendar.SelectedDate;
            if (date != null)
            {
                selDate = date.Value;
            }
            if (!selDate.ToString().Equals("")) saveControlButton.IsEnabled = true;
            else saveControlButton.IsEnabled = false;
        }

        public void setInitialDate(DateTime? initial)
        {
            calendar.SelectedDate = initial;
            timePicker.Value = initial;
            saveControlButton.IsEnabled = true;
        }

        private void TimePicker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            DateTime? time = timePicker.Value;
            if (time != null)
            {
                selTime = time.Value;
            }
        }
    }
}
