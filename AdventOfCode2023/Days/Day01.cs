using System.Text.RegularExpressions;

namespace AdventOfCode2023.Days;

/// <summary>
/// Advent day 1 class.
/// </summary>
/// <seealso cref="AdventDay"/>
public class Day01 : AdventDay
{
    private readonly string[] lines;

    private readonly Dictionary<string, string> wordDigitMap = new()
    {
        { "one", "1" }, { "two", "2" }, { "three", "3" }, { "four", "4" }, { "five", "5" }, { "six", "6" }, { "seven", "7" },
        { "eight", "8" }, { "nine", "9" }
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="Day01"/> class.
    /// </summary>
    /// <param name="isExample">Flag indicating whether the example input should be used..</param>
    public Day01(bool isExample = false) : base(1, isExample)
    {
        this.lines = this.PuzzleInput
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
    }

    /// <summary>
    /// Filters the digits from the input string.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns>
    /// String containing only digits.
    /// </returns>
    private static string FilterDigits(string input)
    {
        return new string(input.Where(char.IsDigit).ToArray());
    }

    /// <summary>
    /// Solves the first part of the advent's puzzle.
    /// </summary>
    /// <returns>
    /// Result for the first part of the puzzle.
    /// </returns>
    public override string SolveFirstPart()
    {
        var sum = 0;

        foreach (var line in this.lines)
        {
            var digitLine = FilterDigits(line);
            var calibrationValue = int.Parse($"{digitLine[0]}{digitLine[^1]}");

            sum += calibrationValue;
        }

        return $"{sum}";
    }

    /// <summary>
    /// Solves the second part of the advent's puzzle.
    /// </summary>
    /// <returns>
    /// Result for the second part of the puzzle.
    /// </returns>
    public override string SolveSecondPart()
    {
        var sum = 0;

        foreach (var line in this.lines)
        {
            var leftRegExp = new Regex("\\d|one|two|three|four|five|six|seven|eight|nine");
            var rightRegExp = new Regex("\\d|one|two|three|four|five|six|seven|eight|nine", RegexOptions.RightToLeft);

            var leftMatch = leftRegExp.Match(line).Value;
            var leftDigit = leftMatch.Length > 1 ? this.wordDigitMap[leftMatch] : leftMatch;

            var lastMatch = rightRegExp.Match(line).Value;
            var lastDigit = lastMatch.Length > 1 ? this.wordDigitMap[lastMatch] : lastMatch;

            var calibrationValue = int.Parse($"{leftDigit}{lastDigit}");

            sum += calibrationValue;
        }

        return $"{sum}";
    }
}