using Core.Entities.SPModels;
using Domain.SPModels.System;
using Microsoft.Data.SqlClient;
using OnionArchitecture.Application.Abstractions.DB.Tools;
using OnionArchitecture.Application.Abstractions.Repositories;
using OnionArchitecture.Application.Utilities.Extensions;
using OnionArchitecture.Persistence.Contexts;
using System.Linq.Expressions;

namespace OnionArchitecture.Persistence.Repositories
{
    public class CommonRepository : ICommonRepository
    {
        private readonly IEFDatabaseTool _eFDatabase;

        public CommonRepository( IEFDatabaseTool eFDatabase)
        {
            _eFDatabase = eFDatabase;
        }
        public IList<SP_KeyValueResult> GetSpeCodeValues(string type)
        {
            var parameters = new List<SqlParameter>();
            parameters.AddParam("type", type);
            parameters.AddLanguageParam();

            return _eFDatabase.ExecuteProcedure<SP_KeyValueResult>(
                "OBJ.SP_GetSpeCodeValues", parameters);
        }

        public IList<SP_GetServices> GetServices()
        {
            var parameters = new List<SqlParameter>();
            parameters.AddLanguageParam();

            return _eFDatabase.ExecuteProcedure<SP_GetServices>(
                "CRD.SP_GetServices", parameters);
        }

        public string GenerateDocumentNumber<TEntity, TOrderKey>(
            string prefix,
            Expression<Func<TEntity, TOrderKey>> orderByExpression,
            Expression<Func<TEntity, string>> selectExpression,
            Expression<Func<TEntity, bool>> whereExpression = null)
            where TEntity : class
        {
            var yearSuffix = (DateTime.Now.Year % 100).ToString();

            using var context = new AppDbContext();
            var queryableEntity = whereExpression == null
                ? context.Set<TEntity>()
                : context.Set<TEntity>().Where(whereExpression);

            var lastNumberStr = queryableEntity
                .OrderByDescending(orderByExpression)
                .Take(1)
                .Select(selectExpression)
                .FirstOrDefault();

            if (lastNumberStr == null
                || yearSuffix != lastNumberStr.Substring(
                    prefix.Length, yearSuffix.Length))
            {
                return $"{prefix}{yearSuffix}-00001";
            }

            var lastNumber = int.Parse(lastNumberStr.Split('-')[1]);

            return $"{prefix}{yearSuffix}-{lastNumber + 1:00000}";
        }

        public string GetResultMessageValue(ResultInfo resultMessage)
        {
            var parameters = new List<SqlParameter>
        {
            new("MessageCode", ((int)resultMessage).ToString())
        };
            parameters.AddLanguageParam();

            var getMessageResult = _eFDatabase.ExecuteProcedure<SP_GetMessage>(
                "OBJ.SP_GetMessage", parameters);



            if (getMessageResult == null
                || getMessageResult.Count == 0)
            {
                return resultMessage.ToString();
            }

            return getMessageResult.First().MessageValue;
        }

        public IList<T> GetAutoCompletedValues<T>(
            string filter,
            AutoCompleteType type)
            where T : class
        {
            var parameters = new List<SqlParameter>
        {
            new("filter", filter),
            new("type", (int)type)
        };
            parameters.AddLanguageParam();

            var result = _eFDatabase.ExecuteProcedure<T>(
                "OBJ.SP_Get_AutoCompletes", parameters);

            return result;
        }

        public IList<SP_KeyValueResult> GetAutoCompletedValues(
            string filter,
            AutoCompleteType type)
            => GetAutoCompletedValues<SP_KeyValueResult>(filter, type);



        public IList<SP_GetContents> GetLanguageContent(string pageName)
        {
            if (string.IsNullOrEmpty(pageName))
            {
                return null;
            }

            List<SqlParameter> parameters = new();
            parameters.AddLanguageParam();
            parameters.AddParam("PageName", pageName);

            var runProcedure = _eFDatabase.ExecuteProcedure<SP_GetContents>("OBJ.SP_GetContents", parameters).ToList();

            return runProcedure;

        }
    }
}
