using AdventOfCode2023.Days;

namespace AdventOfCode2023.Tests.Days;

/// <summary>
/// Advent day 3 tests class.
/// </summary>
/// <seealso cref="TestBase"/>
public class Day03Tests : TestBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Day03Tests"/> class.
    /// </summary>
    public Day03Tests() : base(new Day03(true))
    {
    }

    /// <summary>
    /// Tests that the result of the first part of the puzzle is the same as the provided example result.
    /// </summary>
    [Fact]
    protected override void FirstPart()
    {
        Assert.Equal("4361", this.AdventDay.SolveFirstPart());
    }

    /// <summary>
    /// Tests that the result of the second part of the puzzle is the same as the provided example result.
    /// </summary>
    [Fact]
    protected override void SecondPart()
    {
        Assert.Equal("467835", this.AdventDay.SolveSecondPart());
    }
}