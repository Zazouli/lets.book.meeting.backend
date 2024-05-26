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
        private readonly IAvailableRoomService _availableRoomService;

        public SharedController(IAvailableRoomService availableRoomService)
        {
            _availableRoomService = availableRoomService;
        }

        [HttpGet("availablerooms")]
        [Authorize]
        public async Task<IEnumerable<RoomSummary>> Get()
        {
            var claims = User?.Claims?.Select(c => new { c.Type, c.Value }).ToList();
            return await _availableRoomService.GetAvailableRooms();
        }
    }
}
