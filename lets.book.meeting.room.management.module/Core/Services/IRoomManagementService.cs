using meetspace.room.management.module.Application.DTOs;
using meetspace.room.management.module.Core.Entities;

namespace meetspace.room.management.module.Core.Services
{
    public interface IRoomManagementService
    {
        Task<RoomDetailsDTO> CreateRoom(RoomDetailsDTO roomDetailsDTO);
        Task<List<Room>> GetAllRooms();
        Task<List<Room>> GetRoomsByIds(List<string> roomIds);
    }
}