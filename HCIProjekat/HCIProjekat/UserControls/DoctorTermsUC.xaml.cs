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

namespace HCIProjekat.UserControls
{
    /// <summary>
    /// Interaction logic for DoctorTermsUC.xaml
    /// </summary>
    public partial class DoctorTermsUC : UserControl
    {
        public ObservableCollection<Model.Termin> terminidoktora;
        public Model.Zaposleni doktor;
        public DoctorTermsUC(Model.Zaposleni doktor)
        {
            InitializeComponent();
            this.doktor = doktor;
            

        }

        private void BtnRight_Click(object sender, RoutedEventArgs e)
        {
            DateTime selected_date = dp_date.SelectedDate.Value;
            dp_date.SelectedDate = selected_date.AddDays(1);
        }


        private void BtnLeft_Click(object sender, RoutedEventArgs e)
        {
            DateTime selected_date = dp_date.SelectedDate.Value;
            dp_date.SelectedDate = selected_date.AddDays(-1);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Model.SviZaposleni.getInstance();
            terminidoktora = doktor.zakazaniTermini;
            dp_date.SelectedDate = DateTime.Now.Date;
            DgAppointmentsListXAML.Items.Clear();
            foreach (Model.Termin t in pronadjiTermineUOdgovarajucemDanu(DateTime.Now.Date)) {
                Model.Pacijent p = Model.SviPacijenti.getInstance().searchByJMBG(t.jmbgPacijenta);
                DgAppointmentsListXAML.Items.Add(new Model.TerminiDoktoraRow(t.vreme.ToShortDateString(), t.vreme.ToShortTimeString(), t.soba, t.jmbgPacijenta, p.ime, p.prezime));
               }

        }

        private ObservableCollection<Model.Termin> pronadjiTermineUOdgovarajucemDanu(DateTime dan)
        {
            ObservableCollection<Model.Termin> retVal = new ObservableCollection<Model.Termin>();
            foreach(Model.Termin t in terminidoktora)
            {
                if (t.vreme.ToShortDateString().Equals(dan.ToShortDateString()))
                    retVal.Add(t);
            }
            return retVal;
        }

        private void dp_date_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!dp_date.Text.Equals(""))
            {
                DgAppointmentsListXAML.Items.Clear();
                foreach (Model.Termin t in pronadjiTermineUOdgovarajucemDanu(dp_date.SelectedDate.Value))
                    DgAppointmentsListXAML.Items.Add(t);
            }
        }
    }
}
