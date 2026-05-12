using DotnetLeets.Core;

namespace DotnetLeets.Problems.Easy
{
    internal class PalindromeNumber : ILeetProblem
    {
        public string Name => "Palindrome Number";
        public List<string> Tag => ["Math", "String"];

        public void Run()
        {
            Console.WriteLine("=== Palindrome Number ===\n");

            var tests = new Dictionary<string, int>
            {
                { "Basic case", 121 },
                { "Negative number", -121 },
                { "Ends with zero", 10 },
                { "Odd length palindrome", 12321 },
                { "Even length palindrome", 123321 },
                { "Single digit", 0 },
                { "Palindrome with zeros in the middle", 1001 }
            };

            foreach (var test in tests)
            {
                Console.WriteLine($"=== {test.Key} ===\n");
                Test(test.Value);
            }
        }

        private void Test(int num)
        {
            Console.WriteLine($"Input: {num}");

            var result = Solve(num);
            Console.WriteLine($"\nOutput: {result}");

            Console.WriteLine("\n-------------------\n");
        }

        private static bool Solve(int x)
        {
            if (x < 0) return false;
            if (x < 10) return true;

            var s = x.ToString();

            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i]) return false;
            }

            return true;
        }
    }
}
