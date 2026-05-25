using DotnetLeets.Core;
using static DotnetLeets.Core.LinkedListHelper;

namespace DotnetLeets.Problems.Medium
{
    internal class PartitionList : ILeetProblem
    {
        public string Name => "Partition List";
        public List<string> Tags => ["Linked List"];
        public void Run()
        {
            Console.WriteLine($"=== {Name} ===\n");

            var testCases = new List<((Node?, int) input, Node? expected)>
            {
                ((Create(1,4,3,2,5,2), 3), Create(1,2,2,4,3,5)),
                ((Create(2,1), 2), Create(1,2)),
                ((Create(1), 0), Create(1)),
                ((Create(1,4,3,0,5,2), 3), Create(1,0,2,4,3,5))
            };

            TestHelper.TestAllCases(testCases, Solve, Compare);
        }

        private static Node? Solve(Node head, int x)
        {
            return null;
        }
    }
}
