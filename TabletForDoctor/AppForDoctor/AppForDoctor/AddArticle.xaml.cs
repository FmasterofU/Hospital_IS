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
using System.Windows.Shapes;

namespace AppForDoctor
{
    /// <summary>
    /// Interaction logic for AddArticle.xaml
    /// </summary>
    public partial class AddArticle : Window
    {
        public AddArticle()
        {
            InitializeComponent();
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) ToEnglish();
        }

        private void ToSerbian()
        {
            backFromAddButton.Content = "Nazad";
            addArticleButton.Content = "Dodaj";
            titleLabel.Content = "Naslov";
            contentGroupBox.Header = "Sadržaj";
        }

        private void ToEnglish()
        {
            backFromAddButton.Content = "Back";
            addArticleButton.Content = "Add";
            titleLabel.Content = "Title";
            contentGroupBox.Header = "Content";
        }

        private void AddArticleWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow.CenterDialog(this);
        }

        private void backFromAddButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CanIAddArticle()) addArticleButton.IsEnabled = true;
            else addArticleButton.IsEnabled = false;
        }

        private bool CanIAddArticle()
        {
            if (titleTextBox.Text.Trim().Equals("") || contentText.Text.Trim().Equals("")) return false;
            else return true;
        }

        private void addArticleButton_Click(object sender, RoutedEventArgs e)
        {
            BlogPage.getInstance().AddArticle(titleTextBox.Text, contentText.Text);
            this.Close();
        }
    }
}
