namespace AdventOfCode2023.Tests;

/// <summary>
/// Test base class.
/// </summary>
public abstract class TestBase
{
    /// <summary>
    /// Specific advent day.
    /// </summary>
    /// <seealso cref="AdventDay"/>
    protected AdventDay AdventDay;

    /// <summary>
    /// Initializes a new instance of the <see cref="TestBase"/> class.
    /// </summary>
    /// <param name="adventDay">Specific advent day.</param>
    protected TestBase(AdventDay adventDay)
    {
        this.AdventDay = adventDay;
    }

    /// <summary>
    /// Method that must be implemented which tests the first part of the puzzle.
    /// </summary>
    protected abstract void FirstPart();

    /// <summary>
    /// Method that must be implemented which tests the second part of the puzzle.
    /// </summary>
    protected abstract void SecondPart();
}