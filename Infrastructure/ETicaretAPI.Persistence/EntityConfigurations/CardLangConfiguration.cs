using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Persistence.EntityConfigurations
{
    public class CardLangConfiguration : IEntityTypeConfiguration<CardLang>
    {
        public void Configure(EntityTypeBuilder<CardLang> builder)
        {
            builder.Property(e => e.Type).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Value).IsRequired().HasMaxLength(50);
            builder.HasData(
                new CardLang
                {
                    Id = 1,
                    Type = "SpeCode",
                    LangId = 1,
                    CardId = 1,
                    Value = "Aktiv",
                    Status = true
                },
                new CardLang
                {
                    Id = 2,
                    Type = "SpeCode",
                    LangId = 2,
                    CardId = 2,
                    Value = "Deaktiv",
                    Status = true
                }
                );
        }
    }
}
