using AdventOfCode2023.Days;

namespace AdventOfCode2023.Tests.Days;

/// <summary>
/// Advent day 11 tests class.
/// </summary>
/// <seealso cref="TestBase"/>
public class Day11Tests : TestBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Day11Tests"/> class.
    /// </summary>
    public Day11Tests() : base(new Day11(true))
    {
    }

    /// <summary>
    /// Tests that the result of the first part of the puzzle is the same as the provided example result.
    /// </summary>
    [Fact]
    protected override void FirstPart()
    {
        Assert.Equal("374", this.AdventDay.SolveFirstPart());
    }

    /// <summary>
    /// Tests that the result of the second part of the puzzle is the same as the provided example result.
    /// </summary>
    [Fact]
    protected override void SecondPart()
    {
        Assert.Equal("8410", this.AdventDay.SolveSecondPart());
    }
}