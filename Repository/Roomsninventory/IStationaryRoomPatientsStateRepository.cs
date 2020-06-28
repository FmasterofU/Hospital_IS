// File:    IStationaryRoomPatientsStateRepository.cs
// Author:  fmaster
// Created: Sunday, May 31, 2020 11:08:29 AM
// Purpose: Definition of Interface IStationaryRoomPatientsStateRepository

using Model.Rooms;
using System.Collections.Generic;

namespace Repository.Roomsninventory
{
    public interface IStationaryRoomPatientsStateRepository : Repository.IRepositoryCRUD<StationaryRoomPatientsState, uint>
    {
        List<StationaryRoomPatientsState> GetAllByRoom(Model.Rooms.StationaryRoom room);

    }
}