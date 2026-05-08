using DotnetLeets.LongestCommonPrefix;
using DotnetLeets.ValidParentheses;

class Program
{
    static void Main()
    {
        string [] s = ["iflower", "flow", "flight"];

        var result = LongestCommonPrefix.ReturnString(s);

        Console.WriteLine($"Input: {string.Join(", ", s)}");
        Console.WriteLine($"Output: {result}");
    }
}