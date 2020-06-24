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
    /// Interaction logic for ChoseDate.xaml
    /// </summary>
    public partial class ChoseDate : Window
    {   

        public ChoseDate()
        {
            InitializeComponent();
        }

        private DateTime[] vremenski_opseg = new DateTime[2];
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rb_godina.IsChecked = true;
            cmb_godina.Visibility = Visibility.Visible;
            DateTime date = DateTime.MinValue;
            vremenski_opseg[0] = date;
            vremenski_opseg[1] = date;
        }

        private void RbDate_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton btn = (RadioButton)sender;

            if (btn.Equals(rb_godina))
                cmb_godina.Visibility = Visibility.Visible;
            else if (btn.Equals(rb_mesec))
                grid_mesec.Visibility = Visibility.Visible;
            else if (btn.Equals(rb_dan))
                dp_dan.Visibility = Visibility.Visible;
            else
                grid_datum.Visibility = Visibility.Visible;
        }

        private void RbDate_Unchecked(object sender, RoutedEventArgs e)
        {
            RadioButton btn = (RadioButton)sender;

            if (btn.Equals(rb_godina))
                cmb_godina.Visibility = Visibility.Hidden;
            else if (btn.Equals(rb_mesec))
                grid_mesec.Visibility = Visibility.Hidden;
            else if (btn.Equals(rb_dan))
                dp_dan.Visibility = Visibility.Hidden;
            else
                grid_datum.Visibility = Visibility.Hidden;
        }

        private void BtnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            setVremenskiOpseg();
            this.Close();
        }

        private void BtnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void setVremenskiOpseg()
        {
            if (cmb_godina.Visibility == Visibility.Visible)
            {
                int godina = Int32.Parse(cmb_godina.Text);
                DateTime date = new DateTime(godina, 1, 1);
                vremenski_opseg[0] = date;
                vremenski_opseg[1] = date.AddYears(1);
            }
            else if (grid_mesec.Visibility == Visibility.Visible)
            {
                int godina = Int32.Parse(cmb_godina2.Text);
                int mesec = cmb_mesec.SelectedIndex + 1;
                DateTime date = new DateTime(godina, mesec, 1);
                vremenski_opseg[0] = date;
                vremenski_opseg[1] = date.AddMonths(1);
            }
            else if (dp_dan.Visibility == Visibility.Visible)
            {
                if (dp_dan.Text != "")
                {
                    vremenski_opseg[0] = dp_dan.SelectedDate.Value;
                    vremenski_opseg[1] = dp_dan.SelectedDate.Value;
                }

            }
            else
            {
                if (dp_datum_od.Text != "" && dp_datum_do.Text !="")
                {
                    vremenski_opseg[0] = dp_datum_od.SelectedDate.Value;
                    vremenski_opseg[1] = dp_datum_do.SelectedDate.Value;
                }
            }
        }

      public DateTime[] getVremenskiOpseg()
        {
            return vremenski_opseg;
        }
    }
}
