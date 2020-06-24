using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat.Model
{
    public class Termin
    {
        public String idDoktora { get; set; }
        public String jmbgPacijenta { get; set; }
        public int soba { get; set; }
        public String napomena { get; set; }
        public DateTime vreme { get; set; }

        public Termin(String doktor,String jmbg,int soba,DateTime vreme,String napomena)
        {
            this.idDoktora = doktor;
            this.jmbgPacijenta = jmbg;
            this.vreme = vreme;
            this.napomena = napomena;
            this.soba = soba;
        }

        public void editTermin(Termin t)
        {
            this.idDoktora = t.idDoktora;
            this.jmbgPacijenta = t.jmbgPacijenta;
            this.vreme = t.vreme;
            this.napomena = t.napomena;
            this.soba = t.soba;

        }
    }
}
