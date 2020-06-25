// File:    MedicalRecordRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 10:02:48 PM
// Purpose: Definition of Class MedicalRecordRepository

using Class_Diagram.Repository;
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
            List<string[]> data = Persistence.ReadEntryByPrimaryKey(path, id.ToString());
            //TODO: parse strings and get medRecord object
            return new MedicalRecord();
        }

        public MedicalRecord Update(MedicalRecord item)
        {
            //TODO: put all data in string
            string[] data = { };
            bool isUpdated = Persistence.EditEntry(path, data);
            if (isUpdated) return new MedicalRecord();
            else return null;
        }

        public List<MedicalRecord> GetAll()
        {
            throw new NotImplementedException();
        }
   }
}