﻿using MediatR;
using meetspace.room.management.module.Application.Commands;
using meetspace.room.management.module.Core.Entities;
using meetspace.room.management.module.Infrastructor.Repositories;

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
            var room = new Room { Id = request.Id,
                Description = request.Description,
                Capacity = request.Capacity,
                Name = request.RoomName,
                Location = request.Location };
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
