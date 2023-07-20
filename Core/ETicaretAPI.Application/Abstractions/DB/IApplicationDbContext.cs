using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Abstractions.DB
{
    public interface IApplicationDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<SystemLog> SystemLogs { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<FileUploadSetting> FileUploadSettings { get; set; }
    }
}
