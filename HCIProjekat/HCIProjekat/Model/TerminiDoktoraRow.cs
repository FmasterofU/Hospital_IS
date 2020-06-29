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
        public String sala { get; set; }
        public String medicalRecord { get; set; }


        public TerminiDoktoraRow(String datum, String vreme, string sala, String medicalRecord)
        {
            this.datum = datum;
            this.vreme = vreme;
            this.sala = sala;
            this.medicalRecord = medicalRecord;
           
        }
    }
}
