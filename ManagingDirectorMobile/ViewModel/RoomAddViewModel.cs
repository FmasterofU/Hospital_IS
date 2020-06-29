using Controller;
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
            c.AddRoom(new Room((RoomType)selectedIndex, text, new List<ItemCount>()));
        }
    }
}
