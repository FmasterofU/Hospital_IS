// File:    ReferralRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 10:02:48 PM
// Purpose: Definition of Class ReferralRepository

using Class_Diagram.Repository;
using Model.Examination;
using Model.Roles;
using Repository.Roles;
using System;
using System.Collections.Generic;

namespace Repository.Patientdata
{
   public class ReferralRepository : Repository.IRepositoryCRUD<Referral, uint>

        //Id, Type, Note, Accessory, SpecialistId

    {
        private string path = @"../../Data/referral.csv";
        private static ReferralRepository instance = null;

        private ReferralRepository() {}
      
      public static ReferralRepository GetInstance()
      {
            if (instance == null) instance = new ReferralRepository();
            return instance;
      }

        public bool Delete(uint id)
        {
            return Persistence.RemoveEntry(path, id.ToString());
        }

        public Referral Create(Referral item)
        {
            string[] data = new string[5];
            data[0] = Persistence.GetNewId(path).ToString();
            item.SetId(uint.Parse(data[0]));
            int type = (int)item.Type;
            data[1] = type.ToString();
            data[2] = item.Note;
            data[3] = item.Accessory;
            data[4] = "";
            if (item.specialist != null) data[4] = item.specialist.GetId().ToString();
            bool isAdded = Persistence.WriteEntry(path, data);
            if (isAdded) return item;
            else return null;
        }

        public Referral Read(uint id)
        {
            List<string[]> data = Persistence.ReadEntryByPrimaryKey(path, id.ToString());
            if (data.Count == 1)
            {
                uint refID = uint.Parse(data[0][0]);
                int type = int.Parse(data[0][1]);
                ReferralType refType = (ReferralType)type;
                string note = data[0][2];
                string accessory = data[0][3];
                Specialist s = null;
                if (!data[0][4].Equals(""))
                {
                    uint specID = uint.Parse(data[0][4]);
                    s = (Specialist)PeopleRepository.GetInstance().Read(specID);
                }
                Referral ret = new Referral(refType, note, accessory, s);
                ret.SetId(refID);
                return ret;
            }
            return null;
        }

        public Referral Update(Referral item)
        {
            throw new NotImplementedException();
        }

        public List<Referral> GetAll()
        {
            List<string> ids = Persistence.ReadAllPrimaryIds(path);
            List<Referral> ret = new List<Referral>();
            foreach (string s in ids) ret.Add(Read(uint.Parse(s)));
            return ret;
        }
   }
}