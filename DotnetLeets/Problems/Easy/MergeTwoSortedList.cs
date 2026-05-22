using DotnetLeets.Core;
using static DotnetLeets.Core.LinkedListHelper;

namespace DotnetLeets.Problems.Easy
{
    internal class MergeTwoSortedList : ILeetProblem
    {
        public string Name => "Merge Two Sorted List";
        public List<string> Tags => ["Linked List", "Recursion"];
        public void Run()
        {
            Console.WriteLine($"=== {Name} ===\n");

            var testCases = new List<((Node?, Node?) input, Node? expected)>
            {
                (
                    (Create(1,2,4), Create(1,3,4)),
                    Create(1,1,2,3,4,4)
                ),
                (
                    (Create(), Create()),
                    Create()
                ),
                (
                    (Create(), Create(0)),
                    Create(0)
                ),
                (
                    (Create(5), Create(1,2,3)),
                    Create(1,2,3,5)
                ),
                (
                    (Create(1,2,3), Create()),
                    Create(1,2,3)
                ),
                (
                    (Create(2,4,6), Create(1,3,5)),
                    Create(1,2,3,4,5,6)
                ),
                (
                    (Create(1,1,1), Create(1,1)),
                    Create(1,1,1,1,1)
                )
            };

            TestHelper.TestAllCases(
                testCases,
                Solve,
                Compare
            );
        }

        private static Node Solve(Node list1, Node list2)
        {
            var dummy = new Node();
            var current = dummy;

            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    current.next = list1;
                    list1 = list1.next;
                } else
                {
                    current.next = list2;
                    list2 = list2.next;
                }

                current = current.next;
            }

            if (list1 != null)
            {
                current.next = list1;
            }

            if (list2 != null)
            {
                current.next = list2;
            }

            return dummy.next;
        }

    }
}
