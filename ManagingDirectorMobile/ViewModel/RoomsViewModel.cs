using Controller;
using Model.Rooms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingDirectorMobile.ViewModel
{
    class RoomsViewModel
    {
        private static Controller.IDrugController c = new DrugController();
        public ObservableCollection<Room> rooms { get; set; }
        public RoomsViewModel()
        {
            
        }
    }
}
