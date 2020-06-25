// File:    Leave.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class Leave

using System;

namespace Model.Roles
{
   public class Leave : Repository.IIdentifiable<uint>
   {
      private LeaveType type;
      private DateTime start;
      private DateTime end;
      private uint idStaff;
      private uint id;

        public Leave(LeaveType type, DateTime start, DateTime end, uint idStaff, Staff staff)
        {
            this.type = type;
            this.start = start;
            this.end = end;
            this.idStaff = idStaff;
            this.id = 0;
            this.staff = staff;
        }

        public LeaveType Type
      {
         get
         {
            return type;
         }
         set
         {
            this.type = value;
         }
      }
      
      public DateTime Start
      {
         get
         {
            return start;
         }
         set
         {
            this.start = value;
         }
      }
      
      public uint IdStaff
      {
         get
         {
            return idStaff;
         }
         set
         {
            this.idStaff = value;
         }
      }
      
      public DateTime End
      {
         get
         {
            return end;
         }
         set
         {
            this.end = value;
         }
      }
      
      public Staff staff;

        public uint GetId()
        {
            throw new NotImplementedException();
        }

        public void SetId(uint id)
        {
            throw new NotImplementedException();
        }
    }
}