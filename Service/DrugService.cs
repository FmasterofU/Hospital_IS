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
        public Drug AddDrug(Drug drug)
        {
            return DrugRepository.GetInstance().Create(drug);
        }

        public DrugBatch AddDrugBatch(DrugBatch drugBatch)
        {
            return DrugBatchRepository.GetInstance().Create(drugBatch);
        }

        public DrugStateChange AddDrugStateChange(DrugStateChange dsc)
        {
            return DrugStateChangeRepository.GetInstance().Create(dsc);
        }

        public Ingridient AddIngridient(Ingridient ingridient)
        {
            return IngridientRepository.GetInstance().Create(ingridient);
        }

        public SideEffect AddSideEffect(SideEffect sideEffect)
        {
            return SideEffectRepository.GetInstance().Create(sideEffect);
        }

        public bool DeleteDrugBatch(DrugBatch drugBatch)
        {
            return DrugBatchRepository.GetInstance().Delete(drugBatch.DrugId);
        }

        public bool DisableDrugUse(Drug drug)
        {
            drug.InUse = false;
            Drug ret =  DrugRepository.GetInstance().Update(drug);
            if (ret != null)
                return true;
            else return false;
        }

        public bool EditDrug(Drug drug)
        {
            Drug ret = DrugRepository.GetInstance().Update(drug);
            if (ret != null)
                return true;
            else return false;
        }

        public bool EditDrugBatch(DrugBatch drugBatch)
        {
            DrugBatch ret = DrugBatchRepository.GetInstance().Update(drugBatch);
            if (ret != null)
                return true;
            else return false;
        }

        public bool EditDrugStateChange(DrugStateChange dsc)
        {
            DrugStateChange ret = DrugStateChangeRepository.GetInstance().Update(dsc);
            if (ret != null)
                return true;
            else return false;
        }

        public List<Drug> GetAllDrugs()
        {
            return DrugRepository.GetInstance().GetAll();
        }

        public List<DrugStateChange> GetAllDrugStateChange(Drug drug)
        {
            IDrugStateChangeRepository idsc = DrugStateChangeRepository.GetInstance();
            return idsc.GetAllByDrug(drug);
        }

        public List<DrugBatch> GetDrugBatches(Drug drug)
        {
            List<DrugBatch> temp = DrugBatchRepository.GetInstance().GetAll();
            List<DrugBatch> ret = new List<DrugBatch>();
            foreach (DrugBatch db in temp)
                if (db.DrugId == drug.GetId())
                    ret.Add(db);
            return ret;
        }

        public List<Drug> SearchDrugs(string query)
        {
            List<Drug> list = DrugRepository.GetInstance().GetAll();
            if (query.Equals("")) return list;
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