namespace AdventOfCode2023.Days;

/// <summary>
/// Advent day 6 class.
/// </summary>
/// <seealso cref="AdventDay"/>
public class Day06 : AdventDay
{
    private readonly (int time, int distance)[] raceRecords;

    /// <summary>
    /// Initializes a new instance of the <see cref="Day06"/> class.
    /// </summary>
    /// <param name="isExample">Flag indicating whether the example input should be used..</param>
    public Day06(bool isExample = false) : base(6, isExample)
    {
        var lineNumbers = this.PuzzleInput
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Split(":", StringSplitOptions.TrimEntries)[1])
            .ToArray();

        var times = lineNumbers[0]
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        var distances = lineNumbers[1]
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        this.raceRecords = times.Zip(distances).ToArray();
    }

    /// <summary>
    /// Solves the first part of the advent's puzzle.
    /// </summary>
    /// <returns>
    /// Result for the first part of the puzzle.
    /// </returns>
    public override string SolveFirstPart()
    {
        var multipliedNumberOfWinningWays = 1;

        foreach (var race in this.raceRecords)
        {
            var winningWaysCount = 0;

            for (var buttonHold = 1; buttonHold < race.time; buttonHold++)
            {
                var remainingRaceTime = race.time - buttonHold;
                var traveledDistance = buttonHold * remainingRaceTime;

                if (traveledDistance > race.distance) winningWaysCount++;

            }

            multipliedNumberOfWinningWays *= winningWaysCount;
        }

        return $"{multipliedNumberOfWinningWays}";
    }

    /// <summary>
    /// Solves the second part of the advent's puzzle.
    /// </summary>
    /// <returns>
    /// Result for the second part of the puzzle.
    /// </returns>
    public override string SolveSecondPart()
    {
        var actualRaceTime = long.Parse(string.Join(string.Empty, this.raceRecords.Select(r => r.time)));
        var actualRaceDistance = long.Parse(string.Join(string.Empty, this.raceRecords.Select(r => r.distance)));

        var winningWaysCount = 0;

        for (var buttonHold = 1; buttonHold < actualRaceTime; buttonHold++)
        {
            var remainingRaceTime = actualRaceTime - buttonHold;
            var traveledDistance = buttonHold * remainingRaceTime;

            if (traveledDistance > actualRaceDistance) winningWaysCount++;
        }

        return $"{winningWaysCount}";
    }
}