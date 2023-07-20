namespace Core.Application.Utilities.Results;

public class OperationResult
{
    public OperationResult()
    {

    }

    public ResultInfo ResultInfo { get;  set; }
        
    public int? AuditId { get;  set; }
}