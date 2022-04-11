namespace SegmentedDisplay
{
    public class Segment
    {
        public List<string> ConfigList { get; set; } = new List<string>();

        public Segment GetConfiguration(string signal)
        {
            string[] textSplit = signal.Split();
            var orderedString = new List<string>();
            foreach (var word in textSplit)
            {
                orderedString.Add(string.Concat(word.OrderBy(c => c)));
            }

            orderedString =  orderedString.OrderBy(x => x.Length).ToList();

            var configuration = new Segment();
            bool isSolving = true;
            string num0 = string.Empty;
            string num1 = string.Empty;
            string num2 = string.Empty;
            string num3 = string.Empty;
            string num4 = string.Empty;
            string num5 = string.Empty;
            string num6 = string.Empty;
            string num7 = string.Empty;
            string num8 = string.Empty;
            string num9 = string.Empty;

            while (isSolving)
            {
                for (int i = 0; i < orderedString.Count; i++)
                {
                    var word = orderedString.ElementAt(i);

                    switch (word.Length)
                    {
                        case 2:
                            num1 = word;
                            orderedString.Remove(word);
                            break;
                        case 3:
                            num7 = word;
                            orderedString.Remove(word);
                            break;
                        case 4:
                            num4 = word;
                            orderedString.Remove(word);
                            break;
                        case 5:
                            if (IsReadyForAdvanced(num1, num7, num4, num8))
                            {
                                if (word.ContainsOnEachChar(num1))
                                {
                                    num3 = word;
                                    orderedString.Remove(word);
                                    break;
                                }
                                if (!string.IsNullOrEmpty(num3) && IsNum5(num1, num6, word))
                                {
                                    num5 = word;
                                    orderedString.Remove(word);
                                    break;
                                }
                                if (!string.IsNullOrEmpty(num3) && !string.IsNullOrEmpty(num5))
                                {
                                    num2 = word;
                                    orderedString.Remove(word);
                                    break;
                                }
                            }
                            break;
                        case 6:
                            if (IsReadyForAdvanced(num1, num7, num4, num8))
                            {
                                if (word.ContainsOnEachChar(num3) && word.ContainsOnEachChar(num4))
                                {
                                    num9 = word;
                                    orderedString.Remove(word);
                                    break;
                                }

                                if (!string.IsNullOrEmpty(num9) && !word.ContainsOnEachChar(num1))
                                {
                                    num6 = word;
                                    orderedString.Remove(word);
                                    break;
                                }

                                if (!string.IsNullOrEmpty(num9) && !string.IsNullOrEmpty(num6))
                                {
                                    num0 = word;
                                    orderedString.Remove(word);
                                    break;
                                }
                            }
                            break;
                        case 7:
                            num8 = word;
                            orderedString.Remove(word);
                            break;
                        default:
                            break;
                    }
                }

                if (orderedString.Count == 0)
                {
                    isSolving = false;
                }
            }

            configuration.ConfigList.AddRange(new List<string>
            {
                num0, num1, num2, num3, num4, num5, num6, num7, num8, num9
            });

            return configuration;
        }

        private static bool IsReadyForAdvanced(string num1, string num7, string num4, string num8)
        {
            return (!string.IsNullOrEmpty(num1) && !string.IsNullOrEmpty(num7) && !string.IsNullOrEmpty(num4) && !string.IsNullOrEmpty(num8));
        }

        private static bool IsNum5(string num1, string num6, string currentSeg)
        {
            if (num1 == string.Empty || num6 == string.Empty)
                return false;

            var lowerRightLeg = num6.Intersect(num1).First().ToString();
            return currentSeg.ContainsOnEachChar(lowerRightLeg);
        }
    }
}
