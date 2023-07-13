using OnionArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Domain.Entities
{
    public class SystemLog : BaseEntity<int>
    {
        public string Type { get; set; }
        public string Content { get; set; }
        public string RequestUrl { get; set; }
        public int? UserId { get; set; }
    }
}
