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
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<SpeCode>  SpeCodes { get; set; }
        public DbSet<CardLang>  CardLangs { get; set; }
        public DbSet<Message>  Messages { get; set; }
        public DbSet<MessageLang>  MessageLangs { get; set; }
        public DbSet<FileUploadSetting> FileUploadSettings { get; set; }
        public DbSet<SystemLog> SystemLogs { get; set; }
        public DbSet<Product> Products { get; set; }

        // Added method to get a DbSet of a certain type
        public DbSet<T> Set<T>() where T : class;
    }


}
