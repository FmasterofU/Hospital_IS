using Controller;
using Model.Roles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace HCIProjekat.Pages
{
    /// <summary>
    /// Interaction logic for Terms.xaml
    /// </summary>
    public partial class Terms : Page
    {
        private UserController userController = new UserController();
        ObservableCollection<Model.TermsRow> termini { get; set; }
        ObservableCollection<Model.Termin> zakazani { get; set; }
        private DateTime selektovaniTermin;
        public Terms()
        {
            InitializeComponent();
        }

        private void BtnRight_Click(object sender, RoutedEventArgs e)
        {
            DateTime selected_date = dp_date.SelectedDate.Value;
            dp_date.SelectedDate = selected_date.AddDays(1);
            DgTermsListXAML.Items.Clear();
            popuniTermine(new DateTime(dp_date.SelectedDate.Value.Year, dp_date.SelectedDate.Value.Month, dp_date.SelectedDate.Value.Day, 0, 0, 0));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            DateTime trenutno = DateTime.Now.Date;
            dp_date.SelectedDate = trenutno;
            DgTermsListXAML.Items.Clear();
            popuniTermine(new DateTime(trenutno.Year,trenutno.Month,trenutno.Day,0,0,0));
            

        }

        private void BtnLeft_Click(object sender, RoutedEventArgs e)
        {
            DateTime selected_date = dp_date.SelectedDate.Value;
            dp_date.SelectedDate = selected_date.AddDays(-1);
            DgTermsListXAML.Items.Clear();
            popuniTermine(new DateTime(dp_date.SelectedDate.Value.Year, dp_date.SelectedDate.Value.Month, dp_date.SelectedDate.Value.Day, 0, 0, 0));
        }

        private void BtnPretraziDoktora_Click(object sender, RoutedEventArgs e)
        {
            Dialogs.SearchDoctorDialog dijalog = new Dialogs.SearchDoctorDialog();
            dijalog.ShowDialog();
        }

        private void popuniTermine(DateTime dt)
        {
            zakazani = Model.SviTermini.getInstance().getTerminUOdgovarajucemVremenskomOpsegu(dt, dt.AddDays(1));
            DateTime today = dt;
            DateTime termin = new DateTime(dt.Year, dt.Month, dt.Day, 7, 0, 0); // pocetak radnog vremena
            DateTime zadnjiTermin = new DateTime(dt.Year, dt.Month, dt.Day, 22, 0, 0);//kraj radnog vremena
            while (termin <= zadnjiTermin)
            {
                String s1,s2,s3,s4;
                s1 = s2 = s3 = s4 = "";
                foreach (Model.Termin term in zakazani)
                {
                    
                    if (term.vreme.Equals(termin))
                    {
                        Patient p = userController.GetPatientBySearch(term.jmbgPacijenta,"","")[0];
                        if (term.soba == 1)
                            s1 = p.Name + " " + p.Surname;
                        else if (term.soba == 2)
                            s2 = p.Name + " " + p.Surname;
                        else if (term.soba == 3)
                            s3 = p.Name + " " + p.Surname;
                        else if (term.soba == 4)
                            s4 = p.Name + " " + p.Surname;

                    }
                }
                DgTermsListXAML.Items.Add(new Model.TermsRow(termin.ToShortTimeString(), s1, s2, s3, s4));
                termin = termin.AddMinutes(20.0);
            }
        }

        private void DgTermsListXAML_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime pocetakTermina = dp_date.SelectedDate.Value;
            Model.TermsRow row = DgTermsListXAML.SelectedItem as Model.TermsRow;
            DateTime pom = dp_date.SelectedDate.Value;
            if (row != null)
            {
                //pocetakTermina = row.vreme
                String str = row.vreme.ToString();
                String[] vremeParts = str.Split(':');
                selektovaniTermin = new DateTime(pom.Year, pom.Month, pom.Day, Int32.Parse(vremeParts[0]), Int32.Parse(vremeParts[1]),0);
            }
        }
        private void BtnTermin_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int soba = DgTermsListXAML.CurrentColumn.DisplayIndex;
            Model.Termin term = new Model.Termin("3322", "", soba, selektovaniTermin, "");
            Dialogs.AppointmentDialog dijalog;
            if (!btn.Content.Equals(""))
            {
                Model.Termin pronadjenTermin = Model.SviTermini.getInstance().searchTerminDanSoba(selektovaniTermin, soba);
               dijalog = new Dialogs.AppointmentDialog(pronadjenTermin);
                if (dijalog.sacuvano)
                {
                    DgTermsListXAML.Items.Refresh();
                }
                
            }
            else
                dijalog = new Dialogs.AppointmentDialog(term);
            dijalog.ShowDialog();


        } 

    }
}
