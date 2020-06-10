using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace HCIProjekat
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		public MainWindow()
		{
			InitializeComponent();
			this.Left = (System.Windows.SystemParameters.PrimaryScreenWidth / 2) - (this.Width / 2);
			this.Top = (System.Windows.SystemParameters.PrimaryScreenHeight / 2) - (this.Height / 2);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string name)
		{
			if(PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(name));
			}
		}

		private string _lozinka;

		public string lozinka
		{
			get
			{
				return _lozinka;
			}
			set
			{
				if(value != _lozinka)
				{
					_lozinka = value;
					OnPropertyChanged("Lozinka");
				}
			}
		}

		private string _email;

		public string email
		{
			get
			{
				return _email;
			}
			set
			{
				if (value != _email)
				{
					_email = value;
					OnPropertyChanged("Email");
				}
			}
		}

		private void Prijava_Click(object sender, RoutedEventArgs e)
		{
			var s = new View.GlavnaStrana();
			s.Show();
			this.Close();
		}

		private void Registracija_Click(object sender, RoutedEventArgs e)
		{
			var s = new View.Registracija();
			s.Show();
			this.Close();
		}
	}
}
