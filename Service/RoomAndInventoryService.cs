// File:    RoomAndInventoryService.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:18:25 PM
// Purpose: Definition of Class RoomAndInventoryService

using Model.Inventory;
using Model.Rooms;
using Repository.Roomsninventory;
using System;
using System.Collections.Generic;

namespace Service
{
    public class RoomAndInventoryService : IRoomAndInventoryService
    {
        public Room AddEquipmentToRoom(Room room, MedEquipmentType eqType, uint number)
        {
            if (number == 0) return room;
            for (uint i = 0; i < number; i++)
                AddMedEquipmentItem(eqType, room);
            return RoomRepository.GetInstance().Read(room.GetId());
        }

        public MedEquipmentItem AddMedEquipmentItem(MedEquipmentType medEquipmentType, Room room)
        {
            medEquipmentType.Number += 1;
            medEquipmentType = MedEquipmentTypeRepository.GetInstance().Update(medEquipmentType);
            MedEquipmentItem mei = MedEquipmentItemRepository.GetInstance().Create(new MedEquipmentItem(medEquipmentType.GetId(), room.GetId(), medEquipmentType));
            ItemCount temp = null;
            foreach(ItemCount ic in room.ItemCount)
                if(mei.TypeId == ic.ItemId)
                {
                    temp = ic;
                    break;
                }
            if (temp == null)
            {
                List<MedEquipmentItem> meiList = new List<MedEquipmentItem>();
                meiList.Add(mei);
                ItemCount ic = ItemCountRepository.GetInstance().Create(new ItemCount(1, medEquipmentType.GetId(), meiList.ToArray()));
                room.ItemCount.Add(ic);
                RoomRepository.GetInstance().Update(room);
            }
            else
            {
                temp.Number += 1;
                ItemCountRepository.GetInstance().Update(temp);
            }
            return mei;
        }

        public MedEquipmentType AddMedEquipmentType(MedEquipmentType medEquipmentType)
        {
            return MedEquipmentTypeRepository.GetInstance().Create(medEquipmentType);
        }

        public Room AddRoom(Room room)
        {
            return RoomRepository.GetInstance().Create(room);
        }

        public bool DeleteMedEquipmentitem(MedEquipmentItem medEquipmentItem)
        {
            return MedEquipmentItemRepository.GetInstance().Delete(medEquipmentItem.GetId());
        }

        public bool DeleteRoom(Room room)
        {
            return RoomRepository.GetInstance().Delete(room.GetId());
        }

        public bool EditRoom(Room room)
        {
            return RoomRepository.GetInstance().Update(room) == null ? false : true;
        }

        public List<MedEquipmentType> GetAllMedEquipmentType()
        {
            return MedEquipmentTypeRepository.GetInstance().GetAll();
        }

        public List<Room> GetAllRooms()
        {
            return RoomRepository.GetInstance().GetAll();
        }

        public List<StationaryRoomPatientsState> GetAllStationaryRoomPatientsState(StationaryRoom stationaryRoom)
        {
            return StationaryRoomPatientsStateRepository.GetInstance().GetAllByRoom(stationaryRoom);
        }

        public bool EditMedEquipmentType(MedEquipmentType medEqType)
        {
            return MedEquipmentTypeRepository.GetInstance().Update(medEqType) == null ? false : true;
        }


        public ItemCount AddItemCount(ItemCount item)
        {
            return ItemCountRepository.GetInstance().Create(item);
        }

        public bool EditItemCount(ItemCount item)
        {
            return ItemCountRepository.GetInstance().Update(item) == null ? false : true;
        }

        public bool DeleteItemCount(ItemCount item)
        {
            return ItemCountRepository.GetInstance().Delete(item.GetId());
        }

        public StationaryRoomPatientsState AddStationaryRoomPatientsState(StationaryRoomPatientsState stat)
        {
            return StationaryRoomPatientsStateRepository.GetInstance().Create(stat);
        }

        public bool EditStationaryRoomPatientsState(StationaryRoomPatientsState stat)
        {
            return StationaryRoomPatientsStateRepository.GetInstance().Update(stat) == null ? false : true;
        }
    }
}