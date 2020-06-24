using Common.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Common.DB
{
	public class Baza
	{
		public static Korisnik TrenutniKorisnik;
		public static Dictionary<string, Korisnik> Korisnici = new Dictionary<string, Korisnik>()
		{
			{ "perap", new Korisnik()
				{
					KorisnickoIme = "perap",
					Ime = "pera",
					Prezime = "peric",
					Lozinka = "perap123",
					Jmbg = "1231231231231",
					DatumRodjenja = DateTime.Now,
					BrojTelefona = "0123123123",
					Adresa = "perina 1"

				}
			}
		};
		public static List<Termin> Termini = new List<Termin>()
		{
			new Termin(){Doktor="Doktor 1",Pacijent="perap",Vreme=new DateTime(2020,6,10,10,15,0,0)},
			new Termin(){Doktor="Doktor 2",Pacijent="perap",Vreme=new DateTime(2020,6,10,10,30,0,0)},
			new Termin(){Doktor="Doktor 1",Pacijent="perap",Vreme=new DateTime(2020,6,10,10,45,0,0)},
			new Termin(){Doktor="Doktor 2",Pacijent="perap",Vreme=new DateTime(2020,6,10,11,00,0,0)},
			new Termin(){Doktor="Doktor 1",Pacijent="perap",Vreme=new DateTime(2020,6,10,11,15,0,0)},
		};
		public static List<Doktor> Doktori = new List<Doktor>()
		{
			new Doktor() {Id= 0,ImePrezime = "Doktor 1"},
			new Doktor() {Id= 1,ImePrezime = "Doktor 2"},
			new Doktor() {Id= 2,ImePrezime = "Doktor 3"},
			new Doktor() {Id= 3,ImePrezime = "Doktor 4"},
			new Doktor() {Id= 4,ImePrezime = "Doktor 5"},
			new Doktor() {Id= 5,ImePrezime = "Doktor 6"},

		};



		public static BindingList<Termin> GetMojiTermini()
		{
			BindingList<Termin> termini = new BindingList<Termin>();

			foreach (Termin item in Termini)
			{
				if (item.Pacijent == TrenutniKorisnik.KorisnickoIme)
					termini.Add(item);
			}

			return termini;
		}
		public static BindingList<Termin> GetSlobodniTerminiPoDoktoru(Doktor doktor, DateTime odDan, DateTime doDan)
		{
			BindingList<Termin> ponudjeniTermini = new BindingList<Termin>();


			for (DateTime dt = odDan; dt < doDan + new TimeSpan(1, 0, 0, 0, 0); dt += new TimeSpan(0, 0, 15, 0, 0))
			{
				if (dt.Hour < 7 || dt.Hour > 20)
					continue;

				bool nadjen = false;
				foreach (Termin item in Termini)
				{
					if (item.Vreme == dt && item.Doktor == doktor.ImePrezime)
					{
						nadjen = true;
						break;
					}
				}
				if (!nadjen)
					ponudjeniTermini.Add(new Termin() { Doktor = doktor.ImePrezime, Vreme = dt });
			}

			return ponudjeniTermini;
		}


		public static void OtkaziTermin(Termin termin)
		{
			for (int i = 0; i < Termini.Count; i++)
			{
				if (Termini[i].Vreme == termin.Vreme && Termini[i].Doktor == termin.Doktor)
				{
					Termini.RemoveAt(i);
					break;
				}
			}
		}

		public static void LoadData()
		{
			Korisnici = new Dictionary<string, Korisnik>();
			XmlSerializer deserializer = new XmlSerializer(typeof(List<Korisnik>));
			using (TextReader reader = new StreamReader("../../korisnici.xml"))
			{
				List<Korisnik> korisnici = (List<Korisnik>)deserializer.Deserialize(reader);
				korisnici.ForEach(k => Korisnici.Add(k.KorisnickoIme, k));
			}

			XmlSerializer deserializer2 = new XmlSerializer(typeof(List<Termin>));
			using (TextReader reader = new StreamReader("../../termini.xml"))
			{
				Termini = (List<Termin>)deserializer2.Deserialize(reader);
			}

			XmlSerializer deserializer3 = new XmlSerializer(typeof(List<Doktor>));
			using (TextReader reader = new StreamReader("../../doktori.xml"))
			{
				Doktori = (List<Doktor>)deserializer3.Deserialize(reader);
			}
		}

		public static void StoreData()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Korisnik>));
			using (TextWriter textWriter = new StreamWriter("../../korisnici.xml"))
			{
				serializer.Serialize(textWriter, Korisnici.Values.ToList());
			}

			XmlSerializer serializer2 = new XmlSerializer(typeof(List<Termin>));
			using (TextWriter textWriter = new StreamWriter("../../termini.xml"))
			{
				serializer2.Serialize(textWriter, Termini);
			}

			XmlSerializer serializer3 = new XmlSerializer(typeof(List<Doktor>));
			using (TextWriter textWriter = new StreamWriter("../../doktori.xml"))
			{
				serializer3.Serialize(textWriter, Doktori);
			}
		}
	}
}
