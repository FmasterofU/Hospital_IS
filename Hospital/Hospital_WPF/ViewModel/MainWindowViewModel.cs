using Common.DB;
using Common.Helpers;
using Hospital_WPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_WPF.ViewModel
{
	class MainWindowViewModel : BindableBase
	{
		string korisnickoIme;
		MainWindow window;

		public string KorisnickoIme
		{
			get
			{
				return korisnickoIme;
			}
			set
			{
				korisnickoIme = value;
				OnPropertyChanged("KorisnickoIme");
			}
		}

		public MyICommand OdjavaCommand { get; set; }
		public MainWindowViewModel(MainWindow window)
		{
			Baza.StoreData();
			this.window = window;
			KorisnickoIme = Baza.TrenutniKorisnik.KorisnickoIme;
			OdjavaCommand = new MyICommand(OnOdjava);
		}

		public void OnOdjava()
		{
			Baza.StoreData();
			Baza.TrenutniKorisnik = null;
			Prijava w = new Prijava();
			w.Show();
			window.Close();
		}
	}
}
