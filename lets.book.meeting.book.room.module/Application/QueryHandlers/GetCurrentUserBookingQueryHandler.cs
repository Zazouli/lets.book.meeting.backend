using lets.book.meeting.book.room.module.Application.Queries;
using MediatR;
using meetspace.room.management.module.Core.Entities;
using meetspace.room.management.module.Infrastructor.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lets.book.meeting.book.room.module.Application.QueryHandlers
{
    public class GetCurrentUserBookingQueryHandler : IRequestHandler<GetCurrentUserBookingQuery, List<BookingRoom>>
    {
        private readonly IRoomBookingManagementRepository _roomBookingManagementRepository;

        public GetCurrentUserBookingQueryHandler(IRoomBookingManagementRepository roomBookingManagementRepository)
        {
            _roomBookingManagementRepository = roomBookingManagementRepository;
        }
        public async Task<List<BookingRoom>> Handle(GetCurrentUserBookingQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _roomBookingManagementRepository.GetCurrentUserBooking(request.UserEmail, DateTime.UtcNow.AddDays(-30)));
        }
    }
}
