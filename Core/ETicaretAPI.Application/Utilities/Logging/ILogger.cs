using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Models;

namespace Core.Utilities.Logging
{
    public interface ILogger
    {
        string Log(string content, LogType logType);
    }

    public enum LogType
    {
        Info,
        Exception, 
        BadRequest
    }
}
