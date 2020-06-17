using ManagingDirectorMobile.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingDirectorMobile.ViewModel
{
    class RemovalViewModel
    {
        public String RemovalQuestion { get; set; }

        private IRemoveSelection rem;

        public RemovalViewModel(String diffString, IRemoveSelection removalobject)
        {
            RemovalQuestion = "Da li ste sigurni da želite da uklonite " + diffString + "?";
            rem = removalobject;
        }

        public void Remove()
        {
            rem.RemoveSelectedItem();
        }
    }
}
