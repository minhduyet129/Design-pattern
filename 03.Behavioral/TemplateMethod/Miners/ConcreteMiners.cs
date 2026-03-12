using System;

namespace TemplateMethod.Miners;

public class PdfDataMiner : DataMiner
{
    protected override void OpenFile(string path)
    {
        Console.WriteLine($"PdfDataMiner: Opening PDF file at {path}...");
    }

    protected override void ExtractData()
    {
        Console.WriteLine("PdfDataMiner: Extracting text from PDF...");
    }

    protected override void ParseData()
    {
        Console.WriteLine("PdfDataMiner: Parsing PDF data structure...");
    }

    protected override void CloseFile()
    {
        Console.WriteLine("PdfDataMiner: Closing PDF file.");
    }
}

public class CsvDataMiner : DataMiner
{
    protected override void OpenFile(string path)
    {
        Console.WriteLine($"CsvDataMiner: Opening CSV file at {path}...");
    }

    protected override void ExtractData()
    {
        Console.WriteLine("CsvDataMiner: Extracting rows from CSV...");
    }

    protected override void ParseData()
    {
        Console.WriteLine("CsvDataMiner: Parsing CSV columns...");
    }

    protected override void CloseFile()
    {
        Console.WriteLine("CsvDataMiner: Closing CSV file.");
    }
}
