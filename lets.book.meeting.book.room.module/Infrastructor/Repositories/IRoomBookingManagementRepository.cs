using meetspace.room.management.module.Core.Entities;

namespace meetspace.room.management.module.Infrastructor.Repositories
{
    public interface IRoomBookingManagementRepository
    {
        Task<BookingRoom> CreateBooking(BookingRoom bookingRoom);
        List<BookingRoom> GetBookedByMeetingDuration(DateTimeOffset dateNow, int meetingDuration);
        List<BookingRoom> GetCurrentUserBooking(string userEmail, DateTime from);
    }
}