// File:    PeopleRepository.cs
// Author:  fmaster
// Created: Friday, May 22, 2020 12:14:24 PM
// Purpose: Definition of Class PeopleRepository

using Model.Roles;
using System;
using System.Collections.Generic;

namespace Repository.Roles
{
   public class PeopleRepository : IPersonRepository
   {
      private string path;
      private PeopleRepository instance;
      
      public static PeopleRepository GetInstance()
      {
         throw new NotImplementedException();
      }

        public int GetId(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool HasUsername(string username)
        {
            throw new NotImplementedException();
        }

        public UserType GetRole(int id)
        {
            throw new NotImplementedException();
        }

        public List<int> GetActiveDoctorIds()
        {
            throw new NotImplementedException();
        }

        public List<int> GetActiveSpecialistIds()
        {
            throw new NotImplementedException();
        }

        public List<int> GetActiveSecretaryIds()
        {
            throw new NotImplementedException();
        }

        public List<int> GetActiveDirectorIds()
        {
            throw new NotImplementedException();
        }

        public List<int> GetAllIds()
        {
            throw new NotImplementedException();
        }

        public List<int> GetAllStaffIds()
        {
            throw new NotImplementedException();
        }

        public List<int> GetAllActiveStaffIds()
        {
            throw new NotImplementedException();
        }

        public List<int> GetIdsByJMBG(string jmbg)
        {
            throw new NotImplementedException();
        }

        public List<int> GetIdsByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<int> GetIdsBySurname(string surname)
        {
            throw new NotImplementedException();
        }

        public List<int> GetPatientsIds()
        {
            throw new NotImplementedException();
        }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public Person Create(Person item)
        {
            throw new NotImplementedException();
        }

        public Person Read(uint id)
        {
            throw new NotImplementedException();
        }

        public Person Update(Person item)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public PeopleRepository peopleRepositoryB;
   
   }
}