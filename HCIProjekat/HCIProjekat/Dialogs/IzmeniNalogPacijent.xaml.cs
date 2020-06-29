using Controller;
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

namespace HCIProjekat.Dialogs
{
    /// <summary>
    /// Interaction logic for IzmeniNalogPacijent.xaml
    /// </summary>
    public partial class IzmeniNalogPacijent : Window
    {
        public bool izmeni { get; set; }
        private Patient pacijent = null;

        public IzmeniNalogPacijent(Patient pacijent)
        {
            InitializeComponent();

            this.pacijent = pacijent;
            izmeni = false;
        }

        private void BtnIzadjiClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbl_jmbg.Content = pacijent.Jmbg;
            txt_ime.Text = pacijent.Name;
            txt_prz.Text = pacijent.Surname;
            txt_ime_rod.Text = pacijent.ParentName;
            dp_rodjen.SelectedDate = pacijent.BirthDate;
            txt_adresa.Text = pacijent.Address;
            txt_tel.Text = pacijent.Phone ;
            txt_email.Text = pacijent.Email;
            if (!pacijent.Deceased)
                cb_aktivan.IsChecked = true;
            cekirajPol();

        }

        private void BtnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if(txt_ime.Text=="" || txt_prz.Text=="" || dp_rodjen.Text == "" || txt_email.Text=="" || (rb_pol_m.IsChecked==false && rb_pol_z.IsChecked == false))
            {
                MessageBox.Show("Obavezan je unos polja sa * !", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                UserController userController = new UserController();
                Sex pol = Sex.potato;
                if (rb_pol_m.IsChecked == true)
                    pol = Sex.male;
                else if (rb_pol_z.IsChecked == true)
                    pol = Sex.female;
                pacijent.editPatient(txt_ime.Text, txt_prz.Text, txt_tel.Text, txt_email.Text, pol, txt_email.Text, pacijent.Password, txt_email.Text, dp_rodjen.SelectedDate.Value, cb_aktivan.IsChecked==false,txt_ime_rod.Text);
                bool uspeo = userController.EditPatient(pacijent);
                if (uspeo)
                {
                    MessageBox.Show("Uspesno sacuvavanje podataka");
                    izmeni = true;
                }
                else
                    MessageBox.Show("Greska prilikom sacuvavanja podataka");
                this.Close();
            }
        }

        private String getPol()
        {
            if (rb_pol_m.IsChecked == true)
                return "M";
            else if (rb_pol_z.IsChecked == true)
                return "Z";
            else
                return "";
        }

        private int getStatus()
        {
            if (cb_aktivan.IsChecked == true)
                return 1;
            return 0;
        } 

        private void cekirajPol()
        {
            if (pacijent.Sex.Equals(Sex.male))
            {
                rb_pol_m.IsChecked = true;
            }
            else
            {
                rb_pol_z.IsChecked = true;
            }
        }

        public Patient getPatient()
        {
            return pacijent;
        }

       
    }
}
