namespace Core.Application.Utilities.Results;

public class OperationResult
{
    internal OperationResult()
    {

    }

    public ResultInfo ResultInfo { get; internal set; }

    public int? AuditId { get; internal set; }
}