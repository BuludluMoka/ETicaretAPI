using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Persistence.Contexts
{
    public partial class AppDbContextBase : DbContext
    {
        public AppDbContextBase()
        {
        }

        public AppDbContextBase(DbContextOptions<AppDbContextBase> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<SystemLog> SystemLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=192.168.168.193;Database=DB_TNBUDGET;User Id=budget;Password=@uni3589a43r!@@@;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");

                
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers", "OBJ");

                entity.Property(e => e.CreatedDate)
                  .HasColumnType("datetime")
                  .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<SystemLog>(entity =>
            {
                entity.ToTable("SystemLogs");

                entity.Property(e => e.Content).HasColumnType("ntext");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RequestUrl)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}


//modelBuilder.Entity<City>(entity =>
//{
//    entity.ToTable("Cities", "CRD");

//    entity.Property(e => e.Name).HasMaxLength(50);

//    entity.Property(e => e.Status)
//        .IsRequired()
//        .HasDefaultValueSql("((1))");
//});

//modelBuilder.Entity<Clause>(entity =>
//{
//    entity.ToTable("Clauses", "OPR");

//    entity.Property(e => e.Code)
//        .HasMaxLength(50)
//        .IsUnicode(false)
//        .HasComment("Madde kodu");

//    entity.Property(e => e.CreatedDate)
//        .HasColumnType("datetime")
//        .HasDefaultValueSql("(getdate())");

//    entity.Property(e => e.LevelGroup).HasComment("1,2,3,4 seviyye");

//    entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

//    entity.Property(e => e.Name)
//        .HasMaxLength(250)
//        .HasComment("Madde adi");

//    entity.Property(e => e.Status)
//        .IsRequired()
//        .HasDefaultValueSql("((1))");
//});

//modelBuilder.Entity<Contract>(entity =>
//{
//    entity.ToTable("Contracts", "OPR");

//    entity.Property(e => e.BeginDate).HasColumnType("date");

//    entity.Property(e => e.ContractNo)
//        .HasMaxLength(50)
//        .IsUnicode(false);

//    entity.Property(e => e.CreatedDate)
//        .HasColumnType("datetime")
//        .HasDefaultValueSql("(getdate())");

//    entity.Property(e => e.Date).HasColumnType("date");

//    entity.Property(e => e.EndDate).HasColumnType("date");

//    entity.Property(e => e.IsActive)
//        .IsRequired()
//        .HasDefaultValueSql("((1))");

//    entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

//    entity.Property(e => e.ParentId).HasComment("Elaqeli muqavile id");

//    entity.Property(e => e.Status)
//        .IsRequired()
//        .HasDefaultValueSql("((1))");

//    entity.Property(e => e.StatusId).HasComment("Aktiv/Deaktiv");
//});

//modelBuilder.Entity<ContractDetail>(entity =>
//{
//    entity.ToTable("ContractDetails", "OPR");

//    entity.Property(e => e.AmountWithVat).HasComment("EDV daxil qiymet");

//    entity.Property(e => e.ContractAmount).HasComment("Muqavile meblegi");

//    entity.Property(e => e.CreatedDate)
//        .HasColumnType("datetime")
//        .HasDefaultValueSql("(getdate())");

//    entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

//    entity.Property(e => e.Status)
//        .IsRequired()
//        .HasDefaultValueSql("((1))");

//    entity.Property(e => e.VatIncluded).HasComment("edv daxildir");
//});

//modelBuilder.Entity<ContractDetailItem>(entity =>
//{
//    entity.ToTable("ContractDetailItems", "OPR");

//    entity.Property(e => e.AmountWithVat).HasComment("EDV daxil qiymet");

//    entity.Property(e => e.CreatedDate)
//        .HasColumnType("datetime")
//        .HasDefaultValueSql("(getdate())");

//    entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

//    entity.Property(e => e.Name)
//        .HasMaxLength(250)
//        .HasComment("Ish ve xidmet adi");

//    entity.Property(e => e.Price).HasComment("Vahidin qiymeti");

//    entity.Property(e => e.Status)
//        .IsRequired()
//    .HasDefaultValueSql("((1))");

//    entity.Property(e => e.UnitId).HasComment("Olcu vahidi");

//    entity.Property(e => e.VatIncluded).HasComment("edv daxildir");
//});

//modelBuilder.Entity<Country>(entity =>
//{
//    entity.ToTable("Countries", "CRD");

//    entity.Property(e => e.Code)
//        .HasMaxLength(6)
//        .IsUnicode(false);

//    entity.Property(e => e.Name).HasMaxLength(50);

//    entity.Property(e => e.Region).HasMaxLength(50);

//    entity.Property(e => e.Status)
//        .IsRequired()
//        .HasDefaultValueSql("((1))");
//});

//modelBuilder.Entity<EducationalFacility>(entity =>
//{
//    entity.ToTable("EducationalFacilities", "CRD");

//    entity.Property(e => e.Code).HasMaxLength(50);

//    entity.Property(e => e.CreatedDate)
//        .HasColumnType("datetime")
//        .HasDefaultValueSql("(getdate())");

//    entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

//    entity.Property(e => e.Name).HasMaxLength(450);

//    entity.Property(e => e.Status)
//        .IsRequired()
//        .HasDefaultValueSql("((1))");
//});

//modelBuilder.Entity<FileUpload>(entity =>
//{
//    entity.ToTable("FileUploads", "OPR");

//    entity.HasIndex(e => e.DownloadKey, "UK_FileUploads_DownloadKey")
//        .IsUnique();

//    entity.Property(e => e.CreateDate)
//        .HasColumnType("datetime")
//        .HasDefaultValueSql("(getdate())");

//    entity.Property(e => e.DownloadKey).HasDefaultValueSql("(newid())");

//    entity.Property(e => e.FileName).HasMaxLength(50);

//    entity.Property(e => e.Status)
//        .HasDefaultValueSql("((1))")
//        .HasComment("");

//    entity.Property(e => e.TableName)
//        .HasMaxLength(50)
//        .IsUnicode(false)
//        .HasComment("Table Name");

//    entity.Property(e => e.Url).HasMaxLength(255);
//});

//modelBuilder.Entity<FileUploadSetting>(entity =>
//{
//    entity.ToTable("FileUploadSettings", "OBJ");

//    entity.Property(e => e.ContentType)
//        .IsRequired()
//        .HasMaxLength(250)
//        .IsUnicode(false);

//    entity.Property(e => e.CreateDate)
//        .HasColumnType("datetime")
//        .HasDefaultValueSql("(getdate())");

//    entity.Property(e => e.Extension)
//        .IsRequired()
//        .HasMaxLength(10)
//        .IsUnicode(false);

//    entity.Property(e => e.SizeInMegabyte).HasDefaultValueSql("((10))");

//    entity.Property(e => e.Status)
//        .IsRequired()
//        .HasDefaultValueSql("((1))");
//});

//modelBuilder.Entity<FinancialOrder>(entity =>
//{
//    entity.ToTable("FinancialOrders", "OPR");

//    entity.Property(e => e.Id).HasComment("Maliyye sifarishi ");

//    entity.Property(e => e.AdvanceValue).HasComment("Avans==true ? %");

//    entity.Property(e => e.AllocatedAmount).HasComment("Acilan mebleg");

//    entity.Property(e => e.ContractNo).HasMaxLength(100);

//    entity.Property(e => e.CreatedDate)
//        .HasColumnType("datetime")
//        .HasDefaultValueSql("(getdate())");

//    entity.Property(e => e.Date).HasColumnType("date");

//    entity.Property(e => e.DateForAllocate).HasColumnType("datetime");

//    entity.Property(e => e.DocNo)
//        .HasMaxLength(50)
//        .IsUnicode(false);

//    entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

//    entity.Property(e => e.ModifiedReason)
//        .HasMaxLength(350)
//        .HasComment("Avans olmadığı halda akt və akt sənədi daxil edilməlidir\n\nAvans olduğu halda avans faizi qeyd edilməlidir (max 30 ola biler)");

//    entity.Property(e => e.NoteForAllocate).HasMaxLength(350);

//    entity.Property(e => e.PurchaseMethodId).HasComment("satinalma metodu");

//    entity.Property(e => e.Status)
//        .IsRequired()
//        .HasDefaultValueSql("((1))");

//    entity.Property(e => e.StatusId).HasComment("1-Qaralama,2-Tesdiq");
//});

//modelBuilder.Entity<FinancialOrderDetail>(entity =>
//{
//    entity.ToTable("FinancialOrderDetails", "OPR");

//    entity.Property(e => e.AmountWithVat).HasComment("EDV daxil qiymet");

//    entity.Property(e => e.ContractAmount).HasComment("Muqavile meblegi");

//    entity.Property(e => e.CreatedDate)
//        .HasColumnType("datetime")
//        .HasDefaultValueSql("(getdate())");

//    entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

//    entity.Property(e => e.Status)
//        .IsRequired()
//        .HasDefaultValueSql("((1))");

//    entity.Property(e => e.VatIncluded).HasComment("edv daxildir");
//});

//modelBuilder.Entity<IntegrationInfo>(entity =>
//{
//    entity.ToTable("IntegrationInfo", "OBJ");

//    entity.Property(e => e.Description).HasMaxLength(150);

//    entity.Property(e => e.Name).HasMaxLength(100);

//    entity.Property(e => e.Password).HasMaxLength(100);

//    entity.Property(e => e.ProcedureName)
//        .HasMaxLength(100)
//        .IsUnicode(false);

//    entity.Property(e => e.Status)
//        .IsRequired()
//        .HasDefaultValueSql("((1))");

//    entity.Property(e => e.Username).HasMaxLength(100);
//});

//modelBuilder.Entity<Language>(entity =>
//{
//    entity.ToTable("Languages", "OBJ");

//    entity.Property(e => e.Name).HasMaxLength(50);

//    entity.Property(e => e.ShortName).HasMaxLength(50);

//    entity.Property(e => e.Status).HasDefaultValueSql("((1))");
//});

//modelBuilder.Entity<Menu>(entity =>
//{
//    entity.ToTable("Menus", "OBJ");

//    entity.Property(e => e.Defination).HasMaxLength(50);

//    entity.Property(e => e.Icon)
//        .HasMaxLength(50)
//        .IsUnicode(false);

//    entity.Property(e => e.Link)
//        .HasMaxLength(50)
//        .IsUnicode(false);

//    entity.Property(e => e.MenuType)
//        .HasDefaultValueSql("((0))")
//        .HasComment("0-esas menu, 1-alt, 2-1in alt menusu");

//    entity.Property(e => e.Orderby).HasDefaultValueSql("((0))");

//    entity.Property(e => e.Status).HasDefaultValueSql("((1))");
//});

//modelBuilder.Entity<MenuInfo>(entity =>
//{
//    entity.ToTable("MenuInfo", "OBJ");

//    entity.Property(e => e.Description).HasMaxLength(250);

//    entity.Property(e => e.KeyfieldName)
//        .HasMaxLength(50)
//        .HasComment("QueryString ile gelen parametr adi");

//    entity.Property(e => e.PageName).HasMaxLength(350);

//    entity.Property(e => e.Status)
//        .IsRequired()
//        .HasDefaultValueSql("((1))");
//});

//modelBuilder.Entity<MenuLang>(entity =>
//{
//    entity.ToTable("MenuLangs", "OBJ");

//    entity.Property(e => e.Status).HasDefaultValueSql("((1))");

//    entity.Property(e => e.Value).HasMaxLength(50);
//});

//modelBuilder.Entity<Message>(entity =>
//{
//    entity.ToTable("Messages", "OBJ");

//    entity.Property(e => e.Definition).HasMaxLength(250);

//    entity.Property(e => e.Note).HasMaxLength(250);

//    entity.Property(e => e.Status).HasDefaultValueSql("((1))");
//});

//modelBuilder.Entity<MessageLang>(entity =>
//{
//    entity.ToTable("MessageLangs", "OBJ");

//    entity.Property(e => e.Status).HasDefaultValueSql("((1))");

//    entity.Property(e => e.Value).HasMaxLength(250);
//});

//modelBuilder.Entity<Module>(entity =>
//{
//    entity.ToTable("Modules", "OBJ");

//    entity.Property(e => e.Code)
//        .HasMaxLength(10)
//        .IsUnicode(false);

//    entity.Property(e => e.Color)
//        .HasMaxLength(50)
//        .IsUnicode(false);

//    entity.Property(e => e.Icon)
//        .HasMaxLength(50)
//        .IsUnicode(false);

//    entity.Property(e => e.Status).HasDefaultValueSql("((1))");

//    entity.Property(e => e.Url)
//        .HasMaxLength(250)
//        .IsUnicode(false);

//    entity.Property(e => e.Value).HasMaxLength(50);
//});

//modelBuilder.Entity<ModuleLang>(entity =>
//{
//    entity.ToTable("ModuleLangs", "OBJ");

//    entity.Property(e => e.Status).HasDefaultValueSql("((1))");

//    entity.Property(e => e.Value).HasMaxLength(50);
//});

//modelBuilder.Entity<ObjectContent>(entity =>
//{
//    entity.ToTable("ObjectContents", "OBJ");

//    entity.Property(e => e.Name)
//        .HasMaxLength(150)
//        .IsUnicode(false);

//    entity.Property(e => e.PageName)
//        .HasMaxLength(150)
//        .IsUnicode(false);

//    entity.Property(e => e.Status).HasDefaultValueSql("((1))");

//    entity.Property(e => e.Type)
//        .HasMaxLength(10)
//        .IsUnicode(false);
//});

//modelBuilder.Entity<ObjectContentsLang>(entity =>
//{
//    entity.ToTable("ObjectContentsLang", "OBJ");

//    entity.Property(e => e.Status).HasDefaultValueSql("((1))");

//    entity.Property(e => e.Value).HasMaxLength(250);
//});

//modelBuilder.Entity<OperationBlock>(entity =>
//{
//    entity.ToTable("OperationBlock", "OBJ");

//    entity.Property(e => e.Date).HasColumnType("datetime");

//    entity.Property(e => e.Name).HasMaxLength(250);

//    entity.Property(e => e.Status).HasDefaultValueSql("((1))");

//    entity.Property(e => e.Type)
//        .HasMaxLength(20)
//        .IsUnicode(false);
//});

//modelBuilder.Entity<Payment>(entity =>
//{
//    entity.ToTable("Payments", "OPR");

//    entity.Property(e => e.ActId).HasComment("Avans secende(Vendorlara bagli olan->Actlar siyahisi gelecek)");

//    entity.Property(e => e.CreatedDate)
//        .HasColumnType("datetime")
//        .HasDefaultValueSql("(getdate())");

//    entity.Property(e => e.Date).HasColumnType("date");

//    entity.Property(e => e.DocNo)
//        .HasMaxLength(50)
//        .IsUnicode(false);

//    entity.Property(e => e.FinancialOrderId).HasComment("Autocomp");

//    entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

//    entity.Property(e => e.Status)
//        .IsRequired()
//        .HasDefaultValueSql("((1))");
//});

//modelBuilder.Entity<PaymentDetail>(entity =>
//{
//    entity.ToTable("PaymentDetails", "OPR");

//    entity.Property(e => e.Amount).HasComment("Muqavile meblegi");

//    entity.Property(e => e.CreatedDate)
//        .HasColumnType("datetime")
//        .HasDefaultValueSql("(getdate())");

//    entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

//    entity.Property(e => e.Status)
//        .IsRequired()
//        .HasDefaultValueSql("((1))");
//});

//modelBuilder.Entity<Prediction>(entity =>
//{
//    entity.ToTable("Predictions", "OPR");

//    entity.Property(e => e.AllocatedAmount).HasComment("Ayrilan mebleg");

//    entity.Property(e => e.ClauseId).HasComment("Madde");

//    entity.Property(e => e.CreatedDate)
//        .HasColumnType("datetime")
//        .HasDefaultValueSql("(getdate())");

//    entity.Property(e => e.Date).HasColumnType("date");

//    entity.Property(e => e.Description)
//        .IsRequired()
//        .HasMaxLength(250)
//        .HasComment("Qisa mezmun");

//    entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

//    entity.Property(e => e.OfferNumber)
//        .HasMaxLength(50)
//        .IsUnicode(false);

//    entity.Property(e => e.RequiredAmount).HasComment("Teleb edilen mebleg");

//    entity.Property(e => e.Status)
//        .IsRequired()
//        .HasDefaultValueSql("((1))");

//    entity.Property(e => e.StatusId).HasComment("Gozlemede, Tesdiq");

//    entity.Property(e => e.Type).HasComment("1-Proqnoz/Budce,  2-Proqnoz");

//    entity.Property(e => e.Year).HasComment("Budce ili");
//});

//modelBuilder.Entity<PredictionDetail>(entity =>
//{
//    entity.ToTable("PredictionDetails", "OPR");

//    entity.Property(e => e.Amount).HasComment("Muqavile meblegi");

//    entity.Property(e => e.CreatedDate)
//        .HasColumnType("datetime")
//        .HasDefaultValueSql("(getdate())");

//    entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

//    entity.Property(e => e.Status)
//        .IsRequired()
//        .HasDefaultValueSql("((1))");
//});

//modelBuilder.Entity<Role>(entity =>
//{
//    entity.ToTable("Roles", "OBJ");

//    entity.Property(e => e.Code)
//        .HasMaxLength(10)
//        .IsUnicode(false);

//    entity.Property(e => e.Name).HasMaxLength(50);

//    entity.Property(e => e.Status).HasDefaultValueSql("((1))");
//});

//modelBuilder.Entity<RoleMenu>(entity =>
//{
//    entity.ToTable("RoleMenus", "OBJ");

//    entity.Property(e => e.Status).HasDefaultValueSql("((1))");
//});

//modelBuilder.Entity<SpeCode>(entity =>
//{
//    entity.ToTable("SpeCode", "OBJ");

//    entity.HasIndex(e => new { e.Type, e.RefId }, "UK_SpeCode_TypeRefId")
//        .IsUnique();

//    entity.Property(e => e.Code)
//        .HasMaxLength(10)
//        .IsUnicode(false);

//    entity.Property(e => e.Status).HasDefaultValueSql("((1))");

//    entity.Property(e => e.Type)
//        .HasMaxLength(100)
//        .IsUnicode(false);

//    entity.Property(e => e.Value).HasMaxLength(200);
//});

//modelBuilder.Entity<SystemLog>(entity =>
//{
//    entity.ToTable("SystemLogs", "LOG");

//    entity.Property(e => e.Content).HasColumnType("ntext");

//    entity.Property(e => e.CreateDate)
//        .HasColumnType("datetime")
//        .HasDefaultValueSql("(getdate())");

//    entity.Property(e => e.RequestUrl)
//        .HasMaxLength(250)
//        .IsUnicode(false);

//    entity.Property(e => e.Type)
//        .HasMaxLength(10)
//        .IsUnicode(false);
//});

//modelBuilder.Entity<User>(entity =>
//{
//    entity.ToTable("Users", "OBJ");

//    entity.Property(e => e.Birthday).HasColumnType("date");

//    entity.Property(e => e.CreateDate)
//        .HasColumnType("datetime")
//        .HasDefaultValueSql("(getdate())");

//    entity.Property(e => e.Email)
//        .HasMaxLength(150)
//        .IsUnicode(false);

//    entity.Property(e => e.FinCode).HasMaxLength(50);

//    entity.Property(e => e.FirstName).HasMaxLength(50);

//    entity.Property(e => e.LastName).HasMaxLength(50);

//    entity.Property(e => e.Password).HasMaxLength(250);

//    entity.Property(e => e.Phone1)
//        .HasMaxLength(150)
//        .IsUnicode(false);

//    entity.Property(e => e.Phone2)
//        .HasMaxLength(150)
//        .IsUnicode(false);

//    entity.Property(e => e.Status)
//        .IsRequired()
//        .HasDefaultValueSql("((1))");

//    entity.Property(e => e.Username)
//        .IsRequired()
//        .HasMaxLength(50);
//});

//modelBuilder.Entity<UserLoginHistory>(entity =>
//{
//    entity.ToTable("UserLoginHistories", "OBJ");

//    entity.Property(e => e.LoginDate)
//        .HasColumnType("datetime")
//        .HasDefaultValueSql("(getdate())");
//});

//modelBuilder.Entity<UserPassword>(entity =>
//{
//    entity.ToTable("UserPasswords", "OBJ");

//    entity.Property(e => e.Date).HasColumnType("datetime");

//    entity.Property(e => e.Password).HasMaxLength(250);

//    entity.Property(e => e.Status)
//        .IsRequired()
//        .HasDefaultValueSql("((1))");
//});

//modelBuilder.Entity<UserRole>(entity =>
//{
//    entity.ToTable("UserRoles", "OBJ");

//    entity.Property(e => e.Expdate)
//        .HasColumnType("datetime")
//        .HasDefaultValueSql("('2099-01-01 00:00:00.000')");

//    entity.Property(e => e.Status).HasDefaultValueSql("((1))");
//});

//modelBuilder.Entity<UserToken>(entity =>
//{
//    entity.ToTable("UserTokens", "OBJ");

//    entity.Property(e => e.AccessToken)
//        .HasMaxLength(800)
//        .IsUnicode(false);

//    entity.Property(e => e.EndDate)
//        .HasColumnType("datetime")
//        .HasComment("AccessToken endate");

//    entity.Property(e => e.RefreshToken)
//        .HasMaxLength(800)
//        .IsUnicode(false);
//});

//modelBuilder.Entity<VCity>(entity =>
//{
//    entity.HasNoKey();

//    entity.ToView("V_Cities", "CRD");

//    entity.Property(e => e.Lang).HasMaxLength(50);

//    entity.Property(e => e.Value).HasMaxLength(250);
//});

//modelBuilder.Entity<VCountry>(entity =>
//{
//    entity.HasNoKey();

//    entity.ToView("V_Countries", "CRD");

//    entity.Property(e => e.Id).ValueGeneratedOnAdd();

//    entity.Property(e => e.Value).HasMaxLength(50);
//});

//modelBuilder.Entity<VSpeCode>(entity =>
//{
//    entity.HasNoKey();

//    entity.ToView("V_SpeCode", "OBJ");

//    entity.Property(e => e.KeyType)
//        .HasMaxLength(100)
//        .IsUnicode(false);

//    entity.Property(e => e.Lang).HasMaxLength(50);

//    entity.Property(e => e.Value).HasMaxLength(250);
//});

//modelBuilder.Entity<Vendor>(entity =>
//{
//    entity.ToTable("Vendors", "OPR");

//    entity.Property(e => e.BankCode).HasMaxLength(350);

//    entity.Property(e => e.BankFullName).HasMaxLength(350);

//    entity.Property(e => e.BankShortName).HasMaxLength(250);

//    entity.Property(e => e.BankTin)
//        .HasMaxLength(250)
//        .HasColumnName("BankTIN");

//    entity.Property(e => e.Code)
//        .HasMaxLength(50)
//        .IsUnicode(false);

//    entity.Property(e => e.CreatedDate)
//        .HasColumnType("datetime")
//        .HasDefaultValueSql("(getdate())");

//    entity.Property(e => e.Email).HasMaxLength(250);

//    entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

//    entity.Property(e => e.Name).HasMaxLength(250);

//    entity.Property(e => e.PhoneNumber)
//        .HasMaxLength(150)
//        .IsUnicode(false);

//    entity.Property(e => e.PostAddress).HasMaxLength(250);

//    entity.Property(e => e.ResponsiblePerson).HasMaxLength(250);

//    entity.Property(e => e.Status)
//        .IsRequired()
//        .HasDefaultValueSql("((1))");

//    entity.Property(e => e.Swift).HasMaxLength(250);

//    entity.Property(e => e.Tin)
//        .HasMaxLength(50)
//        .IsUnicode(false)
//        .HasColumnName("TIN")
//        .HasComment("VOEN");

//    entity.Property(e => e.TypeId).HasComment("Huquqi/Fiziki shexs");
//});

//modelBuilder.Entity<VendorBankDetail>(entity =>
//{
//    entity.ToTable("VendorBankDetails", "OPR");

//    entity.Property(e => e.AccountNo).HasMaxLength(550);

//    entity.Property(e => e.CreatedDate)
//        .HasColumnType("datetime")
//        .HasDefaultValueSql("(getdate())");

//    entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

//    entity.Property(e => e.Status)
//        .IsRequired()
//        .HasDefaultValueSql("((1))");
//});