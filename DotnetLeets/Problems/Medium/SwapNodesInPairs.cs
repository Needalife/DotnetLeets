using DotnetLeets.Core;
using System.Net.NetworkInformation;
using static DotnetLeets.Core.LinkedListHelper;

namespace DotnetLeets.Problems.Medium
{
    internal class SwapNodesInPairs : ILeetProblem
    {
        public string Name => "Swap Nodes in Pairs";
        public List<string> Tags => ["Linked List", "Recursion"];
        public void Run()
        {
            Console.WriteLine($"=== {Name} ===\n");
            var testCases = new Dictionary<Node, Node>
            {
                {Create(1,2,3,4), Create(2,1,4,3)},
                {Create(1,2,3,4,5,6), Create(2,1,4,3,6,5)},
                {Create(0), Create(0)},
                {Create(1), Create(1)},
                {Create(1,2,3), Create(2,1,3)}
            };

            TestHelper.TestAllCases(testCases, Solve, Compare);
        }

        private Node Solve(Node? head)
        {
            var dummy = new Node { next = head };
            var prev = dummy;
            var current = head;

            while (current != null && current.next != null)
            {
                var next = current.next;
      
                prev.next = next;
                current.next = next.next;
                next.next = current;

                prev = current;
                current = current.next;
            }

            return dummy.next;
        }
        /*
         * dummy -> 1 -> 2 -> 3 -> 4
         *   p      c    n
         * 
         * p.next = n 
         * dummy -> 2 -> 3 -> 4
         * 
         * c.next = n.next
         * 1 -> 3 -> 4
         * 
         * n.next = c
         * dummy -> 2 -> 1 -> 3 -> 4
         *   p      n    c
         *   
         * p = c
         * dummy -> 2 -> 1 -> 3 -> 4
         *              c,p
         *               
         * c = c.next
         * dummy -> 2 -> 1 -> 3 -> 4
         *               p    c
         */
    }
}
