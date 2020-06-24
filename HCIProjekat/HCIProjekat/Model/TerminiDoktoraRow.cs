using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat.Model
{
    class TerminiDoktoraRow
    {
        public String datum { get; set; }
        public String vreme { get; set; }
        public int sala { get; set; }
        public String jmbg { get; set; }
        public String ime { get; set; }
        public String prezime { get; set; }

        public TerminiDoktoraRow(String datum, String vreme, int sala, String jmbg, String ime, String prezime)
        {
            this.datum = datum;
            this.vreme = vreme;
            this.sala = sala;
            this.jmbg = jmbg;
            this.ime = ime;
            this.prezime = prezime;
        }
    }
}
