using lets.book.meeting.book.room.module.Application.DTOs;
using meetspace.room.management.module.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lets.book.meeting.Controllers
{
    [Route("api/")]
    [ApiController]
    public class BookingManagementController : ControllerBase
    {
        private readonly IRoomBookingManagementService _roomBookingManagementService;
        public BookingManagementController(IRoomBookingManagementService roomBookingManagementService)
        {
            _roomBookingManagementService = roomBookingManagementService;
        }
        // GET: api/<BookingManagementController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BookingManagementController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookingManagementController>
        [HttpPost("bookingmanagement")]
        public async Task<ActionResult> Post([FromBody] CreateBookingRequest request)
        {
            var claims = User?.Claims?.Select(c => new { c.Type, c.Value }).ToList();

                try
                {
                    await _roomBookingManagementService.CreateRoom(request, "oussamazazouli@outlook.com");
                    return Ok();
                }
                catch (Exception)
                {

                    return BadRequest();
                }

        }

        // PUT api/<BookingManagementController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingManagementController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
