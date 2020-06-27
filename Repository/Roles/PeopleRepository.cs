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

        //Id,UserType,Jmbg,Name,Surname,Phone,Email,Sex,Username,Password,MedRecordId,Address,BirthDate,Deceased,ParentName,AlergensIds,Contract,IsActive,Specialization

    {
        private string path = @"../../Data/people.csv";
        private static PeopleRepository instance = null;

        private const int CSV_COLUMN_SIZE = 19;
        private int[] STAFF_COLUM_INDEX_RANGE = { 16, 17 };
        private int SPECIALIZATION_COLUMN_INDEX = 18;
        private int[] PATIENT_COLUMN_INDEX_RANGE = { 10, 15 };
        private int[] PERSON_COLUMN_INDEX_RANGE = { 0, 9 };

        private PeopleRepository() {}
      
      public static PeopleRepository GetInstance()
      {
            if (instance == null) instance = new PeopleRepository();
            return instance;
      }

        public uint GetId(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool HasUsername(string username)
        {
            throw new NotImplementedException();
        }

        public UserType GetRole(uint id)
        {
            throw new NotImplementedException();
        }

        public List<uint> GetActiveDoctorIds()
        {
            throw new NotImplementedException();
        }

        public List<uint> GetActiveSpecialistIds()
        {
            throw new NotImplementedException();
        }

        public List<uint> GetActiveSecretaryIds()
        {
            throw new NotImplementedException();
        }

        public List<uint> GetActiveDirectorIds()
        {
            throw new NotImplementedException();
        }

        public List<uint> GetAllIds()
        {
            throw new NotImplementedException();
        }

        public List<uint> GetAllStaffIds()
        {
            throw new NotImplementedException();
        }

        public List<uint> GetAllActiveStaffIds()
        {
            throw new NotImplementedException();
        }

        public List<uint> GetIdsByJMBG(string jmbg)
        {
            List<uint> result = new List<uint>();
            List<string[]> persons = Class_Diagram.Repository.Persistence.ReadEntryByKey(this.path, jmbg, 2);
            foreach(string[] person in persons)
            {
                result.Add(uint.Parse(person[0]));
            }
            return result;
        }

        public List<uint> GetIdsByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<uint> GetIdsBySurname(string surname)
        {
            throw new NotImplementedException();
        }

        public List<uint> GetPatientsIds()
        {
            throw new NotImplementedException();
        }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public Person Create(Person item)
        {
            Class_Diagram.Repository.Persistence.WriteEntry(this.path, PreparePersonForCSV(item));
            return item;
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

        
        public string getPath()
        {
            return path;
        }
        
        //Metode za pripremu unosa u csv fajl

        private string[] PreparePersonForCSV(Person item)
        {
            if (item.UserType.Equals(UserType.Patient))
                return CreatePatientDataArrayForCSV((Patient)item);
            else if (item.UserType.Equals(UserType.Doctor) || item.UserType.Equals(UserType.Secretary) || item.UserType.Equals(UserType.Manager))
                return CreateStaffDataArrayForCSV((Staff)item);
            else if (item.UserType.Equals(UserType.Specialist))
                return CreateSpecialistDataArrayForCSV((Specialist)item);

            return null;
        }

        private string[] CreatePatientDataArrayForCSV(Patient patient)
        {
            string[] result = new string[CSV_COLUMN_SIZE];

            string[] patientData = patient.getPatientCommaSeparatedData().Split(',');

            for (int i = 0; i < result.Length; i++)
            {
                if (i < patientData.Length)
                    result[i] = patientData[i];
                else
                    result[i] = "";
            }

            return result;
        }

        private string[] CreateSpecialistDataArrayForCSV(Specialist doctor_specialist)
        {
            string[] result = CreateStaffDataArrayForCSV((Staff)doctor_specialist);
            result[SPECIALIZATION_COLUMN_INDEX] = doctor_specialist.Specialization;
            return result;
        }

        private string[] CreateStaffDataArrayForCSV(Staff staff)
        {
            string[] result = new string[CSV_COLUMN_SIZE];
            string[] staffData = staff.getStaffCommaSeparatedData().Split(',');
            int staffDataIndex = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (i <= PERSON_COLUMN_INDEX_RANGE[1] || (i >= STAFF_COLUM_INDEX_RANGE[0] && i <= STAFF_COLUM_INDEX_RANGE[1]))
                {
                    result[i] = staffData[staffDataIndex];
                    staffDataIndex++;
                }
                else
                {
                    result[i] = "";
                }
            }
            return result;
        }
    }
}