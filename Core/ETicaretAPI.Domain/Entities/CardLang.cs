using OnionArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Domain.Entities
{
    public class CardLang : BaseEntity<int>  
    {
        public string Type { get; set; }
        public int LangId { get; set; }
        public int CardId { get; set; }
        public string Value { get; set; }
        public bool Status { get; set; }
    }
}
