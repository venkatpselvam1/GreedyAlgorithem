using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_JumpGame1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * You are given an integer array nums. You are initially positioned at the array's first index, and each element in the array represents your maximum jump length at that position.

             * Return true if you can reach the last index, or false otherwise.
             */

            /*
             * Input: nums = [2,3,1,1,4]
             * Output: true
             * Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.
             */

            /*
             * Input: nums = [3,2,1,0,4]
             * Output: false
             * Explanation: You will always arrive at index 3 no matter what.
             * Its maximum jump length is 0, which makes it impossible to reach the last index.
             */

            var sln = new Solution();
            var nums = new int[] { 2, 3, 1, 1, 4 };
            var ans = sln.CanJump(nums);
            Console.WriteLine(ans);
        }
        public class Solution
        {
            public bool CanJump(int[] nums)
            {
                var length = nums.Length;
                var dp = new bool[length];
                dp[length - 1] = true;
                for (int i = length - 2; i >= 0; i--)
                {
                    // break if i+j goes out of range
                    // break if i already reachable dp[i] == true
                    for (int j = 0; j <= nums[i] && i+j < length && !dp[i]; j++)
                    {
                        if (dp[i+j])
                        {
                            dp[i] = true;
                        }
                    }
                }
                return dp[0];
            }

        }
    }
}
