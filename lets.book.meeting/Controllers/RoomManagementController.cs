using meetspace.room.management.module.Application.DTOs;
using meetspace.room.management.module.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lets.book.meeting.Controllers
{
    [Route("api/roommanagement")]
    [ApiController]
    public class RoomManagementController : ControllerBase
    {
        // GET: api/<RoomManagementController>
        private readonly IRoomManagementService _roomManagementService;

        public RoomManagementController(IRoomManagementService roomManagementService)
        {
            _roomManagementService = roomManagementService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RoomManagementController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RoomManagementController>
        [HttpPost("createroom")]
        public async Task<ActionResult<RoomDetailsDTO>> Post([FromBody] RoomDetailsDTO roomDetailsDTO)
        {
            var claims = User?.Claims?.Select(c => new { c.Type, c.Value }).ToList();
            return await _roomManagementService.CreateRoom(roomDetailsDTO);
        }

        // PUT api/<RoomManagementController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RoomManagementController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
