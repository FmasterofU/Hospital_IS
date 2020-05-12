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

        public class Drug
        {
            public string Name { get; set; }

            public string Code { get; set; }

            public int Number { get; set; }

            public int Threshold { get; set; }

            public string Details { get { return String.Format("šifra: {0}\nminimum: {1}\nbroj: {2}", Code, Threshold, Number); } }
        }

        public ObservableCollection<Drug> drugs { get; set; }

        public DrugsViewModel()
        {
            drugs = new ObservableCollection<Drug>();
            drugs.Add(new Drug() { Name = "Hydroxychloroquine", Code = "AXEL", Number = 69, Threshold = 70 });
            drugs.Add(new Drug() { Name = "Antiretroviral", Code = "FROG", Number = 70, Threshold = 69 });
        }
        
    }
}
