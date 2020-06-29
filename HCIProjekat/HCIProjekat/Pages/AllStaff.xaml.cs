using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model.Roles;
using Controller;

namespace HCIProjekat.Pages
{
    /// <summary>
    /// Interaction logic for AllStaff.xaml
    /// </summary>
    public partial class AllStaff : Page
    {
        private UserController userController = new UserController();
        private ObservableCollection<Staff> zaposleni = new ObservableCollection<Staff>();
        private Staff radnik = null;
        public AllStaff()
        {
            InitializeComponent();
            foreach(Staff radnik in userController.GetAllStaff())
            {
                dg_pronadjeni_zaposleni.Items.Add(radnik);
            }
        }

        private void BtnPocetna_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).FullMainWindow.Content = new HomePage();
        }

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            var frame = ((MainWindow)Application.Current.MainWindow).FullMainWindow;
            frame.Content = new LogPage();
        }

        private void GroupBox_Loaded(object sender, RoutedEventArgs e)
        {
            
            stStaffInfo.Children.Clear();
            stStaffInfo.Children.Add( new UserControls.StaffProfile(null)); // u slucaju pokretanja na pocetku ce biti prazan groupbox
            btn_prikazTermina.IsEnabled = false;
            btn_radniKalendar.IsEnabled = false;
        }

        private void BtnPrikaziTermine_Click(object sender, RoutedEventArgs e)
        {
            stStaffInfo.Children.Clear();
           // stStaffInfo.Children.Add(new UserControls.DoctorTermsUC(radnik)); //prikaz doktorovih termina
            btns_opcije.Visibility = Visibility.Hidden;
            btn_doctor_profile.Visibility = Visibility.Visible;
        }

        private void BtnRadniKalendar_Click(object sender, RoutedEventArgs e)
        {
                Dialogs.ChoseDate dijalog = new Dialogs.ChoseDate();
                dijalog.ShowDialog();
                DateTime[] vremenskiOpseg = dijalog.getVremenskiOpseg();
                if (vremenskiOpseg[0] != DateTime.MinValue)
                {
                    stStaffInfo.Children.Clear();
                    stStaffInfo.Children.Add( new UserControls.ListDoctorAppointmentsUC(vremenskiOpseg[0],vremenskiOpseg[1],(Doctor)radnik));
                    btns_opcije.Visibility = Visibility.Hidden;
                    btn_doctor_profile.Visibility = Visibility.Visible;
                   
                }

           
        }

        private void BtnPratrazi_Click(object sender, RoutedEventArgs e)
        {
            dg_pronadjeni_zaposleni.Items.Clear();

            

            if (cmbStaffType.SelectedIndex == 0) //svi zaposleni
            {
                foreach (Staff pronadjeniRadnik in userController.GetAllStaff())
                {
                    if (ContainsSearchValues(pronadjeniRadnik))
                        dg_pronadjeni_zaposleni.Items.Add(pronadjeniRadnik);
                }
            }
            else if (cmbStaffType.SelectedIndex == 1) //svi doktori
            {
                foreach(Staff pronadjeniDoktor in userController.GetDoctors())
                {
                    if (ContainsSearchValues(pronadjeniDoktor))
                    {
                        if (cmbDoctorSpeciality.SelectedIndex == 0)
                            dg_pronadjeni_zaposleni.Items.Add(pronadjeniDoktor);
                        else if (pronadjeniDoktor.UserType.Equals(UserType.Specialist))
                        {
                            Specialist specialist = (Specialist)pronadjeniDoktor;
                            if (specialist.Specialization.Equals(cmbDoctorSpeciality.Text))
                                dg_pronadjeni_zaposleni.Items.Add(pronadjeniDoktor);
                        }        
                    }
                }
            }
            else if (cmbStaffType.SelectedIndex == 2)
            {
                foreach (Staff pronadjeniSekretar in userController.GetSecretary())
                {
                    if (ContainsSearchValues(pronadjeniSekretar))
                        dg_pronadjeni_zaposleni.Items.Add(pronadjeniSekretar);
                }
            }
            else if (cmbStaffType.SelectedIndex == 3)
            {
                foreach (Staff pronadjeniMenadzer in userController.GetManagers())
                {
                    if (ContainsSearchValues(pronadjeniMenadzer))
                        dg_pronadjeni_zaposleni.Items.Add(pronadjeniMenadzer);
                }
            }
        }

        private bool ContainsSearchValues(Staff staff)
        {
            return staff.GetId().ToString().Contains(txt_jmbg.Text) && staff.Name.Contains(txt_ime.Text) && staff.Surname.Contains(txt_prezime.Text) && staff.Sex.Equals(getPol());
        }

        private Sex getPol()
        {
            Sex pol = Sex.potato;
            if (rb_pol_m.IsChecked == true)
                pol = Sex.male;
            else if (rb_pol_z.IsChecked == true)
                pol = Sex.female;
            return pol;
        }

        private void btn_doctor_profile_Click(object sender, RoutedEventArgs e)
        {
            stStaffInfo.Children.Clear();
            stStaffInfo.Children.Add(new UserControls.StaffProfile(radnik)); // povratak na profil selektovanog radnika
            btn_doctor_profile.Visibility = Visibility.Hidden;
            btns_opcije.Visibility = Visibility.Visible;
        }

        private void CmbStaffType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (cmbStaffType.SelectedItem == cmbItemDoctor)
            {
                cmbDoctorSpeciality.IsEnabled = true;
            }
            else
            {
                if (cmbDoctorSpeciality != null)
                {
                    cmbDoctorSpeciality.SelectedIndex = 0;
                    cmbDoctorSpeciality.IsEnabled = false;
                }
            }
        }

        private void dg_pronadjeni_zaposleni_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            radnik = dg_pronadjeni_zaposleni.SelectedItem as Staff;
            if (radnik.UserType.Equals(UserType.Doctor))
            {
                btn_prikazTermina.IsEnabled = true;
                btn_radniKalendar.IsEnabled = true;
            }
            else
            {
                btn_prikazTermina.IsEnabled = false;
                btn_radniKalendar.IsEnabled = false;
            }
            stStaffInfo.Children.Clear();
            stStaffInfo.Children.Add(new UserControls.StaffProfile(radnik));
        }

        public Staff getZaposleni()
        {
            return radnik;
        }
    }
}
