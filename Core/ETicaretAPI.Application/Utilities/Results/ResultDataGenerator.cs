using Core.Application.Utilities.Results;
using OnionArchitecture.Application.Abstractions.Repositories;
using OnionArchitecture.Application.Helpers;

public static class ResultDataGenerator
{
    private static IResultData Generate(object data, ResultInfo resultInfo, string message = "", bool status = false, int statusCode = 0) => new ResultData
    {
        Data = data,
        Message = !string.IsNullOrEmpty(message) || (resultInfo is ResultInfo.Success or ResultInfo.NotImplemented) ? message : ServiceLocator.GetService<ICommonRepository>().GetResultMessageValue(resultInfo),
        StatusCode = !string.IsNullOrEmpty(message) ? statusCode : (int)resultInfo,
        Status = !string.IsNullOrEmpty(message) ? status : ((int)resultInfo < 2000 && resultInfo != ResultInfo.NotImplemented)
    };

    public static IResultData Generate(Result result) => Generate(result.Data, result.ResultInfo, result.Message, result.Status, result.StatusCode);

    public static IResultData Generate(ResultInfo resultInfo) => Generate(null, resultInfo);
}