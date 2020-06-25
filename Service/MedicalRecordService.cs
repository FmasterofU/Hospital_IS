// File:    MedicalRecordService.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:18:25 PM
// Purpose: Definition of Class MedicalRecordService

using Model.Appointments;
using Model.Examination;
using Model.Medicalrecord;
using Model.Roles;
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
            throw new NotImplementedException();
        }

        public bool EditInsurance(InsurancePolicy insurance)
        {
            throw new NotImplementedException();
        }

        public MedicalRecord GetMedicalRecordByAppointment(Appointment appoinment)
        {
            throw new NotImplementedException();
        }

        public MedicalRecord GetMedicalRecordByPatient(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}