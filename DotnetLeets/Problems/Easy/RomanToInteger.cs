using DotnetLeets.Core;

namespace DotnetLeets.Problems.Easy
{
    internal class RomanToInteger: ILeetProblem
    {
        public string Name => "Roman to Integer";
        public List<string> Tag => ["Math", "String"];
        public void Run()
        {
            Console.WriteLine($"=== {Name} ===\n");
            var tests = new Dictionary<string, int>
            {
                { "III", 3 },
                { "IV", 4 },
                { "VI", 6},
                { "MCMXCIV", 1994 },
                { "V", 5 },
                { "MMMDCCCLXXXVIII", 3888 },
                { "MDCLXVI", 1666 },
                { "MCDLXXVI", 1476 },
                { "MCDLXXIV", 1474 },
                { "MMCDXXV", 2425 }
            };

            TestHelper.TestAllCases(tests, Solve);
        }

        private static int Solve(string s)
        {
            var dict = new Dictionary<char, int>
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

            var num = dict[s[0]];
            for (int i = 1; i < s.Length; i ++)
            {
                if (dict[s[i]] <= dict[s[i - 1]])
                {
                   num += dict[s[i]];
                } else
                {
                    num += dict[s[i]] - dict[s[i - 1]] * 2;
                } 
            }

            return num;
        }
    }
}
