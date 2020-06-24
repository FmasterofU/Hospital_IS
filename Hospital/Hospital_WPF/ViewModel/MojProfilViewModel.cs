using Common.DB;
using Common.Helpers;
using Common.Model;
using Hospital_WPF.BindingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital_WPF.ViewModel
{
	class MojProfilViewModel : BindableBase
	{
		IzmenaBindingModel korisnik;

		public IzmenaBindingModel Korisnik
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

		public MyICommand IzmeniCommand { get; set; }

		public MojProfilViewModel()
		{
			Korisnik = new IzmenaBindingModel(Baza.TrenutniKorisnik);
			IzmeniCommand = new MyICommand(OnIzmeni);
		}

		public void OnIzmeni()
		{
			Korisnik.Validate();

			if (korisnik.IsValid)
			{
				Korisnik k = korisnik.ToKorisnik();
				Baza.Korisnici[korisnik.KorisnickoIme] = k;
				Baza.TrenutniKorisnik = k;
				MessageBox.Show("Uspesna izmena podataka");
			}
		}

	}
}
