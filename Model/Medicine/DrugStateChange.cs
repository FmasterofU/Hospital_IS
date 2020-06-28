// File:    DrugStateChange.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class DrugStateChange

using System;

namespace Model.Medicine
{
    public class DrugStateChange : Repository.IIdentifiable<uint>
    {
        private DateTime timestamp;
        private int totalNumber;
        private int threshold;
        private uint drugId;
        private uint id;

        public DrugStateChange(DateTime timestamp, int totalNumber, int threshold, uint drugId)
        {
            this.timestamp = timestamp;
            this.totalNumber = totalNumber;
            this.threshold = threshold;
            this.drugId = drugId;
            id = 0;
        }

        public DrugStateChange(uint id, DateTime timestamp, int totalNumber, int threshold, uint drugId)
        {
            this.timestamp = timestamp;
            this.totalNumber = totalNumber;
            this.threshold = threshold;
            this.drugId = drugId;
            this.id = id;
        }

        public DateTime Timestamp
        {
            get => timestamp;
            set => timestamp = value;
        }

        public int TotalNumber
        {
            get => totalNumber;
            set => totalNumber = value;
        }

        public int Threshold
        {
            get => threshold;
            set => threshold = value;
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