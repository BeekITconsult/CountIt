namespace CountIt.ConsoleApp.Services;

public class ConsoleOutputWriter : IOutputWriter
{
    public void WriteLine(string line)
    {
        Console.WriteLine(line);
    }
}