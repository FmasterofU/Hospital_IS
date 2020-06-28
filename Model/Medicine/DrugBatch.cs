// File:    DrugBatch.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class DrugBatch

using System;

namespace Model.Medicine
{
    public class DrugBatch : Repository.IIdentifiable<uint>
    {
        private string lotNumber;
        private int number;
        private DateTime expDate;
        private uint drugId;
        private uint id;

        public DrugBatch(string lotNumber, int number, DateTime expDate, uint drugId)
        {
            this.lotNumber = lotNumber;
            this.number = number;
            this.expDate = expDate;
            this.drugId = drugId;
            id = 0;
        }

        public DrugBatch(uint id, string lotNumber, int number, DateTime expDate, uint drugId)
        {
            this.lotNumber = lotNumber;
            this.number = number;
            this.expDate = expDate;
            this.drugId = drugId;
            this.id = id;
        }

        public int Number
        {
            get => number;
            set => number = value;
        }

        public DateTime ExpDate
        {
            get => expDate;
            set => expDate = value;
        }

        public string LotNumber
        {
            get => lotNumber;
            set => lotNumber = value;
        }

        public uint DrugId
        {
            get => drugId;
            set => drugId = value;
        }

        public uint GetId()
        {
            return id;
        }

        public void SetId(uint id)
        {
            this.id = id;
        }
    }
}