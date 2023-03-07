using GoToMeetingApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System;

namespace GoToMeetingApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GtmAdminDetailsController : ControllerBase
    {
        private readonly Gotomeeting_dbContext _context;
        private readonly ILogger<GtmAdminDetails> logger;

        public GtmAdminDetailsController(Gotomeeting_dbContext context, ILogger<GtmAdminDetails> logger)
        {
            this._context = context;
            this.logger = logger;
        }
        [HttpPost("AddAdmin")]
        public IActionResult AddAdmin([FromBody] GtmAdminDetails gtmAdminDetails)
        {
            try
            {
                _context.GtmAdminDetails.Add(gtmAdminDetails);
                _context.SaveChanges();
                logger.LogInformation("AdminId added Successfully.");
                return Created("AdminId added", gtmAdminDetails);
            }
            catch (NullReferenceException ex)
            {
                logger.LogWarning("Data not found" + ex.Message);
                return StatusCode(404, "Data Not Found");

            }
            catch (Exception ex)
            {
                logger.LogWarning("Contact To Admin..Server Error" + ex.Message);
                return StatusCode(500, "Internal Server Error");
            }

        }

        [HttpGet("GetAdmin")]
        public IActionResult GetAdmin()
        {
            try
            {
                List<GtmAdminDetails> Admins = _context.GtmAdminDetails.ToList();
                if (Admins.Count() != 0)
                {
                    logger.LogInformation("Admins details are listed");
                    return StatusCode(200, Admins.Where(status => status.IsActive == true).Count());

                }
                else
                {
                    logger.LogInformation("No RoomAdminId is not available");
                    return StatusCode(404, "No Admin data are available");
                }
            }
            catch (Exception ex)
            {
                logger.LogWarning("Contact To Admin..Server Error" + ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
