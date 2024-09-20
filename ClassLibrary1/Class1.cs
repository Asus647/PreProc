using OfficeOpenXml;
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

        /// <summary>
        /// Читает и сохраняет данные из файла с расширенеим .xlsx
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Данные из файла</returns>
        public static List<string[]> ReadExcelFile(string path)
        {
            // использование версии установленной библиотеки EPPLUS, тип лицензии - некоммерческий
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            int totalRows = 0;
            int totalCols = 0;
            List<string[]> ExcelTable = new List<string[]>();
            // получение названия файла из пути к нему
            var file = new FileInfo(@path);
            // открытие файла локально для его чтения и вывода данных
            using (var excelfile = new ExcelPackage(file))
            {
                // выбор листа экселя(по умолчанию первый)
                var worksheet = excelfile.Workbook.Worksheets[0];
                totalRows = worksheet.Dimension.End.Row;
                totalCols = worksheet.Dimension.End.Column;
                for (int rowIndex = 1; rowIndex <= totalRows; rowIndex++)
                {
                    // создание коллекции элементов одной строки, закрытой строковым типом
                    // а также лямбда выражения для записи значений из ячеек эксель файла
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
