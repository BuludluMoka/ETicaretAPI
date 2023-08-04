using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.EntityConfigurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {

            builder.Property(e => e.Name).HasMaxLength(100);

            builder.Property(e => e.ShortName).HasMaxLength(50);


            builder.HasData(
                new Language()
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Name = "Azerbaycan",
                    ShortName = "AZ",
                    Status = true
                },
                new Language()
                {
                    Id = 2,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Name = "English",
                    ShortName = "EN",
                    Status = true
                }
                );

        }
    }
}
