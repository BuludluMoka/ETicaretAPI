using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SPModels.System
{
    public  class SP_GetContents
    {
        public string Type { get; set; }
        public string PageName { get; set; }
        public string ObjectName { get; set; }
        public string ObjectValue { get; set; }
    }
}
