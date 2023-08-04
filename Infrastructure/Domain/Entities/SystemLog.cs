using System;
using System.Collections.Generic;

namespace OnionArchitecture.Persistence
{
    public partial class SystemLog
    {
        public string? Type { get; set; }
        public string? Content { get; set; }
        public string? RequestUrl { get; set; }
        public int? UserId { get; set; }
    }
}
