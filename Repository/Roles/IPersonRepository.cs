// File:    IPersonRepository.cs
// Author:  fmaster
// Created: Friday, May 22, 2020 5:22:39 PM
// Purpose: Definition of Interface IPersonRepository

using Model.Roles;
using System;
using System.Collections.Generic;

namespace Repository.Roles
{
   public interface IPersonRepository : Repository.IRepositoryCRUD<Person, uint>
   {
      Int32 GetId(string username, string password);
      
      bool HasUsername(string username);
      
      Model.Roles.UserType GetRole(int id);
      
      List<int> GetActiveDoctorIds();
      
      List<int> GetActiveSpecialistIds();
      
      List<int> GetActiveSecretaryIds();
      
      List<int> GetActiveDirectorIds();
      
      List<int> GetAllIds();
      
      List<int> GetAllStaffIds();
      
      List<int> GetAllActiveStaffIds();
      
      List<int> GetIdsByJMBG(string jmbg);
      
      List<int> GetIdsByName(string name);
      
      List<int> GetIdsBySurname(string surname);
      
      List<int> GetPatientsIds();
   
   }
}