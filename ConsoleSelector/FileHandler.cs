

public class FileHandler
{
    public void readFile()
    {
        string[] lines = System.IO.File.ReadAllLines(@"C:\Users\james\source\repos\ConsoleSelector\ConsoleSelector\options.txt");
        foreach (string line in lines)
        {
            System.Console.WriteLine(line);
        }
    }
}