using DotnetLeets.Core;

namespace DotnetLeets.Problems.Easy
{
    internal class LongestCommonPrefix : ILeetProblem
    {
        public string Name => "Longest Common Prefix";
        public List<string> Tag => ["String", "Array"];
        public void Run()
        {
            Console.WriteLine($"=== {Name} ===\n");

            var testCases = new Dictionary<string[], string>()
            {
                { ["flower", "flow", "flight"], "fl" },
                { ["dog", "racecar", "car"], "" },
                { ["interspace", "interstellar", "interstate"], "inters" },
                { ["a", "a", "a"], "a" },
                { ["ab", "a"], "a" },
                { [], "" },
                { ["single"], "single" },
                { ["prefix", "prefixes", "prefixed"], "prefix" }
            };

            TestHelper.TestAllCases(testCases, Solve);
        }

        private static string Solve(string[] s)
        {
            if (s.Length < 1) return "";
            if (s.Length == 1) return s[0];

            string first = s[0];

            for (int i = 0; i < first.Length; i++)
            {
                for (int j = 1; j < s.Length; j++)
                {
                    if (i >= s[j].Length || first[i] != s[j][i])
                    {
                        return first.Substring(0, i);
                    }
                }
            }

            return "";
        }
    }
}
