using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Persistence.EntityConfigurations
{
    public class SpeCodeConfiguration : IEntityTypeConfiguration<SpeCode>
    {
        public void Configure(EntityTypeBuilder<SpeCode> builder)
        {
            builder.Property(e => e.Type).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Code).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Value).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Status).IsRequired().HasMaxLength(50);

            builder.HasData(
                new SpeCode
                {
                    Id = 1,
                    RefId = 1,
                    Type = "All",
                    Code = 1,
                    Value = "Aktiv",
                    OrderBy = 1,
                    Status = true
                },
                new SpeCode
                {
                    Id  = 2,
                    RefId = 2,
                    Type = "All",
                    Code = 2,
                    Value = "Deaktiv",
                    OrderBy = 2,
                    Status = true
                }
            );
        }
    }
}
