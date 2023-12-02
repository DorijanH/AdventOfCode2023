using AdventOfCode2023.Days;

namespace AdventOfCode2023.Tests.Days;

/// <summary>
/// Advent day 2 tests class.
/// </summary>
/// <seealso cref="TestBase"/>
public class Day02Tests : TestBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Day02Tests"/> class.
    /// </summary>
    public Day02Tests() : base(new Day02(true))
    {
    }

    /// <summary>
    /// Tests that the result of the first part of the puzzle is the same as the provided example result.
    /// </summary>
    [Fact]
    protected override void FirstPart()
    {
        Assert.Equal("8", this.AdventDay.SolveFirstPart());
    }

    /// <summary>
    /// Tests that the result of the second part of the puzzle is the same as the provided example result.
    /// </summary>
    [Fact]
    protected override void SecondPart()
    {
        Assert.Equal("2286", this.AdventDay.SolveSecondPart());
    }
}