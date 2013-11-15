using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Philo.Common.PRandom;
using System.Data;

namespace Philo.Lottery.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetPhoneList()
        {
            List<Lottery.Models.LotteryUser> lotteryUserList = new List<Models.LotteryUser>();
            for (int index = 0; index < 2000; index++)
            {
                Lottery.Models.LotteryUser lotteryUser = new Models.LotteryUser();
                lotteryUser.Address = "地区_" + index%5 + "_首";

                lotteryUser.LotteryId = index + 1;
                lotteryUser.Mobile = "15" + index % 9 + RandomBasic.GetRandomInArea(RandomBasic.GetRandomSeed(), 1000, 9999) + RandomBasic.GetRandomInArea(RandomBasic.GetRandomSeed(), 1000, 9999);
                lotteryUser.UserName = "用户" + index;

                lotteryUserList.Add(lotteryUser);
            }
            return Json(lotteryUserList,JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetExcel()
        {
            List<Lottery.Models.LotteryUser> userlist = new List<Models.LotteryUser>();

            DataTable dt = new DataTable();
            string message = "";
            string excelpath = Server.MapPath("/Resource/ExcelData/LotteryList.xlsx");
            dt = Common.PNpoi.ExcelHelper.ReadExcel(excelpath, ref message);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                userlist.Add(new Lottery.Models.LotteryUser {
                    LotteryId = Convert.ToInt32(dt.Rows[i]["LotteryId"].ToString()),
                    UserName = dt.Rows[i]["UserName"].ToString(),
                    Mobile = dt.Rows[i]["Mobile"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString()
                });
            }
            return View(userlist);
        }
    }
}
