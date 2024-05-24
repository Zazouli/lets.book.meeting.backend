using MediatR;
using meetspace.room.management.module.Application.DTOs;
using meetspace.room.management.module.Application.Queries;

namespace meetspace.room.management.module.Application.QueryHandlers
{
    public class GetRoomDetailsQueryHandler : IRequestHandler<GetRoomDetailsQuery, RoomDetailsDTO>
    {
        public GetRoomDetailsQueryHandler()
        {
            
        }
        public Task<RoomDetailsDTO> Handle(GetRoomDetailsQuery request, CancellationToken cancellationToken)
        {
            // Get the room from the database
            return Task.Run(() => new RoomDetailsDTO());
        }
    }
}
