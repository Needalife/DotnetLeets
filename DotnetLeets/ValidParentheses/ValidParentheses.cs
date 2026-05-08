namespace DotnetLeets.ValidParentheses
{
    internal class ValidParentheses
    {
        public static bool IsValid(string s)
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
