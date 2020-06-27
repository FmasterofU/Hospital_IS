// File:    UserService.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:18:25 PM
// Purpose: Definition of Class UserService

using Class_Diagram.Repository;
using Model.Medicalrecord;
using Model.Roles;
using Repository.Patientdata;
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
            if (IsPatientAlreadyExists(patient))
                return;
            patient.SetId(getFirstAvailableId());
            AddNewMedicalRecord(patient);        
            PeopleRepository.GetInstance().Create(patient);            

        }

        private bool IsPatientAlreadyExists(Patient patient)
        {
            List<uint> peoples_ids = PeopleRepository.GetInstance().GetIdsByJMBG(patient.Jmbg);
            foreach(uint id in peoples_ids)
            {
                UserType tipKorisnika = PeopleRepository.GetInstance().GetRole(id);
                if (tipKorisnika.Equals(UserType.Patient))
                    return true;
            }
            return false;
        }

        private void AddNewMedicalRecord(Patient patient)
        {
            MedicalRecord medicalRecord = new MedicalRecord(new InsurancePolicy(getFirstAvailableInsuranceId()),patient, getFistAvailableMedicalRecordId());
            patient.MedRecordId = medicalRecord.GetId();
            MedicalRecordRepository.GetInstance().Create(medicalRecord);
            //TODO: add insurance policy into repository before adding medical record
        }

        private uint getFirstAvailableId()
        {
            string path = PeopleRepository.GetInstance().getPath();
            return Persistence.GetNewId(path);
        }

        private uint getFistAvailableMedicalRecordId()
        {
            string path = MedicalRecordRepository.GetInstance().getPath();
            return Persistence.GetNewId(path);
        }

        private uint getFirstAvailableInsuranceId()
        {
            string path = InsurancePolicyRepository.GetInstance().getPath();
            return Persistence.GetNewId(path);
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