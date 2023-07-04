using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
/// <summary>
/// Controller içərisində  metodların (Action) üzərinə attribute olaraq yazılır, əgər xüsusi sahələr varsa xeta mesaji döndərir
/// </summary>
/// 
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class ModelStateControlAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            context.Result = new BadRequestObjectResult(
                ResultDataGenerator.Generate(ResultInfo.FillRequiredFields));
        }
        base.OnActionExecuting(context);
    }
}
