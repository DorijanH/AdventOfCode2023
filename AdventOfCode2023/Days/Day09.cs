namespace AdventOfCode2023.Days;

/// <summary>
/// Advent day 9 class.
/// </summary>
/// <seealso cref="AdventDay"/>
public class Day09 : AdventDay
{
    private readonly long[][] reportHistories;

    /// <summary>
    /// Initializes a new instance of the <see cref="Day09"/> class.
    /// </summary>
    /// <param name="isExample">Flag indicating whether the example input should be used..</param>
    public Day09(bool isExample = false) : base(9, isExample)
    {
        this.reportHistories = this.PuzzleInput
            .Split("\r\n", StringSplitOptions.TrimEntries)
            .Select(ParseReportValues)
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
        var nextValuesSum = 0L;

        foreach (var reportHistoryValues in this.reportHistories)
        {
            var predictedNext = this.PredictNextValue(reportHistoryValues);

            nextValuesSum += predictedNext;
        }

        return $"{nextValuesSum}";
    }

    /// <summary>
    /// Solves the second part of the advent's puzzle.
    /// </summary>
    /// <returns>
    /// Result for the second part of the puzzle.
    /// </returns>
    public override string SolveSecondPart()
    {
        var previousValuesSum = 0L;

        foreach (var reportHistoryValues in this.reportHistories)
        {
            var predictedPrevious = this.PredictPreviousValue(reportHistoryValues);

            previousValuesSum += predictedPrevious;
        }

        return $"{previousValuesSum}";
    }

    /// <summary>
    /// Parses the report history values.
    /// </summary>
    /// <param name="report">The report.</param>
    /// <returns>
    /// An array of report history values.
    /// </returns>
    private long[] ParseReportValues(string report)
    {
        return report
            .Split(" ", StringSplitOptions.TrimEntries)
            .Select(long.Parse)
            .ToArray();
    }

    /// <summary>
    /// Calculates the difference between each history value.
    /// </summary>
    /// <param name="historyValues">The history values.</param>
    /// <returns>
    /// An array from the differences between each history value.
    /// </returns>
    private long[] ValueDifferences(long[] historyValues)
    {
        // Get pairs to calculate differences from
        var zippedNumbers = historyValues.Zip(historyValues.Skip(1));

        return zippedNumbers
            .Select(p => p.Second - p.First)
            .ToArray();
    }

    /// <summary>
    /// Predicts the next value in the report history.
    /// </summary>
    /// <param name="historyValues">The history values.</param>
    /// <returns>
    /// Predicted next value in the report history.
    /// </returns>
    private long PredictNextValue(long[] historyValues)
    {
        if (historyValues.All(n => n == 0L))
        {
            return 0;
        }

        var diffValues = ValueDifferences(historyValues);
        var predictedNext = PredictNextValue(diffValues);

        return predictedNext + historyValues.Last();
    }

    /// <summary>
    /// Predicts the previous value in the report history.
    /// </summary>
    /// <param name="historyValues">The history values.</param>
    /// <returns>
    /// Predicted previous value in the report history.
    /// </returns>
    private long PredictPreviousValue(long[] historyValues)
    {
        if (historyValues.All(n => n == 0L))
        {
            return 0;
        }

        var diffValues = ValueDifferences(historyValues);
        var predictedPrevious = PredictPreviousValue(diffValues);

        return historyValues.First() - predictedPrevious;
    }
}