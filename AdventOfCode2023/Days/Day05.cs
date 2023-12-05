namespace AdventOfCode2023.Days;

/// <summary>
/// Advent day 5 class.
/// </summary>
/// <seealso cref="AdventDay"/>
public class Day05 : AdventDay
{
    private readonly long[] seeds;

    private readonly List<string> seedToSoilLines = new();
    private readonly List<string> soilToFertilizerLines = new();
    private readonly List<string> fertilizerToWaterLines = new();
    private readonly List<string> waterToLightLines = new();
    private readonly List<string> lightToTemperatureLines = new();
    private readonly List<string> temperatureToHumidityLines = new();
    private readonly List<string> humidityToLocationLines = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Day05"/> class.
    /// </summary>
    /// <param name="isExample">Flag indicating whether the example input should be used..</param>
    public Day05(bool isExample = false) : base(5, isExample)
    {
        var lines = this.PuzzleInput.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

        int FillMapWithInputLines(IList<string> map, int startingLine, IReadOnlyList<string> lines)
        {
            int exitPosition = lines.Count;

            for (var j = startingLine; j < lines.Count; j++)
            {
                var line = lines[j];

                if (line.Contains("map"))
                {
                    exitPosition = j - 1;
                    break;
                }

                map.Add(line);
            }

            return exitPosition;
        }

        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];

            if (i == 0) seeds = this.GetSeeds(line);
            if (line.StartsWith("seed-to-soil"))
            {
                i = FillMapWithInputLines(seedToSoilLines, i + 1, lines);
            }
            else if (line.StartsWith("soil-to-fertilizer"))
            {
                i = FillMapWithInputLines(soilToFertilizerLines, i + 1, lines);
            }
            else if (line.StartsWith("fertilizer-to-water"))
            {
                i = FillMapWithInputLines(fertilizerToWaterLines, i + 1, lines);
            }
            else if (line.StartsWith("water-to-light"))
            {
                i = FillMapWithInputLines(waterToLightLines, i + 1, lines);
            }
            else if (line.StartsWith("light-to-temperature"))
            {
                i = FillMapWithInputLines(lightToTemperatureLines, i + 1, lines);
            }
            else if (line.StartsWith("temperature-to-humidity"))
            {
                i = FillMapWithInputLines(temperatureToHumidityLines, i + 1, lines);
            }
            else if (line.StartsWith("humidity-to-location"))
            {
                i = FillMapWithInputLines(humidityToLocationLines, i + 1, lines);
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
        var lowestLocation = long.MaxValue;

        foreach (var seed in this.seeds)
        {
            var soil = this.GetMappedSourceValue(seed, this.seedToSoilLines);
            var fertilizer = this.GetMappedSourceValue(soil, this.soilToFertilizerLines);
            var water = this.GetMappedSourceValue(fertilizer, this.fertilizerToWaterLines);
            var light = this.GetMappedSourceValue(water, this.waterToLightLines);
            var temperature = this.GetMappedSourceValue(light, this.lightToTemperatureLines);
            var humidity = this.GetMappedSourceValue(temperature, this.temperatureToHumidityLines);
            var location = this.GetMappedSourceValue(humidity, this.humidityToLocationLines);

            if (location < lowestLocation) lowestLocation = location;
        }

        return $"{lowestLocation}";
    }

    /// <summary>
    /// Solves the second part of the advent's puzzle.
    /// </summary>
    /// <returns>
    /// Result for the second part of the puzzle.
    /// </returns>
    public override string SolveSecondPart()
    {
        long lowestLocation = 0;

        for (var i = lowestLocation; i < long.MaxValue; i++)
        {
            var humidity = this.GetMappedDestinationValue(i, this.humidityToLocationLines);
            var temperature = this.GetMappedDestinationValue(humidity, this.temperatureToHumidityLines);
            var light = this.GetMappedDestinationValue(temperature, this.lightToTemperatureLines);
            var water = this.GetMappedDestinationValue(light, this.waterToLightLines);
            var fertilizer = this.GetMappedDestinationValue(water, this.fertilizerToWaterLines);
            var soil = this.GetMappedDestinationValue(fertilizer, this.soilToFertilizerLines);
            var seed = this.GetMappedDestinationValue(soil, this.seedToSoilLines);

            var seedFound = false;

            // Check if the seed exists in input ranges
            for (var j = 0; j < this.seeds.Length - 1; j += 2)
            {
                var inputSeed = this.seeds[j];
                var seedRange = this.seeds[j + 1];

                var lastSeedRange = inputSeed + (seedRange - 1);

                if (inputSeed <= seed && seed <= lastSeedRange)
                {
                    seedFound = true;
                    break;
                }
            }

            if (seedFound)
            {
                lowestLocation = i;
                break;
            }
        }
        
        return $"{lowestLocation}";
    }

    /// <summary>
    /// Gets the seeds from the input line.
    /// </summary>
    /// <param name="seedsLine">The seeds line.</param>
    /// <returns>
    /// An array containing seeds.
    /// </returns>
    private long[] GetSeeds(string seedsLine)
    {
        var lineParts = seedsLine.Split(":", StringSplitOptions.TrimEntries);

        return lineParts[1]
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToArray();
    }

    /// <summary>
    /// Gets the mapped source value.
    /// </summary>
    /// <param name="mapLines">The map lines.</param>
    /// <param name="sourceValue">The source value.</param>
    /// <returns>
    /// Mapped source value.
    /// </returns>
    private long GetMappedSourceValue(long sourceValue, IList<string> mapLines)
    {
        foreach (var line in mapLines)
        {
            var lineNumbers = line
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            var destinationRangeStart = lineNumbers[0];
            var sourceRangeStart = lineNumbers[1];
            var rangeLength = lineNumbers[2];

            var sourceRangeEnd = sourceRangeStart + (rangeLength - 1);

            if (sourceRangeStart <= sourceValue && sourceValue <= sourceRangeEnd)
            {
                var diff = sourceValue - sourceRangeStart;

                return destinationRangeStart + diff;
            }
        }

        return sourceValue;
    }

    /// <summary>
    /// Gets the mapped destination value.
    /// </summary>
    /// <param name="destinationValue">The destination value.</param>
    /// <param name="mapLines">The map lines.</param>
    /// <returns>
    /// Mapped destination value.
    /// </returns>
    private long GetMappedDestinationValue(long destinationValue, IList<string> mapLines)
    {
        foreach (var line in mapLines)
        {
            var lineNumbers = line
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            var destinationRangeStart = lineNumbers[0];
            var sourceRangeStart = lineNumbers[1];
            var rangeLength = lineNumbers[2];

            var destinationRangeEnd = destinationRangeStart + (rangeLength - 1);

            if (destinationRangeStart <= destinationValue && destinationValue <= destinationRangeEnd)
            {
                var diff = destinationValue - destinationRangeStart;

                return sourceRangeStart + diff;
            }
        }

        return destinationValue;
    }
}