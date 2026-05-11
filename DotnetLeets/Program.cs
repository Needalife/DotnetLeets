using DotnetLeets.GroupAnagrams;

class Program
{
    static void Main()
    {
        string [] s = ["eat", "tea", "tan", "ate", "nat", "bat"];

        var result = GroupAnagrams.ReturnGroupsOfString(s);

        Console.WriteLine($"Input: [{string.Join(", ", s)}]");

        Console.WriteLine($"Groupings:");
        foreach (var item in result)
        {
            Console.WriteLine($"[{string.Join(", ", item)}]");
        }
    }
}