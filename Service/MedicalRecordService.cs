// File:    MedicalRecordService.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:18:25 PM
// Purpose: Definition of Class MedicalRecordService

using Model.Appointments;
using Model.Examination;
using Model.Medicalrecord;
using Model.Medicine;
using Model.Roles;
using Repository.Medicine;
using Repository.Patientdata;
using System;

namespace Service
{
    public class MedicalRecordService : IMedicalRecordService
    {
        public MedicalRecord AddMedicalRecord(MedicalRecord medRecord)
        {
            return MedicalRecordRepository.GetInstance().Create(medRecord);            
        }

        public MedicalRecord EditMedicalRecord(MedicalRecord medRecord)
        {
            return MedicalRecordRepository.GetInstance().Update(medRecord);
        }

        public bool AppendExamination(Examination examination, MedicalRecord medicalRecord)
        {
            foreach (Prescription p in examination.Prescription)
            {
                DrugStateChange oldState = p.drug.drugStateChange;
                DrugStateChange newState = new DrugStateChange(DateTime.Now, oldState.TotalNumber - (int)p.Number, oldState.Threshold, oldState.DrugId);
                DrugStateChangeRepository.GetInstance().Create(newState);
                p.drug.drugStateChange = newState;
                DrugRepository.GetInstance().Update(p.drug);
                PrescriptionRepository.GetInstance().Create(p);
            }

            foreach (Referral r in examination.Referral) ReferralRepository.GetInstance().Create(r);

            medicalRecord.AddExamination(examination);
            MedicalRecordRepository.GetInstance().Update(medicalRecord);
            //TODO: check return value
            return true;
        }

        public bool EditInsurance(InsurancePolicy insurance)
        {
            throw new NotImplementedException();
        }

        public MedicalRecord GetMedicalRecordByAppointment(Appointment appoinment)
        {
            MedicalRecord medicalRecord = MedicalRecordRepository.GetInstance().Read(appoinment.MedicalRecordId);
            return medicalRecord;
        }

        public MedicalRecord GetMedicalRecordByPatient(Patient patient)
        {
            throw new NotImplementedException();

        }

        public MedicalRecord GetMedicalRecordById(uint id)
        {
            return MedicalRecordRepository.GetInstance().Read(id);
        }
    }
}