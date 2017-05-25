using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Common;

namespace Zhangjp.WxFri.WebApp.Controllers
{
    public class RegisteCodeController : Controller
    {
        //
        // GET: /RegisteCode/

        public ActionResult Index(string cpuid = "", string validcode = "", string getcode="0")
        {
            ViewBag.CpuId = cpuid;
            ViewBag.ValidCode = validcode;
            ViewBag.RegCode = null;
            if (!string.IsNullOrEmpty(cpuid) && !string.IsNullOrEmpty(validcode) && getcode=="1")
            {
                ViewBag.RegCode = UtilsCommon.GetValidCpuKey(cpuid, validcode);
            }
            return View();
        }

     
        /// <summary>
        /// 获取注册码
        /// </summary>
        /// <param name="cpuid"></param>
        /// <returns></returns>
        public ActionResult GetCode(string cpuid = "",string password="")
        {
            ViewBag.RegCode = null;
            if (!string.IsNullOrEmpty(cpuid) && !string.IsNullOrEmpty(password) && password=="20150523")
            {
                ViewBag.RegCode = UtilsCommon.GetLicence(cpuid);
            }
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

    }
}
