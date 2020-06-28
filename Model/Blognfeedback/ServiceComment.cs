// File:    ServiceComment.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class ServiceComment

namespace Model.Blognfeedback
{
    public class ServiceComment : Repository.IIdentifiable<uint>
    {
        private string note;
        private uint id;
        private uint appointmentId;

        public ServiceComment(string note, uint appointmentId)
        {
            this.note = note;
            id = 0;
            this.appointmentId = appointmentId;
        }

        public string Note
        {
            get => note;
            set => note = value;
        }

        public uint AppointmentId
        {
            get => appointmentId;
            set => appointmentId = value;
        }

        public uint GetId()
        {
            return id;
        }

        public void SetId(uint id)
        {
            this.id = id;
        }
    }
}