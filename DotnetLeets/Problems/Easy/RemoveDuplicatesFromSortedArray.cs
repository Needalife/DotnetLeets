using DotnetLeets.Core;
using System.Runtime.Versioning;

namespace DotnetLeets.Problems.Easy
{
    internal class RemoveDuplicatesFromSortedArray : ILeetProblem
    {
        public string Name => "Remove Duplicates from Sorted Array";
        public List<string> Tag => ["Array", "Two Pointers"];
        public void Run()
        {
            Console.WriteLine($"=== {Name} ===\n");
            var testCases = new Dictionary<int[], int>()
            {
                { [1, 1, 2], 2 }, // Basic case
                { [0,0,1,1,1,2,2,3,3,4], 5 }, // LeetCode example
                { [1, 2, 3], 3 }, // No duplicates
                { [1,1,1,1], 1 }, // All duplicates
                { [], 0 }, // Empty array
                { [5], 1 }, // Single element
                { [-3,-3,-2,-1,-1,0,0,1], 5 }, // Negative numbers
                { [1,1,2,2,3,3,4,4,5,5], 5 }, // Pairs only
                { [1,2,2,2,3], 3 }, // Duplicates in middle
                { [1,1,1,2,3,4], 4 }, // Duplicates at start
                { [1,2,3,4,4,4], 4 } // Duplicates at end
            };

            TestHelper.TestAllCases(testCases, Solve);
        }

        private static int Solve(int[] nums)
        {
            if (nums.Length == 0) return 0;

            var count = 1;
            var current = nums[0];
            var previous = current;

            for (int i = 1; i < nums.Length; i++)
            {
                current = nums[i];
                previous = nums[i - 1];

                if (current != previous) count++;
            }

            return count;
        }

    }
}
