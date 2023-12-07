namespace AdventOfCode2023.Days.Day07;

/// <summary>
/// Camel cards comparer.
/// </summary>
/// <seealso cref="IComparer{T}" />
public class CamelCardsComparer : IComparer<string>
{
    private readonly char[] cardOrderedStrength = {
        'A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2'
    };

    public int Compare(string? x, string? y)
    {
        var xHandType = this.DetermineHandType(x!);
        var yHandType = this.DetermineHandType(y!);

        if (xHandType > yHandType) return 1;
        if (xHandType < yHandType) return -1;

        for (var i = 0; i < x.Length; i++)
        {
            var firstCard = x[i];
            var secondCard = y[i];

            var firstCardRelativeStrength = Array.IndexOf(cardOrderedStrength, firstCard);
            var secondCardRelativeStrength = Array.IndexOf(cardOrderedStrength, secondCard);

            if (firstCardRelativeStrength < secondCardRelativeStrength) return 1;
            if (firstCardRelativeStrength > secondCardRelativeStrength) return -1;
        }

        return -1;
    }

    /// <summary>
    /// Determines the type of the hand.
    /// </summary>
    /// <param name="hand">The hand.</param>
    /// <returns>
    /// Enum value representing the hand type
    /// </returns>
    private HandType DetermineHandType(string hand)
    {
        var groupings = hand.GroupBy(c => c).ToArray();

        var fiveOfAKind = groupings.Count(g => g.Count() == 5) == 1;
        if (fiveOfAKind) return HandType.FiveOfAKind;

        var fourOfAKind = groupings.Count(g => g.Count() == 4) == 1;
        if (fourOfAKind) return HandType.FourOfAKind;

        var isOnePair = groupings.Count(g => g.Count() == 2) == 1;
        var fullHouse = groupings.Count(g => g.Count() == 3) == 1 && isOnePair;
        if (fullHouse) return HandType.FullHouse;

        var threeOfAKind = groupings.Count(g => g.Count() == 3) == 1 && groupings.All(g => g.Count() != 2);
        if (threeOfAKind) return HandType.ThreeOfAKind;

        var isTwoPair = groupings.Count(g => g.Count() == 2) == 2;
        if (isTwoPair) return HandType.TwoPair;

        if (isOnePair) return HandType.OnePair;

        return HandType.HighCard;
    }
}

