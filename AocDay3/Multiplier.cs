using System.Text.RegularExpressions;

namespace AocDay3;
public static class Multiplier
{
    private static int Mul(int x, int y) => x * y;
    public static int AdderMultiplierForLine(string line)
    {
        var lineTotal = 0;

        string pattern = @"mul\((\d+),(\d+)\)";

        var matches = Regex.Matches(line, pattern);
        foreach (Match match in matches)
        {
            lineTotal += Mul(int.Parse(match.Groups[1].Value!), int.Parse(match.Groups[2].Value!));
        }

        return lineTotal;
    }
}