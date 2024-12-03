using System.Text.RegularExpressions;

namespace AocDay3;

public static class Multiplier
{
    private static int Mul(int x, int y) => x * y;

    public static int AdderMultiplierForLine(string line)
    {
        var lineTotal = 0;

        var mulPattern = @"mul\((\d+),(\d+)\)";
        var controlPattern = @"do\(\)|don't\(\)";

        var IsMulEnabled = true;

        var combinedPattern = $@"{controlPattern}|{mulPattern}";

        var matches = Regex.Matches(line, combinedPattern);

        foreach (Match match in matches)
        {
            if (match.Value.StartsWith("do()"))
            {
                IsMulEnabled = true;
            }
            else if (match.Value.StartsWith("don't()"))
            {
                IsMulEnabled = false;
            }
            else if (IsMulEnabled && match.Value.StartsWith("mul("))
            {
                int x = int.Parse(match.Groups[1].Value!);
                int y = int.Parse(match.Groups[2].Value!);
                lineTotal += Mul(x, y);
            }
        }

        return lineTotal;
    }
}
