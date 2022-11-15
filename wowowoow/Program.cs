using Newtonsoft.Json;
using System.Runtime.ConstrainedExecution;
using wowowoow;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Введите путь файла: ");
        readfile readfile = new readfile();
        string path = Console.ReadLine();
        readfile.opener(path);
        edit edit = new edit();
        edit.editing();
        save save = new save();
        save.finalsave();
    }
}