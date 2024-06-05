using lets.book.meeting.book.room.module.Application.Commands;
using MediatR;
using meetspace.room.management.module.Application.Commands;
using meetspace.room.management.module.Core.Entities;
using meetspace.room.management.module.Infrastructor.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace meetspace.room.management.module.Application.CommandHandlers
{
    public class CreateRoomBookingCommandHandler : IRequestHandler<CreateRoomBookingCommand, bool>
    {
        private readonly IRoomBookingManagementRepository _roomBookingManagementRepository;
        public CreateRoomBookingCommandHandler(IRoomBookingManagementRepository roomBookingManagementRepository)
        {
            _roomBookingManagementRepository = roomBookingManagementRepository;
        }
        public async Task<bool> Handle(CreateRoomBookingCommand request, CancellationToken cancellationToken)
        {
            var roomBooking = new BookingRoom { Id = Guid.NewGuid().ToString(), RoomId = request.RoomId, EndDate = request.EndDate, StartDate = request.StartDate, UserEmail = request.UserEmail };
            // Add the room 
            var roomBookingSaved = await _roomBookingManagementRepository.CreateBooking(roomBooking);
            if (roomBookingSaved != null)
            {

                return true;
            }
            return false;
        }
    }
}
