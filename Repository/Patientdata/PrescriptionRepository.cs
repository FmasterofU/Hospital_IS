// File:    PrescriptionRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 10:02:48 PM
// Purpose: Definition of Class PrescriptionRepository

using Model.Examination;
using System;
using System.Collections.Generic;

namespace Repository.Patientdata
{
   public class PrescriptionRepository : Repository.IRepositoryCRUD<Prescription, uint>

        //Id, DrugId, Number, Usage

    {
        private string path = @"../../Data/prescription.csv";
        private static PrescriptionRepository instance = null;

        private PrescriptionRepository() {}
      
      public static PrescriptionRepository GetInstance()
      {
            if (instance == null) instance = new PrescriptionRepository();
            return instance;
      }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public Prescription Create(Prescription item)
        {
            throw new NotImplementedException();
        }

        public Prescription Read(uint id)
        {
            throw new NotImplementedException();
        }

        public Prescription Update(Prescription item)
        {
            throw new NotImplementedException();
        }

        public List<Prescription> GetAll()
        {
            throw new NotImplementedException();
        }
   }
}