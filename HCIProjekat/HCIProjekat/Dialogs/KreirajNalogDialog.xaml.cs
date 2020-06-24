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

                Model.Pacijent pac = Model.SviPacijenti.getInstance().searchByJMBG(txt_jmbg.Text);

                if (pac != null)
                {
                    MessageBox.Show("Vec postoji osoba sa istim JMBG u sistemu!");
                    return;
                }
                Opacity = 0.5;
                
                String pol;
                if (rb_pol_m.IsChecked == true)
                    pol = "M";
                else if (rb_pol_z.IsChecked == true)
                    pol = "Z";
                else
                    pol = "";
                Model.Pacijent pacijent = new Model.Pacijent(txt_jmbg.Text, txt_ime.Text, txt_prz.Text, txt_ime_rod.Text, dp_rodjen.SelectedDate.Value , pol, txt_adresa.Text, txt_email.Text, txt_tel.Text);
                KreirajLozinkuDijalog kld = new KreirajLozinkuDijalog();
                kld.ShowDialog(); //treba da stoji u else
                if (kld.isPotvrdjen())
                {
                    Model.SviPacijenti.getInstance().dodajPacijenta(pacijent);
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
