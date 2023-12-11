using System.Drawing;

namespace AdventOfCode2023.Days;

/// <summary>
/// Advent day 10 class.
/// </summary>
/// <seealso cref="AdventDay"/>
public class Day10 : AdventDay
{
    private readonly string[] pipeDiagram;
    private readonly Point startingPosition;

    private readonly Dictionary<char, string[]> pipeDirectionMap = new()
    {
        { '|', new[] { "DOWN", "UP" } },
        { '-', new[] { "LEFT", "RIGHT" } },
        { 'L', new[] { "UP", "RIGHT" } },
        { 'J', new[] { "UP", "LEFT" } },
        { '7', new[] { "DOWN", "LEFT" } },
        { 'F', new[] { "DOWN", "RIGHT" } },
        { '.', new[] { string.Empty } },
        { 'S', new[] { "UP", "RIGHT", "DOWN", "LEFT" } }
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="Day10"/> class.
    /// </summary>
    /// <param name="isExample">Flag indicating whether the example input should be used..</param>
    public Day10(bool isExample = false) : base(10, isExample)
    {
        this.pipeDiagram = this.PuzzleInput
            .Split("\n", StringSplitOptions.TrimEntries)
            .ToArray();

        for (var i = 0; i < this.pipeDiagram.Length; i++)
        {
            var line = this.pipeDiagram[i];
            var startingPositionIndex = line.IndexOf('S');

            if (startingPositionIndex != -1)
            {
                this.startingPosition = new Point(startingPositionIndex, i);
            }
        }
    }

    /// <summary>
    /// Solves the first part of the advent's puzzle.
    /// </summary>
    /// <returns>
    /// Result for the first part of the puzzle.
    /// </returns>
    public override string SolveFirstPart()
    {
        var loopSteps = 1L;

        var currentPosition = this.startingPosition;
        var previousPosition = this.startingPosition;

        while (true)
        {
            var upPosition = currentPosition with { Y = currentPosition.Y - 1 };
            var rightPosition = currentPosition with { X = currentPosition.X + 1 };
            var downPosition = currentPosition with { Y = currentPosition.Y + 1 };
            var leftPosition = currentPosition with { X = currentPosition.X - 1 };

            var nextPosition = this.DetermineNextPosition(upPosition, rightPosition, downPosition, leftPosition, previousPosition, currentPosition);

            if (nextPosition == this.startingPosition)
            {
                break;
            }
            
            loopSteps++;
            previousPosition = currentPosition;
            currentPosition = nextPosition ?? previousPosition;
        }

        return $"{loopSteps / 2}";
    }

    /// <summary>
    /// Solves the second part of the advent's puzzle.
    /// </summary>
    /// <returns>
    /// Result for the second part of the puzzle.
    /// </returns>
    public override string SolveSecondPart()
    {
        var loopVertices = new List<Point>
        {
            this.startingPosition
        };

        var currentPosition = this.startingPosition;
        var previousPosition = this.startingPosition;

        // 1st: Get the loop vertices
        while (true)
        {
            var upPosition = currentPosition with { Y = currentPosition.Y - 1 };
            var rightPosition = currentPosition with { X = currentPosition.X + 1 };
            var downPosition = currentPosition with { Y = currentPosition.Y + 1 };
            var leftPosition = currentPosition with { X = currentPosition.X - 1 };

            var nextPosition = this.DetermineNextPosition(upPosition, rightPosition, downPosition, leftPosition, previousPosition, currentPosition);

            if (nextPosition == this.startingPosition)
            {
                break;
            }
            
            previousPosition = currentPosition;
            currentPosition = nextPosition ?? previousPosition;

            loopVertices.Add(currentPosition);
        }


        // 2nd: Calculate the polygon area
        var polygonArea = this.ShoelaceFormula(loopVertices);

        return $"{(4 * polygonArea - 2 * loopVertices.Count + 4) / 4}";
    }

    /// <summary>
    /// Determines the next position.
    /// </summary>
    /// <param name="upPosition">The up position.</param>
    /// <param name="rightPosition">The right position.</param>
    /// <param name="downPosition">The down position.</param>
    /// <param name="leftPosition">The left position.</param>
    /// <param name="previousPosition">The previous position.</param>
    /// <param name="currentPosition">The current position.</param>
    /// <returns>
    /// Determined next position.
    /// </returns>
    private Point? DetermineNextPosition(Point upPosition, Point rightPosition, Point downPosition, Point leftPosition, Point previousPosition, Point currentPosition)
    {
        var currentPipe = this.pipeDiagram[currentPosition.Y][currentPosition.X];

        if (upPosition.Y >= 0 && this.pipeDirectionMap[currentPipe].Contains("UP"))
        {
            var upPipe = this.pipeDiagram[upPosition.Y][upPosition.X];
            if (upPosition != previousPosition && this.pipeDirectionMap[upPipe].Contains("DOWN"))
            {
                return upPosition;
            }
        }

        if (rightPosition.X < this.pipeDiagram[0].Length && this.pipeDirectionMap[currentPipe].Contains("RIGHT"))
        {
            var rightPipe = this.pipeDiagram[rightPosition.Y][rightPosition.X];
            if (rightPosition != previousPosition && this.pipeDirectionMap[rightPipe].Contains("LEFT"))
            {
                return rightPosition;
            }
        }

        if (downPosition.Y < this.pipeDiagram.Length && this.pipeDirectionMap[currentPipe].Contains("DOWN"))
        {
            var downPipe = this.pipeDiagram[downPosition.Y][downPosition.X];
            if (downPosition != previousPosition && this.pipeDirectionMap[downPipe].Contains("UP"))
            {
                return downPosition;
            }
        }

        if (leftPosition.X >= 0 && this.pipeDirectionMap[currentPipe].Contains("LEFT"))
        {
            var leftPipe = this.pipeDiagram[leftPosition.Y][leftPosition.X];
            if (leftPosition != previousPosition && this.pipeDirectionMap[leftPipe].Contains("RIGHT"))
            {
                return leftPosition;
            }
        }

        return null;
    }

    /// <summary>
    /// Calculates the polygon area by using shoelace formula.
    /// </summary>
    /// <param name="polygonVertices">The polygon vertices.</param>
    /// <returns>
    /// Calculated polygon area.
    /// </returns>
    private double ShoelaceFormula(IList<Point> polygonVertices)
    {
        var n = polygonVertices.Count;
        var area = 0.0;

        for (var i = 0; i < n - 1; i++)
        {
            area += (polygonVertices[i].X * polygonVertices[i + 1].Y) -
                    (polygonVertices[i + 1].X * polygonVertices[i].Y);
        }

        area = Math.Abs(area + (polygonVertices[n - 1].X * polygonVertices[0].Y) -
                (polygonVertices[0].X * polygonVertices[n - 1].Y));

        return area / 2.0;

    }
}