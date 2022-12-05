static (int Start, int End) ParseInterval(string elfInterval) {
    return (Convert.ToInt32(elfInterval.Split('-')[0]), Convert.ToInt32(elfInterval.Split('-')[1]));
}

var lines = File.ReadAllLines("input.txt");

var fullOverlapsCount = 0;
var partialOverlapCount = 0;

foreach (var line in lines) {
    var elf1Interval = line.Split(',')[0];
    var elf2Interval = line.Split(',')[1];

    var elf1Sections = Enumerable.Range(ParseInterval(elf1Interval).Start, ParseInterval(elf1Interval).End - ParseInterval(elf1Interval).Start + 1).ToList();
    var elf2Sections = Enumerable.Range(ParseInterval(elf2Interval).Start, ParseInterval(elf2Interval).End - ParseInterval(elf2Interval).Start + 1).ToList();

    if (elf1Sections.All(elf2Sections.Contains) || elf2Sections.All(elf1Sections.Contains))
        fullOverlapsCount++;

    if (elf1Sections.Any(elf2Sections.Contains) || elf2Sections.Any(elf1Sections.Contains))
        partialOverlapCount++;
}

Console.WriteLine($"Full overlap Count: {fullOverlapsCount}");
Console.WriteLine($"Partial overlap Count: {partialOverlapCount}");
