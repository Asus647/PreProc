
using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        List<string[]> a = ClassLibrary1.PreProc.ReadCsvFile("C:\\Users\\pompa\\Source\\Repos\\PreProc\\console\\1.csv");
        foreach (string[] c in a)
        {
            foreach (string s in c)
            {
                Console.Write(s + "     ");
            }
            Console.WriteLine();
        }
        List<string[]> b = ClassLibrary1.PreProc.ReadExcelFile("C:\\Users\\pompa\\Source\\Repos\\PreProc\\console\\book1.xlsx");
        Console.WriteLine();
        foreach (string[] v in b)
        {
            foreach (string n in v)
            {
                Console.Write(n + "     ");
            }
            Console.WriteLine();
        }
    }
}