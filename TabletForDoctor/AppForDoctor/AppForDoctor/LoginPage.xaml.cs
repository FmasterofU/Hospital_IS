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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private static LoginPage instance = null;
        private LoginPage()
        {
            InitializeComponent();
        }

        public static LoginPage getInstance()
        {
            if (instance == null) instance = new LoginPage();
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) instance.ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) instance.ToEnglish();
            return instance;
        }

        private void ToSerbian()
        {
            passLabel.Content = "Lozinka:";
        }

        private void ToEnglish()
        {
            passLabel.Content = "Password:";
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            User u = UserList.IsDoctor(mailTextBox.Text, passTextBox.Password);
            if (u == null)
            {
                Style style = this.FindResource("incorectLabelStyle") as Style;
                mailLabel.Style = style;
                passLabel.Style = style;
                return;
            }
            MainWindow w = MainWindow.getInstance();
            w.changePage(4);
            EditProfilePage.getInstance(u);
            w.changePage(1);
            instance = null;
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!mailTextBox.Text.Trim().Equals("") && !passTextBox.Password.Trim().Equals("")) loginButton.IsEnabled = true;
            else loginButton.IsEnabled = false;
        }

        private void passTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!mailTextBox.Text.Trim().Equals("") && !passTextBox.Password.Trim().Equals("")) loginButton.IsEnabled = true;
            else loginButton.IsEnabled = false;
        }

        private void _KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Enter)
            {
                if (loginButton.IsEnabled) loginButton.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }
    }
}
