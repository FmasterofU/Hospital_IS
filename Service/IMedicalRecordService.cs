// File:    IMedicalRecordService.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:18:25 PM
// Purpose: Definition of Interface IMedicalRecordService

using System;

namespace Service
{
   public interface IMedicalRecordService
   {
      Model.Medicalrecord.MedicalRecord GetMedicalRecordByPatient(Model.Roles.Patient patient);
      
      Model.Medicalrecord.MedicalRecord GetMedicalRecordByAppointment(Model.Appointments.Appointment appoinment);
      
      bool AddMedicalRecord(Model.Medicalrecord.MedicalRecord medRecord);
      
      bool EditInsurance(Model.Medicalrecord.InsurancePolicy insurance);
      
      bool AppendExamination(Model.Examination.Examination examination, Model.Medicalrecord.MedicalRecord medicalRecord);
   
   }
}