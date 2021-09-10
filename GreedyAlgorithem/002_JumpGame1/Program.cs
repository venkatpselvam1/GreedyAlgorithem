using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_JumpGame1
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
            int[] nums;
            bool[] isVisited;
            public bool CanJump(int[] nums)
            {
                this.nums = nums;
                this.isVisited = new bool[nums.Length];
                return CanJump(0);
            }
            public bool CanJump(int ind){
                if (ind == nums.Length - 1)
                {
                    return true;
                }

                if (IsValid(ind) && !isVisited[ind])
                {
                    isVisited[ind] = true;
                    for (int i = 1; i <= nums[ind]; i++)
                    {
                        if (CanJump(ind+i) || CanJump(ind-i))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            public bool IsValid(int ind)
            {
                return ind >= 0 && ind < nums.Length;
            }
        }
    }
}
