using OnionArchitecture.Application.Abstractions.Repositories;
using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Application.Repositories.FileUploadRepo
{
    public interface IFileWriteRepository : IWriteRepository<FileUpload, int>
    {
    }
}
