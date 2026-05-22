using DotnetLeets.Core;
using static DotnetLeets.Core.LinkedListHelper;

namespace DotnetLeets.Problems.Easy
{
    internal class RemoveDupplicatesFromSortedList : ILeetProblem
    {
        public string Name => "Remove Duplicates from Sorted List";
        public List<string> Tags => ["Linked List"];
        public void Run()
        {
            Console.WriteLine($"=== {Name} ===\n");
            var testCases = new Dictionary<Node, Node>
            {
                {Create(1,1,2), Create(1,2)},
                {Create(1,1,2,3,3), Create(1,2,3)},
                {Create(1), Create(1)},
                {Create(1,1), Create(1)},
                {Create(1,2), Create(1,2)},
                {Create(1,1,1), Create(1)},
                {Create(0,0,0,0,0), Create(0)}
            };
            TestHelper.TestAllCases(testCases, Solve, Compare);
        }

        private static Node Solve(Node head) 
        {
            if( head == null) return null;

            var dummy = head;
            var prev = dummy;
            var current = dummy.next;

            while (current != null)
            {
                if (current.val == prev.val)
                {
                    prev.next = current.next;
                } else
                {
                    prev = prev.next;
                }

                current = current.next;
            }
                
            return dummy;
        }
    }
}
