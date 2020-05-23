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
    /// Interaction logic for EditProfilePage.xaml
    /// </summary>
    public partial class EditProfilePage : Page
    {
        private static EditProfilePage instance = null;
        private int previousPage = 0;
        private EditProfilePage()
        {
            InitializeComponent();
            //TODO: read all profile date from database
        }

        public static EditProfilePage getInstance()
        {
            if (instance == null) instance = new EditProfilePage();
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) instance.ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) instance.ToEnglish();
            if (MainWindow.GetTheme() == MainWindow.Theme.Light) instance.ToLightTheme();
            else if (MainWindow.GetTheme() == MainWindow.Theme.Dark) instance.ToDarkTheme();
            return instance;
        }

        public static EditProfilePage getInstance(int previousPage)
        {
            instance = getInstance();
            instance.previousPage = previousPage;
            return instance;
        }

        public void ToSerbian()
        {
            nameLabel.Content = "Ime:";
            surnameLabel.Content = "Prezime:";
            adressLabel.Content = "Adresa:";
            saveProfile.Content = "Sacuvaj";
            backFromEditProfile.Content = "Nazad";
        }

        public void ToEnglish()
        {
            nameLabel.Content = "Name:";
            surnameLabel.Content = "Surname:";
            adressLabel.Content = "Adress:";
            saveProfile.Content = "Save";
            backFromEditProfile.Content = "Back";
        }

        public void ToLightTheme()
        {
            nameLabel.Foreground = Brushes.Black;
            surnameLabel.Foreground = Brushes.Black;
            adressLabel.Foreground = Brushes.Black;
            mailLabel.Foreground = Brushes.Black;
            nameTextBox.Foreground = Brushes.Black;
            surnameTextBox.Foreground = Brushes.Black;
            adressTextBox.Foreground = Brushes.Black;
            mailTextBox.Foreground = Brushes.Black;
            nameTextBox.Background = Brushes.White;
            surnameTextBox.Background = Brushes.White;
            adressTextBox.Background = Brushes.White;
            mailTextBox.Background = Brushes.White;
            saveProfile.BorderBrush = Brushes.Black;
            backFromEditProfile.BorderBrush = Brushes.Black;
        }

        public void ToDarkTheme()
        {
            nameLabel.Foreground = Brushes.White;
            surnameLabel.Foreground = Brushes.White;
            adressLabel.Foreground = Brushes.White;
            mailLabel.Foreground = Brushes.White;
            nameTextBox.Foreground = Brushes.White;
            surnameTextBox.Foreground = Brushes.White;
            adressTextBox.Foreground = Brushes.White;
            mailTextBox.Foreground = Brushes.White;
            nameTextBox.Background = Brushes.Black;
            surnameTextBox.Background = Brushes.Black;
            adressTextBox.Background = Brushes.Black;
            mailTextBox.Background = Brushes.Black;
            saveProfile.BorderBrush = Brushes.White;
            backFromEditProfile.BorderBrush = Brushes.White;
        }

        private void backFromEditProfile_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = MainWindow.getInstance();
            w.changePage(previousPage);
            instance = null;
        }
    }
}
