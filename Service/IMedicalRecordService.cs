// File:    IMedicalRecordService.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:18:25 PM
// Purpose: Definition of Interface IMedicalRecordService

using Model.Examination;
using Model.Medicalrecord;
using System;

namespace Service
{
   public interface IMedicalRecordService
   {
        MedicalRecord GetMedicalRecordByPatient(Model.Roles.Patient patient);

        MedicalRecord EditMedicalRecord(MedicalRecord medRecord);

        MedicalRecord GetMedicalRecordByAppointment(Model.Appointments.Appointment appoinment);
      
        MedicalRecord AddMedicalRecord(MedicalRecord medRecord);

        MedicalRecord GetMedicalRecordById(uint id);
      
        bool EditInsurance(InsurancePolicy insurance);

        Examination AppendExamination(Examination examination, MedicalRecord medicalRecord);
   
   }
}