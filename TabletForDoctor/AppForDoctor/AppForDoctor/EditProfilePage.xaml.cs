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
using System.Text.RegularExpressions;

namespace AppForDoctor
{
    /// <summary>
    /// Interaction logic for EditProfilePage.xaml
    /// </summary>
    public partial class EditProfilePage : Page
    {
        private static EditProfilePage instance = null;
        private int previousPage = 0;
        private User user = null;
        private string name = "Elena";
        private string surname = "Elenic";
        private string adress = "Adresa 01";
        private string mail = "elena@mail.com";
        private string password = "123456";
        private bool passChanged = false;
        private List<StringBuilder> reportsForPdfSrb = new List<StringBuilder>();
        private List<StringBuilder> reportsForPdfEng = new List<StringBuilder>();
        private EditProfilePage()
        {
            InitializeComponent();
            //TODO: read all profile data from database
            /*nameTextBox.Text = name;
            surnameTextBox.Text = surname;
            adressTextBox.Text = adress;
            mailTextBox.Text = mail;*/
        }

        public static EditProfilePage getInstance()
        {
            if (instance == null) instance = new EditProfilePage();
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) instance.ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) instance.ToEnglish();
            return instance;
        }

        public static EditProfilePage getInstance(int previousPage)
        {
            instance = getInstance();
            instance.previousPage = previousPage;
            return instance;
        }

        public static EditProfilePage getInstance(User user)
        {
            instance = getInstance();
            instance.user = user;
            instance.nameTextBox.Text = instance.user.Name;
            instance.name = instance.user.Name;
            instance.surnameTextBox.Text = instance.user.Surname;
            instance.surname = instance.user.Surname;
            instance.adressTextBox.Text = instance.user.Adress;
            instance.adress = instance.user.Adress;
            instance.mailTextBox.Text = instance.user.Mail;
            instance.mail = instance.user.Mail;
            instance.password = instance.user.Password;
            return instance;
        }

        private void ToSerbian()
        {
            nameLabel.Content = "Ime:";
            surnameLabel.Content = "Prezime:";
            adressLabel.Content = "Adresa:";
            saveProfileButton.Content = "Sačuvaj";
            backFromEditProfileButton.Content = "Nazad";
            passwordLabel.Content = "Trenutna lozinka:";
            newPasswordLabel.Content = "Nova lozinka:";
            newPassword2Label.Content = "Ponovi novu lozinku:";
            checkPasswordButton.Content = "Proveri lozinku";
        }

        private void ToEnglish()
        {
            nameLabel.Content = "Name:";
            surnameLabel.Content = "Surname:";
            adressLabel.Content = "Address:";
            saveProfileButton.Content = "Save";
            backFromEditProfileButton.Content = "Back";
            passwordLabel.Content = "Password:";
            newPasswordLabel.Content = "New password:";
            newPassword2Label.Content = "Retype new password:";
            checkPasswordButton.Content = "Check password";
        }

        private void nameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Match m = Regex.Match(mailTextBox.Text, "([a-zA-Z0-9]+\\.?)*[a-zA-Z0-9]@[a-z0-9]+(\\.[a-z]{2,3})+");
            if (!name.Equals(nameTextBox.Text) && m.Success) saveProfileButton.IsEnabled = true;
            else if (surname.Equals(surnameTextBox.Text) && adress.Equals(adressTextBox.Text) && mail.Equals(mailTextBox.Text) || !m.Success) saveProfileButton.IsEnabled = false;
        }

        private void surnameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Match m = Regex.Match(mailTextBox.Text, "([a-zA-Z0-9]+\\.?)*[a-zA-Z0-9]@[a-z0-9]+(\\.[a-z]{2,3})+");
            if (!surname.Equals(surnameTextBox.Text) && m.Success) saveProfileButton.IsEnabled = true;
            else if (name.Equals(nameTextBox.Text) && adress.Equals(adressTextBox.Text) && mail.Equals(mailTextBox.Text) || !m.Success) saveProfileButton.IsEnabled = false;
        }

        private void adressTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Match m = Regex.Match(mailTextBox.Text, "([a-zA-Z0-9]+\\.?)*[a-zA-Z0-9]@[a-z0-9]+(\\.[a-z]{2,3})+");
            if (!adress.Equals(adressTextBox.Text) && m.Success) saveProfileButton.IsEnabled = true;
            else if (name.Equals(nameTextBox.Text) && surname.Equals(surnameTextBox.Text) && mail.Equals(mailTextBox.Text) || !m.Success) saveProfileButton.IsEnabled = false;
        }

        private void mailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Match m = Regex.Match(mailTextBox.Text, "([a-zA-Z0-9]+\\.?)*[a-zA-Z0-9]@[a-z0-9]+(\\.[a-z]{2,3})+");
            if (!mail.Equals(mailTextBox.Text) && m.Success) saveProfileButton.IsEnabled = true;
            else if (name.Equals(nameTextBox.Text) && adress.Equals(adressTextBox.Text) && surname.Equals(surnameTextBox.Text) || !m.Success) saveProfileButton.IsEnabled = false;
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
            passChanged = false;
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
                Style stylee = this.FindResource("labelStyle") as Style;
                passwordTextBox.Style = style;
                passwordLabel.Style = stylee;
            }
            else
            {
                disableNewPasswords();
                Style style = this.FindResource("passwordBoxIncorectStyle") as Style;
                Style stylee = this.FindResource("incorectLabelStyle") as Style;
                passwordTextBox.Style = style;
                passwordLabel.Style = stylee;
            }
        }

        public static void clearInstance()
        {
            instance = null;
        }

        public void AddReportSrb(StringBuilder report)
        {
            reportsForPdfSrb.Add(report);
        }

        public void AddReportEng(StringBuilder report)
        {
            reportsForPdfEng.Add(report);
        }

        public List<StringBuilder> getReportsSrb()
        {
            return reportsForPdfSrb;
        }

        public List<StringBuilder> getReportsEng()
        {
            return reportsForPdfEng;
        }

        public User getUser()
        {
            return user;
        }
    }
}
