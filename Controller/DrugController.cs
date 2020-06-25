// File:    DrugController.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:35:06 PM
// Purpose: Definition of Class DrugController

using Model.Medicine;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class DrugController : IDrugController
   {
      public Service.IDrugService iDrugService;

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
            throw new NotImplementedException();
        }
    }
}