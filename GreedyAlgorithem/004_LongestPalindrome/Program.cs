using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_LongestPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Given a string s which consists of lowercase or uppercase letters, return the length of the longest palindrome that can be built with those letters.

             * Letters are case sensitive, for example, "Aa" is not considered a palindrome here.
             */

            /*
             * Input: s = "abccccdd"
             * Output: 7
             * Explanation:
             * One longest palindrome that can be built is "dccaccd", whose length is 7.
             */

            /*
             * Input: s = "bb"
             * Output: 2
             */

            var sln = new Solution();
            var s = "abccccdd";
            var ans = sln.LongestPalindrome(s);
            Console.WriteLine(ans);
        }
        public class Solution
        {
            public int LongestPalindrome(string s)
            {
                var counts = new int[128];
                foreach (var item in s)
                {
                    counts[item]++;
                }
                var ans = 0;
                foreach (var item in counts)
                {
                    ans += item % 2 == 0 ? item : item - 1;
                    if (ans%2==0 && item%2 != 0)
                    {
                        ans++;
                    }
                }
                return ans;
            }
        }
    }
}
