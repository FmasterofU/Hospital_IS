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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum Language
        {
            Serbian,
            English
        }

        public enum Theme
        {
            Dark,
            Light
        }

        private Language language = Language.Serbian;
        private Theme theme = Theme.Light;
        private static MainWindow instance = null;

        public MainWindow()
        {
            InitializeComponent();
            //TODO: add logIn/register page
            this.changePage(1);
            instance = this;
        }

        public static MainWindow getInstance()
        {
            return instance;
        }

        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: implement later
        }

        private void lightButton_Click(object sender, RoutedEventArgs e)
        {
            theme = Theme.Light;
            MeinWindow.Background = Brushes.White;
            lightButton.Background = Brushes.DeepSkyBlue;
            darkButton.Background = Brushes.LightSlateGray;
            mainLabel.Foreground = Brushes.Black;
        }

        private void darkButton_Click(object sender, RoutedEventArgs e)
        {
            theme = Theme.Dark;
            MeinWindow.Background = Brushes.Black;
            lightButton.Background = Brushes.LightSlateGray;
            darkButton.Background = Brushes.DeepSkyBlue;
            mainLabel.Foreground = Brushes.White;
        }

        private void serbianComboItem_Selected(object sender, RoutedEventArgs e)
        {
            language = Language.Serbian;
            serbianComboItem.Content = "Srpski";
            if(englishComboItem != null)    englishComboItem.Content = "Engleski";
            lightButton.Content = "Svetlo";
            darkButton.Content = "Tamno";
            mainLabel.Content = "Postovanje, ulogovani Ste kao lekar.";
        }

        private void englishComboItem_Selected(object sender, RoutedEventArgs e)
        {
            language = Language.English;
            serbianComboItem.Content = "Serbian";
           if(englishComboItem != null) englishComboItem.Content = "English";
            lightButton.Content = "Light";
            darkButton.Content = "Dark";
            mainLabel.Content = "Dear user, you are logged in as doctor.";
        }

        public void changePage(int page)
        {
            // 1 - main menu
            // 2 - examination
            switch(page)
            {
                case 1: 
                    MainFrame.Content = new MainMenuPage();
                    break;
                case 2:
                    MainFrame.Content = new ExaminationPage();
                    break;
            }
        }
    }
}
