// File:    IDrugService.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:18:25 PM
// Purpose: Definition of Interface IDrugService

using Model.Medicine;
using System;
using System.Collections.Generic;

namespace Service
{
   public interface IDrugService
   {
      List<Drug> SearchDrugs(string query);
      
      List<Drug> GetAllDrugs();
      
      Drug AddDrug(Model.Medicine.Drug drug);
      
      bool DisableDrugUse(Model.Medicine.Drug drug);
      
      bool EditDrug(Model.Medicine.Drug drug);
      
      Ingridient AddIngridient(Model.Medicine.Ingridient ingridient);
      
      SideEffect AddSideEffect(Model.Medicine.SideEffect sideEffect);
      
      List<DrugStateChange> GetAllDrugStateChange(Model.Medicine.Drug drug);
      
      List<DrugBatch> GetDrugBatches(Model.Medicine.Drug drug);
      
      DrugBatch AddDrugBatch(Model.Medicine.DrugBatch drugBatch);
      
      bool EditDrugBatch(Model.Medicine.DrugBatch drugBatch);
      
      bool DeleteDrugBatch(Model.Medicine.DrugBatch drugBatch);

        DrugStateChange AddDrugStateChange(DrugStateChange dsc);

        bool EditDrugStateChange(DrugStateChange dsc);


   }
}