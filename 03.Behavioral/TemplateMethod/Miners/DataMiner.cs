using System;

namespace TemplateMethod.Miners;

/// <summary>
/// The Abstract Class defines a template method that contains a skeleton of some
/// algorithm, composed of calls to (usually) abstract primitive operations.
///
/// Concrete subclasses should implement these operations, but leave the
/// template method itself intact.
/// </summary>
public abstract class DataMiner
{
    // The template method defines the skeleton of an algorithm.
    public void Mine(string path)
    {
        OpenFile(path);
        ExtractData();
        ParseData();
        AnalyzeData();
        SendReport();
        CloseFile();
    }

    // These operations already have implementations.
    protected void AnalyzeData()
    {
        Console.WriteLine("DataMiner: Analyzing data...");
    }

    protected void SendReport()
    {
        Console.WriteLine("DataMiner: Sending report...");
    }

    // These operations have to be implemented in subclasses.
    protected abstract void OpenFile(string path);

    protected abstract void ExtractData();

    protected abstract void ParseData();

    protected abstract void CloseFile();
}
