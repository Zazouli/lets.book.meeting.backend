using lets.book.meeting.shared.module.Core.Entities;

namespace lets.book.meeting.shared.module.Core.Services
{
    public interface IAvailableRoomService
    {
        Task<List<RoomSummary>> GetAvailableRooms();
    }
}