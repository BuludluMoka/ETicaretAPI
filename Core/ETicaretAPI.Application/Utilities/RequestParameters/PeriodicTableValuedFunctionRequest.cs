using Microsoft.Data.SqlClient;

public class PeriodicTableValuedFunctionRequest : TableValuedFunctionRequest
{
    public DateTime BeginDate { get; set; }

    public DateTime EndDate { get; set; }

    public IList<SqlParameter> AsSqlParameters()
        => new List<SqlParameter>
        {
            new ("beginDate", BeginDate),
            new ("endDate", EndDate)
        };
}