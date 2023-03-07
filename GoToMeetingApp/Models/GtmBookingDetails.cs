using System;
using System.Collections.Generic;

namespace GoToMeetingApp.Models
{
    public partial class GtmBookingDetails
    {
        public long BookingId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public int? RoomId { get; set; }
        public string ConfirmationStatus { get; set; }
        public string RequestedBy { get; set; }
        public string ApprovedBy { get; set; }
    }
}
