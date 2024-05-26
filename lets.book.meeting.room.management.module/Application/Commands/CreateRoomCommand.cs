using MediatR;
using meetspace.room.management.module.Core.Entities;

namespace meetspace.room.management.module.Application.Commands
{
    public class CreateRoomCommand: IRequest<bool>
    {
        public string Id { get; set; }
        public string RoomName { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
    }
}
