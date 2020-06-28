// File:    MedicalRecordController.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:35:04 PM
// Purpose: Definition of Class MedicalRecordController

using Model.Appointments;
using Model.Examination;
using Model.Medicalrecord;
using Model.Roles;
using Service;
using System;

namespace Controller
{
   public class MedicalRecordController : IMedicalRecordController
   {
      public Service.IMedicalRecordService iMedicalRecordService = new MedicalRecordService();

        public bool AddMedicalRecord(MedicalRecord medRecord)
        {
            throw new NotImplementedException();
        }

        public Examination AppendExamination(Examination examination, MedicalRecord medicalRecord)
        {
            return iMedicalRecordService.AppendExamination(examination, medicalRecord);
        }

        public bool EditInsurance(InsurancePolicy insurance)
        {
            throw new NotImplementedException();
        }

        public MedicalRecord GetMedicalRecordByAppointment(Appointment appoinment)
        {
            MedicalRecord medicalRecord = iMedicalRecordService.GetMedicalRecordByAppointment(appoinment);
            return medicalRecord;
        }

        public MedicalRecord GetMedicalRecordByPatient(Patient patient)
        {
            return iMedicalRecordService.GetMedicalRecordByPatient(patient);
        }
    }
}