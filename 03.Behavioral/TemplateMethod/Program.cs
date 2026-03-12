using TemplateMethod.Miners;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Template Method Pattern Example (Data Mining) ===\n");

        Console.WriteLine("--- Mining PDF ---");
        DataMiner pdfMiner = new PdfDataMiner();
        pdfMiner.Mine("report.pdf");

        Console.WriteLine("\n--- Mining CSV ---");
        DataMiner csvMiner = new CsvDataMiner();
        csvMiner.Mine("data.csv");
    }
}
