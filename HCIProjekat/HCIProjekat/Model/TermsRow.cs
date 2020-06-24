using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat.Model
{
    class TermsRow
    {
        public String vreme { get; set; }
        public String soba1 { get; set; }
        public String soba2 { get; set; }
        public String soba3 { get; set; }
        public String soba4 { get; set; }

        public TermsRow(String vreme, String s1, String s2, String s3,String s4)
        {
            soba1 = s1;
            soba2 = s2;
            soba3 = s3;
            soba4 = s4;
            this.vreme = vreme;
        }
    }
}
