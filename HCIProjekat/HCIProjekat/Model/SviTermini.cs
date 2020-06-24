using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace HCIProjekat.Model
{
    public class SviTermini
    {
        private static SviTermini instance = null;

        public static SviTermini getInstance()
        {
            if (instance == null)
            {
                instance = new SviTermini();
            }
            return instance;
        }

        private ObservableCollection<Termin> termini;

        private SviTermini()
        {
            this.termini = new ObservableCollection<Termin>();
            InicijalizujTermine();
        }


        private void InicijalizujTermine()
        {
            Termin t1 = new Termin("3322", "2233344445555", 3, new DateTime(2020,6,17,7,40,0), "kontrola");
            Termin t2 = new Termin("3322", "3210987654321", 2, new DateTime(2020, 6, 17, 7, 20, 0), "kontrola");
            Model.SviZaposleni.getInstance().getZaposleniById("3322").zakazaniTermini.Add(t1);
            Model.SviZaposleni.getInstance().getZaposleniById("3322").zakazaniTermini.Add(t2);
            termini.Add(t1);
            termini.Add(t2);
        }

        public ObservableCollection<Termin> getTermine()
        {
            return termini;
        }

        public ObservableCollection<Termin> getTerminUOdgovarajucemVremenskomOpsegu(DateTime pocetak,DateTime kraj)
        {
            ObservableCollection<Termin> retVal = new ObservableCollection<Termin>();

            foreach(Termin term in termini)
            {
                if (term.vreme >= pocetak && term.vreme <= kraj)
                    retVal.Add(term);
            }
            return retVal;
        }

        public void dodajTermin(Termin t)
        {
            termini.Add(t);
        }

        public void ukloniTermin(DateTime vreme, int soba)
        {
            Termin t = searchTerminDanSoba(vreme, soba);
            termini.Remove(t);
        }

        public Termin searchTerminDanSoba(DateTime vreme, int soba)
        {
            foreach(Termin t in termini)
            {
                if (t.vreme.Equals(vreme) && t.soba == soba)
                    return t;
                
            }
            return null;
        }

        public Termin searchTerminVreme(DateTime vreme)
        {
            foreach (Termin t in termini)
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
    }
}
