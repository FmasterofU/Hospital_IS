using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat.Model
{

    public class Pacijent
    {
        public String jmbg { get; }
        public String ime { get; set; }
        public String prezime { get; set; }
        public String imeRoditelja { get; set; }
        public DateTime datumRodjenja { get; set; }
        public String pol {get;set;}
        public String adresa { get; set; }
        public String email { get; set; }
        public String telefon { get; set; }
        public int status { get; set; } //0-neaktivan 1-aktivan 2-na lecenju
        public bool moguceZakazivanje { get; set; }



        public Pacijent(String jmbg,String ime,String prezime,String roditelj,DateTime datum,String pol,String adresa,String email,String telefon)
        {
            this.jmbg = jmbg;
            this.ime = ime;
            this.prezime = prezime;
            this.imeRoditelja = roditelj;
            this.datumRodjenja = datum;
            this.adresa = adresa;
            this.email = email;
            this.telefon = telefon;
            this.status = 1;
            this.moguceZakazivanje = true;
            this.pol = pol;
        }

        public Pacijent(String jmbg, String ime, String prezime, String roditelj, DateTime datum, String pol, String adresa, String email, String telefon,int status)
        {
            this.jmbg = jmbg;
            this.ime = ime;
            this.prezime = prezime;
            this.imeRoditelja = roditelj;
            this.datumRodjenja = datum;
            this.adresa = adresa;
            this.email = email;
            this.telefon = telefon;
            this.status = 1;
            this.moguceZakazivanje = true;
            this.pol = pol;
            this.status = status;
        }

        public void editPacijent(Pacijent p)
        {
            ime = p.ime;
            prezime = p.prezime;
            imeRoditelja = p.imeRoditelja;
            datumRodjenja = p.datumRodjenja;
            pol = p.pol;
            adresa = p.adresa;
            email = p.email;
            telefon = p.telefon;
            status = p.status;
            moguceZakazivanje = p.moguceZakazivanje;
           
        }

        public String getStatusString()
        {
            if (status == 0)
                return "Neaktivan";
            else if (status == 1)
                return "Aktivan";
            else
                return "Na lecenju";
        }
    }
}
