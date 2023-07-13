using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SPModels.System
{
    public class SP_GetMenus
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int? ParentId { get; set; }
        public bool? SubMenuExistStatus { get; set; }
        public short? MenuType { get; set; }
        public string Icon { get; set; }
        public string Link { get; set; }
        public short? OrderBy { get; set; }

    }
}
