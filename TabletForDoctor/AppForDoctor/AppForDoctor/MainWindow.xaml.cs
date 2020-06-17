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
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.ComponentModel;
using System.Drawing;

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
            instance = this;
            this.changePage(9);

            /*using (PdfDocument document = new PdfDocument())
            {
                PdfPage page = document.Pages.Add();
                PdfGraphics graphics = page.Graphics;
                PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 35);
                PdfStringFormat format = new PdfStringFormat();
                format.Alignment = PdfTextAlignment.Left;
                format.LineAlignment = PdfVerticalAlignment.Top;
                //graphics.DrawString("Hello world!", font, PdfPens.Black, PdfBrushes.Green, new RectangleF(20, 20, 200, 20), format);
                graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));
                document.Save("Sample.pdf");
                document.Close(true);
            }*/
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
            MainMenuPage.clearInstance();
            ExaminationPage.clearInstance();
            DrugsPage.clearInstance();
            EditProfilePage.clearInstance();
            RefferalsPage.clearInstance();
            MedHistoryPage.clearInstance();
            BlogPage.clearInstance();
            PausesPage.clearInstance();
            MySchedulePage.clearInstance();
            changePage(9);
        }

        private void lightButton_Click(object sender, RoutedEventArgs e)
        {
            if (theme == Theme.Light) return;
            theme = Theme.Light;
            //this.Resources["foregroundColor"] = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            Application.Current.Resources["foregroundColor"] = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
            Application.Current.Resources["backgroundColor"] = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            lightButton.Background = System.Windows.Media.Brushes.DodgerBlue;
            darkButton.Background = System.Windows.Media.Brushes.LightSlateGray;
            UpdateActivePage();
        }

        private void darkButton_Click(object sender, RoutedEventArgs e)
        {
            if (theme == Theme.Dark) return;
            theme = Theme.Dark;
            //this.Resources["foregroundColor"] = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Application.Current.Resources["foregroundColor"] = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
            Application.Current.Resources["backgroundColor"] = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
            lightButton.Background = System.Windows.Media.Brushes.LightSlateGray;
            darkButton.Background = System.Windows.Media.Brushes.DodgerBlue;
            UpdateActivePage();
        }

        private void serbianComboItem_Selected(object sender, RoutedEventArgs e)
        {
            if (language == Language.Serbian) return;
            language = Language.Serbian;
            serbianComboItem.Content = "Srpski";
            if (englishComboItem != null) englishComboItem.Content = "Engleski";
            lightButton.Content = "Svetlo";
            darkButton.Content = "Tamno";
            if (activePage != 9) mainLabel.Content = "Poštovanje, ulogovani Ste kao lekar.";
            else mainLabel.Content = "Trenutno niste ulogovani.";
            editProfileButton.Content = "Uredi profil";
            UpdateActivePage();
        }

        private void englishComboItem_Selected(object sender, RoutedEventArgs e)
        {
            if (language == Language.English) return;
            language = Language.English;
            serbianComboItem.Content = "Serbian";
            if (englishComboItem != null) englishComboItem.Content = "English";
            lightButton.Content = "Light";
            darkButton.Content = "Dark";
            if(activePage != 9) mainLabel.Content = "Dear user, you are logged in as doctor.";
            else mainLabel.Content = "You are not logged in.";
            editProfileButton.Content = "Edit profile";
            UpdateActivePage();
        }

        private void editProfileButton_Click(object sender, RoutedEventArgs e)
        {
            this.changePage(4);
        }

        public void changePage(int page)
        {
            // 1 - main menu
            // 2 - examination
            // 3 - drugs
            // 4 - edit profile
            // 5 - refferals
            // 6 - medical history
            // 7 - blog
            // 8 - pauses
            // 9 - login
            // 10 - schedule
            // 11 - comments
            if (language == Language.Serbian)
            {
                if (page != 9) mainLabel.Content = "Poštovanje, ulogovani Ste kao lekar.";
                else mainLabel.Content = "Trenutno niste ulogovani.";
            }
            else
            {
                if (page != 9) mainLabel.Content = "Dear user, you are logged in as doctor.";
                else mainLabel.Content = "You are not logged in.";
            }
            if (editProfileButton.Visibility == Visibility.Hidden) editProfileButton.Visibility = Visibility.Visible;
            if (logOutButton.IsEnabled == false) logOutButton.IsEnabled = true;
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
                case 4:
                    MainFrame.Content = EditProfilePage.getInstance(activePage);
                    editProfileButton.Visibility = Visibility.Hidden;
                    break;
                case 5:
                    MainFrame.Content = RefferalsPage.getInstance();
                    break;
                case 6:
                    MainFrame.Content = MedHistoryPage.getInstance();
                    break;
                case 7:
                    MainFrame.Content = BlogPage.getInstance();
                    break;
                case 8:
                    MainFrame.Content = PausesPage.getInstance();
                    break;
                case 9:
                    MainFrame.Content = LoginPage.getInstance();
                    editProfileButton.Visibility = Visibility.Hidden;
                    logOutButton.IsEnabled = false;
                    break;
                case 10:
                    MainFrame.Content = MySchedulePage.getInstance();
                    break;
                case 11:
                    MainFrame.Content = CommentsPage.getInstance();
                    break;
            }
            this.activePage = page;
        }

        /*private void changeActivePageToSerbian()
        {
            switch(activePage)
            {
                case 1:
                    MainMenuPage.getInstance();
                    break;
                case 2:
                    ExaminationPage.getInstance();
                    //e.ToSerbian();
                    break;
                case 3:
                    DrugsPage.getInstance();
                    break;
                case 4:
                    EditProfilePage.getInstance();
                    break;
                case 5:
                    RefferalsPage.getInstance();
                    break;
            }
        }

        private void changeActivePageToEnglish()
        {
            switch (activePage)
            {
                case 1:
                    MainMenuPage.getInstance();
                    break;
                case 2:
                    ExaminationPage.getInstance();
                    //e.ToEnglish();
                    break;
                case 3:
                    DrugsPage.getInstance();
                    break;
                case 4:
                    EditProfilePage.getInstance();
                    break;
                case 5:
                    RefferalsPage.getInstance();
                    break;
            }
        }

        private void changeActivePageToLightTheme()
        {
            switch (activePage)
            {
                case 1:
                    MainMenuPage.getInstance();
                    break;
                case 2:
                    ExaminationPage.getInstance();
                    //e.ToLightTheme();
                    break;
                case 3:
                    DrugsPage.getInstance();
                    break;
                case 4:
                    EditProfilePage.getInstance();
                    break;
                case 5:
                    RefferalsPage.getInstance();
                    break;
            }
        }

        private void changeActivePageToDarkTheme()
        {
            switch (activePage)
            {
                case 1:
                    MainMenuPage.getInstance();
                    break;
                case 2:
                    ExaminationPage.getInstance();
                    //e.ToDarkTheme();
                    break;
                case 3:
                    DrugsPage.getInstance();
                    break;
                case 4:
                    EditProfilePage.getInstance();
                    break;
                case 5:
                    RefferalsPage.getInstance();
                    break;
            }
        }*/

        private void UpdateActivePage()
        {
            switch (activePage)
            {
                case 1:
                    MainMenuPage.getInstance();
                    break;
                case 2:
                    ExaminationPage.getInstance();
                    break;
                case 3:
                    DrugsPage.getInstance();
                    break;
                case 4:
                    EditProfilePage.getInstance();
                    break;
                case 5:
                    RefferalsPage.getInstance();
                    break;
                case 6:
                    MedHistoryPage.getInstance();
                    break;
                case 7:
                    BlogPage.getInstance();
                    break;
                case 8:
                    PausesPage.getInstance();
                    break;
                case 9:
                    LoginPage.getInstance();
                    break;
                case 10:
                    MySchedulePage.getInstance();
                    break;
                case 11:
                    CommentsPage.getInstance();
                    break;
            }
        }

        public static void CenterDialog(Window w)
        {
            w.Left = instance.Left + (instance.Width - w.ActualWidth) / 2;
            w.Top = instance.Top + (instance.Height - w.ActualHeight) / 2;
        }

        private void MeinWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void GenerateReports(List<StringBuilder> srb, List<StringBuilder> eng)
        {
            StringBuilder srbsb = new StringBuilder();
            srbsb.Append("--------------------------------------------\n");
            foreach(StringBuilder sb in srb)
            {
                srbsb.Append(sb.ToString());
                srbsb.Append("--------------------------------------------\n\n");
            }

            StringBuilder engsb = new StringBuilder();
            engsb.Append("--------------------------------------------\n");
            foreach (StringBuilder sb in eng)
            {
                engsb.Append(sb.ToString());
                engsb.Append("--------------------------------------------\n\n");
            }

            try
            {
                using (PdfDocument document = new PdfDocument())
                {
                    PdfPage page = document.Pages.Add();
                    PdfGraphics graphics = page.Graphics;
                    PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 35);
                    PdfStringFormat format = new PdfStringFormat();
                    format.Alignment = PdfTextAlignment.Left;
                    format.LineAlignment = PdfVerticalAlignment.Top;
                    graphics.DrawString(srbsb.ToString(), font, PdfBrushes.Black, new PointF(0, 0));
                    document.Save("Srpski.pdf");
                    document.Close(true);
                }

                using (PdfDocument document = new PdfDocument())
                {
                    PdfPage page = document.Pages.Add();
                    PdfGraphics graphics = page.Graphics;
                    PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 35);
                    PdfStringFormat format = new PdfStringFormat();
                    format.Alignment = PdfTextAlignment.Left;
                    format.LineAlignment = PdfVerticalAlignment.Top;
                    graphics.DrawString(engsb.ToString(), font, PdfBrushes.Black, new PointF(0, 0));
                    document.Save("English.pdf");
                    document.Close(true);
                }
            }
            catch (Exception e) { }
        }
    }
}
