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
        public string DrugName { get { return "Hydroxychloroquine"; }}
        public string DrugQuantity { get { return "69"; } }
        public string DrugMinimumFormString { get { return "minimum(70):"; } }
        public ObservableCollection<object> drugBatches = null;
        public string EXPDate { get { return "22.07.1998."; } }
    }
}
