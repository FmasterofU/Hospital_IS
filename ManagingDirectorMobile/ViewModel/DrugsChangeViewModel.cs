using Controller;
using ManagingDirectorMobile.Model;
using Model.Medicine;
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
        Controller.IDrugController c = new DrugController();
        private Drug drug;
        public string DrugName { get { return drug.Name; } }
        public string DrugQuantity { get { return drug.drugStateChange.TotalNumber.ToString(); } }
        public string DrugMinimumFormString { get { return "minimum(" + drug.drugStateChange.Threshold + "):"; } }
        public ObservableCollection<DrugBatch> drugBatches { get; set; }
        public string EXPDate { get; set; }

        public DrugsChangeViewModel(Drug drug) {
            this.drug = drug;
            List<DrugBatch> d = c.GetDrugBatches(drug);
            drugBatches = new ObservableCollection<DrugBatch>();
            foreach (DrugBatch temp in d)
                drugBatches.Add(temp);
            EXPDate = "";
        }

        public void Save(int threshold, DateTime? EXP, string code, int quantity)
        {
            if (threshold != -1) {
                drug.drugStateChange.Threshold = threshold;
                c.EditDrugStateChange(drug.drugStateChange);
            }
            if (code != null)
            {
                DrugBatch check = null;
                foreach(DrugBatch db in c.GetDrugBatches(drug))
                    if (db.LotNumber.Equals(code))
                    {
                        check = db;
                        break;
                    }
                if (check!=null)
                {
                    DrugStateChange dsc = new DrugStateChange(DateTime.Now, quantity != -1 ? drug.drugStateChange.TotalNumber + (quantity - check.Number) : drug.drugStateChange.TotalNumber, drug.drugStateChange.Threshold, drug.GetId());
                    dsc = c.AddDrugStateChange(dsc);
                    check.Number = quantity != -1 ? quantity : check.Number;
                    check.ExpDate = EXP == null ? check.ExpDate : (DateTime)EXP;
                    c.EditDrugBatch(check);
                    drug.drugStateChange = dsc;
                }
                else if(EXP!=null && quantity!=-1)
                {
                    DrugBatch db = new DrugBatch(code, quantity, EXP.GetValueOrDefault(), drug.GetId());
                    db = c.AddDrugBatch(db);
                    drug.drugStateChange.TotalNumber += quantity;
                    drug.drugStateChange = c.AddDrugStateChange(drug.drugStateChange);
                    drug.drugBatch.Add(db);
                }
            }
            c.EditDrug(drug);
        }
    }
}
