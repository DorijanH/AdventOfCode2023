using AdventOfCode2023.Days.Day07;

namespace AdventOfCode2023.Tests.Days;

/// <summary>
/// Advent day 7 tests class.
/// </summary>
/// <seealso cref="TestBase"/>
public class Day07Tests : TestBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Day07Tests"/> class.
    /// </summary>
    public Day07Tests() : base(new Day07(true))
    {
    }

    /// <summary>
    /// Tests that the result of the first part of the puzzle is the same as the provided example result.
    /// </summary>
    [Fact]
    protected override void FirstPart()
    {
        Assert.Equal("6440", this.AdventDay.SolveFirstPart());
    }

    /// <summary>
    /// Tests that the result of the second part of the puzzle is the same as the provided example result.
    /// </summary>
    [Fact]
    protected override void SecondPart()
    {
        Assert.Equal("5905", this.AdventDay.SolveSecondPart());
    }
}