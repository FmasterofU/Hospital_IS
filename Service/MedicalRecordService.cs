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

        public Examination AppendExamination(Examination examination, MedicalRecord medicalRecord)
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

            foreach (Referral r in examination.Referral)
            {
                ReferralRepository.GetInstance().Create(r);
            }

            examination = ExaminationRepository.GetInstance().Create(examination);

            medicalRecord.AddExamination(examination);
            MedicalRecordRepository.GetInstance().Update(medicalRecord);
            return examination;
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
            return MedicalRecordRepository.GetInstance().Read(patient.MedRecordId);

        }

        public MedicalRecord GetMedicalRecordById(uint id)
        {
            return MedicalRecordRepository.GetInstance().Read(id);
        }
    }
}