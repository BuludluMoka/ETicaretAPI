using Core.Application.Utilities.Results;

public static class ResultDataGenerator
{
    private static IResultData Generate(object data,
        ResultInfo resultInfo,
        string message = "",
        bool status = false,
        int statusCode = 0) => new ResultData
        {
            Data = data,
            Message = !string.IsNullOrEmpty(message) || (resultInfo is ResultInfo.Success or ResultInfo.NotImplemented) ? message : ICommonRepository.GetResultMessageValue(resultInfo),
            StatusCode = !string.IsNullOrEmpty(message) ? statusCode : (int)resultInfo,
            Status = !string.IsNullOrEmpty(message) ? status : ((int)resultInfo < 2000 && resultInfo != ResultInfo.NotImplemented)
        };

    internal static IResultData Generate(Result result) => Generate(result.Data, result.ResultInfo, result.Message, result.Status, result.StatusCode);

    internal static IResultData Generate(ResultInfo resultInfo) => Generate(null, resultInfo);
}