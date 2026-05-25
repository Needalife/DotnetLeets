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
                {Create(1,2,3,3,4,4,5,5,6), Create(1,2,6)},
                {Create(1,2,3,3,4,4), Create(1,2)},
                {Create(0,0,3), Create(3)}
            };
            TestHelper.TestAllCases(testCases, Solve, Compare);
        }

        private static Node Solve(Node head)
        {
            if (head == null) return null;

            var dummy = new Node { next = head };
            var curr = dummy.next;
            var prev = dummy;

            while (curr?.next != null)
            {
                if (curr.val == curr.next.val)
                {
                    while (curr.next != null && curr.val == curr.next.val)
                    {
                        curr = curr.next;
                    }

                    prev.next = curr.next;
                }

                curr = curr.next;

                if (prev.next?.val != prev.next?.next?.val) {
                    prev = prev.next;
                }
            }

            return dummy.next;
        }
    }
}
