using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_problems
{
    internal class ListNode
    {
        private int val;
        private ListNode next;

        public ListNode(int x) { val = x; }
        public int Value { get { return val; }
        set { val = value; }  
        }
        public ListNode Next { get { return next; }
        set { next = value; }
        }

    }
}
