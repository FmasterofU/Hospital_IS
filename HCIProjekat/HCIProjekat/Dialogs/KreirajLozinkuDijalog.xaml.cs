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
    /// Interaction logic for KreirajLozinkuDijalog.xaml
    /// </summary>
    public partial class KreirajLozinkuDijalog : Window
    {
        private bool potvrdjen;
        public KreirajLozinkuDijalog()
        {
            InitializeComponent();
            potvrdjen = false;
        }

        private void setTextBoxs()
        {
            txt_lozinka.Text = pass_lozinka.Password.ToString();
            txt_potvrda_lozinke.Text = pass_potvrda_lozinke.Password.ToString();
        }

        private void setPasswordBoxs()
        {
            pass_lozinka.Password = txt_lozinka.Text;
            pass_potvrda_lozinke.Password = txt_potvrda_lozinke.Text;
        }

        private void BtnPotvrdiLozinku_Click(object sender, RoutedEventArgs e)
        {
            if (txt_lozinka.Visibility == Visibility.Visible)
            {
                setPasswordBoxs();
            }
            if (pass_lozinka.Password.ToString().Equals(pass_potvrda_lozinke.Password.ToString()))
            {
                MessageBox.Show("Uspesno kreiranje naloga", "Uspesan unos", MessageBoxButton.OK, MessageBoxImage.Information);
                //foreach(Window window in System.Windows.Application.Current.Windows)
                //{
                //    //if (window.Name == "NalogPacijentaDijalog")
                //    //    window.Close();
                //}
                potvrdjen = true;
                this.Close();                
            }
            else
            {
                MessageBox.Show("Lozinke koje ste uneli su razlicite", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    
        private void BtnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnVisible_Click(object sender, RoutedEventArgs e)
        {
            if (txt_lozinka.Visibility == Visibility.Hidden)
            {
                setTextBoxs();
                txt_lozinka.Visibility = Visibility.Visible;
                txt_potvrda_lozinke.Visibility = Visibility.Visible;
                pass_potvrda_lozinke.Visibility = Visibility.Hidden;
                pass_lozinka.Visibility = Visibility.Hidden;
            }
            else
            {
                setPasswordBoxs();
                txt_lozinka.Visibility = Visibility.Hidden;
                txt_potvrda_lozinke.Visibility = Visibility.Hidden;
                pass_potvrda_lozinke.Visibility = Visibility.Visible;
                pass_lozinka.Visibility = Visibility.Visible;
            }

        }
        public bool isPotvrdjen()
        {
            return potvrdjen; 
        }
    }
}
