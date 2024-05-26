using MediatR;
using meetspace.room.management.module.Application.DTOs;
using meetspace.room.management.module.Application.Queries;
using meetspace.room.management.module.Infrastructor.Repositories;

namespace meetspace.room.management.module.Application.QueryHandlers
{
    public class GetRoomDetailsQueryHandler : IRequestHandler<GetRoomDetailsQuery, RoomDetailsDTO>
    {
        private readonly IRoomManagementRepository _roomManagementRepository;
        public GetRoomDetailsQueryHandler(IRoomManagementRepository roomManagementRepository)
        {
            _roomManagementRepository = roomManagementRepository;
        }
        public Task<RoomDetailsDTO> Handle(GetRoomDetailsQuery request, CancellationToken cancellationToken)
        {
            // Get the room from the database
            var room = _roomManagementRepository.GetById(request.RoomId);
            if(room is null)
            {
                return default;
            }
            return Task.Run(() => new RoomDetailsDTO
            {
                Id = room.Id,
                Name = room.Name,
                Location = room.Location,
                Capacity = room.Capacity,
            });
        }
    }
}
