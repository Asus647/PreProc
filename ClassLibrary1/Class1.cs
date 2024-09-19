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
    }
}
