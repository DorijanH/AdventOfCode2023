﻿using AdventOfCode2023.Days;

namespace AdventOfCode2023.Tests.Days;

/// <summary>
/// Advent day 4 tests class.
/// </summary>
/// <seealso cref="TestBase"/>
public class Day04Tests : TestBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Day04Tests"/> class.
    /// </summary>
    public Day04Tests() : base(new Day04(true))
    {
    }

    /// <summary>
    /// Tests that the result of the first part of the puzzle is the same as the provided example result.
    /// </summary>
    [Fact]
    protected override void FirstPart()
    {
        Assert.Equal("13", this.AdventDay.SolveFirstPart());
    }

    /// <summary>
    /// Tests that the result of the second part of the puzzle is the same as the provided example result.
    /// </summary>
    [Fact]
    protected override void SecondPart()
    {
        Assert.Equal("30", this.AdventDay.SolveSecondPart());
    }
}