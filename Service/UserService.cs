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
      
        public Staff AddStaffUser(Staff staff)
        {
            return (Staff) PeopleRepository.GetInstance().Create(staff);
        }

        public UserType Auth(string username, string password)
        {
           uint id =  PeopleRepository.GetInstance().GetId(username, password);
            if (id == 0)
                return UserType.None;

            return PeopleRepository.GetInstance().GetRole(id);
        }

        public void CloseSession()
        {
            throw new NotImplementedException();
        }

        public bool EditPatient(Patient patient)
        {
            return PeopleRepository.GetInstance().Update(patient)!=null;
        }

        public bool EditStaffUser(Staff staff)
        {
            return PeopleRepository.GetInstance().Update(staff) != null;
        }

        public List<Staff> GetAllStaff()
        {
            List<uint> stafIds = PeopleRepository.GetInstance().GetAllStaffIds();
            List<Staff> retVal = new List<Staff>();
            foreach(uint id in stafIds)
            {
                retVal.Add((Staff)PeopleRepository.GetInstance().Read(id));
            }
            return retVal;
        }

        public UserType GetCurrentSessionType()
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetActiveDoctors()
        {
            List<uint> doctorsIds = PeopleRepository.GetInstance().GetActiveDoctorIds();
            List<Doctor> retVal = new List<Doctor>();
            foreach (uint id in doctorsIds)
            {
                retVal.Add((Doctor)PeopleRepository.GetInstance().Read(id));
            }
            return retVal;
        }

        public List<Patient> GetPatientBySearch(string jmbg, string name, string surname)
        {
            List<Patient> searchedPatient = new List<Patient>();
            foreach (uint id in PeopleRepository.GetInstance().GetPatientsIds())
            {
                Patient patient = (Patient)PeopleRepository.GetInstance().Read(id);
                if (patient.Jmbg.Contains(jmbg) && patient.Name.Contains(name) && patient.Surname.Contains(surname))
                    searchedPatient.Add(patient);
            }
            return searchedPatient;
        }

        public Person GetUser(uint id)
        {
            return PeopleRepository.GetInstance().Read(id);
        }

        public bool RemoveStaffUser(Staff staff)
        {
           return PeopleRepository.GetInstance().Delete(staff.GetId());
        }

        public void SaveUser()
        {
            throw new NotImplementedException();
        }
    }
}