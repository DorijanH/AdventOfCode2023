using AdventOfCode2023.Days;

namespace AdventOfCode2023.Tests.Days;

/// <summary>
/// Advent day 5 tests class.
/// </summary>
/// <seealso cref="TestBase"/>
public class Day05Tests : TestBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Day05Tests"/> class.
    /// </summary>
    public Day05Tests() : base(new Day05(true))
    {
    }

    /// <summary>
    /// Tests that the result of the first part of the puzzle is the same as the provided example result.
    /// </summary>
    [Fact]
    protected override void FirstPart()
    {
        Assert.Equal("35", this.AdventDay.SolveFirstPart());
    }

    /// <summary>
    /// Tests that the result of the second part of the puzzle is the same as the provided example result.
    /// </summary>
    [Fact]
    protected override void SecondPart()
    {
        Assert.Equal("46", this.AdventDay.SolveSecondPart());
    }
}