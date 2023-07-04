namespace Core.Utilities.Exceptions;

public class InvalidRequestParameterException : BadRequestExceptionBase
{
    public InvalidRequestParameterException(string message)
        : base(message, ResultInfo.InvalidRequestParameters)
    {
    }

    public InvalidRequestParameterException(
        string message,
        string parameterName,
        object value)
        : this($"{message ?? "Parameter value is not valid."} [{parameterName}] - {{{value ?? "null"}}}")
    {
    }

    public InvalidRequestParameterException(
        string parameterName, 
        object value)
        : this(null, parameterName, value)
    {
    }

    protected InvalidRequestParameterException(
        Type type,
        string message,
        string parameterName,
        object value)
        : this(message, $"({type.FullName}) {parameterName}", value)
    {
    }
}

public class InvalidRequestParameterException<T> 
    : InvalidRequestParameterException
{
    public InvalidRequestParameterException(string message) 
        : base(message)
    {
    }

    public InvalidRequestParameterException(
        string message, 
        string parameterName, 
        object value) 
        : base(typeof(T), message, parameterName, value)
    {
    }

    public InvalidRequestParameterException(
        string parameterName, 
        object value) 
        : base(typeof(T), null, parameterName, value)
    {
    }
}