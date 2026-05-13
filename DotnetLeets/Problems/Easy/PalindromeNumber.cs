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

            var tests = new Dictionary<int, bool>
            {
                { 121, true },
                { -121, false },
                { 10, false },
                { 12321, true },
                { 123321, true },
                { 0, true },
                { 1001, true }
            };

            TestHelper.TestAllCases(tests, Solve);
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
