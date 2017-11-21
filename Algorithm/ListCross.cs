using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    /// <summary>
    /// 如何寻找两个链表（非环）的交叉点，并计算出对应的时间复杂度
    /// http://www.cnblogs.com/edisonchou/p/4822675.html
    /// </summary>
    public class ListCross
    {
        public class Node
        {
            public int Key;
            public Node NextNode;

            public Node(int key)
            {
                this.Key = key;
            }
        }

        /// <summary>
        /// 借助外部空间法
        /// </summary>
        /// <param name="head1"></param>
        /// <param name="head2"></param>
        /// <returns></returns>
        public static Node FindFirstCommonNodeWithStack(Node head1, Node head2)
        {
            if (head1 == null || head2 == null)
            {
                return null;
            }

            Stack<Node> stack1 = new Stack<Node>();
            Stack<Node> stack2 = new Stack<Node>();

            while (head1 != null)
            {
                stack1.Push(head1);
                head1 = head1.NextNode;
            }

            while (head2 != null)
            {
                stack2.Push(head2);
                head2 = head2.NextNode;
            }

            Node node1;
            Node node2;
            Node common = null;

            while (stack1.Count > 0 && stack2.Count > 0)
            {
                node1 = stack1.Peek();
                node2 = stack2.Peek();

                if (node1.Key == node2.Key)
                {
                    common = node1;
                    stack1.Pop();
                    stack2.Pop();
                }
                else
                {
                    break;
                }
            }

            return common;
        }

        /// <summary>
        /// 不借助外部空间法
        /// </summary>
        /// <param name="head1"></param>
        /// <param name="head2"></param>
        /// <returns></returns>
        public static Node FindFirstCommonNode(Node head1, Node head2)
        {
            // 得到两个链表的长度
            int length1 = GetListLength(head1);
            int length2 = GetListLength(head2);
            int diff = length1 - length2;

            Node headLong = head1;
            Node headShort = head2;
            if (diff < 0)
            {
                headLong = head2;
                headShort = head1;
                diff = length2 - length1;
            }
            // 先在长链表上走几步
            for (int i = 0; i < diff; i++)
            {
                headLong = headLong.NextNode;
            }
            // 再同时在两个链表上遍历
            while (headLong != null && headShort != null && headLong != headShort)
            {
                headLong = headLong.NextNode;
                headShort = headShort.NextNode;
            }

            Node commonNode = headLong;
            return commonNode;
        }

        private static int GetListLength(Node head)
        {
            int length = 0;
            Node tempNode = head;
            while (tempNode != null)
            {
                tempNode = tempNode.NextNode;
                length++;
            }

            return length;
        }
    }
}
