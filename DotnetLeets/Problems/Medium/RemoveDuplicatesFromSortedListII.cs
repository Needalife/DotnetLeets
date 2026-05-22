using DotnetLeets.Core;
using static DotnetLeets.Core.LinkedListHelper;

namespace DotnetLeets.Problems.Medium
{
    internal class RemoveDuplicatesFromSortedListII : ILeetProblem
    {
        public string Name => "Remove Duplicates from Sorted List II";
        public List<string> Tags => ["Linked List"];
        public void Run()
        {
            Console.WriteLine($"=== {Name} ===\n");
            var testCases = new Dictionary<Node, Node>
            {
                {Create(1,2,3,3,4,4,5), Create(1,2,5)},
                {Create(1,1,1,2,3), Create(2,3)},
            };
            TestHelper.TestAllCases(testCases, Solve, Compare);
        }

        private static Node Solve(Node head)
        {
            if (head == null) return null;

            var dummy = head;
            var curr = dummy;
            var val = curr.val;

            while (curr != null)
            {
                if (curr.val == val)
                {
                    curr.next = curr.next?.next;
                } else
                {
                    val = curr.val;
                }
                curr = curr.next;
            }

            return dummy;
        }
    }
}
