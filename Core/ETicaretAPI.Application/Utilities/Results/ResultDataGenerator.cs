using Core.Application.Utilities.Results;
using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Application.Abstractions.Repositories;
using OnionArchitecture.Application.Abstractions.Services.Global;
using OnionArchitecture.Application.Helpers;

public class ResultDataGenerator
{
    private readonly ICommonRepository _commonRepository;
    public ResultDataGenerator()
    {
        var serviceProvider = ServiceProviderHelper.ServiceProvider;
        var commonRepository = serviceProvider.GetRequiredService<ICommonRepository>();
        _commonRepository = commonRepository;
    }

    private  IResultData Generate(object data, ResultInfo resultInfo, string message = "", bool status = false, int statusCode = 0) => new ResultData
    {
        Data = data,
        Message = !string.IsNullOrEmpty(message) || (resultInfo is ResultInfo.Success or ResultInfo.NotImplemented) ? message : _commonRepository.GetResultMessageValue(resultInfo),
        StatusCode = !string.IsNullOrEmpty(message) ? statusCode : (int)resultInfo,
        Status = !string.IsNullOrEmpty(message) ? status : ((int)resultInfo < 2000 && resultInfo != ResultInfo.NotImplemented)
    };

    public  IResultData Generate(Result result) => Generate(result.Data, result.ResultInfo, result.Message, result.Status, result.StatusCode);

    public  IResultData Generate(ResultInfo resultInfo) => Generate(null, resultInfo);
}