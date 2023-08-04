using System;
using System.Collections.Generic;

namespace OnionArchitecture.Persistence
{
    public partial class FileUpload
    {
        public string DownloadKey { get; set; } = null!;
        public string? TableName { get; set; }
        public int? TableId { get; set; }
        public short? DocType { get; set; }
        public string? FileName { get; set; }
        public string? Url { get; set; }
        public bool? Status { get; set; }
        public int? CreateUserId { get; set; }
    }
}
