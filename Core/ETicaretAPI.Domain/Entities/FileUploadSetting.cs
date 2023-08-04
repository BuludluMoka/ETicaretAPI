using OnionArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Domain.Entities
{
    public class FileUploadSetting : BaseEntity<int>    
    {
        public string Extension { get; set; }
        public string ContentType { get; set; }
        public int SizeInMegabyte { get; set; }
        public bool? Status { get; set; }
    }
}
