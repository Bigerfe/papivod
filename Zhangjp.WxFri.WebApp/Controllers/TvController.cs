using Linda.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zhangjp.WeixinFir.DbCommon;

namespace Zhangjp.WxFri.WebApp.Controllers
{
    public class TvController : Controller
    {
        //
        // GET: /电影/

        public ActionResult Index()
        {
            //获得推荐的文章列表

            IList<Tb_Easo_News> newList = NewDal.GetInstance().GetNewList(20);

            ViewBag.News = newList;

            return View();
        }

        //
        // GET: /AboutYinliu/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /AboutYinliu/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AboutYinliu/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AboutYinliu/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /AboutYinliu/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AboutYinliu/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /AboutYinliu/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
