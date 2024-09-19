
using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        List<string[]> a = ClassLibrary1.PreProc.ReadCsvFile("D:\\proc-c#\\console\\1.csv");
        foreach(string[] c in a)
        {
            foreach(string s in c)
            {
                Console.Write(s + "     ");
            }
            Console.WriteLine();
        }
    }
}