// File:    IngridientRatioRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:29:02 PM
// Purpose: Definition of Class IngridientRatioRepository

using Class_Diagram.Repository;
using Model.Medicine;
using System;
using System.Collections.Generic;

namespace Repository.Medicine
{
   public class IngridientRatioRepository : Repository.IRepositoryCRUD<IngridientRatio, uint>

        //Id,IngridientId,DrugId,Ratio

    {
        private string path = @"../../Data/ingridient_ratio.csv";
        private static IngridientRatioRepository instance = null;

        private IngridientRatioRepository() {}
      
      public static IngridientRatioRepository GetInstance()
      {
            if (instance == null) instance = new IngridientRatioRepository();
            return instance;
      }

        public bool Delete(uint id)
        {
            return Persistence.RemoveEntry(path, id.ToString());
        }

        public IngridientRatio Create(IngridientRatio item)
        {
            string[] data = new string[4];
            item.SetId(Persistence.GetNewId(path));
            data[0] = item.GetId().ToString();
            data[1] = item.ingridient.GetId().ToString();
            data[2] = item.DrugId.ToString();
            data[3] = item.Ratio.ToString();
            if (Persistence.WriteEntry(path, data))
                return item;
            else return null;
        }

        public IngridientRatio Read(uint id)
        {
            List<string[]> temp = Persistence.ReadEntryByPrimaryKey(path, id.ToString());
            return new IngridientRatio(uint.Parse(temp[0][0]), decimal.Parse(temp[0][3]), uint.Parse(temp[0][2]), IngridientRepository.GetInstance().Read(uint.Parse(temp[0][1])));
        }

        public IngridientRatio Update(IngridientRatio item)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.List<IngridientRatio> GetAll()
        {
            throw new NotImplementedException();
        }
   }
}