using MediatR;
using meetspace.room.management.module.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meetspace.room.management.module.Application.Queries
{
    public class GetRoomDetailsQuery: IRequest<RoomDetailsDTO>
    {
        public Guid RoomId { get; set; }
    }
}
