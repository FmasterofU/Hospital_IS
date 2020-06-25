// File:    DrugService.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:18:25 PM
// Purpose: Definition of Class DrugService

using Model.Medicine;
using Repository.Medicine;
using System;
using System.Collections.Generic;

namespace Service
{
    public class DrugService : IDrugService
    {
        public bool AddDrug(Drug drug)
        {
            throw new NotImplementedException();
        }

        public bool AddDrugBatch(DrugBatch drugBatch)
        {
            throw new NotImplementedException();
        }

        public bool AddIngridient(Ingridient ingridient)
        {
            throw new NotImplementedException();
        }

        public bool AddSideEffect(SideEffect sideEffect)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDrugBatch(DrugBatch drugBatch)
        {
            throw new NotImplementedException();
        }

        public bool DisableDrugUse(Drug drug)
        {
            throw new NotImplementedException();
        }

        public bool EditDrug(Drug drug)
        {
            throw new NotImplementedException();
        }

        public bool EditDrugBatch(DrugBatch drugBatch)
        {
            throw new NotImplementedException();
        }

        public List<Drug> GetAllDrugs()
        {
            throw new NotImplementedException();
        }

        public List<DrugStateChange> GetAllDrugStateChange(Drug drug)
        {
            throw new NotImplementedException();
        }

        public List<DrugBatch> GetDrugBatches(Drug drug)
        {
            throw new NotImplementedException();
        }

        public List<Drug> SearchDrugs(string query)
        {
            List<Drug> list = DrugRepository.GetInstance().GetAll();
            List<Drug> ret = new List<Drug>();
            foreach(Drug d in list)
            {
                if(d.InUse && d.Name.Contains(query))
                {
                    ret.Add(d);
                }
            }
            return ret;
        }
    }
}