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
        private Model.Pacijent pacijent = null;

        public IzmeniNalogPacijent(String jmbg, String ime, String prezime, String roditelj, DateTime datum, String pol, String adresa, String email, String telefon, int status)
        {
            InitializeComponent();
            pacijent = new Model.Pacijent(jmbg, ime, prezime, roditelj, datum, pol, adresa, email, telefon, status);
            izmeni = false;
        }

        private void BtnIzadjiClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbl_jmbg.Content = pacijent.jmbg;
            txt_ime.Text = pacijent.ime;
            txt_prz.Text = pacijent.prezime;
            txt_ime_rod.Text = pacijent.imeRoditelja;
            dp_rodjen.SelectedDate = pacijent.datumRodjenja;
            txt_adresa.Text = pacijent.adresa;
            txt_tel.Text = pacijent.telefon;
            txt_email.Text = pacijent.email;
            if (pacijent.status == 1)
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
                pacijent = new Model.Pacijent(lbl_jmbg.Content.ToString(), txt_ime.Text, txt_prz.Text, txt_ime_rod.Text, dp_rodjen.SelectedDate.Value, getPol(), txt_adresa.Text, txt_email.Text, txt_tel.Text,getStatus());
                bool uspeo = Model.SviPacijenti.getInstance().azurirajPacijenta(pacijent);
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
            if (pacijent.pol.Equals("M"))
            {
                rb_pol_m.IsChecked = true;
            }
            else
            {
                rb_pol_z.IsChecked = true;
            }
        }

       
    }
}
