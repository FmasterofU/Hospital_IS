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
      private Person loggedInPerson = null;
      
      public Person LoggedInPerson
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

        public Patient AddPatient(Patient patient)
        {
            if (IsPatientAlreadyExists(patient))
                return null;
            
            patient = AddNewMedicalRecord(patient);        
            patient = (Patient)PeopleRepository.GetInstance().Create(patient);
            editPatientInMedicalRecord(patient);
                return patient;
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

        private Patient AddNewMedicalRecord(Patient patient)
        {
            //TODO: Treba srediti insurance policy tako da podatak bude upotrebljiv a ne uvek isti
            MedicalRecord medicalRecord = new MedicalRecord(new InsurancePolicy(30), patient); 
            MedicalRecordService medicalRecordService = new MedicalRecordService();
            medicalRecord = medicalRecordService.AddMedicalRecord(medicalRecord);
            patient.MedRecordId = medicalRecord.GetId();
            
            return patient;

        }

        private bool editPatientInMedicalRecord(Patient patient)
        {
            MedicalRecordService medicalRecordService = new MedicalRecordService();
            MedicalRecord searchedMedicalRecord = medicalRecordService.GetMedicalRecordById(patient.MedRecordId);
            searchedMedicalRecord.patient = patient;
            return medicalRecordService.EditMedicalRecord(searchedMedicalRecord)!=null;
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