using System;
using System.Collections.Generic;

namespace GoToMeetingApp.Models
{
    public partial class GtmAdminDetails
    {
        public int RoomAdminId { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public string VerificationStatus { get; set; }
        public bool IsActive { get; internal set; }
    }
}
