using DotnetLeets.Core;
using static DotnetLeets.Core.LinkedListHelper;
using static System.Net.Mime.MediaTypeNames;

namespace DotnetLeets.Problems.Medium
{
    internal class RotateList : ILeetProblem
    {
        public string Name => "Rotate List";
        public List<string> Tags => ["Linked List", "Two Pointers"];
        public void Run()
        {
            Console.WriteLine($"=== {Name} ===\n");

            var testCases = new List<((Node?, int) input, Node? expected)>
            {
                (
                    (Create(1,2,3,4,5), 2),
                    Create(4,5,1,2,3)
                ),
                (
                    (Create(0,1,2), 4),
                    Create(2,0,1)
                ),
                (
                    (Create(), 0),
                    null
                )
            };

            TestHelper.TestAllCases(testCases, SolveV2, Compare);
        }

        private static Node Solve(Node head, int k) // O(n * k) time complexity
        {
            if (head == null)
            {
                return null;
            }

            var dummy = head;
            var len = 0;

            while (dummy != null)
            {
                dummy = dummy.next;
                len++;
            }
            dummy = head;

            if (k >= len)
            {
                k = k % len;
            }

            while (k > 0)
            {
                var prev = dummy;
                var current = dummy.next;

                while (current.next != null)
                {
                    prev = prev.next;
                    current = current.next;
                }

                prev.next = null;
                current.next = dummy;

                dummy = current;

                k--;
            }

            return dummy;
        }

        private static Node SolveV2(Node head, int k) // O(n) time complexity
        {  
            if (head == null) return null;
            
            var dummy = new Node { next = head };
            var len = 0;
            var count = 0;

            while (dummy.next != null)
            {
                dummy = dummy.next;
                len ++;
            }
            dummy = new Node { next = head };

            if (k >= len) k = k % len;
            if (k == 0) return head;

            var prev = dummy;
            var current = dummy.next;

            while (count < len - k)
            {
                prev = prev.next;
                current = current.next;
                count ++;
            }

            dummy = current;
            while (current.next != null)
            {
                current = current.next;
            }

            prev.next = null;
            current.next = head;

            return dummy;
        }
    }
}
