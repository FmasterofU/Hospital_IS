using ManagingDirectorMobile.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingDirectorMobile.ViewModel
{
    class DrugsViewModel
    {

        public ObservableCollection<Drug> drugs { get; set; }

        public DrugsViewModel()
        {
            drugs = Drug.GetDrugList();
        }

        public void Search(String name = null)
        {
            if (name == null)
            {
                drugs = Drug.GetDrugList();
                return;
            }
            var newDrugs = new ObservableCollection<Drug>();
            foreach(Drug drug in drugs)
                if (drug.Name.Equals(name))
                    newDrugs.Add(drug);
            drugs = newDrugs;
        }
    }
}
