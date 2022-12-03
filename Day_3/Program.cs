

var lines = File.ReadAllLines("input.txt");


static char FindCommonLetter(params string[] list) {
    var hashSet = new HashSet<char>(list[0].ToCharArray());

    foreach (var item in list)
    {
        hashSet.IntersectWith(item.ToCharArray());
    }

    return hashSet.FirstOrDefault();
}

static int FindItemPriority(char input) => 
    char.IsLower(input) ? input - 96 : input -38;

void Part1QuickAndDirty() {
    var totalPrioritySum = 0;
    foreach (var line in lines) {
        var firstCompartment = line.Substring(0, line.Length / 2);
        var secondCompartment = line.Substring(line.Length / 2, line.Length / 2);

        totalPrioritySum += FindItemPriority(FindCommonLetter(firstCompartment, secondCompartment));
    }

    Console.WriteLine(totalPrioritySum);
}

void Part1Linq() {
    var totalPrioritySum = lines.Select(line => (
         FirstPart: line.Substring(0, line.Length / 2),
         SecondPart: line.Substring(line.Length / 2, line.Length / 2)
    )).Sum(e => FindItemPriority(FindCommonLetter(e.FirstPart, e.SecondPart)));

    Console.WriteLine(totalPrioritySum);
}

void Part2Linq() {
    var lists = lines.Select((e, index) => new {Index = index, Value = e})
        .GroupBy(e => e.Index / 3)
        .Select(e => e.Select(v => v.Value).ToList())
        .ToList();

    var result = lists.Sum(list => FindItemPriority(FindCommonLetter(list.ToArray())));
    Console.WriteLine(result);
}



Part1QuickAndDirty();
Part1Linq();
Part2Linq();