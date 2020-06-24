using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace HCIProjekat.Model
{
    public class Zaposleni
    {
        public String id { get; }
        public String ime { get; set; }
        public String prezime { get; set; }
        public String zvanje { get; set; }
        public DateTime datumRodjenja { get; set; }
        public String pol { get; set; }
        public String adresa { get; set; }
        public String email { get; set; }
        public String telefon { get; set; }
        public int status { get; set; } //0-neaktivan 1-aktivan 2-na odmoru
        public String tipZaposlenog { get; }
        public ObservableCollection<Termin> zakazaniTermini { get; set; }

        public Zaposleni(String id, String ime, String prezime, String tip, DateTime datum, String pol, String adresa, String email, String telefon , String zvanje)
        {
            this.id = id;
            this.ime = ime;
            this.prezime = prezime;
            this.tipZaposlenog = tip;
            this.datumRodjenja = datum;
            this.adresa = adresa;
            this.email = email;
            this.telefon = telefon;
            this.status = 1;
            this.pol = pol;
            this.zvanje = zvanje;
            
                zakazaniTermini = new ObservableCollection<Termin>();
           
        }

        public void dodajTermin(Termin t)
        {
            zakazaniTermini.Add(t);
        }

        public void ukloniTermin(DateTime vreme, int soba)
        {
            Termin t = searchTerminDanSoba(vreme, soba);
            zakazaniTermini.Remove(t);
        }

        public Termin searchTerminDanSoba(DateTime vreme, int soba)
        {
            foreach (Termin t in zakazaniTermini)
            {
                if (t.vreme.Equals(vreme) && t.soba == soba)
                    return t;

            }
            return null;
        }

        public Termin searchTerminVreme(DateTime vreme)
        {
            foreach (Termin t in zakazaniTermini)
            {
                if (t.vreme.Equals(vreme))
                    return t;

            }
            return null;
        }

        public void izmeniTermin(Termin t)
        {
            Termin term = searchTerminDanSoba(t.vreme, t.soba);
            term.editTermin(t);
        }

        public ObservableCollection<Termin> getTerminUOdgovarajucemVremenskomOpsegu(DateTime pocetak, DateTime kraj)
        {
            ObservableCollection<Termin> retVal = new ObservableCollection<Termin>();

            foreach (Termin term in zakazaniTermini)
            {
                if (term.vreme >= pocetak && term.vreme <= kraj)
                    retVal.Add(term);
            }
            return retVal;
        }

    }
}
