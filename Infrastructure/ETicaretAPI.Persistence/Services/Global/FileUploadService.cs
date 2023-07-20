using AutoMapper;
using Core.Application.Utilities.Results;
using Core.Entities.SPModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Application.Abstractions.DB.Tools;
using OnionArchitecture.Application.Abstractions.Services.Global;
using OnionArchitecture.Application.DTOs.FileUploads;
using OnionArchitecture.Application.Repositories.FileUploadRepo;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.Services.Global
{
    public class FileUploadService : IFileUploadService
    {
        private readonly AppDbContext _Dbcontext;
        private readonly IMapper _mapper;
        private readonly IEFDatabaseTool _eFDatabase;
        private readonly IFileReadRepository _fileReadRepository;
        private readonly IFileWriteRepository _fileWriteRepository;

        public FileUploadService(AppDbContext context,IMapper mapper, IEFDatabaseTool eFDatabase, IFileReadRepository fileReadRepository, IFileWriteRepository fileWriteRepository) 
        {
            _Dbcontext = context;
            _mapper = mapper;
            _eFDatabase = eFDatabase;
            _fileReadRepository = fileReadRepository;
            _fileWriteRepository = fileWriteRepository;
        }
        private static string BasePath => "..\\Core\\Uploads";

        public IList<SP_GetUploadedFilesInfo> GetUploadedFilesInfo(
            string tableName,
            int id,
            short? documentType = null)
        {
            var parameters = new List<SqlParameter>
        {
            new("tableName", tableName),
            new("id", id)
        };


            if (documentType.HasValue)
            {
                parameters.Add(new SqlParameter("docType", documentType.Value));
            }

            var data = _eFDatabase.ExecuteProcedure<SP_GetUploadedFilesInfo>("OPR.SP_GetUploadedFilesInfo", parameters);

            return data;
        }

        public async Task<ResultInfo> Upload(FileUploadDto fileDto)
        {
            if (fileDto.FormFile == null
                || !IsCorrectFileFormat(fileDto.FormFile))
            {
                return ResultInfo.SaveFailure;
            }

            var directoryPath = Path.Combine(BasePath, fileDto.BasePath);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var fileName = Guid.NewGuid()
                           + Path.GetExtension(fileDto.FormFile.FileName);
            var filePath = Path.Combine(directoryPath, fileName);
            using var fs = new FileStream(filePath, FileMode.Create);
            fileDto.FormFile.CopyTo(fs);

            var fileUpload = new FileUpload
            {
                FileName = fileDto.FormFile.FileName,
                Url = filePath,
                CreateUserId = CurrentScopeDataContainer.Instance.UserId
            };

            _mapper.Map<FileUpload>(fileUpload, fileDto);
            await _fileWriteRepository.AddAsync(fileUpload);
            var affectedRows = await _fileWriteRepository.SaveAsync();
            var result = affectedRows > 0 ? ResultInfo.SaveSuccess : ResultInfo.SaveFailure;

            return result;
        }

        public async Task<DownloadedFileResult> Download(Guid key)
        {
            var fileUpload =   await _fileReadRepository.GetSingleAsync(f => f.DownloadKey == key
                                        && f.Status == true);

            if (fileUpload == null)
            {
                return null;
            }

            var uploadSetting = _Dbcontext.FileUploadSettings
                .FirstOrDefault(s =>
                    s.Extension == Path.GetExtension(fileUpload.FileName)
                        && s.Status == true);

            if (uploadSetting == null)
            {
                return null;
            }

            var result = new DownloadedFileResult
            {
                Content = File.ReadAllBytes(fileUpload.Url),
                ContentType = uploadSetting.ContentType,
                FileName = fileUpload.FileName
            };

            return result;
        }

        public async Task<ResultInfo> Delete(Guid key)
        {
            var fileUpload = await _fileReadRepository.GetSingleAsync(f => f.DownloadKey == key
                                      && f.Status == true);

            if (fileUpload == null)
            {
                return ResultInfo.NotFound;
            }

            fileUpload.Status = false;

             _fileWriteRepository.Update(fileUpload);
            var affectedRows = await _fileWriteRepository.SaveAsync();
            var result = affectedRows > 0 ? ResultInfo.Deleted : ResultInfo.SaveFailure;
            return result;
        }

        private bool IsCorrectFileFormat(IFormFile formFile)
        {
            return _Dbcontext.FileUploadSettings.Any(
                s => s.Status == true
                    && s.ContentType == formFile.ContentType
                     && s.Extension == Path.GetExtension(formFile.FileName)
                     && formFile.Length <= s.SizeInMegabyte * 1024 * 1024);
        }
    }
}
