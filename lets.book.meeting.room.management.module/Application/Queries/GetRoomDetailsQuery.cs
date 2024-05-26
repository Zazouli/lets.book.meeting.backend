using MediatR;
using meetspace.room.management.module.Application.DTOs;

namespace meetspace.room.management.module.Application.Queries
{
    public class GetRoomDetailsQuery: IRequest<RoomDetailsDTO>
    {
        public string RoomId { get; set; }
    }
}
