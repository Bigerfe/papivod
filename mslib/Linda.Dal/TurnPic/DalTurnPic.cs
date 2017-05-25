using System;
using System.Collections.Generic;
using System.Text;
 using System.Data.SqlClient;
using System.Data;
using Linda.Entity;
 
namespace Linda.DAL 
{
    /// <summary>
    /// 轮换图片管理
    /// </summary>
    public class DalTurnPic
    {

        #region 实例信息
        static object DataObj = new object();
        static DalTurnPic dal = null;

        /// <summary>
        /// 返回对象实例
        /// </summary>
        /// <returns></returns>
        public static DalTurnPic CreateInstance()
        {
            if (dal != null)
                return dal;
            else
            {
                lock (DataObj)
                {
                    if (dal == null)
                        return dal = new DalTurnPic();
                    else
                        return dal;
                }
            }
        }

        #endregion


         /// <summary>
		/// 添加记录
		/// </summary>
        public int Add(TurnPic model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TurnPic(");
            strSql.Append("Title,Pic,WPic,Target,Http,Channel,Operid,Ordernum)");
            strSql.Append(" values (");
            strSql.Append("@Title,@Pic,@WPic,@Target,@Http,@Channel,@Operid,@Ordernum)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.VarChar,300),
					new SqlParameter("@Pic", SqlDbType.VarChar,100),
					new SqlParameter("@WPic", SqlDbType.VarChar,100),
					new SqlParameter("@Target", SqlDbType.VarChar,10),
					new SqlParameter("@Http", SqlDbType.VarChar,200),
					new SqlParameter("@Channel", SqlDbType.Int,4),
					new SqlParameter("@Operid", SqlDbType.Int,4),
            new SqlParameter("@Ordernum",SqlDbType.Int)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Pic;
            parameters[2].Value = model.WPic;
            parameters[3].Value = model.Target;
            parameters[4].Value = model.Http;
            parameters[5].Value = model.Channel;
            parameters[6].Value = model.Operid;
            parameters[7].Value = model.OrderNum;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete TurnPic ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

         /// <summary>
		/// 返回一个记录的详细信息
		/// </summary>
		public TurnPic GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Title,Pic,WPic,Target,Http,Addtime,Channel,Operid,ordernum from TurnPic ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

            TurnPic model = new TurnPic();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Pic=ds.Tables[0].Rows[0]["Pic"].ToString();
				model.WPic=ds.Tables[0].Rows[0]["WPic"].ToString();
				model.Target=ds.Tables[0].Rows[0]["Target"].ToString();
				model.Http=ds.Tables[0].Rows[0]["Http"].ToString(); 
                 
                model.OrderNum =  Utils.StrToInt(ds.Tables[0].Rows[0]["ordernum"]);
				 
				if(ds.Tables[0].Rows[0]["Addtime"].ToString()!="")
				{
					model.Addtime=DateTime.Parse(ds.Tables[0].Rows[0]["Addtime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Channel"].ToString()!="")
				{
					model.Channel=int.Parse(ds.Tables[0].Rows[0]["Channel"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Operid"].ToString()!="")
				{
					model.Operid=int.Parse(ds.Tables[0].Rows[0]["Operid"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}


		}

       /// <summary>
		/// 更新一条数据
		/// </summary>
        public int Update(TurnPic model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TurnPic set ");
            strSql.Append("Title=@Title,");
            strSql.Append("Pic=@Pic,");
            strSql.Append("WPic=@WPic,");
            strSql.Append("Target=@Target,");
            strSql.Append("Http=@Http,");
            strSql.Append("Channel=@Channel,");
            strSql.Append("Operid=@Operid,ordernum=@ordernum");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.VarChar,300),
					new SqlParameter("@Pic", SqlDbType.VarChar,100),
					new SqlParameter("@WPic", SqlDbType.VarChar,100),
					new SqlParameter("@Target", SqlDbType.VarChar,10),
					new SqlParameter("@Http", SqlDbType.VarChar,200),
					new SqlParameter("@Channel", SqlDbType.Int,4),
					new SqlParameter("@Operid", SqlDbType.Int,4),
                new SqlParameter("@ordernum", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Pic;
            parameters[3].Value = model.WPic;
            parameters[4].Value = model.Target;
            parameters[5].Value = model.Http;
            parameters[6].Value = model.Channel;
            parameters[7].Value = model.Operid;
            parameters[8].Value = model.OrderNum;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 返回首页的图片列表
        /// </summary>
        /// <returns></returns>
        public IList<string[]> GetIndexPicList(int channel)
        {
            string key = "GetIndexPicList" + channel;
            DataSet ds = (DataSet)DoCache.GetCache(key);
            if (ds == null)
                ds = DbHelperSQL.Query("select [Title],[Pic],[Wpic],[Target],[Http] from TurnPic where [Channel]="+channel+" order by ordernum asc");

            DoCache.AddCache(key, ds);

            if (ds != null)
            {
                DataRowCollection drs = ds.Tables[0].Rows;

                IList<string[]> list = new List<string[]>();

                foreach (DataRow dr in drs)
                {
                    string[] asrr = { dr["title"].ToString(), dr["pic"].ToString(), dr["wpic"].ToString(), dr["target"].ToString(), dr["http"].ToString() };

                    list.Add(asrr);
                }

                return list;
            }

            return null;
        }


        /// <summary>
        /// 返回首页幻灯的js代码
        /// </summary>
        /// <returns></returns>
        public string GetIndexPicListHtml()
        {
        //    imgUrl[1] = "/html/news/xiehuixinwen/238.html";
        //    imgLink[1] = "http://www.zgshjxh.org/uploads/091116/1_174847_1_lit.JPG";
        //    imgtext[1] = "庆祝澳门回归十周年全国书画艺术";
            IList<string[]> list = GetIndexPicList(0);

            if (list!=null)
            {
                StringBuilder sb = new StringBuilder();
                int index=0;
                foreach (string[] strs in list)
                { 
                    index +=1;
                    sb.Append("imgUrl[" + index + "]=\""+strs[4]+"\";");
                    sb.Append("\n");
                    sb.Append("imgLink[" + index + "]=\"" + strs[1] + "\";");
                    sb.Append("\n");
                    sb.Append("imgtext[" + index + "]=\"" + strs[0] + "\";"); sb.Append("\n");
                }

                return sb.ToString();
            }
            return "";

        }


        /// <summary>
        /// 返回js图片切换数组 
        /// </summary>
        /// <returns></returns>
        public string GetTurnPicJsHTML(int channel)
        {
            IList<string[]> list = GetIndexPicList(channel);


            StringBuilder sb = new StringBuilder();

            string title = "", pic = "", wpic = "", http = "";

            foreach (string[] arr in list)
            {
                title = arr[0];
                pic = arr[1];
                wpic = arr[2];
                http = arr[4];

                sb.Append("[" + "\"" + pic + "\",\"" + title + "\",\"" + http + "\",\"" + wpic + "\"],");
            }
            return sb.ToString().TrimEnd(',');
        }

    }
}
