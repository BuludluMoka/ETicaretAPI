using Domain.SPModels;
using Domain.SPModels.System;
using OnionArchitecture.Application.Enums;
using System.Linq.Expressions;

namespace OnionArchitecture.Application.Abstractions.Repositories
{
    public interface ICommonRepository
    {
        public IList<SP_KeyValueResult> GetSpeCodeValues(string type);
        public IList<SP_GetServices> GetServices();
        public string GetResultMessageValue(ResultInfo resultMessage);
        public IList<T> GetAutoCompletedValues<T>(string filter, AutoCompleteType type) where T : class;
        public IList<SP_GetContents> GetLanguageContent(string pageName);
        public IList<SP_KeyValueResult> GetAutoCompletedValues(string filter, AutoCompleteType type);
        public string GenerateDocumentNumber<TEntity, TOrderKey>(
            string prefix,
            Expression<Func<TEntity, TOrderKey>> orderByExpression,
            Expression<Func<TEntity, string>> selectExpression,
            Expression<Func<TEntity, bool>> whereExpression = null)
            where TEntity : class;
    }
}
