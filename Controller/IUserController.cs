// File:    IUserController.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:30:59 PM
// Purpose: Definition of Interface IUserController

using Model.Roles;
using System;
using System.Collections.Generic;

namespace Controller
{
   public interface IUserController
   {
      Model.Roles.UserType Auth(string username, string password);
      
      void CloseSession();
      
      Model.Roles.Person GetUser(uint id);
      
      void SaveUser();

        Staff AddStaffUser(Model.Roles.Staff staff);
      
      Model.Roles.UserType GetCurrentSessionType();
      
      bool EditStaffUser(Model.Roles.Staff staff);
      
      bool RemoveStaffUser(Model.Roles.Staff staff);
      
      List<Doctor> GetDoctors();
      
      List<Staff> GetAllStaff();
      
      Patient AddPatient(Model.Roles.Patient patient);

        bool EditPatient(Model.Roles.Patient patient);
      
      List<Patient> GetPatientBySearch(String jmbg, String name, String surname);

        bool IsPatientAlreadyExist(string jmbg);
   
   }
}