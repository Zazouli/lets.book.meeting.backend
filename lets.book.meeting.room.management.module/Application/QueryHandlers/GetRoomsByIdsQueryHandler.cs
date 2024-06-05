using lets.book.meeting.room.management.module.Application.Queries;
using MediatR;
using meetspace.room.management.module.Core.Entities;
using meetspace.room.management.module.Infrastructor.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lets.book.meeting.room.management.module.Application.QueryHandlers
{
    public class GetRoomsByIdsQueryHandler : IRequestHandler<GetRoomsByIdsQuery, List<Room>>
    {
        private readonly IRoomManagementRepository _roomManagementRepository;
        public GetRoomsByIdsQueryHandler(IRoomManagementRepository roomManagementRepository)
        {
            _roomManagementRepository = roomManagementRepository;
        }
        public Task<List<Room>> Handle(GetRoomsByIdsQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() => _roomManagementRepository.GetRoomsByIds(request.RoomIds));
        }
    }
}
