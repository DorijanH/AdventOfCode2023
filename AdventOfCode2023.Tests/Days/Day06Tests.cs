using AdventOfCode2023.Days;

namespace AdventOfCode2023.Tests.Days;

/// <summary>
/// Advent day 6 tests class.
/// </summary>
/// <seealso cref="TestBase"/>
public class Day06Tests : TestBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Day06Tests"/> class.
    /// </summary>
    public Day06Tests() : base(new Day06(true))
    {
    }

    /// <summary>
    /// Tests that the result of the first part of the puzzle is the same as the provided example result.
    /// </summary>
    [Fact]
    protected override void FirstPart()
    {
        Assert.Equal("288", this.AdventDay.SolveFirstPart());
    }

    /// <summary>
    /// Tests that the result of the second part of the puzzle is the same as the provided example result.
    /// </summary>
    [Fact]
    protected override void SecondPart()
    {
        Assert.Equal("71503", this.AdventDay.SolveSecondPart());
    }
}