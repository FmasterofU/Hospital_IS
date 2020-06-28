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

        public bool AppendExamination(Examination examination, MedicalRecord medicalRecord)
        {
            bool ret = iMedicalRecordService.AppendExamination(examination, medicalRecord);
            return ret;
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
            throw new NotImplementedException();
        }
    }
}