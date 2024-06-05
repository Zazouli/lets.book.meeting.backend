using lets.book.meeting.shared.module.Application.DTOs;
using lets.book.meeting.shared.module.Core.Entities;

namespace lets.book.meeting.shared.module.Core.Services
{
    public interface ISharedService
    {
        Task<List<RoomSummary>> GetAvailableRooms();
        Task<List<RoomSummary>> GetAllRoomSummaries();
        Task<List<RoomSummary>> GetAvailableRoomByDate(DateTime date, int meetingDuration);
        Task<List<BookedByUserDTO>> BookedByCurrentUser(string currentUserEmail);
    }
}