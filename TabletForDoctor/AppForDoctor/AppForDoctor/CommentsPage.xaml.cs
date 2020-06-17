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
    /// Interaction logic for CommentsPage.xaml
    /// </summary>
    public partial class CommentsPage : Page
    {
        private static CommentsPage instance = null;
        private CommentsPage()
        {
            InitializeComponent();
            commentsListBox.Items.Add("Jova Jovic:\n   Stručan lekar koji ume i da izleči i da nasmeje pacijente.");
            commentsListBox.Items.Add("Mika Mikic:\n   Nedovoljno profesionalan, misli da su se pacijenti namerno\nrazboleli.");
        }

        public static CommentsPage getInstance()
        {
            if (instance == null) instance = new CommentsPage();
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) instance.ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) instance.ToEnglish();
            return instance;
        }

        private void ToSerbian()
        {
            blogFromCommentsButton.Content = "Nazad";
        }

        private void ToEnglish()
        {
            blogFromCommentsButton.Content = "Back";
        }

        private void blogFromCommentsButton_Click(object sender, RoutedEventArgs e)
        {
            instance = null;
            MainWindow w = MainWindow.getInstance();
            w.changePage(7);
        }
    }
}
