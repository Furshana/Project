using GoToMeetingApp.Models;
using log4net.Repository.Hierarchy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoToMeetingApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GtmBookingDetailsController : ControllerBase
    {
        private readonly Gotomeeting_dbContext context;
        private readonly ILogger<GtmBookingDetailsController> _logger;
        public GtmBookingDetailsController(ILogger<GtmBookingDetailsController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<GtmBookingDetails> Get()
        {
            return context.GtmBookingDetails.ToList();
        }
        [HttpGet("{BookingId}")]
        public GtmBookingDetails Get(int BookingId)
        {
            return context.GtmBookingDetails.FirstOrDefault(o => o.BookingId == BookingId);
        }
        [HttpPost("AddBookingDetails")]
        public IActionResult AddGtmBookingDetails([FromBody] GtmBookingDetails gtmBookingDetails)
        {
            string result = string.Empty;
            try
            {
                var _bookingDetails = context.GtmBookingDetails.FirstOrDefault(o => o.BookingId == gtmBookingDetails.BookingId);
                if (_bookingDetails != null)
                {
                    _bookingDetails.BookingId = gtmBookingDetails.BookingId;
                    _bookingDetails.FirstName = gtmBookingDetails.FirstName;
                    _bookingDetails.LastName = gtmBookingDetails.LastName;
                    _bookingDetails.StartAt = gtmBookingDetails.StartAt;
                    _bookingDetails.EndAt = gtmBookingDetails.EndAt;
                    _bookingDetails.RoomId = gtmBookingDetails.RoomId;
                    _bookingDetails.ConfirmationStatus = gtmBookingDetails.ConfirmationStatus;
                    _bookingDetails.RequestedBy = gtmBookingDetails.RequestedBy;
                    _bookingDetails.ApprovedBy = gtmBookingDetails.ApprovedBy;
                    context.SaveChanges();
                    _logger.LogInformation("BookingDetails added Successfully.");
                    return Created("BookingDetails added", gtmBookingDetails);

                }
                else
                {
                    GtmBookingDetails bookingDetails = new GtmBookingDetails()
                    {
                        BookingId = gtmBookingDetails.BookingId,
                        FirstName = gtmBookingDetails.FirstName,
                        LastName = gtmBookingDetails.LastName,
                        StartAt = gtmBookingDetails.StartAt,
                        EndAt = gtmBookingDetails.EndAt,
                        RoomId = gtmBookingDetails.RoomId,
                        ConfirmationStatus = gtmBookingDetails.ConfirmationStatus,
                        RequestedBy = gtmBookingDetails.RequestedBy,
                        ApprovedBy = gtmBookingDetails.ApprovedBy
                    };
                    context.GtmBookingDetails.Add(gtmBookingDetails);
                    context.SaveChanges();
                    _logger.LogInformation("Booking Details created Successfully.");
                    return Created("Booking Details created", gtmBookingDetails);
                }

            }
            catch (Exception ex)
            {
                _logger.LogWarning("Contact To Admin..Server Error" + ex.Message);
                return StatusCode(500, "Internal Server Error");
            }

        }
    }
}
        
       

   