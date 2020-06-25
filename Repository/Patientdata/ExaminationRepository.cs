// File:    ExaminationRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 10:02:48 PM
// Purpose: Definition of Class ExaminationRepository

using Model.Examination;
using System;
using System.Collections.Generic;

namespace Repository.Patientdata
{
   public class ExaminationRepository : Repository.IRepositoryCRUD<Examination, uint>
   {
      private string path;
      private ExaminationRepository instance;
      
      public static ExaminationRepository GetInstance()
      {
         throw new NotImplementedException();
      }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public Examination Create(Examination item)
        {
            throw new NotImplementedException();
        }

        public Examination Read(uint id)
        {
            throw new NotImplementedException();
        }

        public Examination Update(Examination item)
        {
            throw new NotImplementedException();
        }

        public List<Examination> GetAll()
        {
            throw new NotImplementedException();
        }

        public ExaminationRepository examinationRepositoryB;
   
   }
}