// File:    IMedicalRecordController.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:30:59 PM
// Purpose: Definition of Interface IMedicalRecordController

using Model.Examination;

namespace Controller
{
    public interface IMedicalRecordController
    {
        Model.Medicalrecord.MedicalRecord GetMedicalRecordByPatient(Model.Roles.Patient patient);

        Model.Medicalrecord.MedicalRecord GetMedicalRecordByAppointment(Model.Appointments.Appointment appoinment);

        bool AddMedicalRecord(Model.Medicalrecord.MedicalRecord medRecord);

        bool EditInsurance(Model.Medicalrecord.InsurancePolicy insurance);

        Examination AppendExamination(Examination examination, Model.Medicalrecord.MedicalRecord medicalRecord);

    }
}