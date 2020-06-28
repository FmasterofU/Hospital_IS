using Controller;
using ManagingDirectorMobile.Model;
using Model.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingDirectorMobile.ViewModel
{
    class DrugsAddViewModel
    {
        private static readonly Random _random = new Random();
        private static Controller.IDrugController c = new DrugController();
        public static void Add(String name, int number)
        {
            //DrugDummy.drugs.Add(new DrugDummy() { Name = name, Threshold=number,Code= _random.Next(0,10000).ToString() });
            Drug d = new Drug(name, true, new List<DrugBatch>(), new List<IngridientRatio>(), new List<SideEffectFrequency>(), new DrugStateChange(DateTime.Now, 0, number, 0));
            d = c.AddDrug(d);
            d.drugStateChange.DrugId = d.GetId();
            c.AddDrugStateChange(d.drugStateChange);
            c.EditDrug(d);
        }
    }
}
