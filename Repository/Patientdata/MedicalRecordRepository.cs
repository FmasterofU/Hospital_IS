// File:    MedicalRecordRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 10:02:48 PM
// Purpose: Definition of Class MedicalRecordRepository

using Class_Diagram.Repository;
using Model.Examination;
using Model.Medicalrecord;
using Model.Roles;
using Repository.Roles;
using System;
using System.Collections.Generic;

namespace Repository.Patientdata
{
   public class MedicalRecordRepository : Repository.IRepositoryCRUD<MedicalRecord, uint>

        //MedicalRecordId,PatientId,InsuranceId,ExaminationIds

    {
        private string path = @"../../Data/medical_record.csv";
        private static MedicalRecordRepository instance = null;

        private MedicalRecordRepository() {}
      
      public static MedicalRecordRepository GetInstance()
      {
            if (instance == null) instance = new MedicalRecordRepository();
            return instance;
      }

        public bool Delete(uint id)
        {
            return Persistence.RemoveEntry(path, id.ToString());
        }

        public MedicalRecord Create(MedicalRecord item)
        {
            string[] data = new string[4];
            data[0] = item.GetId().ToString();
            data[1] = item.patient.GetId().ToString();
            data[2] = item.insurancePolicy.GetId();
            data[3] = "";
            foreach (Examination e in item.Examination)
            {
                data[3] += e.GetId().ToString() + " ";
            }
            data[3] = data[3].Trim();
            bool isAdded = Persistence.WriteEntry(path, data);
            if (isAdded) return item;
            else return null;
        }

        public MedicalRecord Read(uint id)
        {
            List<string[]> data = Persistence.ReadEntryByPrimaryKey(path, id.ToString());
            if(data.Count == 1)
            {
                uint mrID = uint.Parse(data[0][0]);
                uint patID = uint.Parse(data[0][1]);
                string insuranceID = data[0][2];
                InsurancePolicy policy = InsurancePolicyRepository.GetInstance().Read(insuranceID);
                if (policy != null)
                {
                    //Patient patient = PeopleRepository.GetInstance().Read(patID);
                    //TODO: change return type
                    Patient patient = null;
                    List<Examination> exams = new List<Examination>();
                    if (data[0].Length == 4)
                    {
                        string[] examIDs = data[0][3].Split(' ');
                        foreach (string exID in examIDs)
                        {
                            Examination e = ExaminationRepository.GetInstance().Read(uint.Parse(exID));
                            exams.Add(e);
                        }
                    }
                    MedicalRecord ret = new MedicalRecord(policy, exams, patient);
                    ret.SetId(mrID);
                    return ret;
                }
            }
            return null;
        }

        public MedicalRecord Update(MedicalRecord item)
        {
            string[] data = new string[4];
            data[0] = item.GetId().ToString();
            data[1] = item.patient.GetId().ToString();
            data[2] = item.insurancePolicy.GetId();
            data[3] = "";
            foreach(Examination e in item.Examination)
            {
                data[3] += e.GetId().ToString() + " ";
            }
            data[3] = data[3].Trim();
            bool isUpdated = Persistence.EditEntry(path, data);
            if (isUpdated) return item;
            else return null;
        }

        public List<MedicalRecord> GetAll()
        {
            throw new NotImplementedException();
        }

        public string getPath()
        {
            return path;
        }
   }
}