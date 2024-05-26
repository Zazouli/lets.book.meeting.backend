using lets.book.meeting.book.room.module.Application.DTOs;
using meetspace.room.management.module.Core.Entities;

namespace meetspace.room.management.module.Core.Services
{
    public interface IRoomBookingManagementService
    {
        Task<bool> CreateRoom(CreateBookingRequest createBookingRequest, string userEmail);
        Task<List<BookingRoom>> GetBookedInTheNextTwoHours();
    }
}