using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        private string password = "123456";
        private bool passChanged = false;
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

        private void ToSerbian()
        {
            nameLabel.Content = "Ime:";
            surnameLabel.Content = "Prezime:";
            adressLabel.Content = "Adresa:";
            saveProfileButton.Content = "Sacuvaj";
            backFromEditProfileButton.Content = "Nazad";
        }

        private void ToEnglish()
        {
            nameLabel.Content = "Name:";
            surnameLabel.Content = "Surname:";
            adressLabel.Content = "Adress:";
            saveProfileButton.Content = "Save";
            backFromEditProfileButton.Content = "Back";
        }

        private void ToLightTheme()
        {
            //this.Resources["foregroundColor"] = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }

        private void ToDarkTheme()
        {
            //this.Resources["foregroundColor"] = new SolidColorBrush(Color.FromRgb(255, 255, 255));
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
            if (passChanged) password = newPasswordTextBox.Password;
            //TODO: save changes to database
        }

        private void passwordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            disableNewPasswords();
        }

        private void disableNewPasswords()
        {
            newPasswordTextBox.IsEnabled = false;
            newPasswordTextBox.Password = "";
            newPassword2TextBox.IsEnabled = false;
            newPassword2TextBox.Password = "";
            passChanged = false;
        }

        private void passwordTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Enter) checkPasswordButton.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        private void newPasswordTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Enter)
            {
                if (newPasswordTextBox.Password.Equals(newPassword2TextBox.Password) && passwordTextBox.Password.Equals(password))
                {
                    saveProfileButton.IsEnabled = true;
                    passChanged = true;
                }
                else
                {
                    saveProfileButton.IsEnabled = false;
                    passChanged = false;
                }
            }
        }

        private void newPasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            passChanged = false;
        }

        private void checkPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if (passwordTextBox.Password.Equals(password))
            {
                newPasswordTextBox.IsEnabled = true;
                newPassword2TextBox.IsEnabled = true;
                Style style = this.FindResource("passwordBoxStyle") as Style;
                passwordTextBox.Style = style;
            }
            else
            {
                disableNewPasswords();
                Style style = this.FindResource("passwordBoxIncorectStyle") as Style;
                passwordTextBox.Style = style;
            }
        }
    }
}
