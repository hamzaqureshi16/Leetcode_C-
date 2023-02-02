using System.Collections;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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
            double num1 = double.Parse(s1);
            double num2 = double.Parse(s2);


            return ((long)(num1 * num2)).ToString();
        }
        static void Main(string[] args)
        {
            Console.WriteLine(StringProduct("123456789", "987654321"));

        }
    }
}