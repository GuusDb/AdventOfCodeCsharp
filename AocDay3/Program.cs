using AocDay3;
var total = 0;

try
{
    string filePath = Path.Combine("..\\..\\..\\text.txt");
    if (!File.Exists(filePath))
    {
        Console.WriteLine($"File not found: {filePath}");
        return;
    }

    using StreamReader sr = new StreamReader(filePath);
    string? line;

    while ((line = sr.ReadLine()) != null)
    {
        total += Multiplier.AdderMultiplierForLine(line);
    }
}
catch (Exception e)
{
    Console.WriteLine($"Exception: {e.Message}");
}
finally
{
    Console.WriteLine("Finished processing file.");
}

Console.WriteLine($"Total of the muiltiplication: {total}");
