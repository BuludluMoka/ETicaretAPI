using Core.Entities.SPModels;
using Domain.SPModels.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Abstractions.Repositories
{
    public enum AutoCompleteType
    {
        Company = 1,
        Cargo = 2,
        TransportNumber = 3,
        CargoWithCategories = 4,
        Points = 5,
        Countries = 6,
        WagonNumber = 7
    }
    public interface ICommonRepository
    {
        public IList<SP_KeyValueResult> GetSpeCodeValues(string type);
        public IList<SP_GetServices> GetServices();
        public string GenerateDocumentNumber<TEntity, TOrderKey>(
            string prefix,
            Expression<Func<TEntity, TOrderKey>> orderByExpression,
            Expression<Func<TEntity, string>> selectExpression,
            Expression<Func<TEntity, bool>> whereExpression = null)
            where TEntity : class;
        public string GetResultMessageValue(ResultInfo resultMessage);
        public IList<T> GetAutoCompletedValues<T>(
            string filter,
            AutoCompleteType type)
            where T : class;
        public IList<SP_KeyValueResult> GetAutoCompletedValues(
            string filter,
            AutoCompleteType type);
        public IList<SP_GetContents> GetLanguageContent(string pageName);
    }
}
