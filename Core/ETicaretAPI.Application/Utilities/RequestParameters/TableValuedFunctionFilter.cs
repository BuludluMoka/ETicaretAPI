using System.Text.Json.Serialization;
using Microsoft.Data.SqlClient;

public enum FilteredColumnOrder
{
    Default = 0,
    Asc = 1,
    Desc = 2
}

public class TableValuedFunctionFilter
{
    private string _columnName;

    public TableValuedFunctionFilter()
    {
        Order = FilteredColumnOrder.Default;
    }

    public string ColumnName
    {
        get => _columnName;
        set => _columnName = value.Trim();
    }

    public string Value { get; set; }

    public FilteredColumnOrder Order { get; set; }

    [JsonIgnore] private string SqlParameterName => $"__col__{ColumnName}";

    [JsonIgnore] public string Filter => $"[{ColumnName}] like N'%' + @{SqlParameterName} + N'%'";

    [JsonIgnore] public string OrderString => Order != FilteredColumnOrder.Default && Enum.IsDefined(Order)
        ? $"[{ColumnName}] {Order}" : null;

    [JsonIgnore] public SqlParameter ASqlParameter => new(SqlParameterName, Value ?? string.Empty);
}