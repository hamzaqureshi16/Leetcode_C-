using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LeetCode_problems
{
    internal class LinkedList
    {
        private ListNode head;
        public ListNode Head { get { return head; }
               set { head = value; }
        }
        public void Add(int x)
        {
            ListNode node = new ListNode(x);
            if (head == null)
            {
                head = node;
            }
            else
            {
                ListNode current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = node;
            }
        }
        public void Print()
        {
            ListNode current = head;
            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public void removeFromEnd()
        {
            ListNode current = head;
            ListNode prev = null;
            while (current.Next != null)
            {
                prev = current;
                current = current.Next;
            }
            prev.Next = null;
        }

        public void remove(ListNode node) {
            ListNode current = head;
            if(current == node)
            {
                head = current.Next;
                return;
            }

            while(current != null)
            {
                if(current.Next == node)
                {
                    current.Next = current.Next.Next;
                    return;
                }
                current = current.Next;
            }

        }

        public void removeFromStart()
        {
            this.head = this.head.Next;
        }
    }
}
