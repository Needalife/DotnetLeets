namespace DotnetLeets.GroupAnagrams
{
    internal class GroupAnagrams
    {
        public static List<List<string>> ReturnGroupsOfString(string[] input)
        {
            var dict = new Dictionary<string, List<string>>();
            var merged = new List<List<string>>();

            for (int i = 0; i < input.Length; i ++)
            {
                var sortedString = SortString(input[i]);

                if (dict.ContainsKey(sortedString))
                {
                    dict[sortedString].Add(input[i]);
                    continue;
                }

                dict[sortedString] = [input[i]];  
            }

            foreach (KeyValuePair<string, List<string>> kvp in dict)
            {
                merged.Add(kvp.Value);
            }

            return merged;
        } 

        public static string SortString(string s)
        {
            char[] chars = s.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }

        
    }
}
