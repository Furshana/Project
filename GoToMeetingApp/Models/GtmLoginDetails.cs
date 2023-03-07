using System;
using System.Collections.Generic;

namespace GoToMeetingApp.Models
{
    public partial class GtmLoginDetails
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string LoginPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
    }
}
