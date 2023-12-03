using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Days;

/// <summary>
/// Advent day 3 class.
/// </summary>
/// <seealso cref="AdventDay"/>
public class Day03 : AdventDay
{
    private readonly string[] lines;

    private readonly Regex symbolRegex = new ("[^\\d.]");
    private readonly Regex numberRegex = new ("\\d+");

    /// <summary>
    /// Initializes a new instance of the <see cref="Day03"/> class.
    /// </summary>
    /// <param name="isExample">Flag indicating whether the example input should be used..</param>
    public Day03(bool isExample = false) : base(3, isExample)
    {
        this.lines = this.PuzzleInput
            .Split('\n', StringSplitOptions.TrimEntries)
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
        var partNumberSum = 0;

        var pointAdjacencyMap = new Dictionary<Point, List<int>>();

        // First go through the input an make a listing of all numbers and their adjacent locations
        for (var i = 0; i < lines.Length; i++)
        {
            var matches = numberRegex.Matches(lines[i]);

            foreach (Match match in matches)
            {
                var matchedNumber = int.Parse(match.Value);

                this.RecordAdjacentCoordinates(match.Index - 1, (match.Index + match.Length), i - 1, i + 1, matchedNumber, pointAdjacencyMap);
            }
        }

        // Then, go through the input and look for symbols
        for (var i = 0; i < lines.Length; i++)
        {
            var matches = symbolRegex.Matches(lines[i]);

            foreach (Match match in matches)
            {
                var matchPoint = new Point(match.Index, i);

                foreach (var adjacentNumber in pointAdjacencyMap[matchPoint])
                {
                    partNumberSum += adjacentNumber;
                }
            }
        }

        return $"{partNumberSum}";
    }

    /// <summary>
    /// Solves the second part of the advent's puzzle.
    /// </summary>
    /// <returns>
    /// Result for the second part of the puzzle.
    /// </returns>
    public override string SolveSecondPart()
    {
        var gearRatioSum = 0;

        var pointAdjacencyMap = new Dictionary<Point, List<int>>();

        // First go through the input an make a listing of all numbers and their adjacent locations
        for (var i = 0; i < lines.Length; i++)
        {
            var matches = numberRegex.Matches(lines[i]);

            foreach (Match match in matches)
            {
                var matchedNumber = int.Parse(match.Value);

                this.RecordAdjacentCoordinates(match.Index - 1, (match.Index + match.Length), i - 1, i + 1, matchedNumber, pointAdjacencyMap);
            }
        }

        // Then, go through the input and look for symbols
        for (var i = 0; i < lines.Length; i++)
        {
            var matches = symbolRegex.Matches(lines[i]);

            foreach (Match match in matches)
            {
                var matchPoint = new Point(match.Index, i);

                var adjacentNumbers = pointAdjacencyMap[matchPoint];
                if (adjacentNumbers.Count == 2)
                {
                    gearRatioSum += adjacentNumbers[0] * adjacentNumbers[1];
                }
            }
        }

        return $"{gearRatioSum}";
    }

    /// <summary>
    /// Records the adjacent coordinates.
    /// </summary>
    /// <param name="fromX">From x.</param>
    /// <param name="toX">To x.</param>
    /// <param name="fromY">From y.</param>
    /// <param name="toY">To y.</param>
    /// <param name="number">The number.</param>
    /// <param name="map">Point adjacency map.</param>
    private void RecordAdjacentCoordinates(int fromX, int toX, int fromY, int toY, int number, IDictionary<Point, List<int>> map)
    {
        for (var x = fromX; x <= toX; x++)
        {
            for (var y = fromY; y <= toY; y++)
            {
                var point = new Point(x, y);

                if (!map.ContainsKey(point))
                {
                    map.Add(point, new List<int> { number });
                }
                else
                {
                    map[point].Add(number);
                }
            }
        }
    }
}