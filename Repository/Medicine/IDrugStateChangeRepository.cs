// File:    IDrugStateChangeRepository.cs
// Author:  fmaster
// Created: Sunday, May 31, 2020 8:57:21 AM
// Purpose: Definition of Interface IDrugStateChangeRepository

using Model.Medicine;
using System.Collections.Generic;

namespace Repository.Medicine
{
    public interface IDrugStateChangeRepository : Repository.IRepositoryCRUD<DrugStateChange, uint>
    {
        List<DrugStateChange> GetAllByDrug(Drug drug);

    }
}