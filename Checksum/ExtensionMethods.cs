namespace Checksum
{
    public static class ExtensionMethods
    {
        public static bool IsLast(this List<int> list, int index)
        {
            return index != list.Count - 1;
        }
    }
}
