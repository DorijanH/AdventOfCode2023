namespace AdventOfCode2023.Days;

/// <summary>
/// Advent day 8 class.
/// </summary>
/// <seealso cref="AdventDay"/>
public class Day08 : AdventDay
{
    private readonly string directions;
    private readonly Dictionary<string, (string leftNode, string rightNode)> tree = new ();

    /// <summary>
    /// Initializes a new instance of the <see cref="Day08"/> class.
    /// </summary>
    /// <param name="isExample">Flag indicating whether the example input should be used..</param>
    public Day08(bool isExample = false) : base(8, isExample)
    {
        var lines = this.PuzzleInput
            .Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];

            if (i == 0) this.directions = line;
            else
            {
                var lineParts = line.Split("=", StringSplitOptions.TrimEntries);
                var parentNode = lineParts[0];
                var possibleNodes = lineParts[1].Split(",", StringSplitOptions.TrimEntries);

                var leftNode = possibleNodes[0].Replace("(", "");
                var rightNode = possibleNodes[1].Replace(")", "");

                this.tree.Add(parentNode, (leftNode, rightNode));
            }
        }
    }

    /// <summary>
    /// Solves the first part of the advent's puzzle.
    /// </summary>
    /// <returns>
    /// Result for the first part of the puzzle.
    /// </returns>
    public override string SolveFirstPart()
    {
        var foundEnd = false;
        var stepsRequired = 0;

        var endingNode = "ZZZ";
        var currentNode = "AAA";

        while (!foundEnd)
        {
            foreach (var direction in this.directions)
            {
                var currentTreeNode = this.tree[currentNode];

                currentNode = direction switch
                {
                    'R' => currentTreeNode.rightNode,
                    'L' => currentTreeNode.leftNode,
                    _ => throw new ArgumentOutOfRangeException(nameof(direction))
                };

                stepsRequired++;

                if (currentNode == endingNode)
                {
                    foundEnd = true;
                    break;
                }
            }
        }

        return $"{stepsRequired}";
    }

    /// <summary>
    /// Solves the second part of the advent's puzzle.
    /// </summary>
    /// <returns>
    /// Result for the second part of the puzzle.
    /// </returns>
    public override string SolveSecondPart()
    {
        var endingNodeSuffix = 'Z';

        var startingNodes = this.tree.Keys.Where(k => k.EndsWith('A')).ToList();
        var stepsForNodes = new List<long>();
        
        for (var i = 0; i < startingNodes.Count; i++)
        {
            var currentNode = startingNodes[i];

            var foundEnd = false;
            long stepsRequired = 0;

            while (!foundEnd)
            {
                foreach (var direction in this.directions)
                {
                    var currentTreeNode = this.tree[currentNode];

                    currentNode = direction switch
                    {
                        'R' => currentTreeNode.rightNode,
                        'L' => currentTreeNode.leftNode,
                        _ => throw new ArgumentOutOfRangeException(nameof(direction))
                    };

                    stepsRequired++;

                    if (currentNode.EndsWith(endingNodeSuffix))
                    {
                        foundEnd = true;
                        break;
                    }
                }
            }

            stepsForNodes.Add(stepsRequired);
        }

        var totalStepsRequired = stepsForNodes.Aggregate(1L, CalculateLcm);
        return $"{totalStepsRequired}";
    }

    /// <summary>
    /// Calculates the least common multiple.
    /// </summary>
    /// <param name="a">a.</param>
    /// <param name="b">The b.</param>
    /// <returns>
    /// Calculated least common multiple.
    /// </returns>
    private static long CalculateLcm(long a, long b)
    {
        return a / CalculateGcf(a, b) * b;
    }

    /// <summary>
    /// Calculates the greatest common factor.
    /// </summary>
    /// <param name="a">a.</param>
    /// <param name="b">The b.</param>
    /// <returns>
    /// Calculated greatest common factor.
    /// </returns>
    private static long CalculateGcf(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }
}