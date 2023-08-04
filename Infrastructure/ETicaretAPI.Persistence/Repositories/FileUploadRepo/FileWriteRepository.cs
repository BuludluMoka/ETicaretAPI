using OnionArchitecture.Application.Repositories;
using OnionArchitecture.Application.Repositories.FileUploadRepo;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.Repositories.FileUploadRepo
{
    public class FileWriteRepository : WriteRepository<FileUpload, int, AppDbContext>, IFileWriteRepository
    {
        public FileWriteRepository(AppDbContext context) : base(context)
        {

        }
    }
}
