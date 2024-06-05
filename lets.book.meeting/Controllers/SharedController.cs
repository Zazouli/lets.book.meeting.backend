using lets.book.meeting.shared.module.Application.DTOs;
using lets.book.meeting.shared.module.Core.Entities;
using lets.book.meeting.shared.module.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lets.book.meeting.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SharedController : ControllerBase
    {
        private readonly ISharedService _sharedService;

        public SharedController(ISharedService sharedService)
        {
            _sharedService = sharedService;
        }

        [HttpGet("availablerooms")]
        [Authorize]
        public async Task<IEnumerable<RoomSummary>> Get()
        {
            var claims = User?.Claims?.Select(c => new { c.Type, c.Value }).ToList();
            return await _sharedService.GetAvailableRooms();
        }


        [HttpGet("getallsummaries")]
        [Authorize]
        public async Task<IEnumerable<RoomSummary>> GetAll()
        {
            var claims = User?.Claims?.Select(c => new { c.Type, c.Value }).ToList();
            return await _sharedService.GetAllRoomSummaries();
        }

        [HttpGet("searchroombydate")]
        [Authorize]
        public async Task<IEnumerable<RoomSummary>> GetRoomsByCondition([FromQuery] DateTime date, [FromQuery] int meetingDuration)
        {
            var claims = User?.Claims?.Select(c => new { c.Type, c.Value }).ToList();
            return await _sharedService.GetAvailableRoomByDate(date, meetingDuration);
        }

        [HttpGet("bookedbyuser")]
        [Authorize]
        public async Task<IEnumerable<BookedByUserDTO>> GetBookedByUser()
        {
            var claims = User?.Claims?.Select(c => new { c.Type, c.Value }).ToList();
            var email = claims?.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
            return await _sharedService.BookedByCurrentUser(email);
        }
    }
}
