using DotnetLeets.Core;

namespace DotnetLeets.Problems.Medium
{
    internal class GroupAnagrams: ILeetProblem
    {
        public string Name => "Group Anagrams";

        public void Run()
        {
            Console.WriteLine("=== Group Anagrams ===\n");

            Test(["eat", "tea", "tan", "ate", "nat", "bat"]); // Basic example
            Test([""]); // Single empty string
            Test(["a"]); // Single character
            Test(["abc", "def", "ghi"]); // No anagrams
            Test(["abc", "bca", "cab", "cba"]); // All words are anagrams
            Test(["eat", "tea", "eat", "ate"]); // Duplicate words
            Test(["listen", "silent", "enlist", "rat", "tar", "art"]); // Different group sizes
            Test(["aabb", "bbaa", "abab", "baab"]); // Repeated letters
            Test(["a", "ab", "ba", "abc", "cab"]); // Mixed lengths
            Test(["123", "231", "312", "456"]); // Numbers as strings
            Test(["Eat", "Tea", "ate"]); // Case sensitivity test
            Test([]); // Empty input
            Test(["", "", ""]); // Only empty strings
            Test(["abc", "acb", "bac", "bca", "cab", "cba"]); // One giant group
            Test(["a", "b", "c", "d"]); // Many singleton groups
        }

        private static void Test(string[] input)
        {
            var result = Solve(input);

            Console.WriteLine($"Input: [{string.Join(", ", input)}]");
            Console.WriteLine("\nOutput(s):");
            foreach (var group in result)
            {
                Console.WriteLine($"[{string.Join(", ", group)}]");
            }
            Console.WriteLine("\n-------------------\n");
        }

        private static List<List<string>> Solve(string[] input)
        {
            var dict = new Dictionary<string, List<string>>();

            for (int i = 0; i < input.Length; i++)
            {
                var sortedString = SortString(input[i]);

                if (dict.ContainsKey(sortedString))
                {
                    dict[sortedString].Add(input[i]);
                    continue;
                }

                dict[sortedString] = [input[i]];
            }

            return dict.Values.ToList();
        }

        private static string SortString(string s)
        {
            char[] chars = s.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }
    }
}
