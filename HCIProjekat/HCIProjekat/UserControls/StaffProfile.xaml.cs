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

namespace HCIProjekat.UserControls
{
    /// <summary>
    /// Interaction logic for StaffProfile.xaml
    /// </summary>
    public partial class StaffProfile : UserControl
    {
        private Model.Zaposleni zaposleni = null;
        //public StaffProfile(String id, String ime, String prezime, String tip, DateTime datum, String pol, String adresa, String email, String telefon, String zvanje)
        public StaffProfile(Model.Zaposleni zap)
        {
            InitializeComponent();
            //zaposleni = new Model.Zaposleni(id, ime, prezime, tip, datum, pol, adresa, email, telefon, zvanje);
            zaposleni = zap;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(zaposleni == null)
            {
                lbl_adresa.Visibility = lbl_datum.Visibility = lbl_email.Visibility = lbl_id.Visibility = lbl_ime.Visibility = lbl_pol.Visibility = lbl_prezime.Visibility = lbl_status.Visibility = lbl_telefon.Visibility = lbl_zvanje.Visibility  = Visibility.Hidden;
            }
            else
            {
                 azurirajProfil(zaposleni);

                if (!zaposleni.tipZaposlenog.Equals("Doktor"))
                {
                    lbl_zvanje.Visibility = Visibility.Hidden;
                }
            }
        }

        private void azurirajProfil(Model.Zaposleni zap)
        {
            lbl_id.Content = zap.id;
            lbl_ime.Content = zap.ime;
            lbl_prezime.Content = zap.prezime;
            lbl_zvanje.Content = zap.zvanje;
            lbl_datum.Content = zap.datumRodjenja.ToShortDateString();
            lbl_pol.Content = zap.pol;
            lbl_adresa.Content = zap.adresa;
            lbl_email.Content = zap.email;
            lbl_telefon.Content = zap.telefon;
            lbl_status.Content = zap.status;
            lbl_tip.Content = zap.tipZaposlenog;
            getStatus();
        }

        private void getStatus()
        {
            if(zaposleni.status == 0)
            {
                lbl_status.Content = "Neaktivan";
            }else if(zaposleni.status == 1)
            {
                lbl_status.Content = "Aktivan";
            }
            else
            {
                lbl_status.Content = "Na odmoru";
            }
        }

    }
}
