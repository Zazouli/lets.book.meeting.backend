﻿using meetspace.room.management.module.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meetspace.room.management.module.Application.DTOs
{
    public class BookingRoomDetailsDTO
    {
        public string Id { get; set; }
        public string RoomId { get; set; }
        public string UserEmail { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}
