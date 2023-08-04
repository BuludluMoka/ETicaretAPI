using OnionArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Domain.Entities
{
    public class UserToken : BaseEntity<int>   
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? EndDate { get; set; }
        public int? UserId { get; set; }
        public bool LogOut { get; set; }
    }
}
