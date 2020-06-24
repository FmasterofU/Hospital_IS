using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat.Model
{
    class SviZaposleni
    {
        private static SviZaposleni instance = null;

        public static SviZaposleni getInstance()
        {
            if (instance == null)
            {
                instance = new SviZaposleni();
            }
            return instance;
        }

        private ObservableCollection<Zaposleni> zaposleni;

        private SviZaposleni()
        {
            this.zaposleni = new ObservableCollection<Zaposleni>();
            InicijalizujZaposlene();
        }


        private void InicijalizujZaposlene()
        {
            Zaposleni z1 = new Zaposleni("2233", "Darko", "Pancev", "Sekretar", new DateTime(2000, 12, 3), "M", "Topolska 18", "racabog@gmail.com", "", "");
            Zaposleni z2 = new Zaposleni("3322", "Aca", "Lukas", "Doktor", new DateTime(1999, 3, 5), "M", "Bulevari jos su vreli 13", "gospodinkuzma@gmail.com", "065-555-5555", "Opsta praksa");
            Zaposleni z3 = new Zaposleni("h1n1", "Jelena", "Jankovic", "Upravnik", new DateTime(1996, 7, 1), "Z", "Kuda idu ljudi kao ja 22", "volimkiaauto@gmail.com", "064/522-2222", "");
            Zaposleni z4 = new Zaposleni("d1k3", "Dusan", "Eric", "Doktor", new DateTime(1993, 11, 3), "M", "Maksima 3", "makaraka@gmail.com", "063/551-35353", "Hirurg");

            zaposleni.Add(z1);
            zaposleni.Add(z2);
            zaposleni.Add(z3);
            zaposleni.Add(z4);
        }

        public ObservableCollection<Zaposleni> getZaposleni()
        {
            return zaposleni;
        }

        public Zaposleni getZaposleniById(String id)
        {
            foreach(Zaposleni zap in zaposleni)
            {
                if (zap.id.Equals(id))
                    return zap;
            }
            return null;
        }
    }
}
