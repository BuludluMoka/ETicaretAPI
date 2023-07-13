using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SPModels.System
{
    public class SP_GetUserRolesByUserId
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool AssignStatus { get; set; }
    }
}
