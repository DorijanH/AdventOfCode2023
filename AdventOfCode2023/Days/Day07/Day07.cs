namespace AdventOfCode2023.Days.Day07;

/// <summary>
/// Advent day 7 class.
/// </summary>
/// <seealso cref="AdventDay"/>
public class Day07 : AdventDay
{
    private readonly (string cards, int bid)[] hands;

    /// <summary>
    /// Initializes a new instance of the <see cref="Day07"/> class.
    /// </summary>
    /// <param name="isExample">Flag indicating whether the example input should be used..</param>
    public Day07(bool isExample = false) : base(7, isExample)
    {
        this.hands = this.PuzzleInput
            .Split('\n', StringSplitOptions.TrimEntries)
            .Select(line => line.Split(" ", StringSplitOptions.RemoveEmptyEntries))
            .Select(lineParts => (lineParts[0], int.Parse(lineParts[1])))
            .ToArray();
    }

    /// <summary>
    /// Solves the first part of the advent's puzzle.
    /// </summary>
    /// <returns>
    /// Result for the first part of the puzzle.
    /// </returns>
    public override string SolveFirstPart()
    {
        var orderedHands = this.hands.OrderBy(h => h.cards, new CamelCardsComparer()).ToArray();

        var totalWinnings = 0;

        for (var i = 0; i < this.hands.Length; i++)
        {
            totalWinnings += orderedHands[i].bid * (i + 1);
        }

        return $"{totalWinnings}";
    }

    /// <summary>
    /// Solves the second part of the advent's puzzle.
    /// </summary>
    /// <returns>
    /// Result for the second part of the puzzle.
    /// </returns>
    public override string SolveSecondPart()
    {
        var orderedHands = this.hands.OrderBy(h => h.cards, new WildcardCamelCardsComparer()).ToArray();

        var totalWinnings = 0;

        for (var i = 0; i < this.hands.Length; i++)
        {
            totalWinnings += orderedHands[i].bid * (i + 1);
        }

        return $"{totalWinnings}";
    }
}