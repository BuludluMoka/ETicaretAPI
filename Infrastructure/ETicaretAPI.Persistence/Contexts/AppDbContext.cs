using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnionArchitecture.Application.Abstractions.DB;
using OnionArchitecture.Application.Enums;
using OnionArchitecture.Application.Utilities.Settings;
using OnionArchitecture.Domain.Entities;
using System.Reflection;

namespace OnionArchitecture.Persistence.Contexts
{
    public class AppDbContext : DbContext, IApplicationDbContext
    {
        public AppDbContext(){}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<AppUser> AppUsers { get ; set ; }
        public DbSet<UserToken> UserTokens { get ; set ; }
        public DbSet<Language> Languages { get ; set ; }
        public DbSet<SpeCode> SpeCodes { get ; set ; }
        public DbSet<CardLang> CardLangs { get ; set ; }
        public DbSet<Message> Messages { get ; set ; }
        public DbSet<MessageLang> MessageLangs { get ; set ; }
        public DbSet<FileUploadSetting> FileUploadSettings { get ; set ; }
        public DbSet<SystemLog> SystemLogs { get ; set ; }
        public DbSet<Product> Products { get ; set ; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AppSettings.GetSetting(SettingOptions.ConnectionStrings, "SqlServerConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
          
            modelBuilder.Entity<FileUpload>(entity =>
            {

                entity.Property(e => e.DownloadKey).HasMaxLength(50);

                entity.Property(e => e.FileName).HasMaxLength(255);

                entity.Property(e => e.TableName).HasMaxLength(50);

                entity.Property(e => e.Url).HasMaxLength(500);
            });

            modelBuilder.Entity<SystemLog>(entity =>
            {
                entity.Property(e => e.RequestUrl).HasMaxLength(500);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            #region SP,FN Functinality
            var DomainAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a =>a.GetName().Name == "OnionArchitecture.Domain"); 
            var spTypes = DomainAssembly.GetTypes()
              .Where(t => t.Name.StartsWith("SP_")
                          || t.Name.StartsWith("FN_"))
              .ToHashSet();

            var orderedTypes = new List<Type>();

            while (spTypes.Count > 0)
            {
                foreach (var spType in spTypes)
                {
                    var isParentClass = spTypes.Any(spTypeInner => spTypeInner.IsSubclassOf(spType));

                    if (isParentClass)
                    {
                        continue;
                    }

                    orderedTypes.Add(spType);
                    spTypes.Remove(spType);
                }
            }

            foreach (var spType in orderedTypes)
            {
                modelBuilder.Entity(spType).HasNoKey();
            }
            #endregion

            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        SetCreatedAuditProperties(entry);
                        break;
                    case EntityState.Modified:
                        SetModifiedAuditProperties(entry);
                        break;

                }
            }
            return base.SaveChanges();

        }


        private void SetDateAndUserValuesToEntity(EntityEntry entry,
            string datePropertyName,
            string userIdPropertyName)
        {
            var dateProperty = entry.Entity.GetType().GetProperty(datePropertyName);
            var userIdProperty = entry.Entity.GetType().GetProperty(userIdPropertyName);

            if (dateProperty != null)
            {
                dateProperty.SetValue(entry.Entity, DateTime.Now);
            }

            if (userIdProperty != null)
            {
                userIdProperty.SetValue(entry.Entity, CurrentScopeDataContainer.Instance.UserId);
            }
        }


        private void SetCreatedAuditProperties(EntityEntry entry)
        {
            SetDateAndUserValuesToEntity(entry, "CreatedDate", "CreatedUserId");
        }


        private void SetModifiedAuditProperties(EntityEntry entry)
        {

            SetDateAndUserValuesToEntity(entry, "ModifiedDate", "ModifiedUserId");
        }

    }
}
