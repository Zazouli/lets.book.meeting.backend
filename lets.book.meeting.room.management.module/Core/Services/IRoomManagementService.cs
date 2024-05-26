using meetspace.room.management.module.Application.DTOs;
using meetspace.room.management.module.Core.Entities;

namespace meetspace.room.management.module.Core.Services
{
    public interface IRoomManagementService
    {
        Task<bool> CreateRoom(RoomDetailsDTO roomDetailsDTO);
        Task<List<Room>> GetAllRooms();
    }
}