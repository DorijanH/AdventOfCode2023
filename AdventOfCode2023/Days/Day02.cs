namespace AdventOfCode2023.Days;

/// <summary>
/// Advent day 2 class.
/// </summary>
/// <seealso cref="AdventDay"/>
public class Day02 : AdventDay
{
    private readonly (int gameId, string revealedCubes)[] games;

    private const string GameIdPrefix = "Game ";
    private readonly Dictionary<string, int> availableCubesMap = new()
    {
        { "red", 12 }, { "green", 13 }, { "blue", 14 }
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="Day02"/> class.
    /// </summary>
    /// <param name="isExample">Flag indicating whether the example input should be used..</param>
    public Day02(bool isExample = false) : base(2, isExample)
    {
        this.games = this.PuzzleInput
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Split(": ", StringSplitOptions.TrimEntries))
            .Select(lineParts => (int.Parse(lineParts[0].Replace(GameIdPrefix, "")), lineParts[1]))
            .ToArray();
    }

    /// <summary>
    /// Solves the first part of the advent's puzzle.
    /// </summary>
    /// <returns>
    /// Result for the first part of the puzzle.
    /// </returns>
    public override string SolveFirstPart()
    {
        var possibleGameIdSum = 0;

        foreach (var game in this.games)
        {
            var isPossible = true;

            var revealedCubeParts = GetRevealedCubeParts(game.revealedCubes);
            foreach (var revealedCube in revealedCubeParts)
            {
                var (cubeNumber, cubeColor) = ParseCubeInformation(revealedCube);

                // If the game would be impossible continue to the next game
                if (this.availableCubesMap[cubeColor] < cubeNumber)
                {
                    isPossible = false;
                    break;
                }
            }

            if (isPossible) possibleGameIdSum += game.gameId;
        }

        return $"{possibleGameIdSum}";
    }

    /// <summary>
    /// Solves the second part of the advent's puzzle.
    /// </summary>
    /// <returns>
    /// Result for the second part of the puzzle.
    /// </returns>
    public override string SolveSecondPart()
    {
        var powerSum = 0;

        foreach (var game in this.games)
        {
            var fewestMap = new Dictionary<string, int>
            {
                { "blue", 0 }, { "red", 0 }, { "green", 0 }
            };

            var revealedCubeParts = GetRevealedCubeParts(game.revealedCubes);
            foreach (var revealedCube in revealedCubeParts)
            {
                var (cubeNumber, cubeColor) = ParseCubeInformation(revealedCube);

                if (fewestMap[cubeColor] < cubeNumber)
                {
                    fewestMap[cubeColor] = cubeNumber;
                }
            }

            powerSum += fewestMap["blue"] * fewestMap["red"] * fewestMap["green"];
        }

        return $"{powerSum}";
    }

    /// <summary>
    /// Gets the revealed cube parts.
    /// </summary>
    /// <param name="gameRevealedCubes">The game revealed cubes.</param>
    /// <returns>
    /// An array containing each revealed cube and its revealed number.
    /// </returns>
    private static string[] GetRevealedCubeParts(string gameRevealedCubes)
    {
        var flatList = gameRevealedCubes.Replace(";", ",");

        return flatList.Split(",", StringSplitOptions.TrimEntries);
    }

    /// <summary>
    /// Parses the cube information.
    /// </summary>
    /// <param name="revealedCube">The revealed cube.</param>
    /// <returns>
    /// Tuple containing number and color of a cube that was revealed.
    /// </returns>
    private static (int cubeNumber, string cubeColor) ParseCubeInformation(string revealedCube)
    {
        var parts = revealedCube.Split(" ", StringSplitOptions.TrimEntries);
        var cubeNumber = int.Parse(parts[0]);
        var cubeColor = parts[1];

        return (cubeNumber, cubeColor);
    }
}