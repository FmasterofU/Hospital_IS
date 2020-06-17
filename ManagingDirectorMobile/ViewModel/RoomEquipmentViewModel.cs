using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingDirectorMobile.ViewModel
{
    class RoomEquipmentViewModel
    {
        public String RoomName { get { return "M. oprema u Hirurgija 1"; } }
        public ObservableCollection<object> roomEquipment { get { return null; } }

    }
}
