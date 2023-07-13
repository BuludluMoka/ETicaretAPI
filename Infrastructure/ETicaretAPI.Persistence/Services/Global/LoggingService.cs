using OnionArchitecture.Application.Abstractions.Services.Global;
using OnionArchitecture.Application.Enums;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.Services.Global
{
    public class LoggingService : ILoggingService
    {
        public string Log(string content, LogType logType)
        {
            var log = new SystemLog
            {
                Content = content,
                CreatedDate = DateTime.Now,
                RequestUrl = CurrentScopeDataContainer.Instance.RequestUrl,
                UserId = CurrentScopeDataContainer.Instance.UserId,
                Type = logType.ToString()
            };

            using var context = new AppDbContext();
            context.SystemLogs.Add(log);
            context.SaveChanges();

            return log.Id.ToString();
        }
    }
}
