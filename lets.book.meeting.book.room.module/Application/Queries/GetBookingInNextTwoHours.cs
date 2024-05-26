using MediatR;
using meetspace.room.management.module.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lets.book.meeting.book.room.module.Application.Queries
{
    public sealed class GetBookingInNextTwoHours: IRequest<List<BookingRoom>>
    {
        public DateTimeOffset DateNow { get; set; }
    }
}
