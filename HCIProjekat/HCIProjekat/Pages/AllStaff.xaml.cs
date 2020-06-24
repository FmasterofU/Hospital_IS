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

namespace HCIProjekat.Pages
{
    /// <summary>
    /// Interaction logic for AllStaff.xaml
    /// </summary>
    public partial class AllStaff : Page
    {
        private ObservableCollection<Model.Zaposleni> zaposleni = new ObservableCollection<Model.Zaposleni>();
        private Model.Zaposleni radnik = null;
        public AllStaff()
        {
            InitializeComponent();
            zaposleni = Model.SviZaposleni.getInstance().getZaposleni();
            foreach (Model.Zaposleni z in zaposleni)
            {
                dg_pronadjeni_zaposleni.Items.Add(z);
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
            stStaffInfo.Children.Add(new UserControls.DoctorTermsUC(radnik));
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
                    stStaffInfo.Children.Add( new UserControls.ListDoctorAppointmentsUC(vremenskiOpseg[0],vremenskiOpseg[1],radnik));
                    btns_opcije.Visibility = Visibility.Hidden;
                    btn_doctor_profile.Visibility = Visibility.Visible;
                   
                }

           
        }

        private void BtnPratrazi_Click(object sender, RoutedEventArgs e)
        {
            dg_pronadjeni_zaposleni.Items.Clear();

            foreach (Model.Zaposleni z in zaposleni)
            {
                String pol;
                if (rb_pol_m.IsChecked == true)
                    pol = "M";
                else if (rb_pol_z.IsChecked == true)
                    pol = "Z";
                else
                    pol = "";

                if (z.id.Contains(txt_jmbg.Text) && z.ime.Contains(txt_ime.Text) && z.prezime.Contains(txt_prezime.Text) && z.pol.Contains(pol))
                {
                    if (cmbStaffType.SelectedIndex == 0) //svi zaposleni
                    {
                        dg_pronadjeni_zaposleni.Items.Add(z);
                    }
                    else if (cmbStaffType.SelectedIndex == 1 && z.tipZaposlenog.Equals("Doktor")) //doktori
                    {
                        if (cmbDoctorSpeciality.SelectedIndex == 0)
                            dg_pronadjeni_zaposleni.Items.Add(z);
                        else
                        {
                            if (z.zvanje.Equals(cmbDoctorSpeciality.Text))
                                dg_pronadjeni_zaposleni.Items.Add(z);
                        }
                    }
                    else //ostali zaposleni
                    {
                        if (z.tipZaposlenog.Equals(cmbStaffType.Text))
                            dg_pronadjeni_zaposleni.Items.Add(z);
                    }
                }
            }
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

            radnik = dg_pronadjeni_zaposleni.SelectedItem as Model.Zaposleni;
            if (radnik.tipZaposlenog.Equals("Doktor"))
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

        public Model.Zaposleni getZaposleni()
        {
            return radnik;
        }
    }
}
