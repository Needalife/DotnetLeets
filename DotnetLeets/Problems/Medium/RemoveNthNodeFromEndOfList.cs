using DotnetLeets.Core;
using static DotnetLeets.Core.LinkedListHelper;

namespace DotnetLeets.Problems.Medium
{
    internal class RemoveNthNodeFromEndOfList : ILeetProblem
    {
        public string Name => "Remove Nth Node From End of List";
        public List<string> Tag => ["Linked List"];
        public void Run() {
            Console.WriteLine($"=== {Name} ===\n");

            var testCases = new List<((Node?, int) input, Node? expected)>
            {
               ((Create(1,2,3,4,5), 2), Create(1,2,3,5)),
               ((Create(1), 1), Create()),
               ((Create(1,2), 1), Create(1)),
               ((Create(1,2), 2), Create(2)),
            };

            TestHelper.TestAllCases(
                testCases,
                OnePass,
                Compare
            );
        }

        private static Node? TwoPass(Node head, int n)
        {
            var dummy = head;
            var len = 0;
            var count = 1;

            while (dummy != null)
            { 
                len ++;
                dummy = dummy.next;
            }

            if (len - n == 0)
            {
                return head.next;
            }

            dummy = head;
            while (dummy != null)
            {
               if (count == len - n)
                {
                    dummy.next = dummy.next.next;
                    return head;
                }

                dummy = dummy.next;
                count ++;
            }

            return null;
        }

        private static Node? OnePass(Node head, int n)
        {
            if (head.next == null && n == 1)
            {
                return null;
            }

            var dummy = new Node(0);
            dummy.next = head;
            var fast = dummy;
            var slow = dummy;
            
            while (true)
            {
                if (fast.next == null)
                {
                    slow.next = slow.next.next;
                    break;
                }

                if (n > 0)
                {
                    n--;
                } else
                {
                    slow = slow.next;
                }

                fast = fast.next;
            }

            return dummy.next;
        }
    }
}
