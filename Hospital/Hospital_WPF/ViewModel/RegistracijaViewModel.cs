using Common.DB;
using Common.Helpers;
using Common.Model;
using Hospital_WPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Effects;

namespace Hospital_WPF.ViewModel
{
	class RegistracijaViewModel : BindableBase
	{


		Korisnik korisnik = new Korisnik();
		Registracija window;
		public Korisnik Korisnik
		{
			get
			{
				return korisnik;
			}
			set
			{
				korisnik = value;
				OnPropertyChanged("Korisnik");
			}
		}

		public MyICommand RegistracijaCommand { get; set; }
		public MyICommand PrijavaCommand { get; set; }

		public RegistracijaViewModel(Registracija window)
		{
			this.window = window;
			RegistracijaCommand = new MyICommand(OnRegistracija);
			PrijavaCommand = new MyICommand(OnPrijava);
		}

		public void OnPrijava()
		{
			Prijava w = new Prijava();
			w.Show();
			window.Close();

		}
		public void OnRegistracija()
		{
			Korisnik.Validate();

			if (Korisnik.IsValid)
			{
				Baza.Korisnici.Add(Korisnik.Jmbg, korisnik);
				Baza.StoreData();
				Prijava w = new Prijava();
				w.Show();
				window.Close();
			}
		}
	}
}
