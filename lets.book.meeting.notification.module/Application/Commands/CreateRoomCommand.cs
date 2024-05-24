using MediatR;
using meetspace.room.management.module.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meetspace.room.management.module.Application.Commands
{
    public class CreateRoomCommand: IRequest<bool>
    {
        public Guid Id { get; set; }
        public string RoomName { get; set; }
        public int Capacity { get; set; }
        public Location Location { get; set; }
    }
}
