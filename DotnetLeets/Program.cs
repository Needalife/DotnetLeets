using DotnetLeets.Core;
using System.Reflection;

class Program
{
    static void Main()
    {
        var problems = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t =>
                typeof(ILeetProblem).IsAssignableFrom(t) &&
                !t.IsInterface &&
                !t.IsAbstract)
            .Select(t => (ILeetProblem)Activator.CreateInstance(t)!)
            .ToList();

        ConsoleOut(problems);
    }

    private static void ConsoleOut(List<ILeetProblem> problems)
    {
        while (true)
        {
            Console.Clear();

            Console.Write("Search (name/tag): ");
            string search =
                Console.ReadLine()?.Trim().ToLower()
                ?? "";

            var filtered = problems
                .Where(p =>
                    p.Name.ToLower().Contains(search)
                    ||
                    p.Tags.Any(t =>
                        t.Contains(
                            search,
                            StringComparison.OrdinalIgnoreCase)))
                .ToList();

            if (!filtered.Any())
            {
                Console.WriteLine("\nNo results.");
                Console.ReadKey();
                continue;
            }

            Console.WriteLine();

            for (int i = 0; i < filtered.Count; i++)
            {
                Console.WriteLine(
                    $"{i + 1}. {filtered[i].Name} " +
                    $"[{string.Join(", ", filtered[i].Tags)}]");
            }

            Console.Write("\nSelect: ");

            if (int.TryParse(Console.ReadLine(), out int choice)
                && choice > 0
                && choice <= filtered.Count)
            {
                Console.Clear();
                filtered[choice - 1].Run();
                break;
            }
        }
    }
}