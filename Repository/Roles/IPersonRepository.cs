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
      uint GetId(string username, string password);
      
      bool HasUsername(string username);
      
      Model.Roles.UserType GetRole(uint id);
      
      List<uint> GetActiveDoctorIds();
      
      List<uint> GetActiveSpecialistIds();
      
      List<uint> GetActiveSecretaryIds();
      
      List<uint> GetActiveDirectorIds();
      
      List<uint> GetAllIds();
      
      List<uint> GetAllStaffIds();
      
      List<uint> GetAllActiveStaffIds();
      
      List<uint> GetIdsByJMBG(string jmbg);
      
      List<uint> GetIdsByName(string name);
      
      List<uint> GetIdsBySurname(string surname);
      
      List<uint> GetPatientsIds();
   
   }
}