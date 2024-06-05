using lets.book.meeting.room.management.module.Application.Queries;
using MediatR;
using meetspace.room.management.module.Application.Commands;
using meetspace.room.management.module.Application.DTOs;
using meetspace.room.management.module.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meetspace.room.management.module.Core.Services
{
    public class RoomManagementService : IRoomManagementService
    {
        private readonly IMediator _mediator;
        public RoomManagementService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<RoomDetailsDTO> CreateRoom(RoomDetailsDTO roomDetailsDTO)
        {
            // the location will be taken from the admin location
            var command = new CreateRoomCommand
            {
                Id = Guid.NewGuid().ToString(),
                RoomName = roomDetailsDTO.Name,
                Capacity = roomDetailsDTO.Capacity,
                Description = roomDetailsDTO.Description,
                Location = "Aarhus",
            };
            var room =  await _mediator.Send(command);
            return new RoomDetailsDTO
            {
                Id = room.Id,
                Name = room.Name,
                Capacity = roomDetailsDTO.Capacity,
                Description = roomDetailsDTO.Description,
                Location = room.Location
            };
        }

        public async Task<List<Room>> GetAllRooms()
        {
            var query = new GetAllRoomsQuery();
            return await _mediator.Send(query);
        }

        public async Task<List<Room>> GetRoomsByIds(List<string> roomIds)
        {
            var query = new GetRoomsByIdsQuery
            {
                RoomIds = roomIds
            };

            return await _mediator.Send(query);
        }
    }
}
