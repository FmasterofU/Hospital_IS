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
        private static Controller.IRoomAndInventoryController c = new RoomAndInventoryController();
        public ObservableCollection<Room> rooms { get; set; }
        public RoomsViewModel()
        {
            rooms = new ObservableCollection<Room>();
            List<Room> r = c.GetAllRooms();
            foreach (Room room in r)
                rooms.Add(room);
        }

        internal void Search(string text = null)
        {
            rooms = new ObservableCollection<Room>();
            List<Room> r = c.GetAllRooms();
            if (text == null || text.Equals(""))
                foreach (Room room in r)
                    rooms.Add(room);
            else
                foreach (Room room in r)
                    if (room.Name.Contains(text))
                        rooms.Add(room);
        }
    }
}
