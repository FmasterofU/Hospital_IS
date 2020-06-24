// File:    MedicalRecordRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 10:02:48 PM
// Purpose: Definition of Class MedicalRecordRepository

using Model.Medicalrecord;
using System;
using System.Collections.Generic;

namespace Repository.Patientdata
{
   public class MedicalRecordRepository : Repository.IRepositoryCRUD<MedicalRecord, uint>
   {
      private string path;
      private static MedicalRecordRepository instance = null;

        private MedicalRecordRepository() {}
      
      public static MedicalRecordRepository GetInstance()
      {
            if (instance == null) instance = new MedicalRecordRepository();
            return instance;
      }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public MedicalRecord Create(MedicalRecord item)
        {
            throw new NotImplementedException();
        }

        public MedicalRecord Read(uint id)
        {
            throw new NotImplementedException();
        }

        public MedicalRecord Update(MedicalRecord item)
        {
            throw new NotImplementedException();
        }

        public List<MedicalRecord> GetAll()
        {
            throw new NotImplementedException();
        }
   }
}