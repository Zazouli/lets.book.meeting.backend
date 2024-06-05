using meetspace.room.management.module.Core.Entities;

namespace meetspace.room.management.module.Infrastructor.Repositories
{
    public interface IRoomManagementRepository
    {
        Task<Room> CreateRoom(Room room);
        List<Room> GetAll();
        Room? GetById(string roomId);
        List<Room> GetRoomsByIds(List<string> roomIds);
    }
}