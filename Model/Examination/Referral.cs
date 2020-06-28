// File:    Referral.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class Referral

using Model.Roles;
using System;

namespace Model.Examination
{
   public class Referral : Repository.IIdentifiable<uint>
    {
      private ReferralType type;
      private string note;
      private String accessory = null;
      private uint id;

        public Referral(ReferralType type, string note, string accessory, Specialist specialist)
        {
            this.type = type;
            this.note = note;
            this.accessory = accessory;
            this.specialist = specialist;
            this.id = 0;
        }

        public ReferralType Type
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
      
      public string Note
      {
         get
         {
            return note;
         }
         set
         {
            this.note = value;
         }
      }
      
      public String Accessory
      {
         get
         {
            return accessory;
         }
         set
         {
            this.accessory = value;
         }
      }
      
      public Model.Roles.Specialist specialist;

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