using DotnetLeets.Core;

namespace DotnetLeets.Problems.Easy
{
    internal class TwoSum: ILeetProblem
    {
        public string Name => "Two Sum";
        public List<string> Tag => ["Array", "Hash Table"];

        public void Run()
        {
            Console.WriteLine("=== Two Sum ===\n");
    
            Test([2, 7, 11, 15], 9); // Basic case 
            Test([3, 3], 6); // Duplicate numbers
            Test([3, 2, 4], 6); // Multiple possibilities
            Test([-1, -2, -3, -4, -5], -8); // Negative numbers
            Test([-3, 4, 3, 90], 0); // Mix positive and negative
            Test([0, 4, 3, 0], 0); // Zeros   
            Test([1, 2, 3, 4, 5, 100], 105); // Large gap
            Test([1, 5, 8, 10], 18); // Target at end
            Test([1, 2], 3); // Only two elements
            Test([1, 2, 3], 100); // No solution
        }

        private static void Test(int[] nums, int target)
        {
            var result = Solve(nums, target);

            Console.WriteLine($"Input:");
            Console.WriteLine($"nums = [{string.Join(", ", nums)}]");
            Console.WriteLine($"target = {target}");

            Console.WriteLine($"\nOutput:");
            Console.WriteLine($"[{string.Join(", ", result)}]");

            Console.WriteLine("\n-------------------\n");
        }

        private static int[] Solve(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];

                if (!dict.ContainsKey(complement))
                {
                    dict[nums[i]] = i;  
                    continue;
                }

                return [i, dict[complement]];
            }

            return [];
        }
    }
}