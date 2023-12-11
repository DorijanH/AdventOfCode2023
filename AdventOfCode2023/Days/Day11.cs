using System.Drawing;

namespace AdventOfCode2023.Days;

/// <summary>
/// Advent day 11 class.
/// </summary>
/// <seealso cref="AdventDay"/>
public class Day11 : AdventDay
{
    private readonly string[] spaceImage;

    /// <summary>
    /// Initializes a new instance of the <see cref="Day11"/> class.
    /// </summary>
    /// <param name="isExample">Flag indicating whether the example input should be used..</param>
    public Day11(bool isExample = false) : base(11, isExample)
    {
        this.spaceImage = this.PuzzleInput
            .Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
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
        var sumOfTheShortestPaths = 0L;

        var starPositions = this.FindAll('#').ToList();

        foreach (var star1 in starPositions)
        {
            foreach (var star2 in starPositions)
            {
                if (star2 == star1) continue;

                var starDistance = this.DistanceBetween(star1, star2, 1);
                sumOfTheShortestPaths += starDistance;
            }
        }

        return $"{sumOfTheShortestPaths / 2}";
    }

    /// <summary>
    /// Solves the second part of the advent's puzzle.
    /// </summary>
    /// <returns>
    /// Result for the second part of the puzzle.
    /// </returns>
    public override string SolveSecondPart()
    {
        var sumOfTheShortestPaths = 0L;

        var starPositions = this.FindAll('#').ToList();

        foreach (var star1 in starPositions)
        {
            foreach (var star2 in starPositions)
            {
                if (star2 == star1) continue;

                var starDistance = this.DistanceBetween(star1, star2, 999_999);
                sumOfTheShortestPaths += starDistance;
            }
        }

        return $"{sumOfTheShortestPaths / 2}";
    }
    
    /// <summary>
    /// Finds all positions containing a given character.
    /// </summary>
    /// <param name="character">The character to find positions for.</param>
    /// <returns>
    /// An enumerable containing positions containing the given character.
    /// </returns>
    private IEnumerable<Point> FindAll(char character)
    {
        var characterPositions = new List<Point>();

        for (var i = 0; i < this.spaceImage.Length; i++)
        {
            for (var j = 0; j < this.spaceImage[i].Length; j++)
            {
                if (this.spaceImage[i][j] == character) characterPositions.Add(new Point(j, i));
            }
        }

        return characterPositions;
    }

    /// <summary>
    /// Calculates the distance between the stars.
    /// </summary>
    /// <param name="star1">The first star.</param>
    /// <param name="star2">The second star.</param>
    /// <param name="expansionCycles">The expansion cycles that have passed.</param>
    /// <returns>
    /// Calculated distance between the stars.
    /// </returns>
    private long DistanceBetween(Point star1, Point star2, int expansionCycles)
    {
        // Calculating row distance
        var lowestRow = Math.Min(star1.Y, star2.Y);
        var rowDistance = Math.Abs(star1.Y - star2.Y);

        var emptyRowsBetween = 0;
        for (var i = lowestRow + 1; i < lowestRow + rowDistance; i++)
        {
            if (this.spaceImage[i].All(c => c == '.')) emptyRowsBetween++;
        }

        var rowExpandedDistance = rowDistance + (emptyRowsBetween * expansionCycles);

        // Calculating column distance
        var lowestColumn = Math.Min(star1.X, star2.X);
        var columnDistance = Math.Abs(star1.X - star2.X);

        var emptyColumnsBetween = 0;
        for (var i = lowestColumn + 1; i < lowestColumn + columnDistance; i++)
        {
            if (this.spaceImage.All(image => image[i] == '.')) emptyColumnsBetween++;
        }

        var columnExpandedDistance = columnDistance + (emptyColumnsBetween * expansionCycles);

        return rowExpandedDistance + columnExpandedDistance;
    }
}