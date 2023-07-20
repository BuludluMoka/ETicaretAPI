using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Utilities.Extensions
{
    public static class SqlParameterExtension
    {
        public static void AddUserIdParam(this IList<SqlParameter> list)
        {
            list.AddParam("UserId", CurrentScopeDataContainer.Instance.UserId.ToString());
        }
        public static void AddParam(this IList<SqlParameter> list, string paramName, object paramValue)
        {
            list.Add(new SqlParameter(paramName, paramValue));
        }

        /// <summary>
        /// Add UserId parameter to list
        /// </summary>


        /// <summary>
        /// Add Language value to list
        /// </summary>
        public static void AddLanguageParam(this IList<SqlParameter> list)
        {
            list.AddParam("Language", CurrentScopeDataContainer.Instance.Language);
        }

        /// <summary>
        /// Adds UserId, Language values to list
        /// </summary>
        public static void AddSystemParams(this IList<SqlParameter> list)
        {
            list.AddUserIdParam();
            list.AddLanguageParam();
        }
    }
}
