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
        public bool AddMedicalRecord(MedicalRecord medRecord)
        {
            throw new NotImplementedException();
        }

        public bool AppendExamination(Examination examination, MedicalRecord medicalRecord)
        {
            foreach (Prescription p in examination.Prescription)
            {
                DrugStateChange oldState = p.drug.drugStateChange;
                //TODO: generate id(last argument)
                DrugStateChange newState = new DrugStateChange(DateTime.Now, oldState.TotalNumber - (int)p.Number, oldState.Threshold, oldState.DrugId, 69);
                DrugStateChangeRepository.GetInstance().Create(newState);
                p.drug.drugStateChange = newState;
            }

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
    }
}