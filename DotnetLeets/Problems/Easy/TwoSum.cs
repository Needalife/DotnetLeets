using DotnetLeets.Core;

namespace DotnetLeets.Problems.Easy
{
    internal class TwoSum: ILeetProblem
    {
        public string Name => "Two Sum";
        public List<string> Tag => ["Array", "Hash Table"];
        public void Run()
        {
            Console.WriteLine($"=== {Name} ===\n");

            var testCases = new List<((int[] nums, int target) input, int[] expected)>
            {
                (([2, 7, 11, 15], 9), [0, 1]), 
                (([3, 3], 6), [0, 1]), 
                (([3, 2, 4], 6), [1, 2]), 
                (([-1, -2, -3, -4, -5], -8), [2, 4]), 
                (([-3, 4, 3, 90], 0), [0, 2]), 
                (([0, 4, 3, 0], 0), [0, 3]), 
                (([1, 2, 3, 4, 5, 100], 105), [4, 5]), 
                (([1, 5, 8, 10], 18), [2, 3]), 
                (([1, 2], 3), [0, 1]), 
                (([1, 2, 3], 100), []) 
            };

            TestHelper.TestAllCases(testCases, Solve);
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