using DotnetLeets.ValidParentheses;

class Program
{
    static void Main()
    {
        string s = "[]))";

        var result = ValidParentheses.IsValid(s);

        Console.WriteLine($"Input: {s}");
        Console.WriteLine($"Output: {result}");
    }
}