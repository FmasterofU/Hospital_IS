using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingDirectorMobile.Model
{
    public class DrugBatch
    {
        public DateTime EXP { get; set; }
        public int Quantity { get; set; }
        public string Code { get; set; }

        public String StringifyEXP()
        {
            return "" + EXP.Day + "." + EXP.Month + "." + EXP.Year + ".";
        }
    }
}
