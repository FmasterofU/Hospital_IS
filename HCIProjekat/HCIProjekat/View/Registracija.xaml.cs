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
	/// Interaction logic for Registracija.xaml
	/// </summary>
	public partial class Registracija : Window
	{
		public Registracija()
		{
			InitializeComponent();
			this.Left = (System.Windows.SystemParameters.PrimaryScreenWidth / 2) - (this.Width / 2);
			this.Top = (System.Windows.SystemParameters.PrimaryScreenHeight / 2) - (this.Height / 2);
		}
	}
}
