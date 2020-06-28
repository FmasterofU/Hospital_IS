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
    /// Interaction logic for AppointmentDialog.xaml
    /// </summary>
    public partial class AppointmentDialog : Window
    {
        private Model.Termin termin;
        private UserController userController = new UserController();
        public bool sacuvano { get; set; }
        private Model.Zaposleni doktor;
        public AppointmentDialog(Model.Termin termin)
        {
            InitializeComponent();
            this.termin = termin;
            sacuvano = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbl_termin.Content = termin.vreme.ToShortTimeString();
            lbl_datum.Content = termin.vreme.ToShortDateString();
            txt_jmbg.Text = termin.jmbgPacijenta;
            if (!termin.jmbgPacijenta.Equals(""))
            {
                Patient p = userController.GetPatientBySearch(termin.jmbgPacijenta,"","")[0];
                txt_ime.Text = p.Name;
                txt_prz.Text = p.Surname;
                grid_zauzet.Visibility = Visibility.Visible;
                grid_slobodan.Visibility = Visibility.Hidden;
            }

            if (!termin.idDoktora.Equals(""))
            {
                Model.Zaposleni z = Model.SviZaposleni.getInstance().getZaposleniById(termin.idDoktora);
                doktor = z;
                txt_doktor.Text = z.ime + " " + z.prezime;
            }

            if (termin.soba != 0)
                txt_soba.Text = termin.soba.ToString();
            if (!termin.napomena.Equals(""))
                txt_napomena.Text = termin.napomena;
        }

        private void btn_zakazi_Click(object sender, RoutedEventArgs e)
        {
            Model.Termin zakaziTermin = new Model.Termin(doktor.id, txt_jmbg.Text, termin.soba, termin.vreme, txt_napomena.Text);
            Model.SviTermini.getInstance().dodajTermin(zakaziTermin);
            Model.SviZaposleni.getInstance().getZaposleniById(termin.idDoktora).dodajTermin(zakaziTermin);
            MessageBox.Show("Uspesno zakazivanje termina");
            sacuvano = true;
            this.Close();
        }

        private void btn_ukloni_Click(object sender, RoutedEventArgs e)
        {
            Model.SviTermini.getInstance().ukloniTermin(termin.vreme,termin.soba);
            Model.SviZaposleni.getInstance().getZaposleniById(termin.idDoktora).ukloniTermin(termin.vreme,termin.soba);
            MessageBox.Show("Uspesno brisanje termina");
            sacuvano = true;
            this.Close();
        }

        private void btn_odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_izmeni_Click(object sender, RoutedEventArgs e)
        {
            Model.Termin zakaziTermin = new Model.Termin(doktor.id, txt_jmbg.Text, termin.soba, termin.vreme, txt_napomena.Text);
            Model.SviTermini.getInstance().izmeniTermin(zakaziTermin);
            Model.SviZaposleni.getInstance().getZaposleniById(termin.idDoktora).izmeniTermin(zakaziTermin);
            sacuvano = true;
            MessageBox.Show("Uspesno izmenjen termin");
            this.Close();
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            Patient p = userController.GetPatientBySearch(txt_jmbg.Text,"","")[0];
            if(p != null)
            {
                txt_ime.Text = p.Name;
                txt_prz.Text = p.Surname;
            }
        }

        private void txt_jmbg_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool brojevi = true;
            btn_izmeni.IsEnabled = true;
            btn_zakazi.IsEnabled = true;
            if (txt_jmbg.Text.Length != 13)
                brojevi = false;
            foreach(char digit in txt_jmbg.Text)
            {
                if (digit < '0' || digit > '9')
                    brojevi = false;
            }

            if (!brojevi)
            {
                btn_izmeni.IsEnabled = false;
                btn_zakazi.IsEnabled = false;
            }
        }
    }
}
