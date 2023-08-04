using Domain.SPModels;
using OnionArchitecture.Application.DTOs.FileUploads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Abstractions.Services.Global
{
    public interface IFileUploadService
    {
        IList<SP_GetUploadedFilesInfo> GetUploadedFilesInfo(string tableName, int id, short? documentType = null);
        Task<ResultInfo> UploadAsync(IList<FileUploadDto> fileUploadDtos);
        Task<DownloadedFileResult> Download(Guid key);
        Task<ResultInfo> Delete(Guid key);
    }
}
