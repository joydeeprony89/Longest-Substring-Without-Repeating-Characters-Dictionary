using System;
using System.Collections.Generic;

namespace Longest_Substring_Without_Repeating_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "tmmzuxt";
            Console.WriteLine(LengthOfLongestSubstringWORepeatingChars(s));
            Console.WriteLine(LengthOfLongestSubstring(s));
        }


        // The idea is use a hash set to track the longest substring without repeating characters so far, 
        // use a fast pointer j to see if character j is in the hash set or not, if not, great, 
        // add it to the hash set, move j forward and update the max length, otherwise, 
        // delete from the head by using a slow pointer i until we can put character j to the hash set.

        // https://leetcode.com/problems/longest-substring-without-repeating-characters/discuss/1812/Share-my-Java-solution-using-HashSet
        static int LengthOfLongestSubstringWORepeatingChars(string s)
        {
            HashSet<char> hash = new HashSet<char>();
            int max = 0, slow = 0, fast = 0;
            while(fast < s.Length)
            {
                char currentChar = s[fast];
                if (!hash.Contains(currentChar))
                {
                    hash.Add(currentChar);
                    max = Math.Max(max, hash.Count);
                    fast++;
                }
                else
                {
                    hash.Remove(s[slow++]);
                }
            }
            return max;
        }

        // https://leetcode.com/problems/longest-substring-without-repeating-characters/discuss/1729/11-line-simple-Java-solution-O(n)-with-explanation
        // the basic idea is, keep a hashmap which stores the characters in string as keys and their positions as values, 
        // and keep two pointers which define the max substring. move the right pointer to scan through the string , and meanwhile update the hashmap. 
        // If the character is already in the hashmap, then move the left pointer to the right of the same character last found. 
        // Note that the two pointers can only move forward.

        // abcdecfgh // pwwkew // "tmmzuxt"
        static int LengthOfLongestSubstring(string s)
        {
            int max = 0;
            Dictionary<char, int> hash = new Dictionary<char, int>();
            for(int i = 0, j = 0; i < s.Length; i++)
            {
                char currentChar = s[i];
                if (hash.ContainsKey(s[i]))
                {
                    j = Math.Max(j, hash[currentChar] + 1);
                }
                hash[currentChar] = i;
                max = Math.Max(max, i - j + 1);
            }
            return max;
        }
    }
}
