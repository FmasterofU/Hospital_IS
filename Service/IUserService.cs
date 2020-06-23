// File:    IUserService.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:18:25 PM
// Purpose: Definition of Interface IUserService

using Model.Roles;
using System;
using System.Collections.Generic;

namespace Service
{
   public interface IUserService
   {
      Model.Roles.UserType Auth(string username, string password);
      
      void CloseSession();
      
      Model.Roles.Person GetUser();
      
      void SaveUser();
      
      void AddStaffUser(Model.Roles.Staff staff);
      
      Model.Roles.UserType GetCurrentSessionType();
      
      void EditStaffUser(Model.Roles.Staff staff);
      
      void RemoveStaffUser(Model.Roles.Staff staff);
      
      List<Doctor> GetDoctors();
      
      List<Staff> GetAllStaff();
      
      void AddPatient(Model.Roles.Patient patient);
      
      void EditPatient(Model.Roles.Patient patient);
      
      List<Patient> GetPatientBySearch(String jmbg, String name, String surname);
   
   }
}