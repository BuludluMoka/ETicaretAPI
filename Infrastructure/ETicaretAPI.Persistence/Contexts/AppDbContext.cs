using Core.Application.Utilities.Settings;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.Contexts
{
    public class AppDbContext : AppDbContextBase
    {
        public AppDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(AppSettings.Settings.AppDbConnectionModel.ToString());
            }
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var spTypes = Assembly
                .GetExecutingAssembly()
                .GetTypes()
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
