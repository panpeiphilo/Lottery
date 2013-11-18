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
            List<Lottery.Models.LotteryUser> userlist = new List<Models.LotteryUser>();

            DataTable dt = new DataTable();
            string message = "";
            bool bo = false;
            string excelpath = Server.MapPath("/Resource/ExcelData/LotteryList.xlsx");
            dt = Common.PNpoi.ExcelHelper.ReadExcel(excelpath, ref bo, ref message);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                userlist.Add(new Lottery.Models.LotteryUser
                {
                    LotteryId = Convert.ToInt32(dt.Rows[i]["LotteryId"].ToString()),
                    UserName = dt.Rows[i]["UserName"].ToString(),
                    Mobile = dt.Rows[i]["Mobile"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString()
                });
            }
            return Json(userlist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLotteryResult()
        {
            int i = 0;
            DataTable dt = new DataTable();
            string message = "";
            bool bo = false;
            string excelpath = Server.MapPath("/Resource/ExcelData/LotteryList.xlsx");
            dt = Common.PNpoi.ExcelHelper.ReadExcel(excelpath, ref bo, ref message);

            i = Common.PRandom.RandomBasic.GetRandomInArea(Common.PRandom.RandomBasic.GetRandomSeed(), 1, dt.Rows.Count);
            return Json(i, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetExcel()
        {
            List<Lottery.Models.LotteryUser> userlist = new List<Models.LotteryUser>();

            DataTable dt = new DataTable();
            string message = "";
            bool bo = false;
            string excelpath = Server.MapPath("/Resource/ExcelData/LotteryList.xlsx");
            dt = Common.PNpoi.ExcelHelper.ReadExcel(excelpath, ref bo, ref message);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                userlist.Add(new Lottery.Models.LotteryUser
                {
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
