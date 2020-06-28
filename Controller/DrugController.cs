// File:    DrugController.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:35:06 PM
// Purpose: Definition of Class DrugController

using Model.Medicine;
using Service;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Controller
{
   public class DrugController : IDrugController
   {
      public Service.IDrugService iDrugService = new DrugService();

        public Drug AddDrug(Drug drug)
        {
            return iDrugService.AddDrug(drug);
        }

        public DrugBatch AddDrugBatch(DrugBatch drugBatch)
        {
            return iDrugService.AddDrugBatch(drugBatch);
        }

        public Ingridient AddIngridient(Ingridient ingridient)
        {
            return iDrugService.AddIngridient(ingridient);
        }

        public SideEffect AddSideEffect(SideEffect sideEffect)
        {
            return iDrugService.AddSideEffect(sideEffect);
        }

        public bool DeleteDrugBatch(DrugBatch drugBatch)
        {
            return iDrugService.DeleteDrugBatch(drugBatch);
        }

        public bool DisableDrugUse(Drug drug)
        {
            return iDrugService.DisableDrugUse(drug);
        }

        public bool EditDrug(Drug drug)
        {
            return iDrugService.EditDrug(drug);
        }

        public bool EditDrugBatch(DrugBatch drugBatch)
        {
            return iDrugService.EditDrugBatch(drugBatch);
        }

        public List<Drug> GetAllDrugs()
        {
            return iDrugService.GetAllDrugs();
        }

        public List<DrugStateChange> GetAllDrugStateChange(Drug drug)
        {
            return iDrugService.GetAllDrugStateChange(drug);
        }

        public List<DrugBatch> GetDrugBatches(Drug drug)
        {
            return iDrugService.GetDrugBatches(drug);
        }

        public List<Drug> SearchDrugs(string query)
        {
            query = query.Trim();
            List<Drug> ret = iDrugService.SearchDrugs(query);
            return ret;
        }
    }
}
