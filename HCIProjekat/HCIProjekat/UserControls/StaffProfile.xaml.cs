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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HCIProjekat.UserControls
{
    /// <summary>
    /// Interaction logic for StaffProfile.xaml
    /// </summary>
    public partial class StaffProfile : UserControl
    {
        private Staff zaposleni = null;
        public StaffProfile(Staff zaposleni)
        {
            InitializeComponent();
            this.zaposleni = zaposleni;
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

                if (!(zaposleni.UserType.Equals(UserType.Doctor) && zaposleni.UserType.Equals(UserType.Specialist)))
                {
                    lbl_zvanje.Visibility = Visibility.Hidden;
                }
            }
        }

        private void azurirajProfil(Staff zap)
        {
            lbl_id.Content = zap.GetId();
            lbl_ime.Content = zap.Name;
            lbl_prezime.Content = zap.Surname;
            lbl_zvanje.Content = getZvanje(zap);
            lbl_pol.Content = zap.Sex;
            lbl_email.Content = zap.Email;
            lbl_telefon.Content = zap.Phone;
            lbl_status.Content = getStatus();
            lbl_tip.Content = zap.UserType;
            
        }

        private string getZvanje(Staff zap)
        {
            if (zap.UserType.Equals(UserType.Specialist))
                return ((Specialist)zap).Specialization;
            else if (zap.UserType.Equals(UserType.Doctor))
                return "Doktor opste prakse";
            else if (zap.UserType.Equals(UserType.Secretary))
                return "Sekretar";
            else if (zap.UserType.Equals(UserType.Manager))
                return  "Menadzer";
            else
                return "";
        }

        private string getStatus()
        {
            if(!zaposleni.Active)
            {
                return "Neaktivan";
            }else 
            {
                return"Aktivan";
            }
            
        }

    }
}
