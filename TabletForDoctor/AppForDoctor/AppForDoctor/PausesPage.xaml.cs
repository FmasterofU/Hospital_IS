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

namespace AppForDoctor
{
    /// <summary>
    /// Interaction logic for PausesPage.xaml
    /// </summary>
    public partial class PausesPage : Page
    {
        private static PausesPage instance = null;
        private PausesPage()
        {
            InitializeComponent();
            AddComboBoxItems();
        }

        public static PausesPage getInstance()
        {
            if (instance == null) instance = new PausesPage();
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) instance.ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) instance.ToEnglish();
            return instance;
        }

        private void ToSerbian()
        {
            menuFromPausesButton.Content = "Meni";
            savePausesButton.Content = "Sačuvaj";
            mondayLabel.Content = "Ponedeljak:";
            tuesdayLabel.Content = "Utorak:";
            wednesdayLabel.Content = "Sreda:";
            thursdayLabel.Content = "Četvrtak:";
            fridayLabel.Content = "Petak:";
            saturdayLabel.Content = "Subota:";
            sundayLabel.Content = "Nedelja:";
            oneForAllButton.Content = "Svaki dan isto";
        }

        private void ToEnglish()
        {
            menuFromPausesButton.Content = "Menu";
            savePausesButton.Content = "Save";
            mondayLabel.Content = "Monday:";
            tuesdayLabel.Content = "Tueday:";
            wednesdayLabel.Content = "Wednesday:";
            thursdayLabel.Content = "Thursday:";
            fridayLabel.Content = "Friday:";
            saturdayLabel.Content = "Saturday:";
            sundayLabel.Content = "Sunday:";
            oneForAllButton.Content = "Same for all days";
        }

        private void menuFromPausesButton_Click(object sender, RoutedEventArgs e)
        {
            instance = null;
            MainWindow w = MainWindow.getInstance();
            w.changePage(1);
        }

        private void AddComboBoxItems()
        {
            for(int i = 0; i < 24; i++)
            {
                monhfCombo.Items.Add(i);
                monhsCombo.Items.Add(i);
                tuehfCombo.Items.Add(i);
                tuehsCombo.Items.Add(i);
                wedhfCombo.Items.Add(i);
                wedhsCombo.Items.Add(i);
                thuhfCombo.Items.Add(i);
                thuhsCombo.Items.Add(i);
                frihfCombo.Items.Add(i);
                frihsCombo.Items.Add(i);
                sathfCombo.Items.Add(i);
                sathsCombo.Items.Add(i);
                sunhfCombo.Items.Add(i);
                sunhsCombo.Items.Add(i);
            }

            for(int i = 0; i < 56; i += 5)
            {
                monmfCombo.Items.Add(i);
                monmsCombo.Items.Add(i);
                tuemfCombo.Items.Add(i);
                tuemsCombo.Items.Add(i);
                wedmfCombo.Items.Add(i);
                wedmsCombo.Items.Add(i);
                thumfCombo.Items.Add(i);
                thumsCombo.Items.Add(i);
                frimfCombo.Items.Add(i);
                frimsCombo.Items.Add(i);
                satmfCombo.Items.Add(i);
                satmsCombo.Items.Add(i);
                sunmfCombo.Items.Add(i);
                sunmsCombo.Items.Add(i);
            }
        }

        private bool IsDayValid(int dayInWeek)
        {
            int firstMin = -1;
            int secondMin = -1;
            int firstHour = -1;
            int secondHour = -1;

            if (dayInWeek == 1)
            {
                firstMin = monmfCombo.SelectedIndex * 5;
                secondMin = monmsCombo.SelectedIndex * 5;
                firstHour = monhfCombo.SelectedIndex;
                secondHour = monhsCombo.SelectedIndex;
            }
            else if (dayInWeek == 2)
            {
                firstMin = tuemfCombo.SelectedIndex * 5;
                secondMin = tuemsCombo.SelectedIndex * 5;
                firstHour = tuehfCombo.SelectedIndex;
                secondHour = tuehsCombo.SelectedIndex;
            }
            else if (dayInWeek == 3)
            {
                firstMin = wedmfCombo.SelectedIndex * 5;
                secondMin = wedmsCombo.SelectedIndex * 5;
                firstHour = wedhfCombo.SelectedIndex;
                secondHour = wedhsCombo.SelectedIndex;
            }
            else if (dayInWeek == 4)
            {
                firstMin = thumfCombo.SelectedIndex * 5;
                secondMin = thumsCombo.SelectedIndex * 5;
                firstHour = thuhfCombo.SelectedIndex;
                secondHour = thuhsCombo.SelectedIndex;
            }
            else if (dayInWeek == 5)
            {
                firstMin = frimfCombo.SelectedIndex * 5;
                secondMin = frimsCombo.SelectedIndex * 5;
                firstHour = frihfCombo.SelectedIndex;
                secondHour = frihsCombo.SelectedIndex;
            }
            else if (dayInWeek == 6)
            {
                firstMin = satmfCombo.SelectedIndex * 5;
                secondMin = satmsCombo.SelectedIndex * 5;
                firstHour = sathfCombo.SelectedIndex;
                secondHour = sathsCombo.SelectedIndex;
            }
            else if (dayInWeek == 7)
            {
                firstMin = sunmfCombo.SelectedIndex * 5;
                secondMin = sunmsCombo.SelectedIndex * 5;
                firstHour = sunhfCombo.SelectedIndex;
                secondHour = sunhsCombo.SelectedIndex;
            }

            if (firstHour >= 0 && secondHour >= 0 && firstMin >= 0 && secondMin >= 0)
            {
                if (firstHour == secondHour && secondMin > firstMin && secondMin - firstMin <= 30) return true;
                else if (secondHour - firstHour == 1 && firstMin > secondMin)
                {
                    if (firstMin == 30 && secondMin == 0) return true;
                    else if (firstMin == 35 && firstMin + secondMin <= 40) return true;
                    else if (firstMin == 40 && firstMin + secondMin <= 50) return true;
                    else if (firstMin == 45 && firstMin + secondMin <= 60) return true;
                    else if (firstMin == 50 && firstMin + secondMin <= 70) return true;
                    else if (firstMin == 55 && firstMin + secondMin <= 80) return true;
                    else return false;
                }
                else return false;
            }
            else    return false;
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsDayValid(1)) oneForAllButton.IsEnabled = true;
            else    oneForAllButton.IsEnabled = false;
            if (CanISavePauses()) savePausesButton.IsEnabled = true;
            else    savePausesButton.IsEnabled = false;
        }

        private void oneForAllButton_Click(object sender, RoutedEventArgs e)
        {
            int firstHour = monhfCombo.SelectedIndex;
            int firstMin = monmfCombo.SelectedIndex;
            int secondHour = monhsCombo.SelectedIndex;
            int secondMin = monmsCombo.SelectedIndex;

            tuehfCombo.SelectedIndex = firstHour;
            tuehsCombo.SelectedIndex = secondHour;
            wedhfCombo.SelectedIndex = firstHour;
            wedhsCombo.SelectedIndex = secondHour;
            thuhfCombo.SelectedIndex = firstHour;
            thuhsCombo.SelectedIndex = secondHour;
            frihfCombo.SelectedIndex = firstHour;
            frihsCombo.SelectedIndex = secondHour;
            sathfCombo.SelectedIndex = firstHour;
            sathsCombo.SelectedIndex = secondHour;
            sunhfCombo.SelectedIndex = firstHour;
            sunhsCombo.SelectedIndex = secondHour;

            tuemfCombo.SelectedIndex = firstMin;
            tuemsCombo.SelectedIndex = secondMin;
            wedmfCombo.SelectedIndex = firstMin;
            wedmsCombo.SelectedIndex = secondMin;
            thumfCombo.SelectedIndex = firstMin;
            thumsCombo.SelectedIndex = secondMin;
            frimfCombo.SelectedIndex = firstMin;
            frimsCombo.SelectedIndex = secondMin;
            satmfCombo.SelectedIndex = firstMin;
            satmsCombo.SelectedIndex = secondMin;
            sunmfCombo.SelectedIndex = firstMin;
            sunmsCombo.SelectedIndex = secondMin;

            oneForAllButton.IsEnabled = false;
        }

        private bool CanISavePauses()
        {
            if (oneForAllButton.IsEnabled && IsDayValid(2) && IsDayValid(3) && IsDayValid(4) && IsDayValid(5) && IsDayValid(6) && IsDayValid(7)) return true;
            else return false;
            /*if (oneForAllButton.IsEnabled && tuehfCombo.SelectedIndex >= 0 && tuehsCombo.SelectedIndex >= 0 && tuemfCombo.SelectedIndex >= 0 && tuemsCombo.SelectedIndex >= 0
                && wedhfCombo.SelectedIndex >= 0 && wedhsCombo.SelectedIndex >= 0 && wedmfCombo.SelectedIndex >= 0 && wedmsCombo.SelectedIndex >= 0
                && thuhfCombo.SelectedIndex >= 0 && thuhsCombo.SelectedIndex >= 0 && thumfCombo.SelectedIndex >= 0 && thumsCombo.SelectedIndex >= 0
                && frihfCombo.SelectedIndex >= 0 && frihsCombo.SelectedIndex >= 0 && frimfCombo.SelectedIndex >= 0 && frimsCombo.SelectedIndex >= 0
                && sathfCombo.SelectedIndex >= 0 && sathsCombo.SelectedIndex >= 0 && satmfCombo.SelectedIndex >= 0 && satmsCombo.SelectedIndex >= 0
                && sunhfCombo.SelectedIndex >= 0 && sunhsCombo.SelectedIndex >= 0 && sunmfCombo.SelectedIndex >= 0 && sunmsCombo.SelectedIndex >= 0)
                return true;*/
        }
    }
}
