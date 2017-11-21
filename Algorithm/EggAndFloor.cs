using System;

namespace Algorithm
{
    /// <summary>
    /// 有座100层的建筑，还有两个软硬程度一样的但未知的鸡蛋，它们有可能都在一楼就摔碎，也可能从一百层楼摔下来没事，请问在最差情况下，最少需要多少次实验才能判断
    /// 鸡蛋在多少层高度会摔碎？可以单最多只能摔碎2个鸡蛋。如：第一次在50层，最差情况下，鸡蛋碎了，第二个鸡蛋只能从1逐层试到49层，一共需要50次实验
    /// 这个问题还有一个泛化的版本，egg个鸡蛋，即floor层楼，然后设计方案找出N，使最坏情况下测试的次数最少。
    /// </summary>
    public class EggAndFloor
    {
        public int CountMinSetp(int egg, int floor)
        {
            if (egg < 1 || floor < 1)
                return 0;

            var f = new int[egg + 1, floor + 1];  //表示egg个鸡蛋，floor层楼时最小判断次数

            for (var i = 1; i <= egg; i++)
            {
                for (var j = 1; j <= floor; j++)
                    f[i, j] = j;  //初始化，最坏的步数
            }

            for (var n = 2; n <= egg; n++)
            {
                for (var m = 1; m <= floor; m++)
                {
                    for (var k = 1; k < m; k++)  //假设一个鸡蛋从第k层开始仍
                    {
                        var current = f[n, m];
                        var borken = f[n - 1, k - 1];  //如果碎了，那么还剩下n-1个鸡蛋，需要遍历剩下k-1层
                        var unBroken = f[n, m - k];  //如果没碎，那么还剩下n个鸡蛋，上面还有m-k层
                        var badSituation = Math.Max(borken, unBroken);  //题中的最差情况

                        f[n, m] = Math.Min(current, 1 + badSituation);
                    }
                }
            }

            return f[egg, floor];
        }
    }
}
