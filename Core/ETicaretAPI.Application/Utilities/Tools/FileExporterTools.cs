using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Core.Utilities.Exceptions;
using OnionArchitecture.Application.Abstractions.Repositories;

namespace Core.Utilities.Tools
{
    public class FileExporterTools
    {
        public ICommonRepository _commonRepository;

        public FileExporterTools(ICommonRepository commonRepository)
        {
            _commonRepository = commonRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data">List<object></object></param>
        /// <param name="pageName">Hansi sehifedeyikse onun pageName-ni gonderirik(dile gore kontent gelir)</param>
        /// <param name="documentName">Fayl adi</param>
        /// <returns></returns>

        public byte[] ExportDataToExcel(object data, string pageName, string documentName)
        {
            try
            {
                byte[] content;
                using var workbook = new XLWorkbook();

                int cellCount = 1;
                IXLWorksheet worksheet =
                    workbook.Worksheets.Add(documentName);


                var getLanguageContent = _commonRepository.GetLanguageContent(pageName);


                #region Set Headers
                PropertyInfo[] propertyInfos = null;
                propertyInfos = data.GetType().GetProperties();
                foreach (var propertyInfo in propertyInfos)
                {
                    var propertyValue = propertyInfo.GetValue(data);
                    if (propertyInfo.GetType().IsClass && propertyValue is IEnumerable && !(propertyValue is string))
                    {
                        if (propertyValue.GetType().Name == "List`1")
                        {
                            var firstElement = (propertyValue as IEnumerable).Cast<object>().FirstOrDefault();
                            if (firstElement == null) return null;
                            var properties = firstElement.GetType().GetProperties();
                            foreach (var property in properties)
                            {

                                var last = $"{property.Name} = {property.GetValue(firstElement)}";

                                var getTranslatedDataValue = getLanguageContent.FirstOrDefault(x => string.Equals(x.ObjectName, property.Name, StringComparison.OrdinalIgnoreCase))?.ObjectValue;

                                if (getTranslatedDataValue?.Count() > 0)
                                {
                                    worksheet.Cell(1, cellCount++).Value = getTranslatedDataValue;
                                }
                                else
                                {
                                    worksheet.Cell(1, cellCount++).Value = property.Name;
                                }
                            }
                        }
                    }
                }
                #endregion
                RenderCellValues(data, worksheet);

                using var stream = new MemoryStream();
                workbook.SaveAs(stream);
                content = stream.ToArray();
                return content;
            }
            catch (Exception ex)
            {
                return null;

            }
        }


        private static void RenderCellValues(object data, IXLWorksheet worksheet)
        {
            int currentRow = 1;

            PropertyInfo[] propertyInfos = null;
            propertyInfos = data.GetType().GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                var propertyValue = propertyInfo.GetValue(data);
                if (propertyInfo.GetType().IsClass && propertyValue is IEnumerable && !(propertyValue is string))
                {
                    if (propertyValue.GetType().Name == "List`1")
                    {
                        foreach (dynamic listItem in propertyValue as IEnumerable)
                        {
                            int countForData = 1;
                            currentRow++;
                            var properties = listItem.GetType().GetProperties();
                            foreach (var property in properties)
                            {
                                var last = $"{property.Name} = {property.GetValue(listItem)}";
                                worksheet.Cell(currentRow, countForData++).Value = property.GetValue(listItem);

                            }
                        }
                    }
                }
            }


        }







    }
}
