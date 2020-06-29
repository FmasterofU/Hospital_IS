using Controller;
using Model.Roles;
using Model.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingDirectorMobile.ViewModel
{
    class RoomAddViewModel
    {
        private static Controller.IRoomAndInventoryController c = new RoomAndInventoryController();

        internal static void Add(string text, int selectedIndex)
        {
            if(selectedIndex == (int)RoomType.stationary)
            {
                StationaryRoomPatientsState stat = new StationaryRoomPatientsState(DateTime.Now, 0, 0);
                stat = c.AddStationaryRoomPatientsState(stat);
                StationaryRoom r = c.AddRoom(new StationaryRoom((RoomType)selectedIndex, text, new List<ItemCount>(), 0, new List<Patient>(), stat)) as StationaryRoom;
                stat.RoomId = r.GetId();
                c.EditStationaryRoomPatientsState(stat);
                
                    return;
            }
            c.AddRoom(new Room((RoomType)selectedIndex, text, new List<ItemCount>()));
        }
    }
}
