using SegmentedDisplay;

var inputlines = await File.ReadAllLinesAsync(@"segmented display - input.txt");

var allSegments = new List<int>();

foreach (var inputline in inputlines)
{
    var seg = new Segment();
    var trimmedLine = inputline.Split(" | ");
    var config = seg.GetConfiguration(trimmedLine[0]);
    string[] textSplit = trimmedLine[1].Split();
    string tempNumber = string.Empty;
    foreach (var word in textSplit)
    {
        string segmentedNumber = config.GetNumber(word);
        tempNumber += segmentedNumber;
    }
    allSegments.Add(int.Parse(tempNumber));
}

Console.WriteLine(allSegments.Sum());
