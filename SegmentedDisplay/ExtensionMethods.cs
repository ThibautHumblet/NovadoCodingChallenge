namespace SegmentedDisplay
{
    public static class ExtensionMethods
    {
        public static bool ContainsOnEachChar(this string currentSeg, string compareSeg)
        {
            if (currentSeg == string.Empty || compareSeg == string.Empty)
                return false;

            var curSegArr = currentSeg.ToCharArray();
            var compSegArr = compareSeg.ToCharArray();

            return compSegArr.All(x => curSegArr.Contains(x));
        }

        public static string GetNumber(this Segment config, string input)
        {
            string sortedInput = string.Concat(input.OrderBy(c => c));
            var configList = config.ConfigList;
            return configList.FindIndex(a => a.Equals(sortedInput)).ToString();
        }
    }
}
