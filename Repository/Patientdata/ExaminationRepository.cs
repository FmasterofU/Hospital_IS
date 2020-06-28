// File:    ExaminationRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 10:02:48 PM
// Purpose: Definition of Class ExaminationRepository

using Class_Diagram.Repository;
using Model.Examination;
using Model.Roles;
using Repository.Roles;
using System;
using System.Collections.Generic;

namespace Repository.Patientdata
{
    public class ExaminationRepository : Repository.IRepositoryCRUD<Examination, uint>

    //Id,Time,DoctorId,Diagnosis,PrescriptionIds,ReferralIds

    {
        private string path = @"../../Data/examination.csv";
        private static ExaminationRepository instance = null;

        private ExaminationRepository() { }

        public static ExaminationRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new ExaminationRepository();
            }

            return instance;
        }

        public bool Delete(uint id)
        {
            return Persistence.RemoveEntry(path, id.ToString());
        }

        public Examination Create(Examination item)
        {
            string[] data = new string[6];
            data[0] = Persistence.GetNewId(path).ToString();
            item.SetId(uint.Parse(data[0]));
            data[1] = item.Time.Ticks.ToString();
            data[2] = item.Doctor.GetId().ToString();
            data[3] = item.Diagnosis;
            data[4] = "";
            foreach (Prescription p in item.Prescription)
            {
                data[4] += p.GetId().ToString() + " ";
            }
            data[4] = data[4].Trim();
            data[5] = "";
            foreach (Referral r in item.Referral)
            {
                data[5] += r.GetId().ToString() + " ";
            }
            data[5] = data[5].Trim();
            bool isAdded = Persistence.WriteEntry(path, data);
            if (isAdded)
            {
                return item;
            }
            else
            {
                return null;
            }
        }

        public Examination Read(uint id)
        {
            List<string[]> data = Persistence.ReadEntryByPrimaryKey(path, id.ToString());
            if (data.Count == 1)
            {
                uint exID = uint.Parse(data[0][0]);
                long ticks = long.Parse(data[0][1]);
                DateTime date = new DateTime(ticks);
                uint docID = uint.Parse(data[0][2]);
                Doctor d = (Doctor)PeopleRepository.GetInstance().Read(docID);
                string diagnosis = data[0][3];
                List<Prescription> presList = new List<Prescription>();
                string[] presIDs = data[0][4].Split(' ');
                foreach (string presID in presIDs)
                {
                    if (presID.Equals(""))
                    {
                        break;
                    }

                    Prescription p = PrescriptionRepository.GetInstance().Read(uint.Parse(presID));
                    presList.Add(p);
                }
                List<Referral> refList = new List<Referral>();
                string[] refIDs = data[0][5].Split(' ');
                foreach (string refID in refIDs)
                {
                    if (refID.Equals(""))
                    {
                        break;
                    }

                    Referral r = ReferralRepository.GetInstance().Read(uint.Parse(refID));
                    refList.Add(r);
                }

                Examination ret = new Examination(date, diagnosis, d, presList, refList);
                ret.SetId(exID);
                return ret;
            }
            return null;
        }

        public Examination Update(Examination item)
        {
            throw new NotImplementedException();
        }

        public List<Examination> GetAll()
        {
            List<string> ids = Persistence.ReadAllPrimaryIds(path);
            List<Examination> ret = new List<Examination>();
            foreach (string s in ids)
            {
                ret.Add(Read(uint.Parse(s)));
            }

            return ret;
        }
    }
}