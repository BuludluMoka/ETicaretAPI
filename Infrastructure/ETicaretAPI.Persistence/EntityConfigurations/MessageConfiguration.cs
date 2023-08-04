using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Persistence.EntityConfigurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {

            builder.HasData(

               new Message { Id = 1, Code = 1000, Definition = "SaveSuccess", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 3, Code = 1001, Definition = "Deleted", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 2, Code = 4000, Definition = "SaveFailure", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 5, Code = 4001, Definition = "BlockedOperation", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 6, Code = 4002, Definition = "NotApproved", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 4, Code = 4004, Definition = "NotFound", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 7, Code = 4005, Definition = "AlreadyApproved", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 8, Code = 4006, Definition = "DataConflict", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 9, Code = 4007, Definition = "AlreadyExists", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 10, Code = 4008, Definition = "CannotBeChanged", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 11, Code = 4009, Definition = "FillRequiredFields", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 12, Code = 4010, Definition = "UnexpectedError", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 13, Code = 4011, Definition = "InvalidRequestParameters", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 14, Code = 4012, Definition = "RateLimitReached", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 15, Code = 4013, Definition = "UserNamePasswordIncorrect", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 16, Code = 4014, Definition = "TokenExpired", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 17, Code = 4015, Definition = "TokenIsInvalid", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 18, Code = 4016, Definition = "Unauthorized", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 19, Code = 4017, Definition = "ConfirmPasswordError", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 20, Code = 4018, Definition = "UserNotActive", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 21, Code = 4019, Definition = "UserNameAlreadyExists", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 22, Code = 4020, Definition = "EmailAlreadyExists", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 23, Code = 4021, Definition = "AccountLocked", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 24, Code = 4022, Definition = "PasswordValidation", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 25, Code = 4023, Definition = "OldPasswordError", Note = "", CreatedDate = DateTime.Now, Status = true },
               new Message { Id = 26, Code = 5000, Definition = "InternalServerError", Note = "", CreatedDate = DateTime.Now, Status = true }

             


         );
        }
    }
}
