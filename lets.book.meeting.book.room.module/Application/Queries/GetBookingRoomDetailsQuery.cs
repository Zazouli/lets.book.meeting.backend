using MediatR;
using meetspace.room.management.module.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meetspace.room.management.module.Application.Queries
{
    public class GetBookingRoomDetailsQuery: IRequest<BookingRoomDetailsDTO>
    {
        public string Id { get; set; }
        public string RoomId { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}
