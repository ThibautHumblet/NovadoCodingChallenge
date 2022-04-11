using Checksum;

var input = await File.ReadAllTextAsync(@"checksum - input.txt");

List<int> ringbuffer = new List<int>();
foreach (var number in input)
{
    int parsedNumber;
    if (int.TryParse(number.ToString(), out parsedNumber))
    {
        ringbuffer.Add(parsedNumber);
    }
    else
    {
        throw new ArgumentException("The given input file does not contain the right characters! (Only use 0-9)");
    }
}

List<int> checksumList = new List<int>();
int nextNumber;

for (int i = 0; i < ringbuffer.Count; i++)
{
    nextNumber = ringbuffer.IsLast(i) ? ringbuffer.ElementAt(i + 1) : ringbuffer.First();

    var number = ringbuffer.ElementAt(i);
    if (number.Equals(nextNumber))
    {
        checksumList.Add(number);
    }
}

Console.WriteLine(checksumList.Sum());