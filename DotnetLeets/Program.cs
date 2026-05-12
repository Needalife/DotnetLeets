using DotnetLeets.Core;
using DotnetLeets.Problems.Arrays;

class Program
{
    static void Main()
    {
        List<ILeetProblem> problems =
        [
            new TwoSum()
        ];

        Console.WriteLine("==== DOTNET LEETS ====\n");

        for (int i = 0; i < problems.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {problems[i].Name}");
        }

        Console.Write("\nSelect problem: ");

        string? input = Console.ReadLine();

        bool valid = int.TryParse(input, out int choice);

        if (!valid)
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        if (choice < 1 || choice > problems.Count)
        {
            Console.WriteLine("Problem not found.");
            return;
        }

        Console.Clear();

        problems[choice - 1].Run();
    }
}