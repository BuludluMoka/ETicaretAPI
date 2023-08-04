using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Persistence.EntityConfigurations
{
    public class MessageLangConfiguration : IEntityTypeConfiguration<MessageLang>
    {
        public void Configure(EntityTypeBuilder<MessageLang> builder)
        {
            builder.HasData(
                new MessageLang { Id = 1, MessageId = 1, LangId = 1, Value = "Yadda saxlanıldı.", CreatedDate = DateTime.Now ,Status = true },
                new MessageLang { Id = 2, MessageId = 2, LangId = 1, Value = "Silindi", CreatedDate = DateTime.Now ,Status = true },
                new MessageLang { Id = 3, MessageId = 3, LangId = 1, Value = "Yadda saxlanılarkən xəta baş verdi.", CreatedDate = DateTime.Now, Status = true },
                new MessageLang { Id = 4, MessageId = 4, LangId = 1, Value = "Qadağan olunmuş əməliyyat", CreatedDate = DateTime.Now, Status = true },
                new MessageLang { Id = 5, MessageId = 5, LangId = 1, Value = "Təsdiq olunmayıb", CreatedDate = DateTime.Now, Status = true },
                new MessageLang { Id = 6, MessageId = 6, LangId = 1, Value = "Məlumat tapılmadı.", CreatedDate = DateTime.Now, Status = true },
                new MessageLang { Id = 7, MessageId = 7, LangId = 1, Value = "Artıq təsdiqlənib.", CreatedDate = DateTime.Now, Status = true },
                new MessageLang { Id = 8, MessageId = 8, LangId = 1, Value = "Verilmiş məlumatlar uyğun deyil.", CreatedDate = DateTime.Now, Status = true },
                new MessageLang { Id = 9, MessageId = 9, LangId = 1, Value = "Daxil etdiyiniz məlumat artıq bazada mövcuddur!", CreatedDate = DateTime.Now, Status = true },
                new MessageLang { Id = 10, MessageId = 10, LangId = 1, Value = "Məlumatlar dəyişdirilə bilməz.", CreatedDate = DateTime.Now, Status = true },
                new MessageLang { Id = 11, MessageId = 11, LangId = 1, Value = "Ulduzlu bölmələri doldurun.", CreatedDate = DateTime.Now, Status = true },
                new MessageLang { Id = 12, MessageId = 12, LangId = 1, Value = "Xəta baş verdi.", CreatedDate = DateTime.Now, Status = true },
                new MessageLang { Id = 13, MessageId = 13, LangId = 1, Value = "Göndərilən parametrlər düzgün deyil.", CreatedDate = DateTime.Now, Status = true },
                new MessageLang { Id = 14, MessageId = 14, LangId = 1, Value = "Rate Limitə çatıldı.", CreatedDate = DateTime.Now, Status = true },
                new MessageLang { Id = 15, MessageId = 15, LangId = 1, Value = "İstifadəçi adı və ya şifrəsi yanlışdır.", CreatedDate = DateTime.Now, Status = true },
                new MessageLang { Id = 16, MessageId = 16, LangId = 1, Value = "Token vaxtı bitib.", CreatedDate = DateTime.Now, Status = true },
                new MessageLang { Id = 17, MessageId = 17, LangId = 1, Value = "Yanlış token", CreatedDate = DateTime.Now, Status = true },
                new MessageLang { Id = 18, MessageId = 18, LangId = 1, Value = "Avtorizasiya xətası", Status = true },
                new MessageLang { Id = 19, MessageId = 19, LangId = 1, Value = "Şifrələr eyni deyil!", Status = true },
                new MessageLang { Id = 20, MessageId = 20, LangId = 1, Value = "Istifadəçi aktiv deyil!", Status = true },
                new MessageLang { Id = 21, MessageId = 21, LangId = 1, Value = "İstifadəçi adı artıq mövcuddur!", Status = true },
                new MessageLang { Id = 22, MessageId = 22, LangId = 1, Value = "Bu mail adresinə bağlı istifədəçi artıq mövcuddur!", Status = true },
                new MessageLang { Id = 23, MessageId = 23, LangId = 1, Value = "Hesab kilidləndi", Status = true },
                new MessageLang { Id = 24, MessageId = 24, LangId = 1, Value = "Şifrədə min. 6 simvol, böyük-kiçik hərf və bir xüsusi simvol olmalıdır", Status = true },
                new MessageLang { Id = 25, MessageId = 25, LangId = 1, Value = "Diqqət! Bu şifrəni artıq istifadə etmisiniz. Zəhmət olmasa yeni şifrə daxil edin", Status = true },
                new MessageLang { Id = 26, MessageId = 26, LangId = 1, Value = "Server xətası", Status = true },


                new MessageLang { Id = 27, MessageId = 1, LangId = 2, Value = "Saved successfully.", Status = true },
                new MessageLang { Id = 28, MessageId = 2, LangId = 2, Value = "Deleted", Status = true },
                new MessageLang { Id = 29, MessageId = 3, LangId = 2, Value = "Error occurred while saving.", Status = true },
                new MessageLang { Id = 30, MessageId = 4, LangId = 2, Value = "Operation forbidden", Status = true },
                new MessageLang { Id = 31, MessageId = 5, LangId = 2, Value = "Not confirmed", Status = true },
                new MessageLang { Id = 32, MessageId = 6, LangId = 2, Value = "Data not found.", Status = true },
                new MessageLang { Id = 33, MessageId = 7, LangId = 2, Value = "Already confirmed.", Status = true },
                new MessageLang { Id = 34, MessageId = 8, LangId = 2, Value = "The provided information is not suitable.", Status = true },
                new MessageLang { Id = 35, MessageId = 9, LangId = 2, Value = "The information you entered already exists in the database!", Status = true },
                new MessageLang { Id = 36, MessageId = 10, LangId = 2, Value = "Data cannot be modified.", Status = true },
                new MessageLang { Id = 37, MessageId = 11, LangId = 2, Value = "Please fill in the starred sections.", Status = true },
                new MessageLang { Id = 38, MessageId = 12, LangId = 2, Value = "An error occurred.", Status = true },
                new MessageLang { Id = 39, MessageId = 13, LangId = 2, Value = "The parameters sent are not correct.", Status = true },
                new MessageLang { Id = 40, MessageId = 14, LangId = 2, Value = "Rate limit reached.", Status = true },
                new MessageLang { Id = 41, MessageId = 15, LangId = 2, Value = "The username or password is incorrect.", Status = true },
                new MessageLang { Id = 42, MessageId = 16, LangId = 2, Value = "Token has expired.", Status = true },
                new MessageLang { Id = 43, MessageId = 17, LangId = 2, Value = "Invalid token", Status = true },
                new MessageLang { Id = 44, MessageId = 18, LangId = 2, Value = "Authorization error", Status = true },
                new MessageLang { Id = 45, MessageId = 19, LangId = 2, Value = "Passwords are not the same!", Status = true },
                new MessageLang { Id = 46, MessageId = 20, LangId = 2, Value = "User is not active!", Status = true },
                new MessageLang { Id = 47, MessageId = 21, LangId = 2, Value = "The username already exists!", Status = true },
                new MessageLang { Id = 48, MessageId = 22, LangId = 2, Value = "A user already exists with this email address!", Status = true },
                new MessageLang { Id = 49, MessageId = 23, LangId = 2, Value = "Account locked", Status = true },
                new MessageLang { Id = 50, MessageId = 24, LangId = 2, Value = "Password must contain min. 6 characters, upper-lower case letters and a special character", Status = true },
                new MessageLang { Id = 51, MessageId = 25, LangId = 2, Value = "Attention! You've already used this password. Please enter a new password", Status = true },
                new MessageLang { Id = 52, MessageId = 26, LangId = 2, Value = "Server error", Status = true },


                new MessageLang { Id = 53, MessageId = 1, LangId = 3, Value = "Успешно сохранено.", Status = true },
                new MessageLang { Id = 54, MessageId = 2, LangId = 3, Value = "Удалено", Status = true },
                new MessageLang { Id = 55, MessageId = 3, LangId = 3, Value = "Произошла ошибка при сохранении.", Status = true },
                new MessageLang { Id = 56, MessageId = 4, LangId = 3, Value = "Операция запрещена", Status = true },
                new MessageLang { Id = 57, MessageId = 5, LangId = 3, Value = "Не подтверждено", Status = true },
                new MessageLang { Id = 58, MessageId = 6, LangId = 3, Value = "Данные не найдены.", Status = true },
                new MessageLang { Id = 59, MessageId = 7, LangId = 3, Value = "Уже подтверждено.", Status = true },
                new MessageLang { Id = 60, MessageId = 8, LangId = 3, Value = "Предоставленная информация не подходит.", Status = true },
                new MessageLang { Id = 61, MessageId = 9, LangId = 3, Value = "Введенная вами информация уже существует в базе данных!", Status = true },
                new MessageLang { Id = 62, MessageId = 10, LangId = 3, Value = "Данные нельзя изменить.", Status = true },
                new MessageLang { Id = 63, MessageId = 11, LangId = 3, Value = "Пожалуйста, заполните обязательные поля.", Status = true },
                new MessageLang { Id = 64, MessageId = 12, LangId = 3, Value = "Произошла ошибка.", Status = true },
                new MessageLang { Id = 65, MessageId = 13, LangId = 3, Value = "Отправленные параметры некорректны.", Status = true },
                new MessageLang { Id = 66, MessageId = 14, LangId = 3, Value = "Достигнут лимит скорости.", Status = true },
                new MessageLang { Id = 67, MessageId = 15, LangId = 3, Value = "Имя пользователя или пароль неверны.", Status = true },
                new MessageLang { Id = 68, MessageId = 16, LangId = 3, Value = "Срок действия токена истек.", Status = true },
                new MessageLang { Id = 69, MessageId = 17, LangId = 3, Value = "Неверный токен", Status = true },
                new MessageLang { Id = 70, MessageId = 18, LangId = 3, Value = "Ошибка авторизации", Status = true },
                new MessageLang { Id = 71, MessageId = 19, LangId = 3, Value = "Пароли не совпадают!", Status = true },
                new MessageLang { Id = 72, MessageId = 20, LangId = 3, Value = "Пользователь не активен!", Status = true },
                new MessageLang { Id = 73, MessageId = 21, LangId = 3, Value = "Имя пользователя уже существует!", Status = true },
                new MessageLang { Id = 74, MessageId = 22, LangId = 3, Value = "Пользователь уже существует с этим адресом электронной почты!", Status = true },
                new MessageLang { Id = 75, MessageId = 23, LangId = 3, Value = "Аккаунт заблокирован", Status = true },
                new MessageLang { Id = 76, MessageId = 24, LangId = 3, Value = "Пароль должен содержать мин. 6 символов, заглавные и строчные буквы и специальный символ", Status = true },
                new MessageLang { Id = 77, MessageId = 25, LangId = 3, Value = "Внимание! Вы уже использовали этот пароль. Пожалуйста, введите новый пароль", Status = true },
                new MessageLang { Id = 78, MessageId = 26, LangId = 3, Value = "Ошибка сервера", Status = true }


           );
        }
    }
}
