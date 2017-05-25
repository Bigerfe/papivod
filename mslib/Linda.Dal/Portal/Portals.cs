using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Easo.DAL;

namespace Linda.DAL
{
    /// <summary>
    /// 前台页面调用
    /// </summary>
    public class Portals
    {

        /// <summary>
        /// 返回这个类别的推荐新闻
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public static DataSet GetTopNewsByClassidCommend(int classid, int count)
        {
            string key = "GetTopNewsByClassidCoommend" + classid + count;
            DataSet ds = (DataSet)DoCache.GetCache(key);
            if (ds == null)
            {
                ds = DbHelperSQL.Query(" select top " + count + " id,title,Label,addtime,downfile from Tb_Easo_News where classid=" + classid + "  and IfRecommend=1  order by [RecommendOrderNum] asc");

                DoCache.AddCache(key, ds);
            }
            return ds;
        }

        /// <summary>
        /// 返回从指定推荐类里面推荐的信息 留学咨询,高中留学，本科生留学，留学预警，签证护照
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public static DataSet GetNewsListFromTheClassidCommend(int count)
        {
            string key = "GetNewsListFromTheClassidCommend" +  count;
            DataSet ds = (DataSet)DoCache.GetCache(key);
            if (ds == null)
            {
                ds = DbHelperSQL.Query(" select top " + count + " id,title,Label,addtime,downfile from Tb_Easo_News where classid in  (select id from Tb_Easo_NewClass where type in (2,100,101,6,105)) and IfRecommend=1  order by [RecommendOrderNum] asc");

                DoCache.AddCache(key, ds);
            }
            return ds;
        }


        /// <summary>
        /// 返回推荐院校的最新学校信息
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public static DataSet GetTjyxInfos(int count)
        {
            string key = "GetTjyxInfos" + count;
            DataSet ds = (DataSet)DoCache.GetCache(key);
            if (ds == null)
            {
                ds = DbHelperSQL.Query(" select top " + count + " id,title,add_yxaddress,add_lxguojia,add_lxms,label,downfile from Tb_Easo_News where classid in (select [id] from Tb_Easo_NewClass where [type]=" + (int)GlobalData.院校推荐 + ") order by [id] desc");

                DoCache.AddCache(key, ds);
            }
            return ds;
        }

        /// <summary>
        /// 返回被设为推荐的院校的最新学校信息
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public static DataSet GetTjyxInfos_ByTj(int count)
        {
            string key = "GetTjyxInfos_ByTj" + count;
            DataSet ds = (DataSet)DoCache.GetCache(key);
            if (ds == null)
            {
                ds = DbHelperSQL.Query(" select top " + count + " id,title,add_yxaddress,add_lxguojia,add_lxms,label,downfile from Tb_Easo_News where classid in (select [id] from Tb_Easo_NewClass where [type]=" + (int)GlobalData.院校推荐 + ") and IfRecommend=1  order by [RecommendOrderNum] asc");

                DoCache.AddCache(key, ds);
            }
            return ds;
        }


        /// <summary>
        /// 返回这个类别的前几条新闻  供首页显示
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public static DataSet GetTopNewsByClassid(int classid, int count)
        {
            string key = "GetTopNewsByClassid" + classid + count;
            DataSet ds = (DataSet)DoCache.GetCache(key);
            if (ds == null)
            {
                // ds = DbHelperSQL.Query(" select top " + count + " id,title,addtime,downfile from Tb_Easo_News where classid=" + classid + "  and IfRecommend=1  order by [RecommendOrderNum] asc");
                ds = DbHelperSQL.Query(" select top " + count + " id,title,addtime,downfile from Tb_Easo_News where classid in (select [id] from Tb_Easo_NewClass where [type]=" + classid + ") order by [id] desc");

                DoCache.AddCache(key, ds);
            }
            return ds;
        }


        /// <summary>
        /// 返回这个类别的前几条新闻  供首页显示
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        private static DataSet GetCommendNewsByType(int typeid, int count)
        {
            string key = "GetCommendNewsByType" + typeid + count;
            DataSet ds = (DataSet)DoCache.GetCache(key);
            if (ds == null)
            {
                ds = DbHelperSQL.Query(" select top " + count + " id,title,content,addtime from Tb_Easo_News where classid in (select [id] from Tb_Easo_NewClass where [type]=" + typeid + ")  and IfRecommend=1  order by [RecommendOrderNum] asc");
                //ds = DbHelperSQL.Query(" select top " + count + " id,title,addtime,downfile from Tb_Easo_News where classid in (select [id] from Tb_Easo_NewClass where [type]=" + classid + ") order by [id] desc");

                DoCache.AddCache(key, ds);
            }
            return ds;
        }

        /// <summary>
        /// 返回首页关于我们的推荐的信息 0 id,1title ,2描述
        /// </summary>
        /// <returns></returns>
        public static string[] GetBhdtCommandInfo()
        {
            DataSet ds = GetCommendNewsByType((int)GlobalData.大学排名, 1);
            string[] strs = { "", "", "" };
            if (ds != null)
            {
                strs[0] = ds.Tables[0].Rows[0][0].ToString();
                strs[1] = ds.Tables[0].Rows[0][1].ToString();
                strs[2] = ds.Tables[0].Rows[0][2].ToString();
            }

            return strs;
        }


        /// <summary>
        /// 返回这个类别的推荐的一条信息
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        static DataSet GetTopNewsByClassid(int classid)
        {
            string key = "GetTopNewsByClassid" + classid + "sesese";
            DataSet ds = (DataSet)DoCache.GetCache(key);
            if (ds == null)
            {
                ds = DbHelperSQL.Query(" select top 1 id,title,content,Downfile  from Tb_Easo_News where classid=" + classid + "  and IfRecommend=1  order by [RecommendOrderNum] asc");

                DoCache.AddCache(key, ds);
            }
            return ds;
        }

        /// <summary>
        /// 返回首页关于我们的推荐的信息 0 id,1title ,2描述
        /// </summary>
        /// <returns></returns>
        public static string[] GetAboutUsCommandInfo()
        {
            DataSet ds = GetTopNewsByClassid((int)GlobalData.教学管理);
            string[] strs = { "", "", "" };
            if (ds != null)
            {
                strs[0] = ds.Tables[0].Rows[0][0].ToString();
                strs[1] = ds.Tables[0].Rows[0][1].ToString();
                strs[2] = ds.Tables[0].Rows[0][2].ToString();
            }

            return strs;
        }

        /// <summary>
        /// 返回这条新闻的基本信息
        /// </summary>
        /// <param name="nid"></param>
        /// <returns></returns>
        public static DataRow GetOneNewSampleContent(int nid)
        {
            return DbHelperSQL.ReadRow("select top 1  [id],[title],[downfile],[content],[addtime],[ClassId],[label] from Tb_Easo_News where [id]=" + nid);
        }

        /// <summary>
        /// 返回指定新闻的详细信息 0id,1标题,2downfile,3 content,4addtime
        /// </summary>
        /// <param name="nid">id</param>
        /// <returns></returns>
        public static string[] GetNewsContent(int nid)
        {
            DataRow dr = GetOneNewSampleContent(nid);
            string[] strs = { "", "", "", "", "", "","" };
            if (dr != null)
            {
                strs[0] = dr[0].ToString();
                strs[1] = dr[1].ToString();
                strs[2] = dr[2].ToString();
                strs[3] = dr[3].ToString();
                strs[4] = dr[4].ToString();
                strs[5] = dr[5].ToString();
                strs[6] = dr[6].ToString();
            }
            return strs;
        }


        /// <summary>
        /// 返回首页会长简介的信息 0 id,1 pic ,2描述
        /// </summary>
        /// <returns></returns>
        public static string[] GetHuizhangInfoForIndex()
        {
            DataRow dr = GetOneNewSampleContent(ConfigHelper.GetConfigInt("huizhang"));
            string[] strs = { "", "", "" };
            if (dr != null)
            {
                strs[0] = dr[0].ToString();
                strs[1] = dr[2].ToString();
                strs[2] = dr[3].ToString();
            }

            return strs;
        }


        /// <summary>
        /// 返回这个类别的新闻，但不计算推荐参数
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public static DataSet GetNewsListByClass(int classid, int count)
        {
            string key = "GetNewsListByClass" + classid + count;
            DataSet ds = (DataSet)DoCache.GetCache(key);
            if (ds == null)
            {
                ds = DbHelperSQL.Query(" select top " + count + " id,title,addtime from Tb_Easo_News where classid=" + classid + "   order by [RecommendOrderNum] asc");

                DoCache.AddCache(key, ds);
            }
            return ds;
        }

        /// <summary>
        /// 返回这个类别最新的新闻
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public static DataSet GetZxNewsListByClass(int classid, int count)
        {
            string key = "GetZxNewsListByClass222" + classid + count;
            DataSet ds = (DataSet)DoCache.GetCache(key);
            string sql = " select top " + count + " id,title,addtime,downfile from Tb_Easo_News where classid in (select [id] from Tb_Easo_NewClass where [type]=" + classid + ") order by [id] desc";

            if (ds == null)
            {

                ds = DbHelperSQL.Query(sql);


                DoCache.AddCache(key, ds);
            }

            return ds;
        }

        /// <summary>
        /// 返回指定类别下的，根据排序显示的第一条新闻 0id,1标题，2内容
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public static string[] GetFirstNewByClass(int classid)
        {
            DataRow dr = DbHelperSQL.ReadRow("select top 1 id,title,[content] from Tb_Easo_News where [classid]=" + classid + " order by [RecommendOrderNum] asc");
            string[] strs ={ "", "", "" };
            if (dr != null)
            {
                strs[0] = dr[0].ToString();
                strs[1] = dr[1].ToString();
                strs[2] = dr[2].ToString();
            }
            return strs;
        }



        /// <summary>
        /// 返回友情链接诶
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public static DataSet GetLinkList(int type, int count, int channel)
        {
            string key = "GetLinkList" + count + channel;
            DataSet ds = (DataSet)DoCache.GetCache(key);

            if (ds == null)
            {

                ds = DalTb_Easo_FriendLink.CreateInstance().GetLinkList(type, count, channel);

                DoCache.AddCache(key, ds);
            }

            return ds;
        }



        /// <summary>
        /// 返回推荐的公告
        /// </summary>       
        /// <returns></returns>
        private static DataSet GetCommendGonggao(int count)
        {
            string key = "GetCommendGonggao" + count;
            DataSet ds = (DataSet)DoCache.GetCache(key);
            if (ds == null)
            {
                ds = DbHelperSQL.Query(" select top " + count + " id,title from Tb_Easo_News where classid=" + (int)GlobalData.最新公告 + "  and IfRecommend=1  order by [RecommendOrderNum] asc");
                //ds = DbHelperSQL.Query(" select top " + count + " id,title,addtime,downfile from Tb_Easo_News where classid in (select [id] from Tb_Easo_NewClass where [type]=" + classid + ") order by [id] desc");

                DoCache.AddCache(key, ds);
            }
            return ds;
        }

        /// <summary>
        /// 返回推荐的公告
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string GetCommandGonggaoStrs(int count)
        {
            DataSet ds = GetCommendGonggao(count);
            StringBuilder sb = new StringBuilder();
            if (ds != null)
            {
                int index = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sb.Append((index == 0 ? " " : " | ") + "<a href=\"/news/" + dr[0].ToString() + "\">" + dr[1].ToString() + "</a> ");
                    index += 1;
                }
            }

            return sb.ToString();
        }


        /// <summary>
        /// 返回热点zhuant
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public static DataSet GetHotZt(int count)
        {
            string key = "GetHotZt" + count;
            DataSet ds = (DataSet)DoCache.GetCache(key);
            if (ds == null)
            {
                ds = DbHelperSQL.Query(" select top " + count + " id,title,downfile,content from Tb_Easo_News where classid =" + (int)GlobalData.热点专题 + " order by [id] desc");

                DoCache.AddCache(key, ds);
            }
            return ds;
        }

        /// <summary>
        ///  返回热点zhuant
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string GetHotZtStrs(int count)
        {
            DataSet ds = GetHotZt(count);
            StringBuilder sb = new StringBuilder();
            string f1 = "<div class=\"l2\"><div class=\"img\"><a href='/news/{1}/' target='_blank'><img src=\"{0}\" width='80' height='60' /></a></div><div class=\"l2title\"><div><a href=\"/news/{1}\" target='_target'>{2}</a></div><div>{3}<a href=\"/news/{1}\" target='_target'>全文</a></div></div></div>";

            string f2 = "<div class=\"l1\"><a href=\"/news/{0}\" title='{2}' target='_blank'>{1}</a></div>";

            if (ds != null)
            {
                int index = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (index == 0)
                    {
                        sb.Append(string.Format(f1, dr[2].ToString(), dr[0].ToString(), Utils.GetSubString(dr[1].ToString(), 16, "..."), Utils.GetSubString(StringUtil.NoHTML(dr[3].ToString()), 34, "...")));
                    }
                    else
                    {
                        sb.Append(string.Format(f2, dr[0].ToString(), Utils.GetSubString(dr[1].ToString(), 28, "..."), dr[1].ToString()));
                    }

                    index += 1;
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 返回国外大学列表
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string[] GetGuoWaiDaxueClass(int classcount, int infocount)
        {
            DataSet ds = DalTb_Easo_NewClass.CreateInstance().GetWebNewClassList((int)GlobalData.国外合作大学);
            StringBuilder sb = new StringBuilder();

            StringBuilder sb1 = new StringBuilder();
            DataSet dsinnder = null;


            StringBuilder sb2 = new StringBuilder();

            string f1 = "<div class=\"list\" id=\"guowaidaxue_{0}\"  style='display:{1}'>";
            string con = "<div><a href=\"/news/{0}\" target='_blank'>{1}</a></div>";
            string f2 = "</div>";

            if (ds != null)
            {

                StringBuilder sbi;

                int index = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sbi = new StringBuilder();

                    sb.Append("<li class=\"" + (index == 0 ? "tbover" : "") + "\" id=\"guowaidaxue" + index + "\">" + dr["cname"].ToString() + "</li>");

                    dsinnder = GetNewsListByClass(int.Parse(dr["Id"].ToString()), infocount);



                    sb1.Append(string.Format(f1, index, (index == 0 ? "" : "none")));
                    if (dsinnder != null)
                    {
                        foreach (DataRow dd in dsinnder.Tables[0].Rows)
                        {
                            sbi.Append(string.Format(con, dd[0].ToString(), Utils.GetSubString(dd[1].ToString(), 16, "...")));
                        }
                    }

                    sb1.Append(sbi.ToString());

                    sb1.Append(f2);

                    sb2.Append("$(\"#guowaidaxue" + index + "\").mouseover(function(){" +
             "changetb(" + ds.Tables[0].Rows.Count + "," + index + ",\"\",\"tbover\",\"guowaidaxue\")" +
           "});");

                    index += 1;
                }
            }
            return new string[] { sb.ToString(), sb1.ToString(), sb2.ToString() };
        }



        /// <summary>
        /// 返回这个类别的类型ID
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public static int GetTypeID(int classid)
        {
            string key = "GetTypeID" + classid;
            object strtype = DoCache.GetCache(key);
            if (strtype == null)
            {
                DataRow dr = DbHelperSQL.ReadRow("select top 1 type from Tb_Easo_NewClass where id=" + classid);

                if (dr != null)
                {
                    strtype = dr[0].ToString();
                    DoCache.AddCache(key, strtype);
                }
            }

            return Utils.StrToInt( strtype);
        }


    }
}
