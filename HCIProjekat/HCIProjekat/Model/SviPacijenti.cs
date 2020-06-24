using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace HCIProjekat.Model
{
    public class SviPacijenti
    {
        private static SviPacijenti instance = null;

        public static SviPacijenti getInstance()
        {
            if (instance == null)
            {
                instance = new SviPacijenti();
            }
            return instance;
        }

        private ObservableCollection<Pacijent> pacijenti;

        private SviPacijenti()
        {
            this.pacijenti = new ObservableCollection<Pacijent>();
            InicijalizujPacijente();
        }


        private void InicijalizujPacijente()
        {
            Pacijent p1 = new Pacijent("1234567890123", "Rados", "Maric", "Nikola", new DateTime(2000, 12, 3), "M", "Topolska 18", "racabog@gmail.com", "");
            Pacijent p2 = new Pacijent("3210987654321", "Milos", "Kuzmic", "Isus", new DateTime(1999, 3, 5), "M", "Bulevari jos su vreli 13", "gospodinkuzma@gmail.com", "065-555-5555");
            Pacijent p3 = new Pacijent("2233344445555", "Sandra", "Kockar", "Kia", new DateTime(1996, 7, 1), "Z", "Kuda idu ljudi kao ja 22", "volimkiaauto@gmail.com", "064/522-2222");

            pacijenti.Add(p1);
            pacijenti.Add(p2);
            pacijenti.Add(p3);
        }

        public ObservableCollection<Pacijent> getPacijente()
        {
            return pacijenti;
        }

        public Pacijent searchByJMBG(String jmbg)
        {
            foreach (Pacijent pac in pacijenti)
            {
                if (pac.jmbg.Equals(jmbg))
                {
                    return pac;
                }
            }
            return null;
        }

        public void dodajPacijenta(Pacijent p)
        {
            pacijenti.Add(p);
        }

        public bool bezbednoDodavanjePacijenta(Pacijent p)
        {
            Pacijent pac = searchByJMBG(p.jmbg);
            if (pac != null)
                return false;

            dodajPacijenta(p);
            return true;
        }

        public bool azurirajPacijenta(Pacijent p)
        {
            Pacijent pac = searchByJMBG(p.jmbg);
            if (pac != null)
            {
                pac.editPacijent(p);
                return true;
            }
            return false;
        }
    }
}
