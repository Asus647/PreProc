using OfficeOpenXml;
using System.Drawing.Text;
using System.IO;
namespace ClassLibrary1
{
    public static class PreProc
    {
        /// <summary>
        /// Читает и сохраняет данные из файла с расширением .csv
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns></returns>
        public static List<string[]> ReadCsvFile(string path)
        {
            List<string[]> output = new List<string[]>();
            StreamReader reader = new StreamReader(path);
            string? line = reader.ReadLine();
            while (line != null)
            {
                string[] values = line.Split(',');
                output.Add(values);
                line = reader.ReadLine();
            }
            return output;
        }
        public static List<string[]> ReadExcelFile(string path)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            int totalRows = 0;
            int totalCols = 0;
            List<string[]> ExcelTable = new List<string[]>();
            var file = new FileInfo(@path);
            using (var excelfile = new ExcelPackage(file))
            {
                var worksheet = excelfile.Workbook.Worksheets[0];
                totalRows = worksheet.Dimension.End.Row;
                totalCols = worksheet.Dimension.End.Column;
                for (int rowIndex = 1; rowIndex <= totalRows; rowIndex++)
                {
                    IEnumerable<string?> row = worksheet.Cells[rowIndex, 1, rowIndex, totalCols]
                        .Select(c => c.Value == null ? string.Empty : c.Value.ToString());
                    List<string> tempRow = row!.ToList<string>();
                    ExcelTable.Add(tempRow.ToArray());
                }
                return ExcelTable;
            }
        }
    }
}
