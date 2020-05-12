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

namespace HCIProjekat.View
{
	/// <summary>
	/// Interaction logic for GlavnaStrana.xaml
	/// </summary>
	public partial class GlavnaStrana : Window
	{
		public GlavnaStrana()
		{
			InitializeComponent();
		}

		private void Cenovnik_Click(object sender, RoutedEventArgs e)
		{

		}

		private void MojProfil_Click(object sender, RoutedEventArgs e)
		{
			glavnaStranica.Content = new MojProfil();
		}

		private void ONama_Click(object sender, RoutedEventArgs e)
		{
			glavnaStranica.Content = new ONama();
		}

		private void CestaPitanja_Click(object sender, RoutedEventArgs e)
		{
			glavnaStranica.Content = new CestaPitanja();
		}

		private void OdjaviSe_Click(object sender, RoutedEventArgs e)
		{
			var s = new View.Odjava();
			s.ShowDialog();
		}

		private void Zakazi_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Promeni_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Pregledaj_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Otkazi_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Kontakt_Click(object sender, RoutedEventArgs e)
		{
			glavnaStranica.Content = new Kontakt();
		}
	}
}
