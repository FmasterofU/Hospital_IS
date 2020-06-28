// File:    SideEffectFrequency.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class SideEffectFrequency

namespace Model.Medicine
{
    public class SideEffectFrequency : Repository.IIdentifiable<uint>
    {
        private uint drugId;
        private uint id;
        private int basis;
        private int freq;

        public SideEffectFrequency(uint drugId, int basis, int freq, SideEffect sideEffect)
        {
            this.drugId = drugId;
            id = 0;
            this.basis = basis;
            this.freq = freq;
            this.sideEffect = sideEffect;
        }

        public SideEffectFrequency(uint id, uint drugId, int basis, int freq, SideEffect sideEffect)
        {
            this.drugId = drugId;
            this.id = id;
            this.basis = basis;
            this.freq = freq;
            this.sideEffect = sideEffect;
        }

        public uint DrugId
        {
            get => drugId;
            set => drugId = value;
        }

        public int Basis
        {
            get => basis;
            set => basis = value;
        }

        public int Freq
        {
            get => freq;
            set => freq = value;
        }

        public SideEffect sideEffect;

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