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
      
      Person GetUser(uint id);
      
      void SaveUser();
      
      Staff AddStaffUser(Staff staff);
      
      UserType GetCurrentSessionType();
      
      bool EditStaffUser(Staff staff);
      
      bool RemoveStaffUser(Staff staff);
      
      List<Doctor> GetActiveDoctors();
      
      List<Staff> GetAllStaff();
      
      Patient AddPatient(Patient patient);
      
      bool EditPatient(Patient patient);
      
      List<Patient> GetPatientBySearch(String jmbg, String name, String surname);
   
   }
}