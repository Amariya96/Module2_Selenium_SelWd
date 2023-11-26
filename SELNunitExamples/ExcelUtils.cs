using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELNunitExamples
{
    internal class ExcelUtils
    {
        public static List<ExcelData> ReadExcelData(string excelFilePath)
        {
            List<ExcelData> excelDataList = new List<ExcelData>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });
                    var dataTable = result.Tables["GS"];
                    foreach(DataRow row in dataTable.Rows)
                    {
                        ExcelData excelData = new()
                        {
                            SearchText = row["searchText"].ToString(),
                        };
                        excelDataList.Add(excelData);
                    }
                }
            }
            return excelDataList;
        }
    }
}
