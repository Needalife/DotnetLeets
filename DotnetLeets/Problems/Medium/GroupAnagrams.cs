using DotnetLeets.Core;

namespace DotnetLeets.Problems.Medium
{
    internal class GroupAnagrams: ILeetProblem
    {
        public string Name => "Group Anagrams";
        public List<string> Tags => ["Hash Table", "String"];
        public void Run()
        {
            Console.WriteLine($"=== {Name} ===\n");

            var testCases = new Dictionary<string[], List<List<string>>>()
            {
                {
                    ["eat", "tea", "tan", "ate", "nat", "bat"],
                    [
                        ["eat", "tea", "ate"],
                        ["tan", "nat"],
                        ["bat"]
                    ]
                }, // Basic example

                {
                    [""],
                    [
                        [""]
                    ]
                }, // Single empty string

                {
                    ["a"],
                    [
                        ["a"]
                    ]
                }, // Single character

                {
                    ["abc", "def", "ghi"],
                    [
                        ["abc"],
                        ["def"],
                        ["ghi"]
                    ]
                }, // No anagrams

                {
                    ["abc", "bca", "cab", "cba"],
                    [
                        ["abc", "bca", "cab", "cba"]
                    ]
                }, // All words are anagrams

                {
                    ["eat", "tea", "eat", "ate"],
                    [
                        ["eat", "tea", "eat", "ate"]
                    ]
                }, // Duplicate words

                {
                    ["listen", "silent", "enlist", "rat", "tar", "art"],
                    [
                        ["listen", "silent", "enlist"],
                        ["rat", "tar", "art"]
                    ]
                }, // Different group sizes

                {
                    ["aabb", "bbaa", "abab", "baab"],
                    [
                        ["aabb", "bbaa", "abab", "baab"]
                    ]
                }, // Repeated letters

                {
                    ["a", "ab", "ba", "abc", "cab"],
                    [
                        ["a"],
                        ["ab", "ba"],
                        ["abc", "cab"]
                    ]
                }, // Mixed lengths

                {
                    ["123", "231", "312", "456"],
                    [
                        ["123", "231", "312"],
                        ["456"]
                    ]
                }, // Numbers as strings

                {
                    ["Eat", "Tea", "ate"],
                    [
                        ["Eat"],
                        ["Tea"],
                        ["ate"]
                    ]
                }, // Case sensitivity test

                {
                    [],
                    []
                }, // Empty input

                {
                    ["", "", ""],
                    [
                        ["", "", ""]
                    ]
                }, // Only empty strings

                {
                    ["abc", "acb", "bac", "bca", "cab", "cba"],
                    [
                        ["abc", "acb", "bac", "bca", "cab", "cba"]
                    ]
                }, // One giant group

                {
                    ["a", "b", "c", "d"],
                    [
                        ["a"],
                        ["b"],
                        ["c"],
                        ["d"]
                    ]
                } // Many singleton groups
            };

            TestHelper.TestAllCases(testCases, Solve, CompareAnagramGroups);
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

        // Helper method to compare two lists of anagram groups regardless of order
        private static bool CompareAnagramGroups(
            List<List<string>> output,
            List<List<string>> expected)
        {
            var normalizedOutput = output
                .Select(group => group.OrderBy(x => x))
                .OrderBy(group => string.Join(",", group));

            var normalizedExpected = expected
                .Select(group => group.OrderBy(x => x))
                .OrderBy(group => string.Join(",", group));

            return normalizedOutput
                .Zip(normalizedExpected)
                .All(pair => pair.First.SequenceEqual(pair.Second));
        }
    }
}
