using System;
using System.Collections.Generic;

namespace GoToMeetingApp.Models
{
    public partial class GtmRegisterDetails
    {
        public int RoomId { get; set; }
        public string FullName { get; set; }
        public string OrganizationName { get; set; }
        public string CategoryName { get; set; }
        public long? PhoneNumber { get; set; }
        public string MeetingType { get; set; }
        public int? ExistSpace { get; set; }
        public int? AvailableSpace { get; set; }
    }
}
