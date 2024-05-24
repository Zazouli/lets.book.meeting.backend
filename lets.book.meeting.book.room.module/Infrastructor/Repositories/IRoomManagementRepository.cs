using meetspace.room.management.module.Core.Entities;

namespace meetspace.room.management.module.Infrastructor.Repositories
{
    public interface IRoomManagementRepository
    {
        Task<Room> CreateRoom(Room room);
    }
}