// File:    UserController.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:35:02 PM
// Purpose: Definition of Class UserController

using Model.Roles;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class UserController : IUserController
   {
      public Service.IUserService iUserService;

        public void AddPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public void AddStaffUser(Staff staff)
        {
            throw new NotImplementedException();
        }

        public UserType Auth(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void CloseSession()
        {
            throw new NotImplementedException();
        }

        public void EditPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public void EditStaffUser(Staff staff)
        {
            throw new NotImplementedException();
        }

        public List<Staff> GetAllStaff()
        {
            throw new NotImplementedException();
        }

        public UserType GetCurrentSessionType()
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetDoctors()
        {
            throw new NotImplementedException();
        }

        public List<Patient> GetPatientBySearch(string jmbg, string name, string surname)
        {
            throw new NotImplementedException();
        }

        public Person GetUser()
        {
            throw new NotImplementedException();
        }

        public void RemoveStaffUser(Staff staff)
        {
            throw new NotImplementedException();
        }

        public void SaveUser()
        {
            throw new NotImplementedException();
        }
    }
}