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
    /// Interaction logic for BlogPage.xaml
    /// </summary>
    public partial class BlogPage : Page
    {
        private static BlogPage instance = null;
        private ArticleList list;
        private BlogPage()
        {
            InitializeComponent();
            list = new ArticleList();
            foreach (Article a in list.Articles) blogsList.Items.Add("\t\t" + a.Title + "\n" + a.Content);
        }

        public static BlogPage getInstance()
        {
            if (instance == null) instance = new BlogPage();
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) instance.ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) instance.ToEnglish();
            return instance;
        }

        private void ToSerbian()
        {
            menuFromBlog.Content = "Meni";
            addArticleButton.Content = "Dodaj članak";
            commentsButton.Content = "Pogledaj komentare";
        }

        private void ToEnglish()
        {
            menuFromBlog.Content = "Menu";
            addArticleButton.Content = "Add article";
            commentsButton.Content = "See comments";
        }

        private void menuFromBlog_Click(object sender, RoutedEventArgs e)
        {
            //list.SerializeNow();
            instance = null;
            MainWindow w = MainWindow.getInstance();
            w.changePage(1);
        }

        private void addArticleButton_Click(object sender, RoutedEventArgs e)
        {
            AddArticle a = new AddArticle();
            a.ShowDialog();
        }

        public void AddArticle(string title, string content)
        {
            blogsList.Items.Insert(0, "\t\t" + title + "\n" + content);
            list.Articles.Insert(0, new Article(title, content));
        }

        public static void clearInstance()
        {
            instance = null;
        }

        private void commentsButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = MainWindow.getInstance();
            w.changePage(11);
        }
    }
}
