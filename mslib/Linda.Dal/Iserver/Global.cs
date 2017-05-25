using System;
using System.Collections.Generic;
using System.Text;

namespace Linda.DAL
{
    /// <summary>
    /// 全局变量
    /// </summary>
    public class Global
    {
        /// <summary>
        /// 获得一个类别的url
        /// </summary>
        /// <returns></returns>
        public static string ClassUrlList(int cid)
        {
            string key = "ClassUrlList1111";
            SortedList<int, string> list = (SortedList<int, string>)DoCache.GetCache(key);
            if (list == null)
            {
                list = new SortedList<int, string>();

                list.Add((int)GlobalData.最新公告, "/gonggao/");
                list.Add((int)GlobalData.录取快报, "/lqkb/");
                list.Add((int)GlobalData.留学资讯, "/lxzx/");
                list.Add((int)GlobalData.热点专题, "/hotzt/");
                list.Add((int)GlobalData.精彩图片, "/jctp/");
                list.Add((int)GlobalData.院校动态, "/yxdt/");
                list.Add((int)GlobalData.教学管理, "/jxgl/");
                list.Add((int)GlobalData.留学预警, "/sztd/");
                list.Add((int)GlobalData.留学预科, "/lxyk/");
                list.Add((int)GlobalData.留学预科课程, "/lxykkc/");
                list.Add((int)GlobalData.国外合作大学, "/guowaidaxue/");
                list.Add((int)GlobalData.大学排名, "/dxpm/");
                list.Add((int)GlobalData.专业排名, "/zypm/");
                DoCache.AddCache(key, list);
            }
            return list[cid];
        }

        public static string jsturnpath = "/upfiles/jsture/";
        /// <summary>
        /// 允许上传的图片的最大kb
        /// </summary>
        public static int InfoUpSize = 100;

        /// <summary>
        /// 一个信息允许上传的图片个数
        /// </summary>
        public static int InfoUpPics = 8;

        /// <summary>
        /// 帮助信息的id设置
        /// </summary>
        public static int helpid = 3;


        /// <summary>
        /// 是否启用缓存
        /// </summary>
        public static bool UseCache = ConfigHelper.GetConfigInt("UsedCache") == 1 ? true : false;


        /// <summary>
        /// 友情链接的图片地址
        /// </summary>
        public static string linkimgpath = "/upfiles/friendlink";

        /// <summary>
        /// 默认上传图片的大小 300kb
        /// </summary>
        public static int default_filesize = 300;

        /// <summary>
        /// 默认用户上传图片的大小20kb
        /// </summary>
        public static int user_default_filesize = 20;

        /// <summary>
        /// 图片默认上传目录
        /// </summary>
        public static string default_imgpath = "/upfiles/website/";

        /// <summary>
        /// 默认图片类型
        /// </summary>
        public static string default_imgtype = ".jpg,.gif,.jpeg,.bmp,.png";

        /// <summary>
        /// 广告图片的上传路径 
        /// </summary>
        public static string AdsImage_Path = "/upfiles/guangg/";

        /// <summary>
        /// 广告flash的上传路径 
        /// </summary>
        public static string AdsFlash_Path = "/upfiles/flashgg/";

        /// <summary>
        /// 广告flash的类型
        /// </summary>
        public static string AdsFlash_type = ".swf";


        /// <summary>
        /// 广告音频地址
        /// </summary>
        public static string AdsVideo_Path = "/upfiles/adsvideo/";

        /// <summary>
        /// 广告音频类型
        /// </summary>
        public static string AdsVideo_type = ".mp3,.wav";

        /// <summary>
        /// 广告音频大小
        /// </summary>
        public static int AdsVieo_Size = 2000;

        /// <summary>
        /// 广告视频地址
        /// </summary>
        public static string AdsFlv_Path = "/upfiles/adsflv/";

        /// <summary>
        /// 广告视频类型
        /// </summary>
        public static string AdsFlv_type = ".flv";


        /// <summary>
        /// 管理员照片地址
        /// </summary>
        public static string adminpicpath = "/upfiles/adminpic/";

        /// <summary>
        /// 管理员照片允许大小
        /// </summary>
        public static int adminpicsize = 200;

        /// <summary>
        /// 返回类型名称
        /// </summary>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public static string GetTypeName(int typeid)
        {
            if (typeid == 4)
                return "国外合作大学";
            else if (typeid == 16)
                return "报名志愿";
            else if (typeid == 17)
                return "学历";
            return "";
        }
    }


    /// <summary>
    /// 新闻类别所属类型的枚举形式
    /// </summary>
    public enum GlobalData
    {
        院校动态 = 1,
        留学资讯 = 2,
        留学预科 = 3,
        国外合作大学 = 4,
        教学管理 = 5,
        留学预警 = 6,
        预科导航 = 7,
        最新公告 = 8,
        录取快报 = 9,
        大学排名 = 10,
        专业排名 = 11,
        热点专题 = 12,
        精彩图片 = 13,
        留学预科课程 = 15,
        报名志愿 = 16,
        学历=17,

        高中生留学=100,
        本科生留学=101,
        院校推荐=102,
        海外生活=103,
        出国考试=104,
        签证护照=105,
        推荐课程=106,
        招生简章=107,
        海外大学排名=10,
        留学经验交流=108,
        留学国家=1000,
        所在城市=10001


    }

    /// <summary>
    /// 系统单页面的id设置
    /// </summary>
    public enum EnumSianPage
    {
        学校简介 = 101,
        联系我们 = 100,
    }

}
