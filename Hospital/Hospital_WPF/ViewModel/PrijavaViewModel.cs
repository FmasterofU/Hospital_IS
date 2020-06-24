using Common.DB;
using Common.Helpers;
using Hospital_WPF.BindingModel;
using Hospital_WPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital_WPF.ViewModel
{
	class PrijavaViewModel : BindableBase
	{
		PrijavaBindingModel prijava = new PrijavaBindingModel();
		Prijava window;
		public PrijavaBindingModel Prijava
		{
			get
			{
				return prijava;
			}
			set
			{
				prijava = value;
				OnPropertyChanged("Prijava");
			}
		}

		public MyICommand PrijavaCommand { get; set; }
		public MyICommand RegistracijaCommand { get; set; }
		public PrijavaViewModel(Prijava window)
		{
			Baza.LoadData();
			this.window = window;
			PrijavaCommand = new MyICommand(OnPrijava);
			RegistracijaCommand = new MyICommand(OnRegistracija);
		}

		public void OnPrijava()
		{
			Prijava.Validate();

			if (Prijava.IsValid)
			{
				Baza.TrenutniKorisnik = Baza.Korisnici[prijava.KorisnickoIme];
				MainWindow w = new MainWindow();
				w.Show();
				window.Close();
			}
		}
		public void OnRegistracija()
		{
			Registracija w = new Registracija();
			w.Show();
			window.Close();
		}
	}
}
