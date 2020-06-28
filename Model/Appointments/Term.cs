using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Diagram.Model.Appointments
{
    public class Term
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Term(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
