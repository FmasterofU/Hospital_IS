// File:    Patient.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class Patient

using Model.Medicine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Roles
{
    public class Patient : Person
    {
        private string address;
        private DateTime birthDate;
        private bool deceased = false;
        private string parentName;
        private uint medRecordId;

        public Patient(string name, string surname, string phone, string email, Sex sex, string jmbg, string username, string password, UserType userType, string address, DateTime birthDate, bool deceased,
                string parentName, uint medRecordId, List<Ingridient> alergens) : base(name, surname, phone, email, sex, jmbg, username, password, userType)
        {
            this.address = address;
            this.birthDate = birthDate;
            this.deceased = deceased;
            this.parentName = parentName;
            this.medRecordId = medRecordId;
            this.alergens = alergens;
        }

        public Patient(uint id, string name, string surname, string phone, string email, Sex sex, string jmbg, string username, string password, UserType userType, string address, DateTime birthDate, bool deceased,
                string parentName, uint medRecordId, List<Ingridient> alergens) : base(id, name, surname, phone, email, sex, jmbg, username, password, userType)
        {
            this.address = address;
            this.birthDate = birthDate;
            this.deceased = deceased;
            this.parentName = parentName;
            this.medRecordId = medRecordId;
            this.alergens = alergens;
        }

        public string Address
        {
            get => address;
            set => address = value;
        }

        public DateTime BirthDate
        {
            get => birthDate;
            set => birthDate = value;
        }

        public bool Deceased
        {
            get => deceased;
            set => deceased = value;
        }

        public string ParentName
        {
            get => parentName;
            set => parentName = value;
        }

        public uint MedRecordId
        {
            get => medRecordId;
            set => medRecordId = value;
        }

        public System.Collections.Generic.List<Ingridient> alergens;

        /// <summary>
        /// Property for collection of Ingridient
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<Ingridient> Alergens
        {
            get
            {
                if (alergens == null)
                {
                    alergens = new System.Collections.Generic.List<Ingridient>();
                }

                return alergens;
            }
            set
            {
                RemoveAllAlergens();
                if (value != null)
                {
                    foreach (Ingridient oIngridient in value)
                    {
                        AddAlergens(oIngridient);
                    }
                }
            }
        }

        /// <summary>
        /// Add a new Ingridient in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddAlergens(Ingridient newIngridient)
        {
            if (newIngridient == null)
            {
                return;
            }

            if (alergens == null)
            {
                alergens = new System.Collections.Generic.List<Ingridient>();
            }

            if (!alergens.Contains(newIngridient))
            {
                alergens.Add(newIngridient);
            }
        }

        /// <summary>
        /// Remove an existing Ingridient from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveAlergens(Ingridient oldIngridient)
        {
            if (oldIngridient == null)
            {
                return;
            }

            if (alergens != null)
            {
                if (alergens.Contains(oldIngridient))
                {
                    alergens.Remove(oldIngridient);
                }
            }
        }

        /// <summary>
        /// Remove all instances of Ingridient from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllAlergens()
        {
            if (alergens != null)
            {
                alergens.Clear();
            }
        }

        public string getPatientCommaSeparatedData()
        {
            return getPersonCommaSeparatedData() + "," + MedRecordId + "," + Address + "," + BirthDate.Ticks + "," + deceased.ToString() + "," + ParentName + "," + getAlergensSpaceSeparateIds();
        }

        private string getAlergensSpaceSeparateIds()
        {
            StringBuilder result = new StringBuilder("");
            foreach (Ingridient alergen in alergens)
            {
                result.Append(" " + alergen.GetId().ToString());
            }
            if (alergens.Count != 0)
            {
                return result.ToString().Substring(1);
            }

            return result.ToString();
        }


    }
}