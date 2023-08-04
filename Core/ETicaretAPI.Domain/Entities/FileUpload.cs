using OnionArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Domain.Entities
{
    public class FileUpload : BaseEntity<int>
    {
        public Guid DownloadKey { get; set; }
        public string TableName { get; set; }
        public int? TableId { get; set; }
        public short? DocType { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
        public bool? Status { get; set; }
        public int? CreateUserId { get; set; }
    }
}
