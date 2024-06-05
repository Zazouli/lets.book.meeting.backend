using lets.book.meeting.shared.module.Application.DTOs;
using lets.book.meeting.shared.module.Core.Entities;
using MediatR.NotificationPublishers;
using meetspace.room.management.module.Core.Services;

namespace lets.book.meeting.shared.module.Core.Services
{
    public sealed class SharedService : ISharedService
    {
        private readonly IRoomManagementService _roomManagementService;
        private readonly IRoomBookingManagementService _roomBookingManagementService;

        public SharedService(IRoomManagementService roomManagementService, IRoomBookingManagementService roomBookingManagementService)
        {
            _roomManagementService = roomManagementService;
            _roomBookingManagementService = roomBookingManagementService;
        }

        public async Task<List<RoomSummary>> GetAvailableRooms()
        {
            var rooms = await _roomManagementService.GetAllRooms();
            var bookedInNextTwoHours = await _roomBookingManagementService.GetBookedByMeetingDuration(DateTime.UtcNow);
            var bookedRoomsIds = bookedInNextTwoHours.Select(b => b.RoomId).ToList();
            return rooms.Where(r => !bookedRoomsIds.Contains(r.Id))
                .Select(r => new RoomSummary
                {
                    RoomId = r.Id,
                    RoomDescription = r.Description,
                    Location = r.Location,
                    RoomName = r.Name,
                }).ToList();
        }

        public async Task<List<RoomSummary>> GetAllRoomSummaries()
        {
            var rooms = await _roomManagementService.GetAllRooms();
            return rooms.ConvertAll(r => new RoomSummary
            {
                RoomId = r.Id,
                RoomDescription = r.Description,
                Location = r.Location,
                RoomName = r.Name,
            });
        }

        public async Task<List<RoomSummary>> GetAvailableRoomByDate(DateTime date, int meetingDuration)
        {
            var rooms = await _roomManagementService.GetAllRooms();
            var bookedRooms = await _roomBookingManagementService.GetBookedByMeetingDuration(date, meetingDuration);

            var bookedRoomsIds = bookedRooms.Select(b => b.RoomId).ToList();
            return rooms.Where(r => !bookedRoomsIds.Contains(r.Id))
                .Select(r => new RoomSummary
                {
                    RoomId = r.Id,
                    RoomDescription = r.Description,
                    Location = r.Location,
                    RoomName = r.Name,
                }).ToList();
        }

        public async Task<List<BookedByUserDTO>> BookedByCurrentUser(string currentUserEmail)
        {
            var bookedByUser = await  _roomBookingManagementService.GetCurrentUserBooking(currentUserEmail);
            var bookedRoomIds = bookedByUser.Select(b => b.RoomId).ToList();
            var rooms = await _roomManagementService.GetRoomsByIds(bookedRoomIds);

            return bookedByUser.Select(b =>
            {
                var roomInfo = rooms.FirstOrDefault(r => r.Id == b.RoomId);
                if(roomInfo == null)
                {
                    return null;
                }
                return new BookedByUserDTO(b.Id, roomInfo?.Name, b.StartDate, b.EndDate);
            })
            .Where(b => b != null)
            .ToList();
        }
    }
}
