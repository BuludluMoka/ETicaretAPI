namespace Core.Application.Utilities.Results
{
    public interface IResultData
    {
        object Data { get; }

       string Message { get; }

       int StatusCode { get; }

       bool Status { get; }
    }
}