﻿using lets.book.meeting.book.room.module.Application.Queries;
using MediatR;
using meetspace.room.management.module.Core.Entities;
using meetspace.room.management.module.Infrastructor.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lets.book.meeting.book.room.module.Application.QueryHandlers
{
    internal class GetBookingInNextTwoHoursQueryHandler : IRequestHandler<GetBookingByMeetingDurationQuery, List<BookingRoom>>
    {
        private readonly IRoomBookingManagementRepository _roomBookingManagementRepository;

        public GetBookingInNextTwoHoursQueryHandler(IRoomBookingManagementRepository roomBookingManagementRepository)
        {
            _roomBookingManagementRepository = roomBookingManagementRepository;
        }

        public Task<List<BookingRoom>> Handle(GetBookingByMeetingDurationQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() => _roomBookingManagementRepository.GetBookedByMeetingDuration(request.DateNow, request.MeetingDuration));
        }
    }
}
