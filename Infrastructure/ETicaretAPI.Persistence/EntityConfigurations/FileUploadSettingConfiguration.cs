using DocumentFormat.OpenXml.Vml.Office;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.EntityConfigurations
{
    internal class FileUploadSettingConfiguration : IEntityTypeConfiguration<FileUploadSetting>
    {
        public void Configure(EntityTypeBuilder<FileUploadSetting> builder)
        {
            builder.Property(e => e.ContentType).HasMaxLength(100);

            builder.Property(e => e.CreatedDate).HasColumnType("datetime");

            builder.Property(e => e.Extension).HasMaxLength(10);

            builder.HasData(
            new FileUploadSetting { Id = 1, Extension = ".txt", ContentType = "text/plain", SizeInMegabyte = 10, CreatedDate = DateTime.Now, Status = true },
            new FileUploadSetting { Id = 2, Extension = ".pdf", ContentType = "application/pdf", SizeInMegabyte = 10, CreatedDate = DateTime.Now, Status = true },
            new FileUploadSetting { Id = 3, Extension = ".doc", ContentType = "application/vnd.ms-word", SizeInMegabyte = 10, CreatedDate = DateTime.Now, Status = true },
            new FileUploadSetting { Id = 4, Extension = ".docx", ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document", SizeInMegabyte = 10, CreatedDate = DateTime.Now, Status = true },
            new FileUploadSetting { Id = 5, Extension = ".xls", ContentType = "application/vnd.ms-excel", SizeInMegabyte = 10, CreatedDate = DateTime.Now, Status = true },
            new FileUploadSetting { Id = 6, Extension = ".xlsx", ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", SizeInMegabyte = 10, CreatedDate = DateTime.Now, Status = true },
            new FileUploadSetting { Id = 7, Extension = ".png", ContentType = "image/png", SizeInMegabyte = 10, CreatedDate = DateTime.Now, Status = true },
            new FileUploadSetting { Id = 8, Extension = ".jpg", ContentType = "image/jpeg", SizeInMegabyte = 10, CreatedDate = DateTime.Now, Status = true },
            new FileUploadSetting { Id = 9, Extension = ".jpeg", ContentType = "image/jpeg", SizeInMegabyte = 10, CreatedDate = DateTime.Now, Status = true },
            new FileUploadSetting { Id = 10, Extension = ".gif", ContentType = "image/gif", SizeInMegabyte = 10, CreatedDate = DateTime.Now, Status = true },
            new FileUploadSetting { Id = 11, Extension = ".csv", ContentType = "text/csv", SizeInMegabyte = 10, CreatedDate = DateTime.Now, Status = true }
        );
        }
    }
}
