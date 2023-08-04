using System;
using System.Collections.Generic;

namespace OnionArchitecture.Persistence
{
    public partial class AppUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public bool? Gender { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool PasswordStatus { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool? Status { get; set; }
    }
}
