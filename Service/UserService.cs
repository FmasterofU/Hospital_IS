// File:    UserService.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:18:25 PM
// Purpose: Definition of Class UserService

using Model.Roles;
using Repository.Roles;
using System;
using System.Collections.Generic;

namespace Service
{
   public class UserService : IUserService
   {
      private Model.Roles.Person loggedInPerson = null;
      
      public Model.Roles.Person LoggedInPerson
      {
         get
         {
            return loggedInPerson;
         }
         private set
         {
            this.loggedInPerson = value;
         }
      }

        public void AddPatient(Patient patient)
        {
            List<uint> pacijenti = PeopleRepository.GetInstance().GetIdsByJMBG(patient.Jmbg);
            if (pacijenti.Count == 0)
                PeopleRepository.GetInstance().Create(patient);            
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