// File:    ReferralRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 10:02:48 PM
// Purpose: Definition of Class ReferralRepository

using Class_Diagram.Repository;
using Model.Examination;
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
            throw new NotImplementedException();
        }

        public Referral Create(Referral item)
        {
            string[] data = new string[5]; //TODO: getNewID
            data[0] = item.GetId().ToString();
            data[1] = item.Type.ToString();
            data[2] = item.Note;
            data[3] = item.Accessory;
            data[4] = item.specialist.GetId().ToString();
            bool isAdded = Persistence.WriteEntry(path, data);
            if (isAdded) return item;
            else return null;
        }

        public Referral Read(uint id)
        {
            throw new NotImplementedException();
        }

        public Referral Update(Referral item)
        {
            throw new NotImplementedException();
        }

        public List<Referral> GetAll()
        {
            throw new NotImplementedException();
        }
   }
}