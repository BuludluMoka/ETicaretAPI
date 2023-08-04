using Microsoft.AspNetCore.Http;
using OnionArchitecture.Application.Utilities.Mapper;
using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.DTOs.FileUploads
{
    public class FileUploadDto : IMapTo<FileUpload>
    {
        public string BasePath { get; set; }

        public string TableName { get; set; }

        public int? TableId { get; set; }

        public short? DocType { get; set; }

        public IFormFile FormFile { get; set; }
    }
}
