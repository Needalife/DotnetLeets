using DotnetLeets.Core;

namespace DotnetLeets.Problems.Easy
{
    internal class LongestCommonPrefix : ILeetProblem
    {
        public string Name => "Longest Common Prefix";

        public void Run()
        {
            Console.WriteLine("=== Longest Common Prefix ===\n");

            Test(["flower", "flow", "flight"]); // Basic case
            Test(["dog", "racecar", "car"]); // No common prefix
            Test(["interspace", "interstellar", "interstate"]); // Common prefix with different lengths
            Test(["a", "a", "a"]); // All strings are the same
            Test(["ab", "a"]); // One string is a prefix of the other
            Test([]); // Empty input
            Test(["single"]); // Single string input
            Test(["prefix", "prefixes", "prefixed"]); // Common prefix is the entire first string
        }

        public void Test(string[] input)
        {
            var result = Solve(input);
            Console.WriteLine($"Input: [{string.Join(", ", input)}]");
            Console.WriteLine($"\nOutput: {result}");
            Console.WriteLine("\n-------------------\n");
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

            return "No prefix!";
        }
    }
}
