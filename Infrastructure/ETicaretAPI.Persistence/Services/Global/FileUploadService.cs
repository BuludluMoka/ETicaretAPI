using AutoMapper;
using Domain.SPModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using OnionArchitecture.Application.Abstractions.DB.Tools;
using OnionArchitecture.Application.Abstractions.Services.Global;
using OnionArchitecture.Application.Abstractions.Storage;
using OnionArchitecture.Application.DTOs.FileUploads;
using OnionArchitecture.Application.Repositories.FileUploadRepo;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Persistence.Contexts;

namespace OnionArchitecture.Persistence.Services.Global
{
    public class FileUploadService : IFileUploadService
    {
        private readonly AppDbContext _Dbcontext;
        private readonly IMapper _mapper;
        private readonly IEFDatabaseTool _eFDatabase;
        private readonly IFileReadRepository _fileReadRepository;
        private readonly IFileWriteRepository _fileWriteRepository;
        private readonly IStorageService _storageService;

        public FileUploadService(AppDbContext context,
            IMapper mapper,
            IEFDatabaseTool eFDatabase,
            IFileReadRepository fileReadRepository,
            IFileWriteRepository fileWriteRepository,
            IStorageService storageService)
        {
            _Dbcontext = context;
            _mapper = mapper;
            _eFDatabase = eFDatabase;
            _fileReadRepository = fileReadRepository;
            _fileWriteRepository = fileWriteRepository;
            _storageService = storageService;
        }


        public async Task<ResultInfo> UploadAsync(IList<FileUploadDto> fileUploadDtos)
        {
            foreach (var fileUpload in fileUploadDtos)
            {
                if (fileUpload.FormFile == null || !IsCorrectFileFormat(fileUpload.FormFile))
                {
                    return ResultInfo.FileFormatIncorrect;
                }
            }

            foreach (var file in fileUploadDtos)
            {
                var UploadedFile = await _storageService.UploadAsync(file.FormFile, file.TableName);
                var fileUpload = new FileUpload
                {
                    FileName = UploadedFile.fileName,
                    Url = UploadedFile.pathOrContainerName,
                    CreateUserId = CurrentScopeDataContainer.Instance.UserId
                };
                _mapper.Map<FileUpload>(fileUploadDtos, fileUpload);
                await _fileWriteRepository.AddAsync(fileUpload);
            }
            var affectedRows = await _fileWriteRepository.SaveAsync();
            var result = affectedRows > 0 ? ResultInfo.SaveSuccess : ResultInfo.SaveFailure;

            return result;
        }

        public async Task<DownloadedFileResult> Download(Guid key)
        {
            var fileUpload = await _fileReadRepository.GetSingleAsync(f => f.DownloadKey == key
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
        public IList<SP_GetUploadedFilesInfo> GetUploadedFilesInfo(string tableName, int id, short? documentType = null)
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

        private bool IsCorrectFileFormat(IFormFile formFile)
        {
            return _Dbcontext.FileUploadSettings.Any(
             s => s.Status == true
                 && s.ContentType == formFile.ContentType
                  && s.Extension == Path.GetExtension(formFile.FileName)
                  && formFile.Length <= s.SizeInMegabyte * 1024 * 1024);
        }
        public IList<FileUploadDto> GenerateFileUploadDto(IFormFileCollection formFiles, int id, string TableName)
        {
            if (formFiles.Count < 0 && id < 0 && string.IsNullOrEmpty(TableName)) return null;
            var result = new List<FileUploadDto>();
            foreach (var item in formFiles)
            {
                result.Add(new FileUploadDto()
                {
                    TableId = id,
                    TableName = TableName,
                    BasePath = TableName,
                    FormFile = item
                });
            }
            return result;
        }
    }
}
