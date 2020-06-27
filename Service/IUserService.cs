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
      UserType Auth(string username, string password);
      
      void CloseSession();
      
      Person GetUser();
      
      void SaveUser();
      
      void AddStaffUser(Staff staff);
      
      UserType GetCurrentSessionType();
      
      void EditStaffUser(Staff staff);
      
      void RemoveStaffUser(Staff staff);
      
      List<Doctor> GetDoctors();
      
      List<Staff> GetAllStaff();
      
      Patient AddPatient(Patient patient);
      
      void EditPatient(Patient patient);
      
      List<Patient> GetPatientBySearch(String jmbg, String name, String surname);
   
   }
}