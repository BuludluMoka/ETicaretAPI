using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Core.Entities.SPModels;

namespace OnionArchitecture.Application.Abstractions.Repositories;

public class FileUploadRepository : EntityRepositoryBase<FileUpload, AppDbContext>, IFileUploadRepository
{

    public FileUploadRepository(IMapper mapper) : base(mapper)
    {
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

        var data = EfDbTools.ExecuteProcedure<SP_GetUploadedFilesInfo>("OPR.SP_GetUploadedFilesInfo", parameters);

        return data;
    }

    public ResultInfo Upload(FileUploadDto fileDto)
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

        Mapper.Map<FileUpload>(fileDto, fileUpload);

        return Add(fileUpload).ResultInfo;
    }

    public DownloadedFileResult Download(Guid key)
    {
        var fileUpload = Get(f => f.DownloadKey == key
                                    && f.Status == true);

        if (fileUpload == null)
        {
            return null;
        }

        using var context = new AppDbContext();
        var uploadSetting = context.FileUploadSettings
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

    public ResultInfo Delete(Guid key)
    {
        var fileUpload = Get(f => f.DownloadKey == key
                                  && f.Status == true);

        if (fileUpload == null)
        {
            return ResultInfo.NotFound;
        }

        fileUpload.Status = false;

        return Update(fileUpload).ResultInfo;
    }

    private static bool IsCorrectFileFormat(IFormFile formFile)
    {
        using var context = new AppDbContext();
        return context.FileUploadSettings.Any(
            s => s.Status == true
                && s.ContentType == formFile.ContentType
                 && s.Extension == Path.GetExtension(formFile.FileName)
                 && formFile.Length <= s.SizeInMegabyte * 1024 * 1024);
    }
}