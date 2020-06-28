using System;

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
