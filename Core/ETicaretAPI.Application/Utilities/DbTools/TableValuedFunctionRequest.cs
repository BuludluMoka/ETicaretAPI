using System.Text.Json.Serialization;
using Core.Utilities.Exceptions;

public class TableValuedFunctionRequest
{
    private TableValuedFunctionFilter[] _filters;
    private int _nextPageNumber;
    private int _visibleItemCount;


    private string _currentPageName;
    public string CurrentPageName
    {
        get { return _currentPageName; }
        set { _currentPageName = value; }
    }

    private bool _exportToExcel;

    public bool ExportToExcel
    {
        get => _exportToExcel;
        set => _exportToExcel = value;
    }


    public int NextPageNumber
    {
        get => _nextPageNumber;
        set => _nextPageNumber = value < 0
            ? throw new InvalidRequestParameterException<TableValuedFunctionRequest>(
                nameof(NextPageNumber), value)
            : value;
    }

    public int VisibleItemCount
    {
        get => _visibleItemCount;
        set => _visibleItemCount = value < 0
            ? throw new InvalidRequestParameterException<TableValuedFunctionRequest>(
                nameof(VisibleItemCount), value)
            : value;
    }

    public TableValuedFunctionFilter[] Filters
    {
        get => _filters;
        set => _filters = value ?? Array.Empty<TableValuedFunctionFilter>();
    }

    [JsonIgnore] public int Offset => (NextPageNumber - 1) * VisibleItemCount; 

    [JsonIgnore] public int Next => VisibleItemCount;
    [JsonIgnore] public bool ExportToExcelData => ExportToExcel;
    [JsonIgnore] public string CurrentPage => CurrentPageName;

    public void SetColumnOrder(string columnName, FilteredColumnOrder columnOrder)
    {
        columnName = columnName.Trim();
        var filters = new List<TableValuedFunctionFilter>(Filters);
        var filter = filters.FirstOrDefault(
            f => string.Equals(f.ColumnName, columnName, StringComparison.CurrentCultureIgnoreCase));

        switch (filter)
        {
            case null:
                filters.Add(new TableValuedFunctionFilter
                {
                    ColumnName = columnName.ToLower(),
                    Order = columnOrder
                });
                break;
            case { OrderString: null }:
                filter.Order = columnOrder;
                break;
        }

        Filters = filters.ToArray();
    }
}
