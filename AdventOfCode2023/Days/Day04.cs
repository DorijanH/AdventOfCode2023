namespace AdventOfCode2023.Days;

/// <summary>
/// Advent day 4 class.
/// </summary>
/// <seealso cref="AdventDay"/>
public class Day04 : AdventDay
{
    private readonly (string winningNumbersString, string elfNumbersString)[] cards;

    /// <summary>
    /// Initializes a new instance of the <see cref="Day04"/> class.
    /// </summary>
    /// <param name="isExample">Flag indicating whether the example input should be used..</param>
    public Day04(bool isExample = false) : base(4, isExample)
    {
        this.cards = this.PuzzleInput
            .Split('\n', StringSplitOptions.TrimEntries)
            .Select(line => line.Remove(0, line.IndexOf(':') + 1))
            .Select(line => line.Split("|", StringSplitOptions.TrimEntries))
            .Select(lineParts => (lineParts[0], lineParts[1]))
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
        var cardPileWorth = 0;

        foreach (var card in cards)
        {
            var elfsWinningNumbers = this.GetWinningNumbers(card.winningNumbersString, card.elfNumbersString);
            var cardWorth = this.CalculateCardWorth(elfsWinningNumbers.Length);

            cardPileWorth += cardWorth;
        }

        return $"{cardPileWorth}";
    }

    /// <summary>
    /// Solves the second part of the advent's puzzle.
    /// </summary>
    /// <returns>
    /// Result for the second part of the puzzle.
    /// </returns>
    public override string SolveSecondPart()
     {
        var wonCardCopiesMap = new Dictionary<int, int>();

        for (var i = 1; i <= this.cards.Length; i++)
        {
            var card = this.cards[i - 1];
            var elfsMatchingNumbersCount = this.GetWinningNumbers(card.winningNumbersString, card.elfNumbersString).Length;

            if (!wonCardCopiesMap.ContainsKey(i))
            {
                wonCardCopiesMap.Add(i, 1);
            }
            else
            {
                wonCardCopiesMap[i]++;
            }
           
            for (var y = i + 1; y <= i + elfsMatchingNumbersCount; y++)
            {
                wonCardCopiesMap.TryGetValue(i, out var multiplier);

                if (!wonCardCopiesMap.ContainsKey(y))
                {
                    wonCardCopiesMap.Add(y, multiplier);
                }
                else
                {
                    wonCardCopiesMap[y] += multiplier;
                }
            }
        }

        return $"{wonCardCopiesMap.Values.Sum()}";
    }

    /// <summary>
    /// Gets the winning numbers.
    /// </summary>
    /// <param name="winningNumbersString">The winning numbers string.</param>
    /// <param name="elfNumbersString">The elf numbers string.</param>
    /// <returns>
    /// An array containing the winning numbers.
    /// </returns>
    private int[] GetWinningNumbers(string winningNumbersString, string elfNumbersString)
    {
        var winningNumbers = winningNumbersString
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var elfNumbers = elfNumbersString
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        return winningNumbers.Intersect(elfNumbers).ToArray();
    }

    /// <summary>
    /// Calculates the card worth.
    /// </summary>
    /// <param name="winningNumbersCount">The winning numbers count.</param>
    /// <returns>
    /// Calculated card worth.
    /// </returns>
    private int CalculateCardWorth(int winningNumbersCount)
    {
        return (int) Math.Pow(2, winningNumbersCount - 1);
    }
}