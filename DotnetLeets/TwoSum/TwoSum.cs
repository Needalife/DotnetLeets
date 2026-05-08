namespace DotnetLeets.TwoSum
{
    internal class TwoSum
    {
        public static int[]? ReturnIndices(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];

                if (dict.ContainsKey(complement))
                {
                    return [i, dict[complement]];
                }

                dict[nums[i]] = i;
            }

            return null;
        }
    }
}