using CountIt.ConsoleApp.Services;

namespace CountIt.TestSupport;

public class OutputWriterCapturer : IOutputWriter
{
    public List<string> CapturedLines { get; } = new List<string>();

    public void WriteLine(string line)
    {
        CapturedLines.Add(line);
    }
}