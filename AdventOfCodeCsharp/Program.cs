using AdventOfCodeCsharp;

int validLines = 0;

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
        if (string.IsNullOrWhiteSpace(line)) continue;

        try
        {
            var numbers = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToList();

            if (Validator.IsValidRow(numbers))
            {
                validLines++;
            }
            else
            {
                bool dampenedSafe = false;
                for (int i = 0; i < numbers.Count; i++)
                {
                    var modified = new List<int>(numbers);
                    modified.RemoveAt(i);

                    if (Validator.IsValidRow(modified))
                    {
                        dampenedSafe = true;
                        break;
                    }
                }

                if (dampenedSafe)
                {
                    validLines++;
                }
                else
                {
                    Console.WriteLine($"Unsafe row: {line}");
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine($"Invalid line format: {line}");
        }
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

Console.WriteLine($"Total valid lines with Problem Dampener: {validLines}");
