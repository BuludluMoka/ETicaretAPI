using System;
using System.Collections.Generic;

namespace OnionArchitecture.Persistence
{
    public partial class FileUploadSetting
    {
        public string? Extension { get; set; }
        public string? ContentType { get; set; }
        public int SizeInMegabyte { get; set; }
        public DateTime CreateDate { get; set; }
        public bool? Status { get; set; }
    }
}
