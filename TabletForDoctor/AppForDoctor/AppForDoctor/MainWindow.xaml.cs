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

        private static Language language = Language.Serbian;
        private static Theme theme = Theme.Light;
        private static MainWindow instance = null;
        private int activePage = 0;

        public MainWindow()
        {
            InitializeComponent();
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
            //TODO: add logIn/register page
            instance = this;
            this.changePage(1);
        }

        public static MainWindow getInstance()
        {
            return instance;
        }

        public static Language GetLanguage()
        {
            return language;
        }

        public static Theme GetTheme()
        {
            return theme;
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
            changeActivePageToLightTheme();
        }

        private void darkButton_Click(object sender, RoutedEventArgs e)
        {
            theme = Theme.Dark;
            MeinWindow.Background = Brushes.Black;
            lightButton.Background = Brushes.LightSlateGray;
            darkButton.Background = Brushes.DeepSkyBlue;
            mainLabel.Foreground = Brushes.White;
            changeActivePageToDarkTheme();
        }

        private void serbianComboItem_Selected(object sender, RoutedEventArgs e)
        {
            language = Language.Serbian;
            serbianComboItem.Content = "Srpski";
            if(englishComboItem != null)    englishComboItem.Content = "Engleski";
            lightButton.Content = "Svetlo";
            darkButton.Content = "Tamno";
            mainLabel.Content = "Postovanje, ulogovani Ste kao lekar.";
            changeActivePageToSerbian();
        }

        private void englishComboItem_Selected(object sender, RoutedEventArgs e)
        {
            language = Language.English;
            serbianComboItem.Content = "Serbian";
           if(englishComboItem != null) englishComboItem.Content = "English";
            lightButton.Content = "Light";
            darkButton.Content = "Dark";
            mainLabel.Content = "Dear user, you are logged in as doctor.";
            changeActivePageToEnglish();
        }

        public void changePage(int page)
        {
            // 1 - main menu
            // 2 - examination
            // 3 - drugs
            this.activePage = page;
            switch(page)
            {
                case 1: 
                    MainFrame.Content = MainMenuPage.getInstance();
                    break;
                case 2:
                    MainFrame.Content = ExaminationPage.getInstance();
                    break;
                case 3:
                    MainFrame.Content = DrugsPage.getInstance();
                    break;
            }
        }

        private void changeActivePageToSerbian()
        {
            switch(activePage)
            {
                case 1:
                    MainMenuPage m = MainMenuPage.getInstance();
                    m.ToSerbian();
                    break;
                case 2:
                    ExaminationPage e = ExaminationPage.getInstance();
                    e.ToSerbian();
                    break;
                case 3:
                    DrugsPage d = DrugsPage.getInstance();
                    d.ToSerbian();
                    break;
            }
        }

        private void changeActivePageToEnglish()
        {
            switch (activePage)
            {
                case 1:
                    MainMenuPage m = MainMenuPage.getInstance();
                    m.ToEnglish();
                    break;
                case 2:
                    ExaminationPage e = ExaminationPage.getInstance();
                    e.ToEnglish();
                    break;
                case 3:
                    DrugsPage d = DrugsPage.getInstance();
                    d.ToEnglish();
                    break;
            }
        }

        private void changeActivePageToLightTheme()
        {
            switch (activePage)
            {
                case 1:
                    MainMenuPage m = MainMenuPage.getInstance();
                    m.ToLightTheme();
                    break;
                case 2:
                    ExaminationPage e = ExaminationPage.getInstance();
                    e.ToLightTheme();
                    break;
                case 3:
                    DrugsPage d = DrugsPage.getInstance();
                    d.ToLightTheme();
                    break;
            }
        }

        private void changeActivePageToDarkTheme()
        {
            switch (activePage)
            {
                case 1:
                    MainMenuPage m = MainMenuPage.getInstance();
                    m.ToDarkTheme();
                    break;
                case 2:
                    ExaminationPage e = ExaminationPage.getInstance();
                    e.ToDarkTheme();
                    break;
                case 3:
                    DrugsPage d = DrugsPage.getInstance();
                    d.ToDarkTheme();
                    break;
            }
        }

        private void MeinWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
