using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Presentation;
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
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(e => e.Birthday).HasColumnType("datetime");

            builder.Property(e => e.Email).HasMaxLength(100);

            builder.Property(e => e.FirstName).HasMaxLength(50);

            builder.Property(e => e.LastName).HasMaxLength(50);

            builder.Property(e => e.Password).HasMaxLength(255);

            builder.Property(e => e.Phone).HasMaxLength(20);

            builder.Property(e => e.Username).HasMaxLength(50);

            builder.HasData(
                new AppUser()
                {
                    Id = 1,
                    FirstName = "Moka",
                    LastName = "Buludlu",
                    Email = "BuludluMoka@gmail.com",
                    Birthday = DateTime.Parse("09/12/1996"),
                    Password = "Moka",
                    PasswordStatus = true,
                    Phone = "0502420288",
                    Status = true,
                    Username = "Moka",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Gender = true
                }
                );
        }
    }
}
