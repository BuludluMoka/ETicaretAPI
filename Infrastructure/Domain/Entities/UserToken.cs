using System;
using System.Collections.Generic;

namespace OnionArchitecture.Persistence
{
    public partial class UserToken
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? EndDate { get; set; }
        public int? UserId { get; set; }
        public bool LogOut { get; set; }
        public string? Wer { get; set; }
    }
}
