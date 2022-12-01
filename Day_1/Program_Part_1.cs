using System.IO;

var elfList = new List<Elf>();
const string fileInputName = "input.txt";

var currentElf = 0;
foreach (var line in File.ReadAllLines(fileInputName))
{
    if (string.IsNullOrWhiteSpace(line))
    {
        currentElf++;
        continue;
    }

    var existingElf = elfList.FirstOrDefault(e => e.Id == currentElf);
    var currentElfCalories = Convert.ToInt32(line);

    if (existingElf != null)
        AddToExistingElf(existingElf, currentElfCalories);
    else
        AddNewElf(elfList, currentElf, currentElfCalories);
}

// Part 1
Console.WriteLine($"Part 1 answer: {elfList.Max(e => e.Calories)}");

// Part 2
Console.WriteLine($"Part 2 answer: {elfList.OrderByDescending(e=>e.Calories).Take(3).Sum(e=>e.Calories)}");

static void AddNewElf(List<Elf> elfList, int currentElf, int currentElfCalories)
{
    elfList.Add(new Elf()
    {
        Id = currentElf,
        Calories = currentElfCalories
    });
}

static void AddToExistingElf(Elf existingElf, int currentElfCalories)
{
    existingElf.Calories += currentElfCalories;
}