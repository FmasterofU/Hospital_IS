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

        public RemovalViewModel(String diffString)
        {
            RemovalQuestion = "Da li ste sigurni da želite da uklonite " + diffString + "?";
        }
    }
}
