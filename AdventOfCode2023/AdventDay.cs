using System.Diagnostics;

namespace AdventOfCode2023;

/// <summary>
/// An abstract class representing an advent day.
/// </summary>
public abstract class AdventDay
{
    /// <summary>
    /// Gets or sets a value indicating whether the example input should be used.
    /// </summary>
    public bool IsExample { get; set; }

    /// <summary>
    /// Gets or sets the day.
    /// </summary>
    public string Day { get; set; }

    /// <summary>
    /// Gets the puzzle's input.
    /// </summary>
    public string PuzzleInput =>
        File.ReadAllText($"../../../../AdventOfCode2023/Inputs/Day{this.Day}{(this.IsExample ? "Example" : "")}.txt");

    /// <summary>
    /// Initializes a new instance of the <see cref="AdventDay"/> class.
    /// </summary>
    /// <param name="day">Number representing the day.</param>
    /// <param name="isExample">Flag indicating whether the example input should be used.</param>
    protected AdventDay(int day, bool isExample)
    {
        this.Day = day.ToString("D2");
        this.IsExample = isExample;
    }

    /// <summary>
    /// Solves the advent day.
    /// </summary>
    public void Solve()
    {
        var stopwatch = new Stopwatch();

        stopwatch.Start();
        var firstPart = this.SolveFirstPart();
        stopwatch.Stop();

        Console.WriteLine($"FIRST PART: (took {stopwatch.Elapsed:m\\:ss\\.fff})");
        Console.WriteLine(firstPart);

        Console.WriteLine();
        stopwatch.Reset();
        
        stopwatch.Start();
        var secondPart = this.SolveSecondPart();
        stopwatch.Stop();

        Console.WriteLine($"SECOND PART: (took {stopwatch.Elapsed:m\\:ss\\.fff})");
        Console.WriteLine(secondPart);
    }

    /// <summary>
    /// Solves the first part of the advent's puzzle.
    /// </summary>
    /// <returns>
    /// Result for the first part of the puzzle.
    /// </returns>
    public abstract string SolveFirstPart();

    /// <summary>
    /// Solves the second part of the advent's puzzle.
    /// </summary>
    /// <returns>
    /// Result for the second part of the puzzle.
    /// </returns>
    public abstract string SolveSecondPart();
}