using OnionArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Domain.Entities
{
    public class Message : BaseEntity<int>
    {
        public short Code { get; set; }
        public string Definition { get; set; }
        public string Note { get; set; }
        public bool Status { get; set; }

    }
}
