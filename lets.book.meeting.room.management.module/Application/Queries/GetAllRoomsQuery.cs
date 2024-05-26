using MediatR;
using meetspace.room.management.module.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lets.book.meeting.room.management.module.Application.Queries
{
    public class GetAllRoomsQuery: IRequest<List<Room>>
    {
    }
}
