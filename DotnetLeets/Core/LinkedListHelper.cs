using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetLeets.Core
{
    internal class LinkedListHelper
    {
        public class Node
        {
            public int val;
            public Node? next;
            public Node(int val = 0, Node? next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public static Node? Create(params int[] values)
        {
            if (values.Length == 0)
                return null;

            var head = new Node(values[0]);
            var current = head;

            for (int i = 1; i < values.Length; i++)
            {
                current.next = new Node(values[i]);
                current = current.next;
            }

            return head;
        }

        public static bool Compare(Node? a, Node? b)
        {
            while (a != null && b != null)
            {
                if (a.val != b.val)
                    return false;

                a = a.next;
                b = b.next;
            }

            return a == null && b == null;
        }
    }
}
