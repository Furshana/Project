using GoToMeetingApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GoToMeetingApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GtmMeetingRoomDetailsController : ControllerBase
    {
        
        private readonly Gotomeeting_dbContext _Context;
        public GtmMeetingRoomDetailsController(Gotomeeting_dbContext Context)
        {
            _Context = Context;
        }
        [HttpGet("GetRoomId")]
        public List<GtmMeetingRoomDetails> GetRoomId()
        {
            List<GtmMeetingRoomDetails> RoomId = _Context.GtmMeetingRoomDetails.ToList();
            return RoomId;
        }
    }
}
