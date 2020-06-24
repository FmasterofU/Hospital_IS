using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
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
    /// Interaction logic for AllPatients.xaml
    /// </summary>
    public partial class AllPatients : Page 
    {
        private ObservableCollection<Model.Pacijent> pacijenti = new ObservableCollection<Model.Pacijent>();
        private Model.Pacijent pacijent = null;
        public AllPatients()
        {
            InitializeComponent();
            pacijenti = Model.SviPacijenti.getInstance().getPacijente();

            foreach(Model.Pacijent p in pacijenti)
            {
                dg_pronadjeni_pacijenti.Items.Add(p);
            }
        }
        private void BtnPocetna_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).FullMainWindow.Content = new HomePage();
        }

        private void BtnIzmeniPodatke_Click(object sender, RoutedEventArgs e)
        {
           
            Dialogs.IzmeniNalogPacijent dijalog = new Dialogs.IzmeniNalogPacijent(lbl_jmbg.Content.ToString(),lbl_ime.Content.ToString(), lbl_prezime.Content.ToString(), lbl_roditelj.Content.ToString(), stringToDate(),lbl_pol.Content.ToString(), lbl_adresa.Content.ToString(), lbl_email.Content.ToString(), lbl_telefon.Content.ToString(), getStatus());
            dijalog.ShowDialog();
            if (dijalog.izmeni)
            {
                dg_pronadjeni_pacijenti.Items.Refresh();
                azurirajProfil(Model.SviPacijenti.getInstance().searchByJMBG(lbl_jmbg.Content.ToString()));
            }
        }

        private void BtnClickZakaziTermin_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).FullMainWindow.Content = new Terms();
        }

        private void BtnPretraga_Click(object sender, RoutedEventArgs e)
        {
            dg_pronadjeni_pacijenti.Items.Clear();
            foreach(Model.Pacijent p in pacijenti)
            {
                String pol = getPol();
                if(p.jmbg.Contains(txt_jmbg.Text) && p.ime.Contains(txt_ime.Text) && p.prezime.Contains(txt_prezime.Text) && p.pol.Contains(pol))
                {
                    dg_pronadjeni_pacijenti.Items.Add(p);
                }
            }
        }

        private String getPol()
        {
            if (rb_pol_m.IsChecked == true)
                return  "M";
            else if (rb_pol_z.IsChecked == true)
                return  "Z";
            else
                return "";
        }

        private int getStatus()
        {
            if (lbl_status.Content.Equals("Aktivan"))
                return 1;
            else if (lbl_status.Content.Equals("Neaktivan"))
                return 0;
            else
            {
                return 2;
            }
        }

        private void dg_pronadjeni_pacijenti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pacijent = dg_pronadjeni_pacijenti.SelectedItem as Model.Pacijent;
            if(pacijent != null)
            {
                azurirajProfil(pacijent);
            }
        }

        private void azurirajProfil(Model.Pacijent pac)
        {
            lbl_jmbg.Content = pac.jmbg;
            lbl_ime.Content = pac.ime;
            lbl_prezime.Content = pac.prezime;
            lbl_roditelj.Content = pac.imeRoditelja;
            lbl_datum.Content = pac.datumRodjenja.ToShortDateString();
            lbl_pol.Content = pac.pol;
            lbl_adresa.Content = pac.adresa;
            lbl_email.Content = pac.email;
            lbl_telefon.Content = pac.telefon;
            tb_moguce_zakazivanje.IsChecked = pac.moguceZakazivanje;
            lbl_status.Content = pac.getStatusString();
        }

        private void tb_moguce_zakazivanje_Checked(object sender, RoutedEventArgs e)
        {
            pacijent.moguceZakazivanje = true;
            bool uspeo = Model.SviPacijenti.getInstance().azurirajPacijenta(pacijent);
        }

        private void tb_moguce_zakazivanje_Unchecked(object sender, RoutedEventArgs e)
        {
            pacijent.moguceZakazivanje = false;
            bool uspeo = Model.SviPacijenti.getInstance().azurirajPacijenta(pacijent);
        }

        private DateTime stringToDate()
        {
            String[] dateParts = lbl_datum.Content.ToString().Split('/');
            int mesec = Int32.Parse(dateParts[0]);
            int dan = Int32.Parse(dateParts[1]);
            int godina = Int32.Parse(dateParts[2]);
            DateTime datum = new DateTime(godina, mesec, dan);
            return datum;
        }
    }
}
