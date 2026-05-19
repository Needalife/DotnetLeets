using DotnetLeets.Core;
using static DotnetLeets.Core.LinkedListHelper;

namespace DotnetLeets.Problems.Easy
{
    internal class AddTwoNumbers : ILeetProblem
    {
        public string Name => "Add Two Numbers";
        public List<string> Tag => ["Linked List", "Math"];
        public void Run() { 
            Console.WriteLine($"=== {Name} ===\n");

            var testCases = new List<((Node?, Node?) input, Node? expected)>
            {
                (
                    (Create(2,4,3), Create(5,6,4)),
                    Create(7,0,8)
                ),
                (
                    (Create(0), Create(0)),
                    Create(0)
                ),
                (
                    (Create(9,9,9,9,9,9,9), Create(9,9,9,9)),
                    Create(8,9,9,9,0,0,0,1)
                ),
                (
                    (Create(5), Create(5)), 
                    Create(0,1)
                ),
                (
                    (Create(7), Create(5)),
                    Create(2,1)
                )
            };

            TestHelper.TestAllCases(
                testCases,
                Solve,
                Compare
            );
        }

        private static Node Solve(Node l1, Node l2)
        {
            var dummy = new Node(0);
            var current = dummy;
            var sum = 0;
            var remain = 0;

            while (l1 != null && l2 != null)
            {
                sum = l1.val + l2.val + remain;

                if (sum >= 10)
                {
                    current.val = sum - 10;
                    remain = 1;
                } else
                {
                    current.val = sum;
                    remain = 0;
                }

                if (l1.next != null || l2.next != null) current = current.next = new Node(0);

                l1 = l1.next;
                l2 = l2.next;
            }

            while (l1 != null)
            {
                sum = l1.val + remain;
                if (sum >= 10)
                {
                    current.val = sum - 10;
                    remain = 1;
                }
                else
                {
                    current.val = sum;
                    remain = 0;
                }

                if (l1.next != null) current = current.next = new Node(0);
                l1 = l1.next;
            }

            while (l2 != null)
            {
                sum = l2.val + remain;
                if (sum >= 10)
                {
                    current.val = sum - 10;
                    remain = 1;
                }
                else
                {
                    current.val = sum;
                    remain = 0;
                }

                if (l2.next != null) current = current.next = new Node(0);
                l2 = l2.next;
            }

            if (remain > 0) current.next = new Node(remain);

            return dummy;
        }

