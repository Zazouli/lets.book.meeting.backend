using lets.book.meeting.book.room.module.Application.Commands;
using lets.book.meeting.book.room.module.Application.DTOs;
using lets.book.meeting.book.room.module.Application.Queries;
using MediatR;
using meetspace.room.management.module.Application.Commands;
using meetspace.room.management.module.Application.DTOs;
using meetspace.room.management.module.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meetspace.room.management.module.Core.Services
{
    public class RoomBookingManagementService : IRoomBookingManagementService
    {
        private readonly IMediator _mediator;
        public RoomBookingManagementService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> CreateRoom(CreateBookingRequest createBookingRequest, string userEmail)
        {
            var command = new CreateRoomBookingCommand
            {
                Id = Guid.NewGuid().ToString(),
                RoomId = createBookingRequest.RoomId,
                UserEmail = userEmail,
                StartDate = createBookingRequest.StartDate,
                EndDate = createBookingRequest.EndDate,
            };
            return await _mediator.Send(command);
        }

        public async Task<List<BookingRoom>> GetBookedInTheNextTwoHours()
        {
            var request = new GetBookingInNextTwoHours
            {
                DateNow = DateTimeOffset.UtcNow
            };
            return await _mediator.Send(request);
        }
    }
}
