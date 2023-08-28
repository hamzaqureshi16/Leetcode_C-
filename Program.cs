using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.XPath;

namespace LeetCode_MedianOf2SortedArrays
{
    internal class Program
    {

        public static double Median(int[] a, int[] b)
        {
            List<int> arr1 = a.ToList<int>();
            arr1.AddRange(b.ToList<int>());

            arr1.Sort();
            int length = arr1.Count;
            return (length % 2 == 0) ? (double)(arr1[(length - 1) / 2] + arr1[((length - 1) / 2) + 1]) / 2 : (double)arr1[(length - 1) / 2];

        }

        public static void ReverseInteger(ref int number)
        {
            int reverse = 0;

            while (number != 0)
            {
                reverse = (reverse * 10) + (number % 10);
                number /= 10;
            }
            number = reverse;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            List<int> num1 = new List<int>(), num2 = new List<int>();
            while (l1.next != null)
            {

                num1.Add(l1.val);
                l1 = l1.next;

            }



            while (l2.next != null)
            {
                num2.Add(l2.val);
                l2 = l2.next;
            }

            num1.Add(l1.val);
            l1 = l1.next;
            num2.Add(l2.val);
            l2 = l2.next;

            num2.Reverse();
            num1.Reverse();

            string x1 = "", x2 = "";

            foreach (int i in num1)
            {
                x1 += (i.ToString());
            }
            foreach (int i in num2)
            {
                x2 += (i.ToString());
            }


            string answer = (BigInteger.Parse(x1) + BigInteger.Parse(x2)).ToString();
            Console.WriteLine(answer);





            ListNode result = new ListNode(Convert.ToInt32(answer[0].ToString()), null);
            for (int i = 1; i < answer.Length; i++)
            {

                result = new ListNode(Convert.ToInt32(answer[i].ToString()), result);
            }


            return result;

        }

        public static string StringProduct(string s1, string s2)
        {

            string answer = "";
            int carry = 0;
            int[] result = new int[s1.Length + s2.Length];
            for (int i = s1.Length - 1; i >= 0; i--)
            {
                for (int j = s2.Length - 1; j >= 0; j--)
                {
                    int sum = (s1[i] - '0') * (s2[j] - '0') + carry + result[i + j + 1];
                    result[i + j + 1] = sum % 10;
                    carry = sum / 10;
                }
                result[i] += carry;
                carry = 0;
            }
            StringBuilder sb = new StringBuilder();
            foreach (int i in result)
            {
                sb.Append(i);
            }
            answer = sb.ToString();
            while (answer[0] == '0' && answer.Length > 1)
            {
                answer = answer.Substring(1);
            }
            return answer;
        }


        //Longest Substring Without Repeating Characters
        public static int lengthOfLongestSubstring(String arr)
        {


            String substring = "";
            List<int> maxlens = new List<int>();
            maxlens.Add(0);
            if (!arr.Equals(string.Empty))
            {
                for (int r = 0; r < arr.Length; r++)
                {
                    for (int i = r; i < arr.Length; i++)
                    {
                        if (substring.Contains(arr[i]))
                        {


                            substring = "";

                            break;

                        }
                        else
                        {

                            substring += arr[i];
                            maxlens.Add(substring.Length);

                        }
                    }
                }
            }
            else
            {
                return 0;
            }

            return maxlens.Max();
        }

        public static int MyAtoi(string s)
        {
            bool isNegative = false;
            int number = 0;

            s = s.Trim();
            Console.WriteLine(s);
            if (s.Contains('-'))
            {
                isNegative = true;

                s = s.Remove(0, 1);
            }
            else if (s.Contains('+'))
            {
                s = s.Remove(0, 1);
            }

            if (!s.Equals(string.Empty))
            {
                if (!Int32.TryParse(s[0].ToString(), out int re)) return 0;
            }
            else
            {
                return 0;
            }
            for (int i = 0; i < s.Length; i++)
            {

                if (!Char.IsDigit(s[i]))
                {

                    if (s[i].Equals('.'))
                    {
                        s = s.Remove(i, s.Length - i);
                        break;
                    }
                    else
                    {
                        s = s.Remove(i, 1);
                        i--;
                    }
                }
                //also remove avery digit after decimal


            }




            if (Int32.TryParse(s, out int x))
            {

                for (int i = 0; i < s.Length; i++)
                {
                    if (Int32.TryParse(s[i].ToString(), out int res))
                    {
                        number = (number * 10) + res;


                    }
                }

                if (number >= Int32.MaxValue) return Int32.MaxValue;
                else if (number <= Int32.MinValue) return Int32.MinValue;

                return isNegative ? Convert.ToInt32(number) * (-1) : Convert.ToInt32(number);
            }
            else
            {
                return isNegative ? Int32.MinValue : Int32.MaxValue;
            }

        }

        public static int[] Shuffle(int[] nums, int n)
        {
            int[] result = new int[nums.Length];


            int count = 0;
            for (int i = 0; i < 2 * n; i++)
            {
                if (i % 2 == 0)
                {
                    result[i] = nums[count];
                }
                else
                {
                    result[i] = nums[count + n];
                    count++;
                }
            }

            return result;
        }

        public static string ZigZagConversion(string s, int numRows)
        {
            string[] zig  = new string[numRows];

            if (numRows == 1) return s;

            int strLen = 0;
            bool goBack = false;

            try
            {
                while (strLen < s.Length)
                {
                    if (!goBack)
                    {
                        for (int rows = 0; rows < zig.Length; rows++)
                        {
                            zig[rows] += s[strLen];
                            Console.WriteLine(@"adding {0} in row {1}", s[strLen], rows + 1);
                            strLen++;
                           
                        }
                        goBack = true;
                    }
                    else
                    {
                        Console.WriteLine("in else");
                        for (int rows = zig.Length-2 ; rows > 0; rows--)
                        {
                            zig[rows] += s[strLen];
                            Console.WriteLine(@"adding {0} in row {1}", s[strLen], rows+1);
                            strLen++;
                           
                        }

                        goBack = false;
                    }
                }
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            string zag = "";
            foreach(string str in zig)
            {
                zag += str;
            }


            return zag;
        }

        public static string LongestPalindrome(string s)
        {
            int n = s.Length;
            bool[,] dp = new bool[n, n];
            int start = 0; // Start index of the longest palindrome substring
            int maxLen = 1; // Length of the longest palindrome substring

            // All substrings of length 1 are palindromes
            for (int i = 0; i < n; i++)
            {
                dp[i, i] = true;
            }

            // Check for palindromes of length 2
            for (int i = 0; i < n - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    dp[i, i + 1] = true;
                    start = i;
                    maxLen = 2;
                }
            }

            // Check for palindromes of length 3 and more
            for (int len = 3; len <= n; len++)
            {
                for (int i = 0; i <= n - len; i++)
                {
                    int j = i + len - 1; // Ending index of current substring
                    if (s[i] == s[j] && dp[i + 1, j - 1])
                    {
                        dp[i, j] = true;
                        if (len > maxLen)
                        {
                            start = i;
                            maxLen = len;
                        }
                    }
                }
            }

            return s.Substring(start, maxLen);
        }


        public static bool isPalindrome(string s)
        {
            char[] chars = s.ToCharArray();
            Array.Reverse(chars);
            string rev = new string(chars);
            return s.Equals(rev);
        }

        public static string IntToRoman(int num)
        {
            //making a hashmap of all the roman numerals
            Dictionary<int, string> roman = new Dictionary<int, string>();
            roman.Add(1, "I");
            roman.Add(4, "IV");
            roman.Add(5, "V");
            roman.Add(9, "IX");
            roman.Add(10, "X");
            roman.Add(40, "XL");
            roman.Add(50, "L");
            roman.Add(90, "XC");
            roman.Add(100, "C");
            roman.Add(400, "CD");
            roman.Add(500, "D");
            roman.Add(900, "CM");
            roman.Add(1000, "M");


            int[] ordArray = new int[roman.Count];
            ordArray = roman.Keys.ToArray();
            Array.Sort(ordArray);
            Array.Reverse(ordArray);

            StringBuilder ans = new StringBuilder();
            foreach(int n in ordArray)
            { 
                if ((num - n) < 0)
                { 
                    continue;
                }

                while( (num - n) >= 0 )
                { 
                    ans.Append(roman[n]);
                    num -= n; 
                }
            }

            return ans.ToString();
        }

        public static string LongestCommonPrefix(string[] strs)
        {
            StringBuilder ans = new StringBuilder();
            ans.Append(strs[0]);
            foreach (string str in strs)
            {
                if(str.Length < ans.Length)
                {
                    ans.Clear();
                    ans.Append(str);
                }
            }

            int goBackFrom = ans.Length ;
            bool found = false;

            while(goBackFrom > 0 && !found)
            { 
                Stack<string> strings = new Stack<string>();
                foreach (string str in strs)
                {
                    strings.Push(str.Substring(0,goBackFrom));
                }

                found = true;

                foreach(string str in strings)
                { 

                   Console.WriteLine(str);
                }
            }

            return ans.ToString();
        }

        //max water container
        public static int MaxArea(int[] height)
        {
            int max = 0,left = 0 , right = height.Length-1;


            while (left < right)
            {
                int area = Math.Min(height[left], height[right]) * (right - left);
                max = Math.Max(max, area);

                if (height[left] < height[right])
                    left++;
                else
                    right--;
            }


            return max;
            
        }


        //3Sum
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            //find all those triples which equal 0 i, j,k where i != j and k and j!=k
            IList<IList<int>> ans;
            ans = new List<IList<int>>();

            ans.Add(nums);

            foreach(int num in ans[0]) {
                Console.WriteLine($"{num[0]}");    
            }

            return ans;
        }
        static void Main(string[] args)
        {
            int[] nums = { 2, 4, 5, 24, 2 };
            Console.WriteLine(ThreeSum(nums));
        }
    }
}