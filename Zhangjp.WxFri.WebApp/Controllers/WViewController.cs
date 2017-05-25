using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zhangjp.WxFri.WebApp.App_Start;
using System.Collections.Generic;
using Linda.Entity;
using Zhangjp.WeixinFir.DbCommon;
namespace Zhangjp.WxFri.WebApp.Controllers
{
    public class WViewController : UsController
    {
        //
        // GET: /WebView/

        public ActionResult Index()
        {
            //获得推荐的文章列表

            IList<Tb_Easo_News> newList = NewDal.GetInstance().GetHomeNew(2);

            ViewBag.News = newList;

            return View();
        }

        /// <summary>
        /// 获得新闻内容
        /// </summary>
        /// <param name="newsid"></param>
        /// <returns></returns>
        public ActionResult ShowNews(int newsid = 0)
        {

            Tb_Easo_News entity = NewDal.GetInstance().GetEntity(newsid);

            if (entity != null)
            {
                NewDal.GetInstance().AddViewCount(newsid);
            }

            return View(entity);

        }

    }
}
