using DotnetLeets.Core;

namespace DotnetLeets.Problems.Easy
{
    internal class ValidParentheses : ILeetProblem
    {
        public string Name => "Valid Parentheses";
        public List<string> Tag => ["String", "Stack"];
        public void Run()
        {
            Console.WriteLine($"=== {Name} ===\n");

            var testCases = new Dictionary<string, bool>
            {
                { "()", true }, // Basic case
                { "()[]{}", true }, // Multiple types of brackets
                { "(]", false }, // Mismatched brackets
                { "([)]", false }, // Incorrectly nested brackets
                { "{[]}", true }, // Nested brackets
                { "", true }, // Empty string
                { "(", false }, // Single opening bracket
                { ")", false }, // Single closing bracket
                { "(((())))", true }, // Deeply nested brackets
                { "((())", false }, // Unmatched opening bracket
                { "(()))", false } // Unmatched closing bracket
            };

            TestHelper.TestAllCases(testCases, Solve);
        }

        private static bool Solve(string s)
        {
            if  (s.Length %2 != 0) {
                Console.WriteLine($"Bracket is odd");
                return false;
            }

            var stack = new Stack<char>();
            var closingBracket = new Dictionary<char, char>()
            {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };
            var openingBracket = new HashSet<char>()
            {
                { '(' },
                { '[' },
                { '{' }
            };

            for (int i = 0; i < s.Length; i++)
            {
                if (openingBracket.Contains(s[i]))
                {
                    stack.Push(s[i]);
                    continue;
                }

                if (closingBracket.ContainsKey(s[i]) && stack.Count > 0)
                {
                    if (stack.Peek() == closingBracket[s[i]])
                    {
                        stack.Pop();
                    } else
                    {
                        Console.WriteLine($"Bracket {s[i]} does not match with {stack.Peek()}");
                        return false;
                    } 
                } else
                {
                    Console.WriteLine($"No opening/closing bracket found for {s[i]} at iteration {i}");
                    return false;
                }
            }

            return true;
        }
    }
}
