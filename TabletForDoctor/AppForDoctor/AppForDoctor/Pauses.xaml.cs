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
    /// Interaction logic for Pauses.xaml
    /// </summary>
    public partial class Pauses : Window
    {
        public Pauses()
        {
            InitializeComponent();
            if (MainWindow.GetLanguage() == MainWindow.Language.Serbian) ToSerbian();
            else if (MainWindow.GetLanguage() == MainWindow.Language.English) ToEnglish();
        }

        private void ToSerbian()
        {
            backFromPausesButton.Content = "Nazad";
            savePausesButton.Content = "Sacuvaj";
        }

        private void ToEnglish()
        {
            backFromPausesButton.Content = "Back";
            savePausesButton.Content = "Save";
        }

        private void PausesWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow.CenterDialog(this);
        }

        private void backFromPausesButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
