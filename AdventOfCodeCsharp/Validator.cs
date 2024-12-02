namespace AdventOfCodeCsharp;
public static class Validator
{
    public static bool IsValidRow(List<int> numbers)
    {
        if (numbers.Count < 2) return true;

        bool ascending = numbers[1] > numbers[0];

        for (int i = 1; i < numbers.Count; i++)
        {
            int diff = numbers[i] - numbers[i - 1];

            if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
            {
                return false;
            }

            if (ascending && diff < 0) return false;
            if (!ascending && diff > 0) return false;
        }

        return true;
    }

}
