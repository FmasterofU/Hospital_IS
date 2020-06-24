using Common.DB;
using Common.Helpers;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hospital_WPF.BindingModel
{
	public class IzmenaBindingModel : ValidationBase
	{
		string korisnickoIme;
		string ime;
		string prezime;
		string lozinka;
		string jmbg;
		string adresa;
		string brojTelefona;
		DateTime datumRodjenja = DateTime.Now;

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
		public string Ime
		{
			get
			{
				return ime;
			}
			set
			{
				ime = value;
				OnPropertyChanged("Ime");
			}
		}
		public string Prezime
		{
			get
			{
				return prezime;
			}
			set
			{
				prezime = value;
				OnPropertyChanged("Prezime");
			}
		}
		public string Lozinka
		{
			get
			{
				return lozinka;
			}
			set
			{
				lozinka = value;
				OnPropertyChanged("Lozinka");
			}
		}
		public string Jmbg
		{
			get
			{
				return jmbg;
			}
			set
			{
				jmbg = value;
				OnPropertyChanged("Jmbg");
			}
		}
		public string Adresa
		{
			get
			{
				return adresa;
			}
			set
			{
				adresa = value;
				OnPropertyChanged("Adresa");
			}
		}
		public string BrojTelefona
		{
			get
			{
				return brojTelefona;
			}
			set
			{
				brojTelefona = value;
				OnPropertyChanged("BrojTelefona");
			}
		}
		public DateTime DatumRodjenja
		{
			get
			{
				return datumRodjenja;
			}
			set
			{
				datumRodjenja = value;
				OnPropertyChanged("DatumRodjenja");
			}
		}

		public IzmenaBindingModel() { }
		public IzmenaBindingModel(Korisnik k)
		{
			Ime = k.Ime;
			Prezime = k.Prezime;
			KorisnickoIme = k.KorisnickoIme;
			Lozinka = k.Lozinka;
			Jmbg = k.Jmbg;
			Adresa = k.Adresa;
			BrojTelefona = k.BrojTelefona;
			DatumRodjenja = k.DatumRodjenja;

		}

		public Korisnik ToKorisnik()
		{
			Korisnik k = new Korisnik();

			k.Ime = Ime;
			k.Prezime = Prezime;
			k.KorisnickoIme = KorisnickoIme;
			k.Lozinka = Lozinka;
			k.Jmbg = Jmbg;
			k.Adresa = Adresa;
			k.BrojTelefona = BrojTelefona;
			k.DatumRodjenja = DatumRodjenja;

			return k;
		}
		protected override void ValidateSelf()
		{
			if (String.IsNullOrEmpty(Ime))
			{
				ValidationErrors["Ime"] = "Ime obavezno.";
			}
			if (String.IsNullOrEmpty(Prezime))
			{
				ValidationErrors["Prezime"] = "Prezime obavezno.";
			}




			if (String.IsNullOrEmpty(Lozinka))
			{
				ValidationErrors["Lozinka"] = "Lozinka obavezna.";
			}
			else if (!validirajLozinku())
			{
				ValidationErrors["Lozinka"] = "Lozinka mora imati 8 slova i jednu cifru.";
			}


		}

		bool validirajLozinku()
		{
			Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*[0-9])(?=.{8,})");
			if (regex.IsMatch(lozinka))
			{
				return true;
			}
			return false;
		}

	}
}
