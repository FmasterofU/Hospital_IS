using Controller;
using Model.Medicine;
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
    /// Interaction logic for KreirajNalogDialog.xaml
    /// </summary>
    public partial class KreirajNalogDialog : Window
    {
        //public static bool closing = false;
        private bool isStaff = false;
        public KreirajNalogDialog(bool isStaff)
        {
            InitializeComponent();
            //closing = false;
            this.isStaff = isStaff;
        }

        private void BtnEraseClick(object sender, RoutedEventArgs e)
        {
            txt_ime.Text = txt_jmbg.Text = txt_adresa.Text = txt_email.Text = txt_ime_rod.Text = txt_mesto_stan.Text = txt_tel.Text = txt_prz.Text = txt_tel.Text = txt_opstina.Text = "";
            rb_pol_m.IsChecked = false;
            rb_pol_z.IsChecked = false;
            dp_rodjen.Text = "";
        }

        private void BtnKreirajNalogClick(object sender, RoutedEventArgs e)
        {
            if (txt_ime.Text == "" || txt_jmbg.Text == "" || txt_prz.Text == "" || txt_email.Text == "" || (rb_pol_m.IsChecked == false && rb_pol_z.IsChecked == false) || dp_rodjen.Text == "")
            {
                MessageBox.Show("Obavezan je unos polja sa * !","",MessageBoxButton.OK,MessageBoxImage.Warning);
                
            }
            else
            {
                Sex pol = Sex.potato;
                if (rb_pol_m.IsChecked == true)
                    pol = Sex.male;
                else if (rb_pol_z.IsChecked == true)
                    pol = Sex.female;

                // Model.Pacijent pac = Model.SviPacijenti.getInstance().searchByJMBG(txt_jmbg.Text);
                UserController controller = new UserController();
                Patient patient = new Patient(txt_ime.Text, txt_prz.Text, txt_tel.Text, txt_email.Text, pol, txt_jmbg.Text, txt_email.Text, "", UserType.Patient, txt_adresa.Text, dp_rodjen.SelectedDate.Value, false, txt_ime_rod.Text, 0, new List<Ingridient>());
                List<Patient> existPatients = controller.GetPatientBySearch(patient.Jmbg, "", "");
                if (existPatients.Count != 0)
                {
                    MessageBox.Show("Vec postoji osoba sa istim JMBG u sistemu!");
                    return;
                }
                Opacity = 0.5;
                
                KreirajLozinkuDijalog kld = new KreirajLozinkuDijalog();
                kld.ShowDialog(); //treba da stoji u else
                if (kld.isPotvrdjen())
                {
                    patient.Password = kld.getLozinku();
                    patient = controller.AddPatient(patient);
                }
                Opacity =1;
            }
           
        }

        private void BtnOdustaniClick(object sender, RoutedEventArgs e)
        {
            
            CloseDialog();
        }

        private void CloseDialog()
        {
            this.Close();
        }

        private void NalogPacijentaDijalog_Loaded(object sender, RoutedEventArgs e)
        {
            if(isStaff == false)
            {
                btn_search.Visibility = Visibility.Hidden;
            }
        }
    }
}
