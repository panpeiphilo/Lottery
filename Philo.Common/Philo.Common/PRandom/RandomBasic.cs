using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Philo.Common.PRandom
{
    /// <summary>
    /// 基础随机数库
    /// </summary>
    public static class RandomBasic
    {
        /// <summary>
        /// 获取随机数种子
        /// </summary>
        /// <returns>随机数种子</returns>
        public static int GetRandomSeed()
        {
            DateTime dt = DateTime.Now;
            long l = dt.Millisecond * dt.Minute * dt.Second * dt.Hour;
            return Convert.ToInt32(l);
        }

        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <returns>随机数</returns>
        public static int GetRandomNumber()
        {
            Random random = new Random();
            return random.Next();
        }

        /// <summary>
        /// 根据种子获取随机数
        /// </summary>
        /// <param name="seed">种子</param>
        /// <returns>随机数</returns>
        public static int GetRandomBySeed(int seed)
        {
            Random random = new Random(seed);
            return random.Next();
        }

        /// <summary>
        /// 根据种子及区域获取随机数
        /// </summary>
        /// <param name="seed">种子</param>
        /// <param name="begin">起始数</param>
        /// <param name="end">结束数</param>
        /// <returns>随机数(begin必须小于end,否则返回0.)</returns>
        public static int GetRandomInArea(int seed, int begin, int end)
        {
            if (end > begin)
            {
                Random random = new Random(seed);
                int num = random.Next(begin, end);
                return num;
            }
            else
            {
                return 0;
            }            
        }
    }
}
