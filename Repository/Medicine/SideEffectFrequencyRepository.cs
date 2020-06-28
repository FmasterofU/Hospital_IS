// File:    SideEffectFrequencyRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:29:02 PM
// Purpose: Definition of Class SideEffectFrequencyRepository

using Class_Diagram.Repository;
using Model.Medicine;
using System;
using System.Collections.Generic;

namespace Repository.Medicine
{
   public class SideEffectFrequencyRepository : Repository.IRepositoryCRUD<SideEffectFrequency, uint>

        //Id,DrugId,Basis,Freq,SideEffectId

    {
        private string path = @"../../Data/side_effect_frequency.csv";
        private static SideEffectFrequencyRepository instance = null;

        private SideEffectFrequencyRepository() {}
      
      public static SideEffectFrequencyRepository GetInstance()
      {
            if (instance == null) instance = new SideEffectFrequencyRepository();
            return instance;
      }

        public bool Delete(uint id)
        {
            return Persistence.RemoveEntry(path, id.ToString());
        }

        public SideEffectFrequency Create(SideEffectFrequency item)
        {
            string[] data = new string[5];
            item.SetId(Persistence.GetNewId(path));
            data[0] = item.GetId().ToString();
            data[1] = item.DrugId.ToString();
            data[2] = item.Basis.ToString();
            data[3] = item.Freq.ToString();
            data[4] = item.sideEffect.GetId().ToString();
            if (Persistence.WriteEntry(path, data))
                return item;
            else return null;
        }

        public SideEffectFrequency Read(uint id)
        {
            List<string[]> temp = Persistence.ReadEntryByPrimaryKey(path, id.ToString());
            return new SideEffectFrequency(uint.Parse(temp[0][0]), uint.Parse(temp[0][1]), int.Parse(temp[0][2]), int.Parse(temp[0][3]), SideEffectRepository.GetInstance().Read(uint.Parse(temp[0][4])));
        }

        public SideEffectFrequency Update(SideEffectFrequency item)
        {
            string[] data = new string[5];
            data[0] = item.GetId().ToString();
            data[1] = item.DrugId.ToString();
            data[2] = item.Basis.ToString();
            data[3] = item.Freq.ToString();
            data[4] = item.sideEffect.GetId().ToString();
            if (Persistence.EditEntry(path, data))
                return item;
            else return null;
        }

        public List<SideEffectFrequency> GetAll()
        {
            throw new NotImplementedException();
        }
   }
}