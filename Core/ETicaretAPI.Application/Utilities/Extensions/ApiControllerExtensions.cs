using Microsoft.AspNetCore.Mvc;
using Core.Application.Utilities.Results;
using OnionArchitecture.Application.DTOs.FileUploads;

public static class ApiControllerExtensions
{

    public static IActionResult AsObjectResult(
        this Result result)
    {
        return new ObjectResult(ResultDataGenerator.Generate(result));
    }


    //public static IActionResult AsObjectResult(
    //    this Result result, TableValuedFunctionRequest request )
    //{
    //    if (request != null && request.ExportToExcelData)
    //        return AsExcelFile(result, request.CurrentPage);

    //    return new ObjectResult(ResultDataGenerator.Generate(result));
    //}



    public static IActionResult AsObjectResult(
        this ResultInfo resultInfo)
        => new ObjectResult(ResultDataGenerator.Generate(resultInfo));


    //private static IActionResult AsExcelFile(Result resultData, string pageName = null, string documentName = null)
    //{
    //    documentName = documentName ?? "Excel_" + DateTime.Now.ToString("yyyyMMddHHmmss");
    //    string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    //    //var byteArrayContent = new FileExporterTools().ExportDataToExcel(ResultDataGenerator.Generate(resultData).Data, pageName, documentName);
      
    //    return new FileContentResult(byteArrayContent, contentType);

    //}



    /// <summary>
    /// 
    /// </summary>
    /// <param name="data">List<object></object></param>
    /// <param name="pageName">Hansi sehifedeyikse onun pageName-ni gonderirik(dile gore kontent gelir)</param>
    /// <param name="documentName">Fayl adi</param>
    /// <returns></returns>
    //private static IActionResult AsExcelFile(Result resultData, string pageName = null, string documentName = null)
    //{
    //    documentName = documentName ?? "Excel_" + DateTime.Now.ToString("yyyyMMddHHmmss");
    //    string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    //    var byteArrayContent = FileExporterTools.ExportDataToExcel(ResultDataGenerator.Generate(resultData).Data, pageName, documentName);
    //    return new FileContentResult(byteArrayContent, contentType);
    //}


    //public static IActionResult AsExcelFile(this ControllerBase controller, Result resultData, string pageName = null, string documentName = null)
    //{
    //    documentName = documentName ?? "Excel_" + DateTime.Now.ToString("yyyyMMddHHmmss");
    //    string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    //    var byteArrayContent = FileExporterTools.ExportDataToExcel(ResultDataGenerator.Generate(resultData).Data, pageName, documentName);

    //    return controller.File(
    //    byteArrayContent,
    //    contentType,
    //   documentName);

    //}



    public static IActionResult AsFileResult(
        this ControllerBase controller,
        DownloadedFileResult downloadedFile)
    {
        return controller.File(
            downloadedFile.Content,
            downloadedFile.ContentType,
            downloadedFile.FileName);
    }
}