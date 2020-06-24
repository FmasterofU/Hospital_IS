using Common.DB;
using Common.Helpers;
using Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital_WPF.ViewModel
{
	class TerminiViewModel : BindableBase
	{
		BindingList<Termin> mojiTermini;
		BindingList<Termin> ponudjeniTermini;
		BindingList<Doktor> doktori;
		Doktor selektovaniDoktor;
		Termin selektovaniMojTermin;
		DateTime odDatum = DateTime.Now;
		DateTime doDatum = DateTime.Now;
		Termin selektovaniPonudjeniTermin;

		public DateTime OdDatum
		{
			get
			{
				return odDatum;
			}
			set
			{
				odDatum = value;
				OnPropertyChanged("OdDatum");
			}
		}

		public DateTime DoDatum
		{
			get
			{
				return doDatum;
			}
			set
			{
				doDatum = value;
				OnPropertyChanged("DoDatum");
			}
		}


		public Termin SelektovaniMojTermin
		{
			get
			{
				return selektovaniMojTermin;
			}
			set
			{
				selektovaniMojTermin = value;
				OnPropertyChanged("SelektovaniMojTermin");
			}
		}

		public Doktor SelektovaniDoktor
		{
			get
			{
				return selektovaniDoktor;
			}
			set
			{
				selektovaniDoktor = value;
				OnPropertyChanged("SelektovaniDoktor");
			}
		}

		public Termin SelektovaniPonudjeniTermin
		{
			get
			{
				return selektovaniPonudjeniTermin;
			}
			set
			{
				selektovaniPonudjeniTermin = value;
				OnPropertyChanged("SelektovaniPonudjeniTermin");
			}
		}

		public BindingList<Termin> MojiTermini
		{
			get
			{
				return mojiTermini;
			}
			set
			{
				mojiTermini = value;
				OnPropertyChanged("Termini");
			}

		}
		public BindingList<Termin> PonudjeniTermini
		{
			get
			{
				return ponudjeniTermini;
			}
			set
			{
				ponudjeniTermini = value;
				OnPropertyChanged("PonudjeniTermini");
			}

		}
		public BindingList<Doktor> Doktori
		{
			get
			{
				return doktori;
			}
			set
			{
				doktori = value;
				OnPropertyChanged("Doktori");
			}

		}


		public MyICommand OtkaziCommand { get; set; }
		public MyICommand ZakaziCommand { get; set; }
		public MyICommand PronadjiCommand { get; set; }
		public TerminiViewModel()
		{
			MojiTermini = Baza.GetMojiTermini();
			Doktori = new BindingList<Doktor>(Baza.Doktori);
			OtkaziCommand = new MyICommand(OnOtkazi);
			ZakaziCommand = new MyICommand(OnZakazi);
			PronadjiCommand = new MyICommand(OnPronadji);
		}

		public void OnOtkazi()
		{
			try
			{
				Baza.OtkaziTermin(SelektovaniMojTermin);
				MojiTermini.Remove(SelektovaniMojTermin);
				MessageBox.Show($"Uspesno otkazan termin.");
			}
			catch { }
		}

		public void OnZakazi()
		{
			try
			{
				selektovaniPonudjeniTermin.Pacijent = Baza.TrenutniKorisnik.KorisnickoIme;
				Baza.Termini.Add(selektovaniPonudjeniTermin);
				MojiTermini.Add(selektovaniPonudjeniTermin);
				Baza.StoreData();
				MessageBox.Show($"Uspesno zakazan termin u {selektovaniPonudjeniTermin.Vreme.ToShortTimeString()}.");
			}
			catch { }
		}

		public void OnPronadji()
		{
			try
			{
				PonudjeniTermini = Baza.GetSlobodniTerminiPoDoktoru(selektovaniDoktor, OdDatum, DoDatum);
				if (PonudjeniTermini.Count == 0)
				{
					if (MessageBox.Show("Nema slobodnog termina za datog doktora i vreme, zelite li da vam ponudimo druge termine u narednih 14 dana kod zadatog doktora?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
					{
						DateTime danas = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
						PonudjeniTermini = Baza.GetSlobodniTerminiPoDoktoru(selektovaniDoktor, danas, danas + new TimeSpan(14, 0, 0, 0, 0));
					}

				}
			}
			catch { }
		}
	}
}
