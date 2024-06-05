using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lets.book.meeting.shared.module.Application.DTOs
{
    public sealed record BookedByUserDTO(string BookingId, string RoomName, DateTime StartDate, DateTime EndDate);
}
