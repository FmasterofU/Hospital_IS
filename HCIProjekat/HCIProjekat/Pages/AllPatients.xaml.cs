using Controller;
using Model.Roles;
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
        private Patient pacijent = null;
        private UserController userController = new UserController();
        private string jmbg="";
        private string ime="";
        private string prezime="";
        public AllPatients()
        {
            InitializeComponent();
            foreach (Patient p in userController.GetPatientBySearch("", "", ""))
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
            UserController userController = new UserController();
            Patient pacijent = userController.GetPatientBySearch(lbl_jmbg.Content.ToString(),"","")[0];
            Dialogs.IzmeniNalogPacijent dijalog = new Dialogs.IzmeniNalogPacijent(pacijent);
            dijalog.ShowDialog();
            if (dijalog.izmeni)
            {
                dg_pronadjeni_pacijenti.Items.Clear();
                foreach(Patient p in userController.GetPatientBySearch(jmbg, ime, prezime)){
                    dg_pronadjeni_pacijenti.Items.Add(p);
                }
                azurirajProfil(dijalog.getPatient());
            }
        }

        private void BtnClickZakaziTermin_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).FullMainWindow.Content = new Terms();
        }

        private void BtnPretraga_Click(object sender, RoutedEventArgs e)
        {
            dg_pronadjeni_pacijenti.Items.Clear();
            jmbg = txt_jmbg.Text;
            ime = txt_ime.Text;
            prezime = txt_prezime.Text;
            foreach (Patient p in userController.GetPatientBySearch(txt_jmbg.Text,txt_ime.Text,txt_prezime.Text))
            {
                dg_pronadjeni_pacijenti.Items.Add(p);
            }

        }

        private Sex getPol()
        {
            if (rb_pol_m.IsChecked == true)
                return  Sex.male;
            else if (rb_pol_z.IsChecked == true)
                return  Sex.female;
            else
                return Sex.potato;
        }


        private void dg_pronadjeni_pacijenti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pacijent = dg_pronadjeni_pacijenti.SelectedItem as Patient;
            if(pacijent != null)
            {
                azurirajProfil(pacijent);
            }
        }

        private void azurirajProfil(Patient pac)
        {
            lbl_jmbg.Content = pac.Jmbg;
            lbl_ime.Content = pac.Name;
            lbl_prezime.Content = pac.Surname;
            lbl_roditelj.Content = pac.ParentName;
            lbl_datum.Content = pac.BirthDate.ToShortDateString();
            lbl_pol.Content = pac.Sex;
            lbl_adresa.Content = pac.Address;
            lbl_email.Content = pac.Email;
            lbl_telefon.Content = pac.Phone;
            //tb_moguce_zakazivanje.IsChecked = pac.moguceZakazivanje;
            lbl_status.Content = getStatus(pac);
        }

        private string getStatus(Patient patient)
        {
            if (patient.Deceased)
                return "Neaktivan";
            else
                return "Aktivan";
        }

        private void tb_moguce_zakazivanje_Checked(object sender, RoutedEventArgs e)
        {
           
        }

        private void tb_moguce_zakazivanje_Unchecked(object sender, RoutedEventArgs e)
        {
            
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
