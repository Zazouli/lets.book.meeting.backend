using meetspace.room.management.module.Application.DTOs;

namespace meetspace.room.management.module.Core.Services
{
    public interface IRoomManagementService
    {
        Task<bool> CreateRoom(RoomDetailsDTO roomDetailsDTO);
    }
}