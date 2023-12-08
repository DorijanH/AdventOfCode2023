using AdventOfCode2023.Days;

namespace AdventOfCode2023.Tests.Days;

/// <summary>
/// Advent day 8 tests class.
/// </summary>
/// <seealso cref="TestBase"/>
public class Day08Tests : TestBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Day08Tests"/> class.
    /// </summary>
    public Day08Tests() : base(new Day08(true))
    {
    }

    /// <summary>
    /// Tests that the result of the first part of the puzzle is the same as the provided example result.
    /// </summary>
    [Fact]
    protected override void FirstPart()
    {
        Assert.Equal("6", this.AdventDay.SolveFirstPart());
    }

    /// <summary>
    /// Tests that the result of the second part of the puzzle is the same as the provided example result.
    /// </summary>
    [Fact]
    protected override void SecondPart()
    {
        Assert.Equal("6", this.AdventDay.SolveSecondPart());
    }
}