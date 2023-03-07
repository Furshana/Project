using System;
using System.Collections.Generic;

namespace GoToMeetingApp.Models
{
    public partial class GtmMeetingRoomDetails
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? RoomId { get; set; }
        public long? Capacity { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Password { get; set; }
    }
}
