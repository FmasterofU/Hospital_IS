using ManagingDirectorMobile.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingDirectorMobile.ViewModel
{
    class DrugsChangeViewModel
    {
        private Drug drug;
        public string DrugName { get { return drug.Name; } }
        public string DrugQuantity { get { return drug.Number.ToString(); } }
        public string DrugMinimumFormString { get { return "minimum(" + drug.Threshold + "):"; } }
        public ObservableCollection<DrugBatch> drugBatches { get; set; }
        public string EXPDate { get; set; }

        public DrugsChangeViewModel(Drug drug) {
            this.drug = drug;
            drugBatches = drug.drugBatches;
            EXPDate = "";
        }

        public void Save(int threshold, DateTime? EXP, string code, int quantity)
        {
            if (threshold != -1)
                drug.Threshold = threshold;
            if (code != null)
            {
                DrugBatch check = null;
                foreach(DrugBatch db in drug.drugBatches)
                    if (db.Code.Equals(code))
                    {
                        check = db;
                        break;
                    }
                if (check!=null)
                {
                    drug.Number += quantity != -1 ? quantity - check.Quantity : 0;
                    check.Quantity = quantity != -1 ? quantity : check.Quantity;
                    check.EXP = EXP==null? check.EXP: (DateTime)EXP;
                }
                else if(EXP!=null && quantity!=-1)
                {
                    drug.Number += quantity;
                    drug.drugBatches.Add(new DrugBatch() { Code = code, EXP = (DateTime)EXP, Quantity = quantity });
                }
            }
                
        }
    }
}
