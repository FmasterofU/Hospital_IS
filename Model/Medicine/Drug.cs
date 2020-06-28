// File:    Drug.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class Drug

using System.Collections.Generic;

namespace Model.Medicine
{
    public class Drug : Repository.IIdentifiable<uint>
    {
        private uint id;
        private string name;
        private bool inUse = true;

        public Drug(string name, bool inUse, List<DrugBatch> drugBatch, List<IngridientRatio> ingridientRatio, List<SideEffectFrequency> sideEffectFrequency, DrugStateChange drugStateChange)
        {
            id = 0;
            this.name = name;
            this.inUse = inUse;
            this.drugBatch = drugBatch;
            this.ingridientRatio = ingridientRatio;
            this.sideEffectFrequency = sideEffectFrequency;
            this.drugStateChange = drugStateChange;
        }

        public Drug(uint id, string name, bool inUse, List<DrugBatch> drugBatch, List<IngridientRatio> ingridientRatio, List<SideEffectFrequency> sideEffectFrequency, DrugStateChange drugStateChange)
        {
            this.id = id;
            this.name = name;
            this.inUse = inUse;
            this.drugBatch = drugBatch;
            this.ingridientRatio = ingridientRatio;
            this.sideEffectFrequency = sideEffectFrequency;
            this.drugStateChange = drugStateChange;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public bool InUse
        {
            get => inUse;
            set => inUse = value;
        }

        public System.Collections.Generic.List<DrugBatch> drugBatch;

        /// <summary>
        /// Property for collection of DrugBatch
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<DrugBatch> DrugBatch
        {
            get
            {
                if (drugBatch == null)
                {
                    drugBatch = new System.Collections.Generic.List<DrugBatch>();
                }

                return drugBatch;
            }
            set
            {
                RemoveAllDrugBatch();
                if (value != null)
                {
                    foreach (DrugBatch oDrugBatch in value)
                    {
                        AddDrugBatch(oDrugBatch);
                    }
                }
            }
        }

        /// <summary>
        /// Add a new DrugBatch in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddDrugBatch(DrugBatch newDrugBatch)
        {
            if (newDrugBatch == null)
            {
                return;
            }

            if (drugBatch == null)
            {
                drugBatch = new System.Collections.Generic.List<DrugBatch>();
            }

            if (!drugBatch.Contains(newDrugBatch))
            {
                drugBatch.Add(newDrugBatch);
            }
        }

        /// <summary>
        /// Remove an existing DrugBatch from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveDrugBatch(DrugBatch oldDrugBatch)
        {
            if (oldDrugBatch == null)
            {
                return;
            }

            if (drugBatch != null)
            {
                if (drugBatch.Contains(oldDrugBatch))
                {
                    drugBatch.Remove(oldDrugBatch);
                }
            }
        }

        /// <summary>
        /// Remove all instances of DrugBatch from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllDrugBatch()
        {
            if (drugBatch != null)
            {
                drugBatch.Clear();
            }
        }
        public System.Collections.Generic.List<IngridientRatio> ingridientRatio;

        /// <summary>
        /// Property for collection of IngridientRatio
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<IngridientRatio> IngridientRatio
        {
            get
            {
                if (ingridientRatio == null)
                {
                    ingridientRatio = new System.Collections.Generic.List<IngridientRatio>();
                }

                return ingridientRatio;
            }
            set
            {
                RemoveAllIngridientRatio();
                if (value != null)
                {
                    foreach (IngridientRatio oIngridientRatio in value)
                    {
                        AddIngridientRatio(oIngridientRatio);
                    }
                }
            }
        }

        /// <summary>
        /// Add a new IngridientRatio in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddIngridientRatio(IngridientRatio newIngridientRatio)
        {
            if (newIngridientRatio == null)
            {
                return;
            }

            if (ingridientRatio == null)
            {
                ingridientRatio = new System.Collections.Generic.List<IngridientRatio>();
            }

            if (!ingridientRatio.Contains(newIngridientRatio))
            {
                ingridientRatio.Add(newIngridientRatio);
            }
        }

        /// <summary>
        /// Remove an existing IngridientRatio from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveIngridientRatio(IngridientRatio oldIngridientRatio)
        {
            if (oldIngridientRatio == null)
            {
                return;
            }

            if (ingridientRatio != null)
            {
                if (ingridientRatio.Contains(oldIngridientRatio))
                {
                    ingridientRatio.Remove(oldIngridientRatio);
                }
            }
        }

        /// <summary>
        /// Remove all instances of IngridientRatio from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllIngridientRatio()
        {
            if (ingridientRatio != null)
            {
                ingridientRatio.Clear();
            }
        }
        public System.Collections.Generic.List<SideEffectFrequency> sideEffectFrequency;

        /// <summary>
        /// Property for collection of SideEffectFrequency
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<SideEffectFrequency> SideEffectFrequency
        {
            get
            {
                if (sideEffectFrequency == null)
                {
                    sideEffectFrequency = new System.Collections.Generic.List<SideEffectFrequency>();
                }

                return sideEffectFrequency;
            }
            set
            {
                RemoveAllSideEffectFrequency();
                if (value != null)
                {
                    foreach (SideEffectFrequency oSideEffectFrequency in value)
                    {
                        AddSideEffectFrequency(oSideEffectFrequency);
                    }
                }
            }
        }

        /// <summary>
        /// Add a new SideEffectFrequency in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddSideEffectFrequency(SideEffectFrequency newSideEffectFrequency)
        {
            if (newSideEffectFrequency == null)
            {
                return;
            }

            if (sideEffectFrequency == null)
            {
                sideEffectFrequency = new System.Collections.Generic.List<SideEffectFrequency>();
            }

            if (!sideEffectFrequency.Contains(newSideEffectFrequency))
            {
                sideEffectFrequency.Add(newSideEffectFrequency);
            }
        }

        /// <summary>
        /// Remove an existing SideEffectFrequency from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveSideEffectFrequency(SideEffectFrequency oldSideEffectFrequency)
        {
            if (oldSideEffectFrequency == null)
            {
                return;
            }

            if (sideEffectFrequency != null)
            {
                if (sideEffectFrequency.Contains(oldSideEffectFrequency))
                {
                    sideEffectFrequency.Remove(oldSideEffectFrequency);
                }
            }
        }

        /// <summary>
        /// Remove all instances of SideEffectFrequency from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllSideEffectFrequency()
        {
            if (sideEffectFrequency != null)
            {
                sideEffectFrequency.Clear();
            }
        }

        public uint GetId()
        {
            return id;
        }

        public void SetId(uint id)
        {
            this.id = id;
        }

        public DrugStateChange drugStateChange;

    }
}