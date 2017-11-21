using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    /// <summary>
    /// 给定一个正整数n，给出所有的i(0~i~n)转换成二进制时“1”的个数，并计算出对应的时间复杂度。如n=5，返回[0,1,1,2,1,2]
    /// </summary>
    public class BinaryCount
    {
        public int[] Calc(int n)
        {
            var array = new int[n + 1];
            ;
            for (int i = 0; i <= n; i++)  //线性阶
            {
                array[i] = BitCount(i);  //指数阶
            }

            return array;
        }

        //计算一个十进制数字转换成二进制后1的个数
        private int BitCount(int i)
        {
            var result = 0;

            while (i > 0)
            {
                if ((i & 1) == 1)  //与计算，当前位是一
                    ++result;

                i = i >> 1;
            }

            return result;
        }
    }
}
