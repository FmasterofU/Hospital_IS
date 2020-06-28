// File:    PeopleRepository.cs
// Author:  fmaster
// Created: Friday, May 22, 2020 12:14:24 PM
// Purpose: Definition of Class PeopleRepository

using Class_Diagram.Constants;
using Class_Diagram.Repository;
using Model.Medicine;
using Model.Roles;
using Repository.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;



namespace Repository.Roles
{
    public class PeopleRepository : IPersonRepository

    //Id,UserType,Jmbg,Name,Surname,Phone,Email,Sex,Username,Password,MedRecordId,Address,BirthDate,Deceased,ParentName,AlergensIds,Contract,IsActive,Specialization

    {
        private string path = @"../../Data/people.csv";
        private static PeopleRepository instance = null;

        private PeopleRepository() { }

        public static PeopleRepository GetInstance()
        {
            if (instance == null) instance = new PeopleRepository();
            return instance;
        }

        public uint GetId(string username, string password)
        {
            List<string[]> searchedResult = Persistence.ReadEntryByKey(path, username, PeopleConstants.USERNAME_COLUMN);
            if (searchedResult.Count == 0)
                return 0;
            string[] person = searchedResult[0];
            if (person[PeopleConstants.PASSWORD_COLUMN].Equals(password))
                return uint.Parse(person[PeopleConstants.ID_COLUMN]);
            return 0;
        }

        public bool HasUsername(string username)
        {
            List<string[]> searchedResult = Persistence.ReadEntryByKey(path, username, PeopleConstants.USERNAME_COLUMN);
            return searchedResult.Count != 0;
        }

        public UserType GetRole(uint id)
        {
            UserType result = UserType.None;
            List<string[]> searchedResult = Persistence.ReadEntryByPrimaryKey(path, id.ToString());
            if (searchedResult.Count != 0)
            {
                string[] person = searchedResult[PeopleConstants.ID_COLUMN];
                result = (UserType)int.Parse(person[PeopleConstants.USER_TYPE_COLUMN]);
            }
            return result;
        }

        private UserType convertToUserType(string type)
        {
            if (type.Equals(UserType.Manager.ToString()))
                return UserType.Manager;
            else if (type.Equals(UserType.Secretary.ToString()))
                return UserType.Secretary;
            else if (type.Equals(UserType.Doctor.ToString()))
                return UserType.Doctor;
            else if (type.Equals(UserType.Specialist.ToString()))
                return UserType.Specialist;
            else if (type.Equals(UserType.Patient.ToString()))
                return UserType.Patient;
            else
                return UserType.None;
        }

        private List<uint> getActiveUsers(UserType type)
        {
            int typeEnumNumber = (int) type;
            List<string[]> searchedResult = Persistence.ReadEntryByKey(path, typeEnumNumber.ToString(), PeopleConstants.USER_TYPE_COLUMN);
            List<uint> result = new List<uint>();
            foreach (string[] person in searchedResult)
            {
                if (bool.Parse(person[PeopleConstants.IS_ACTIVE_COLUMN]))
                    result.Add(uint.Parse(person[PeopleConstants.ID_COLUMN]));
            }

            return result;
        }

        public List<uint> GetActiveDoctorIds()
        {
            return getActiveUsers(UserType.Doctor);
        }

        public List<uint> GetActiveSpecialistIds()
        {
            return getActiveUsers(UserType.Specialist);
        }

        public List<uint> GetActiveSecretaryIds()
        {
            return getActiveUsers(UserType.Secretary);
        }

        public List<uint> GetActiveDirectorIds()
        {
            return getActiveUsers(UserType.Manager);
        }


        public List<uint> GetAllIds()
        {
            List<uint> result = new List<uint>();
            foreach(Person person in GetAll())
            {
                result.Add(person.GetId());
            }

            return result;
        }

        public List<uint> GetAllStaffIds()
        {
            List<uint> result = new List<uint>();
            foreach (Person person in GetAll())
            {
                if(person.IsStaff())
                    result.Add(person.GetId());
            }

            return result;
        }

        public List<uint> GetAllActiveStaffIds()
        {
            List<uint> result = new List<uint>();
            foreach (Person person in GetAll())
            {
                if (person.IsStaff())
                {
                    if (((Staff)person).Active)
                        result.Add(person.GetId());
                }
            }

            return result;
        }

        public List<uint> GetIdsByJMBG(string jmbg)
        {
            List<uint> result = new List<uint>();
            List<string[]> persons = Persistence.ReadEntryByKey(this.path, jmbg, PeopleConstants.JMBG_COLUMN);
            foreach(string[] person in persons)
            {
                result.Add(uint.Parse(person[PeopleConstants.ID_COLUMN]));
            }
            return result;
        }

        public List<uint> GetIdsByName(string name)
        {
            List<uint> result = new List<uint>();
            List<string[]> persons = Persistence.ReadEntryByKey(this.path, name, PeopleConstants.NAME_COLUMN);
            foreach (string[] person in persons)
            {
                if(person[PeopleConstants.NAME_COLUMN].Equals(name))
                    result.Add(uint.Parse(person[PeopleConstants.ID_COLUMN]));
            }
            return result;
        }

        public List<uint> GetIdsBySurname(string surname)
        {
            List<uint> result = new List<uint>();
            List<string[]> persons = Persistence.ReadEntryByKey(this.path, surname, PeopleConstants.SURNAME_COLUMN);
            foreach (string[] person in persons)
            {
                if (person[PeopleConstants.SURNAME_COLUMN].Equals(surname))
                    result.Add(uint.Parse(person[PeopleConstants.ID_COLUMN]));
            }
            return result;
        }

        public List<uint> GetPatientsIds()
        {
            int patientEnumNumber = (int) UserType.Patient;
            List<string[]> searchedResult = Persistence.ReadEntryByKey(path, patientEnumNumber.ToString(), PeopleConstants.USER_TYPE_COLUMN);
            List<uint> result = new List<uint>();
            foreach (string[] person in searchedResult)
            {
                result.Add(uint.Parse(person[PeopleConstants.ID_COLUMN]));
            }

            return result;
        }

        public bool Delete(uint id)
        {
            return Persistence.RemoveEntry(path, id.ToString());
        }

        public Person Create(Person item)
        {
            item.SetId(Persistence.GetNewId(path));
            bool isAdded = Persistence.WriteEntry(this.path, PreparePersonForCSV(item));
            if (isAdded)
                return item;
            else
                return null;
        }

        public Person Read(uint id)
        {
            List<string[]> data = Persistence.ReadEntryByPrimaryKey(path, id.ToString());

            if (data.Count == 0)
                return null;
            //Person data
            string[] line = data[0];
            uint personId = uint.Parse(line[PeopleConstants.ID_COLUMN]);
            UserType personType = (UserType) int.Parse(line[PeopleConstants.USER_TYPE_COLUMN]);
            string jmbg = line[PeopleConstants.JMBG_COLUMN];
            string name = line[PeopleConstants.NAME_COLUMN];
            string surname = line[PeopleConstants.SURNAME_COLUMN];
            string phone = line[PeopleConstants.PHONE_COLUMN];
            string email = line[PeopleConstants.EMAIL_COLUMN];
            Sex sex = (Sex)int.Parse(line[PeopleConstants.SEX_COLUMN]);
            string username = line[PeopleConstants.USERNAME_COLUMN];
            string password = line[PeopleConstants.PASSWORD_COLUMN];
            uint medRecordId = line[PeopleConstants.MEDICAL_RECORD_ID_COLUMN].Equals("")? 0: uint.Parse(line[PeopleConstants.MEDICAL_RECORD_ID_COLUMN]);
            string address = line[PeopleConstants.ADDRESS_COLUMN];

            //StaffData
            long dateTicks = line[PeopleConstants.BIRTH_DATE_COLUMN].Equals("") ? 0 : long.Parse(line[PeopleConstants.BIRTH_DATE_COLUMN]);
            bool decased = line[PeopleConstants.DECASED_COLUMN].Equals("") ? false : bool.Parse(line[PeopleConstants.DECASED_COLUMN]);
            string parentName = line[PeopleConstants.PARENT_NAME_COLUMN];
            string alergenIdsText = line[PeopleConstants.ALERGENS_IDS_COLUMN];
            //string contract = line[PeopleRepositoryConstants.CONTRACT_COLUMN];
            bool active = line[PeopleConstants.IS_ACTIVE_COLUMN].Equals("") ? false : bool.Parse(line[PeopleConstants.IS_ACTIVE_COLUMN]);
            string specialization = line[PeopleConstants.SPECIALIZATION_COLUMN];

            if (personType.Equals(UserType.Patient))
                return new Patient(personId, name, surname, phone, email, sex, jmbg, username, password, personType, address, new DateTime(dateTicks), decased, parentName, medRecordId, getAlergens(alergenIdsText));
            else if (personType.Equals(UserType.Secretary))
                return new Secretary(personId, name, surname, phone, email, sex, jmbg, username, password, personType, null, active);
            else if (personType.Equals(UserType.Doctor))
                return new Doctor(personId, name, surname, phone, email, sex, jmbg, username, password, personType, null, active);
            else if (personType.Equals(UserType.Manager))
                return new Manager(personId, name, surname, phone, email, sex, jmbg, username, password, personType, null, active);
            else if (personType.Equals(UserType.Specialist))
                return new Specialist(personId, name, surname, phone, email, sex, jmbg, username, password, personType, null, active, specialization);
            else return null;
   
        }

        private List<Ingridient> getAlergens(string alergensIdsText)
        {
            List<Ingridient> result = new List<Ingridient>();
            if (alergensIdsText.Equals(""))
                return result;
            foreach (string alergenId in alergensIdsText.Split(' '))
            {
                result.Add(IngridientRepository.GetInstance().Read(uint.Parse(alergenId)));
            }
            return result;
        }

        public Person Update(Person item)
        {
            if (Persistence.EditEntry(path, PreparePersonForCSV(item)))
                return item;
            return null;
        }

        public List<Person> GetAll()
        {
            List<string> allIds = Persistence.ReadAllPrimaryIds(path);
            List<Person> ret = new List<Person>();
            foreach (string s in allIds)
                ret.Add(Read(uint.Parse(s)));
            return ret;
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
            string[] result = new string[PeopleConstants.CSV_COLUMN_SIZE];

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
            result[PeopleConstants.SPECIALIZATION_COLUMN] = doctor_specialist.Specialization;
            return result;
        }

        private string[] CreateStaffDataArrayForCSV(Staff staff)
        {
            string[] result = new string[PeopleConstants.CSV_COLUMN_SIZE];
            string[] staffData = staff.getStaffCommaSeparatedData().Split(',');
            int staffDataIndex = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (i <= PeopleConstants.PERSON_COLUMN_INDEX_END || (i >= PeopleConstants.STAFF_COLUM_INDEX_START  && i <= PeopleConstants.STAFF_COLUM_INDEX_END ))
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
