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
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, bool>
    {
        private readonly IRoomManagementRepository _roomManagementRepository;
        public CreateRoomCommandHandler(IRoomManagementRepository roomManagementRepository)
        {
            _roomManagementRepository = roomManagementRepository;
        }
        public async Task<bool> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = new Room { Id = Guid.NewGuid().ToString(), Location = "Aarhus", Capacity = 5, Name = "Random" };
            // Add the room 
            var roomSaved = await _roomManagementRepository.CreateRoom(room);
            if (roomSaved != null)
            {

                return true;
            }
            return false;
        }
    }
}
