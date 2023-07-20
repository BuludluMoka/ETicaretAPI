using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Abstractions.DB.Tools
{
    public interface IEFDatabaseTool
    {
        IList<T> ExecuteProcedure<T>(string procedureName, params SqlParameter[] parameters) where T : class;
        IList<T> ExecuteProcedure<T>(string procedureName, IList<SqlParameter> parameters) where T : class;
        TableValuedFunctionResult<T> ExecuteTableValuedFunction<T>(string functionName, TableValuedFunctionFilter[] filters, IList<SqlParameter> parameters, bool exportToExcel, bool defaultDesc = true) where T : class;
        TableValuedFunctionResult<T> ExecuteTableValuedFunction<T>(string functionName, TableValuedFunctionRequest request, bool defaultDesc, params SqlParameter[] parameters) where T : class;
        TableValuedFunctionResult<T> ExecuteTableValuedFunction<T>(string functionName, TableValuedFunctionRequest request, params SqlParameter[] parameters) where T : class;
        TableValuedFunctionResult<T> ExecuteTableValuedFunction<T>(string functionName, TableValuedFunctionRequest request, IList<SqlParameter> parameters, bool exportToExcel = false, bool defaultDesc = true) where T : class;
    }
}
