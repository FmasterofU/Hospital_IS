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
        private string name = "Elena";
        private string surname = "Elenic";
        private string adress = "Adresa 01";
        private string mail = "elena@mail.com";
        private EditProfilePage()
        {
            InitializeComponent();
            //TODO: read all profile data from database
            nameTextBox.Text = name;
            surnameTextBox.Text = surname;
            adressTextBox.Text = adress;
            mailTextBox.Text = mail;
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
            saveProfileButton.Content = "Sacuvaj";
            backFromEditProfileButton.Content = "Nazad";
        }

        public void ToEnglish()
        {
            nameLabel.Content = "Name:";
            surnameLabel.Content = "Surname:";
            adressLabel.Content = "Adress:";
            saveProfileButton.Content = "Save";
            backFromEditProfileButton.Content = "Back";
        }

        public void ToLightTheme()
        {
            this.Resources["foregroundColor"] = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            nameTextBox.Background = Brushes.White;
            surnameTextBox.Background = Brushes.White;
            adressTextBox.Background = Brushes.White;
            mailTextBox.Background = Brushes.White;
            passwordTextBox.Background = Brushes.White;
            newPasswordTextBox.Background = Brushes.White;
            newPassword2TextBox.Background = Brushes.White;
            saveProfileButton.BorderBrush = Brushes.Black;
            backFromEditProfileButton.BorderBrush = Brushes.Black;
        }

        public void ToDarkTheme()
        {
            this.Resources["foregroundColor"] = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            nameTextBox.Background = Brushes.Black;
            surnameTextBox.Background = Brushes.Black;
            adressTextBox.Background = Brushes.Black;
            mailTextBox.Background = Brushes.Black;
            passwordTextBox.Background = Brushes.Black;
            newPasswordTextBox.Background = Brushes.Black;
            newPassword2TextBox.Background = Brushes.Black;
            saveProfileButton.BorderBrush = Brushes.White;
            backFromEditProfileButton.BorderBrush = Brushes.White;
        }

        private void nameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!name.Equals(nameTextBox.Text)) saveProfileButton.IsEnabled = true;
            else if (surname.Equals(surnameTextBox.Text) && adress.Equals(adressTextBox.Text) && mail.Equals(mailTextBox.Text)) saveProfileButton.IsEnabled = false;
        }

        private void surnameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!surname.Equals(surnameTextBox.Text)) saveProfileButton.IsEnabled = true;
            else if (name.Equals(nameTextBox.Text) && adress.Equals(adressTextBox.Text) && mail.Equals(mailTextBox.Text)) saveProfileButton.IsEnabled = false;
        }

        private void adressTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!adress.Equals(adressTextBox.Text)) saveProfileButton.IsEnabled = true;
            else if (name.Equals(nameTextBox.Text) && surname.Equals(surnameTextBox.Text) && mail.Equals(mailTextBox.Text)) saveProfileButton.IsEnabled = false;
        }

        private void mailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!mail.Equals(mailTextBox.Text)) saveProfileButton.IsEnabled = true;
            else if (name.Equals(nameTextBox.Text) && adress.Equals(adressTextBox.Text) && surname.Equals(surnameTextBox.Text)) saveProfileButton.IsEnabled = false;
        }

        private void backFromEditProfileButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = MainWindow.getInstance();
            w.changePage(previousPage);
            //instance = null;
        }

        private void saveProfileButton_Click(object sender, RoutedEventArgs e)
        {
            name = nameTextBox.Text;
            surname = surnameTextBox.Text;
            adress = adressTextBox.Text;
            mail = mailTextBox.Text;
            saveProfileButton.IsEnabled = false;
            //TODO: save changes to database
        }
    }
}
