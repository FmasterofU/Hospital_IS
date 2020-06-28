// File:    UserController.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:35:02 PM
// Purpose: Definition of Class UserController

using Model.Roles;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class UserController : IUserController
   {
      public Service.IUserService iUserService = new UserService();

        public Patient AddPatient(Patient patient)
        {
            return iUserService.AddPatient(patient);
        }

        public Staff AddStaffUser(Staff staff)
        {
            return iUserService.AddStaffUser(staff);
        }

        public UserType Auth(string username, string password)
        {
            return iUserService.Auth(username, password);
        }

        public void CloseSession()
        {
            throw new NotImplementedException();
        }

        public bool EditPatient(Patient patient)
        {
            return iUserService.EditPatient(patient);
        }

        public bool EditStaffUser(Staff staff)
        {
            return iUserService.EditStaffUser(staff);
        }

        public List<Staff> GetAllStaff()
        {
            return iUserService.GetAllStaff();
        }

        public UserType GetCurrentSessionType()
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetDoctors()
        {
            return iUserService.GetActiveDoctors();
        }

        public List<Patient> GetPatientBySearch(string jmbg, string name, string surname)
        {
            return iUserService.GetPatientBySearch(jmbg, name, surname);
        }

        public Person GetUser(uint id)
        {
            return iUserService.GetUser(id);
        }

        public bool IsPatientExist(string jmbg)
        {
            return iUserService.IsPatientExist(jmbg);
        }

        public bool RemoveStaffUser(Staff staff)
        {
            return iUserService.RemoveStaffUser(staff);
        }

        public void SaveUser()
        {
            throw new NotImplementedException();
        }
    }
}