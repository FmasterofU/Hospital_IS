using Controller;
using ManagingDirectorMobile.Model;
using Model.Medicine;
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
        Controller.IDrugController c = new DrugController();

        public DrugsViewModel()
        {
            List<Drug> d = c.GetAllDrugs();
            drugs = new ObservableCollection<Drug>();
            foreach (Drug temp in d)
                drugs.Add(temp);
        }

        public void Search(String name = null)
        {
            List<Drug> d;
            if (name == null)
            {
                d = c.GetAllDrugs();
            }
            else
            {
                d = c.SearchDrugs(name);
            }
            drugs = new ObservableCollection<Drug>();
            foreach (Drug temp in d)
                drugs.Add(temp);
        }
    }
}
