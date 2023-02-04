using System.Collections;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

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
            return (length%2==0) ? (double)(arr1[(length-1 )/ 2] + arr1[((length-1) /2)+1])/2 : (double)arr1[(length-1) / 2];
            
        }

        public static void ReverseInteger(ref int number)
        {
            int reverse = 0;

            while(number != 0)
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
            //9999999991
            //9

            num1.Add(l1.val);
            l1 = l1.next;
            num2.Add(l2.val);
            l2 = l2.next;
            
            num2.Reverse();
            num1.Reverse();

            string x1="", x2="";

            foreach (int i in num1)
            {
                x1+=(i.ToString());
            }
            foreach(int i in num2)
            {
                x2+= (i.ToString());
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
            //multiply two strings without using biginteger
            //123456789
            //987654321
            //121932631112635269

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
                for(int r = 0; r < arr.Length; r++)
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
            BigInteger number = 0;

            s = s.Trim();
            Console.WriteLine(s);
            if (s.Contains('-')) isNegative = true;

            

            if (isNegative)
            {
                if (!Int32.TryParse(s[0].ToString(), out int re)) return 0;
            }
            else
            {
                if (!Int32.TryParse(s[1].ToString(), out int re)) return 0;
            }

            for(int i = 0; i < s.Length; i++)
            {
                if (Int32.TryParse(s[i].ToString(),out int res) )
                {
                    number = (number * 10) + res;

                   
                }
            }

            if (number >= Int32.MaxValue) return Int32.MaxValue;
            else if (number <= Int32.MinValue) return Int32.MinValue; 

            return isNegative ? Convert.ToInt32(number) * (-1) : Convert.ToInt32(number);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(-91283472332 < Int32.MinValue);
           Console.WriteLine(MyAtoi("-91283472332"));
        }
    }
}