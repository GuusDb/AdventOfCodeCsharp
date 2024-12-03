using System.Text.RegularExpressions;

namespace AocDay3;
public static class Multiplier
{
    private static int Mul(int x, int y) => x * y;

    public static int AdderMultiplierForLine(string line)
    {
        var lineTotal = 0;
        var isEnabled = true;

        string mulPattern = @"mul\((\d+),(\d+)\)";
        string doPattern = @"\bdo\(\)";
        string dontPattern = @"\bdon't\(\)";

        string combinedPattern = $@"{mulPattern}|{doPattern}|{dontPattern}";
        var matches = Regex.Matches(line, combinedPattern);

        foreach (Match match in matches)
        {
            if (match.Groups[1].Success && match.Groups[2].Success)
            {
                if (isEnabled)
                {
                    int x = int.Parse(match.Groups[1].Value);
                    int y = int.Parse(match.Groups[2].Value);
                    lineTotal += Mul(x, y);
                }
            }
            else if (Regex.IsMatch(match.Value, doPattern))
            {
                isEnabled = true;
            }
            else if (Regex.IsMatch(match.Value, dontPattern))
            {
                isEnabled = false;
            }
        }

        return lineTotal;
    }
}
