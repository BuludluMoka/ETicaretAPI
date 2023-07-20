using OnionArchitecture.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Abstractions.Services.Global
{
    public interface ILoggingService
    {
        string Log(string content, LogType logType);
    }
}
