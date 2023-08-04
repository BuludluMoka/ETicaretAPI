using Domain.SPModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Application.Abstractions.DB.Tools;
using OnionArchitecture.Application.Enums;
using OnionArchitecture.Application.Utilities.Exceptions;
using OnionArchitecture.Persistence.Contexts;

public class EfDatabaseTool : IEFDatabaseTool
{
    private readonly AppDbContext context;

    public EfDatabaseTool(AppDbContext dbContext)
    {
        context = dbContext;
    }
    public IList<T> ExecuteProcedure<T>(string procedureName, params SqlParameter[] parameters) where T : class
    {
        if (parameters != null && parameters.Any(p => p.Value == null))
        {
            return new List<T>();
        }

        if (!HasObjectInDb(context, procedureName, DbObjectType.Procedure))
        {
            throw new InvalidRequestParameterException($"Invalid procedure name: '{procedureName}'.");
        }

        var parametersStr = parameters != null
            ? string.Join(", ", parameters.Select(p => $"@{p.ParameterName} = @{p.ParameterName}"))
            : "";
        var query = $"exec {procedureName} {parametersStr}";
        var parametersList = new List<object>();

        if (parameters != null)
        {
            parametersList.AddRange(parameters);
        }

        return context
            .Set<T>()
            .FromSqlRaw(query, parametersList.ToArray())
            .ToList();
    }

    public IList<T> ExecuteProcedure<T>(string procedureName, IList<SqlParameter> parameters) where T : class
    {
        return ExecuteProcedure<T>(procedureName, parameters.ToArray());
    }

    private TableValuedFunctionResult<T> ExecuteTableValuedFunction<T>(
        string functionName,
        int offset,
        int next,
        bool exportToExcel,
        bool defaultDesc,
        TableValuedFunctionFilter[] filters,
        params SqlParameter[] parameters) where T : class
    {
        using var context = new AppDbContext();

        if (!HasObjectInDb(context, functionName, DbObjectType.Function))
        {
            throw new InvalidRequestParameterException(
                $"Invalid function name: '{functionName}'.");
        }

        var parametersList = new List<object>();

        if (parameters != null)
        {
            parametersList.AddRange(parameters);
        }

        string filtersString = "", ordersString = "";

        if (filters is { Length: > 0 } && IsFiltersValid<T>(filters))
        {
            filtersString = string.Join(" and ", filters.Select(f => f.Filter));
            ordersString = string.Join(", ", filters.Where(f => f.OrderString != null)
                .Select(f => f.OrderString));

            parametersList.AddRange(filters.Select(f => f.ASqlParameter));
        }

        var parametersStr = parameters != null ? string.Join(", ", parameters.Select(p => $"@{p.ParameterName}")) : "";
        var query = $"select * from {functionName}({parametersStr})" +
                    $"{(filtersString.Length > 0 ? $" where {filtersString}" : "")}";

        var dbSet = context.Set<T>();
        var parametersArr = parametersList.ToArray();
        var orderBySql =
            $" order by {(ordersString.Length > 0 ? $"{ordersString}" : $"1{(defaultDesc ? " desc" : "")}")}";

        if (exportToExcel)//Get all data
        {
            query += orderBySql;
            var data = dbSet.FromSqlRaw(query, parametersArr).ToList();
            return new TableValuedFunctionResult<T>
            {
                Result = data,
                Count = data.Count
            };
        }

        var result = new TableValuedFunctionResult<T>
        {
            Count = dbSet.FromSqlRaw(query, parametersArr).Count()
        };

        query += orderBySql
        + $" offset {offset} rows fetch next {next} rows only";
        result.Result = dbSet.FromSqlRaw(query, parametersArr).ToList();

        return result;
    }

    public TableValuedFunctionResult<T> ExecuteTableValuedFunction<T>(
        string functionName,
        TableValuedFunctionFilter[] filters,
        IList<SqlParameter> parameters,
        bool exportToExcel,
        bool defaultDesc = true
    )
        where T : class
    {
        return ExecuteTableValuedFunction<T>(
            functionName,
            0,
            int.MaxValue,
             exportToExcel,
            defaultDesc,
            filters,
            parameters.ToArray());
    }

    public TableValuedFunctionResult<T> ExecuteTableValuedFunction<T>(
        string functionName,
        TableValuedFunctionRequest request,
        bool defaultDesc,
        params SqlParameter[] parameters)
        where T : class
    {
        if (request == null)
        {
            throw new InvalidRequestParameterException <TableValuedFunctionRequest>(nameof(request), null);
        }

        return ExecuteTableValuedFunction<T>(
            functionName,
            request.Offset,
            request.Next,
            request.ExportToExcelData,
            defaultDesc,
            request.Filters,
            parameters);
    }

    public TableValuedFunctionResult<T> ExecuteTableValuedFunction<T>(
        string functionName,
        TableValuedFunctionRequest request,
        params SqlParameter[] parameters)
        where T : class
    {
        return ExecuteTableValuedFunction<T>(
            functionName,
            request,
            true,
            parameters);
    }

    public TableValuedFunctionResult<T> ExecuteTableValuedFunction<T>(
        string functionName,
        TableValuedFunctionRequest request,
        IList<SqlParameter> parameters,
         bool exportToExcel = false,
        bool defaultDesc = true)
        where T : class
    {
        return ExecuteTableValuedFunction<T>(
            functionName,
            request,
            defaultDesc,
            parameters.ToArray());
    }

    /// <summary>
    /// Add parameter to list
    /// </summary>
   

    private bool HasObjectInDb( AppDbContext context, string objectName, DbObjectType objectType)
    {
        var dbObjects = context
            .Set<SP_GetDbObjects>()
            .FromSqlRaw($"exec dbo.SP_GetDbObjects {(int)objectType}")
            .ToList();
        var a = dbObjects.FirstOrDefault(o => string.Equals(o.ObjectName, objectName, StringComparison.CurrentCultureIgnoreCase)) != null;
        Console.WriteLine();
        return a;
    }

    private bool IsFiltersValid<T>(TableValuedFunctionFilter[] filters) where T : class
    {
        var properties = typeof(T).GetProperties();

        return filters
            .All(filter => properties
                .FirstOrDefault(prop => string
                    .Equals(prop.Name, filter.ColumnName, StringComparison.CurrentCultureIgnoreCase)) == null
                ? throw new InvalidRequestParameterException<TableValuedFunctionFilter>(
                    nameof(filter.ColumnName), filter.ColumnName)
                : true);
    }
}