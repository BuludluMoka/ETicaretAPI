namespace Core.Utilities.Exceptions;

public abstract class BadRequestExceptionBase : ApplicationException
{
    protected BadRequestExceptionBase(
        string message, ResultInfo exceptionResult)
        : base(message)
    {
        ExceptionResult = exceptionResult;
    }

    public ResultInfo ExceptionResult { get; }
}