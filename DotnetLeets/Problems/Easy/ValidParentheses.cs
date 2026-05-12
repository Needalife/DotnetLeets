using DotnetLeets.Core;

namespace DotnetLeets.Problems.Easy
{
    internal class ValidParentheses : ILeetProblem
    {
        public string Name => "Valid Parentheses";

        public void Run()
        {
            Console.WriteLine("=== Valid Parentheses ===\n");
            Test("()"); // Basic case
            Test("()[]{}"); // Multiple types of brackets
            Test("(]"); // Mismatched brackets
            Test("([)]"); // Incorrectly nested brackets
            Test("{[]}"); // Nested brackets
            Test(""); // Empty string
            Test("("); // Single opening bracket
            Test(")"); // Single closing bracket
            Test("(((())))"); // Deeply nested brackets
            Test("((())"); // Unmatched opening bracket
            Test("(()))"); // Unmatched closing bracket
        }

        public void Test(string input)
        {
            var result = Solve(input);
            Console.WriteLine($"Input: {input}");
            Console.WriteLine($"\nOutput: {result}");
            Console.WriteLine("\n-------------------\n");
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
