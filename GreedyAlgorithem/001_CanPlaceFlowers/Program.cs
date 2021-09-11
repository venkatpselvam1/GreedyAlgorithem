using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_CanPlaceFlowers
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * You have a long flowerbed in which some of the plots are planted, and some are not. 
             * However, flowers cannot be planted in adjacent plots.

             * Given an integer array flowerbed containing 0's and 1's, where 0 means empty and 1 means not empty, and an integer n,
             * return if n new flowers can be planted in the flowerbed without violating the no-adjacent-flowers rule.
             */

            /*
             * Input: flowerbed = [1,0,0,0,1], n = 1
             * Output: true
             */

            /*
             * Input: flowerbed = [1,0,0,0,1], n = 2
             * Output: false
             */

            var sln = new Solution();
            var arr = new int[] { 1, 0, 0, 0, 1 };
            var ans = sln.CanPlaceFlowers(arr, 2);
            Console.WriteLine(ans);
        }

        public class Solution
        {
            public bool CanPlaceFlowers(int[] flowerbed, int n)
            {
                if (n == 0)
                {
                    return true;
                }
                var length = flowerbed.Length;
                if (length == 0|| length < n)
                {
                    return false;
                }

                if (length == 1)
                {
                    // n is not 0 as the first condition checks that
                    // n is not more than 1 as second condition checks that
                    // so n is 1
                    return flowerbed[0] == 0;
                }

                var ans = 0;

                //length is more than 1
                if (flowerbed[0] == 0 && flowerbed[1] == 0)
                {
                    flowerbed[0] = 1;
                    ans++;
                }

                for (int i = 1; i < length - 1; i++)
                {
                    if (CanBePlanted(i, flowerbed))
                    {
                        flowerbed[i] = 1;
                        ans++;
                    }
                }

                if (flowerbed[length-1] == 0 && flowerbed[length - 2] == 0)
                {
                    flowerbed[length - 1] = 1;
                    ans++;
                }

                return ans >= n;
            }

            public bool CanBePlanted(int ind, int[] flowerbed)
            {
                return flowerbed[ind] == 0 && flowerbed[ind - 1] == 0 && flowerbed[ind + 1] == 0;
            }
        }
    }
}
