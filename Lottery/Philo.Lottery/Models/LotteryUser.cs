using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Philo.Lottery.Models
{
    public class LotteryUser
    {
        /// <summary>
        /// 抽奖编号
        /// </summary>
        public int LotteryId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 地区
        /// </summary>
        public string Address { get; set; }
    }
}