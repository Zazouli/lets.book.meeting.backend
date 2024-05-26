using lets.book.meeting.shared.module.Core.Entities;
using meetspace.room.management.module.Core.Services;

namespace lets.book.meeting.shared.module.Core.Services
{
    public sealed class AvailableRoomService : IAvailableRoomService
    {
        private readonly IRoomManagementService _roomManagementService;
        private readonly IRoomBookingManagementService _roomBookingManagementService;

        public AvailableRoomService(IRoomManagementService roomManagementService, IRoomBookingManagementService roomBookingManagementService)
        {
            _roomManagementService = roomManagementService;
            _roomBookingManagementService = roomBookingManagementService;
        }

        public async Task<List<RoomSummary>> GetAvailableRooms()
        {
            var rooms = await _roomManagementService.GetAllRooms();
            var bookedInNextTwoHours = await _roomBookingManagementService.GetBookedInTheNextTwoHours();
            var bookedRoomsIds = bookedInNextTwoHours.Select(b => b.RoomId).ToList();
            return rooms.Where(r => !bookedRoomsIds.Contains(r.Id))
                .Select(r => new RoomSummary
                {
                    RoomId = r.Id,
                    Location = r.Location,
                    RoomName = r.Name,
                }).ToList();
        }
    }
}
