using Common.DB;
using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_WPF.BindingModel
{
	class PrijavaBindingModel : ValidationBase
	{
		string korisnickoIme;
		string lozinka;

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


		protected override void ValidateSelf()
		{
			if (Baza.Korisnici.ContainsKey(korisnickoIme))
				if (Baza.Korisnici[korisnickoIme].Lozinka == lozinka)
					return;

			ValidationErrors["Greska"] = "Korisnicko ime i lozinka se ne poklapaju";

		}
	}
}
