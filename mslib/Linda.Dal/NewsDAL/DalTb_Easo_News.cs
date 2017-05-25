using System;
using System.Collections.Generic;
using System.Text;
 using System.Data.SqlClient;
using System.Data;
using Linda.DAL.IServer;
using Linda.Entity;

namespace Easo.DAL
{
    /// <summary>
    /// 新闻管理
    /// </summary>
    public class DalTb_Easo_News : BaseCommon
    {
        #region 实例信息
        static object DataObj = new object();
        static DalTb_Easo_News dal = null;

        /// <summary>
        /// 返回对象实例
        /// </summary>
        /// <returns></returns>
        public static DalTb_Easo_News CreateInstance()
        {
            if (dal != null)
                return dal;
            else
            {
                lock (DataObj)
                {
                    if (dal == null)
                        return dal = new DalTb_Easo_News();
                    else
                        return dal;
                }
            }
        }
        #endregion

        public DalTb_Easo_News()
        { }

        #region  成员方法

        /// <summary>
        /// 发布新闻
        /// </summary>
        public int Add(Tb_Easo_News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tb_Easo_News(");
            strSql.Append("ClassId,Title,Content,Source,Label,IfTop,TopOrderNum,IfRecommend,RecommendOrderNum,Addtime,Downfile,viewcount,realviewcount,commentcount)");
            strSql.Append(" values (");
            strSql.Append("@ClassId,@Title,@Content,@Source,@Label,@IfTop,@TopOrderNum,@IfRecommend,@RecommendOrderNum,@Addtime,@Downfile,@viewcount,@realviewcount,@commentcount)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.VarChar,200),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@Source", SqlDbType.VarChar,200),
					new SqlParameter("@Label", SqlDbType.VarChar,2000),
					new SqlParameter("@IfTop", SqlDbType.Int,4),
					new SqlParameter("@TopOrderNum", SqlDbType.Int,4),
					new SqlParameter("@IfRecommend", SqlDbType.Int,4),
					new SqlParameter("@RecommendOrderNum", SqlDbType.Int,4),
					new SqlParameter("@Addtime", SqlDbType.SmallDateTime),
            new SqlParameter("@Downfile",SqlDbType.VarChar),
                                        new SqlParameter("@viewcount",SqlDbType.Int),
                                        new SqlParameter("@realviewcount",SqlDbType.Int),
                                        new SqlParameter("@commentcount",SqlDbType.Int),
                                        };
            parameters[0].Value = model.ClassId;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.Source;
            parameters[4].Value = model.Label;
            parameters[5].Value = model.IfTop;
            parameters[6].Value = model.TopOrderNum;
            parameters[7].Value = model.IfRecommend;
            parameters[8].Value = model.RecommendOrderNum;
            parameters[9].Value = model.Addtime;
            parameters[10].Value = model.Downfile;
            parameters[11].Value = model.viewcount;
            parameters[12].Value = model.realviewcount;
            parameters[13].Value = model.commentcount;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 发布学校信息
        /// </summary>
        public int AddXueXiao(Tb_Easo_News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tb_Easo_News(");
            strSql.Append("ClassId,Title,Content,Source,Label,IfTop,TopOrderNum,IfRecommend,RecommendOrderNum,Addtime,Downfile,add_yxaddress,add_lxguojia,add_lxms)");
            strSql.Append(" values (");
            strSql.Append("@ClassId,@Title,@Content,@Source,@Label,@IfTop,@TopOrderNum,@IfRecommend,@RecommendOrderNum,@Addtime,@Downfile,@add_yxaddress,@add_lxguojia,@add_lxms)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.VarChar,200),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@Source", SqlDbType.VarChar,200),
					new SqlParameter("@Label", SqlDbType.VarChar,2000),
					new SqlParameter("@IfTop", SqlDbType.Int,4),
					new SqlParameter("@TopOrderNum", SqlDbType.Int,4),
					new SqlParameter("@IfRecommend", SqlDbType.Int,4),
					new SqlParameter("@RecommendOrderNum", SqlDbType.Int,4),
					new SqlParameter("@Addtime", SqlDbType.SmallDateTime),
            new SqlParameter("@Downfile",SqlDbType.VarChar),new SqlParameter("@add_yxaddress",SqlDbType.VarChar),new SqlParameter("@add_lxguojia",SqlDbType.VarChar),
            new SqlParameter("@add_lxms",SqlDbType.VarChar)};
            parameters[0].Value = model.ClassId;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.Source;
            parameters[4].Value = model.Label;
            parameters[5].Value = model.IfTop;
            parameters[6].Value = model.TopOrderNum;
            parameters[7].Value = model.IfRecommend;
            parameters[8].Value = model.RecommendOrderNum;
            parameters[9].Value = model.Addtime;
            parameters[10].Value = model.Downfile;

            parameters[11].Value = model.YxAddress;
            parameters[12].Value = model.LxGuojia;
            parameters[13].Value = model.Lxms;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 修改新闻
        /// </summary>
        public int Update(Tb_Easo_News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tb_Easo_News set ");
            strSql.Append("ClassId=@ClassId,");
            strSql.Append("Title=@Title,");
            strSql.Append("Content=@Content,");
            strSql.Append("Source=@Source,");
            strSql.Append("Label=@Label,");
            strSql.Append("IfTop=@IfTop,");
          
            strSql.Append("IfRecommend=@IfRecommend,");

            strSql.Append("Addtime=@Addtime,Downfile=@Downfile,add_yxaddress=@add_yxaddress,add_lxguojia=@add_lxguojia,add_lxms=@add_lxms,viewcount=@viewcount,commentcount=@commentcount");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.VarChar,200),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@Source", SqlDbType.VarChar,200),
					new SqlParameter("@Label", SqlDbType.VarChar,2000),
					new SqlParameter("@IfTop", SqlDbType.Int,4),
				 
					new SqlParameter("@IfRecommend", SqlDbType.Int,4),
					 
					new SqlParameter("@Addtime", SqlDbType.SmallDateTime),
            new SqlParameter("@Downfile",SqlDbType.VarChar),new SqlParameter("@add_yxaddress",SqlDbType.VarChar),new SqlParameter("@add_lxguojia",SqlDbType.VarChar),
            new SqlParameter("@add_lxms",SqlDbType.VarChar),
                                        new SqlParameter("@viewcount", SqlDbType.Int,4),new SqlParameter("@commentcount", SqlDbType.Int,4),
                                        };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.ClassId;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.Content;
            parameters[4].Value = model.Source;
            parameters[5].Value = model.Label;
            parameters[6].Value = model.IfTop;
           
            parameters[7].Value = model.IfRecommend;
            
            parameters[8].Value = model.Addtime;
            parameters[9].Value = model.Downfile;
            parameters[10].Value = model.YxAddress;
            parameters[11].Value = model.LxGuojia;
            parameters[12].Value = model.Lxms;

            parameters[13].Value = model.viewcount;
            parameters[14].Value = model.commentcount;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tb_Easo_News GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,ClassId,Title,Content,Source,Label,IfTop,TopOrderNum,IfRecommend,RecommendOrderNum,Addtime,Downfile,add_yxaddress,add_lxguojia,add_lxms,viewcount,realviewcount,commentcount from Tb_Easo_News ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)};
            parameters[0].Value = ID;

            Tb_Easo_News model = new Tb_Easo_News();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds != null)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ClassId"].ToString() != "")
                {
                    model.ClassId = int.Parse(ds.Tables[0].Rows[0]["ClassId"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Downfile = ds.Tables[0].Rows[0]["Downfile"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                model.Source = ds.Tables[0].Rows[0]["Source"].ToString();
                model.Label = ds.Tables[0].Rows[0]["Label"].ToString();
                if (ds.Tables[0].Rows[0]["IfTop"].ToString() != "")
                {
                    model.IfTop = int.Parse(ds.Tables[0].Rows[0]["IfTop"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TopOrderNum"].ToString() != "")
                {
                    model.TopOrderNum = int.Parse(ds.Tables[0].Rows[0]["TopOrderNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IfRecommend"].ToString() != "")
                {
                    model.IfRecommend = int.Parse(ds.Tables[0].Rows[0]["IfRecommend"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RecommendOrderNum"].ToString() != "")
                {
                    model.RecommendOrderNum = int.Parse(ds.Tables[0].Rows[0]["RecommendOrderNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Addtime"].ToString() != "")
                {
                    model.Addtime = DateTime.Parse(ds.Tables[0].Rows[0]["Addtime"].ToString());
                }

                model.YxAddress = ds.Tables[0].Rows[0]["add_yxaddress"].ToString();
                model.LxGuojia = ds.Tables[0].Rows[0]["add_lxguojia"].ToString();
                model.Lxms = ds.Tables[0].Rows[0]["add_lxms"].ToString();

                model.viewcount =int.Parse( ds.Tables[0].Rows[0]["viewcount"].ToString());
                model.realviewcount = int.Parse(ds.Tables[0].Rows[0]["realviewcount"].ToString());
                model.commentcount =int.Parse( ds.Tables[0].Rows[0]["commentcount"].ToString());
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 设置一个类别没有推荐的信息，这个设置针对一个类别只能推荐一条的类别
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public int SetNoCommend(int classid)
        {
            return DbHelperSQL.ExecuteSql("update " + tbname + " set [IfRecommend]=0 where classid=" + classid);
        }

        /// <summary>
        /// 返回这个新闻所属的栏目
        /// </summary>
        /// <param name="newid"></param>
        /// <returns></returns>
        public int GetCurNewTypeID(int newid)
        {
            DataSet ds  = DbHelperSQL.Query("select top 1 type from Tb_Easo_NewClass where [id]=(select top 1 ClassId from Tb_Easo_News where [id]="+newid+") ");
            if (ds != null)
            {
                int type = int.Parse(ds.Tables[0].Rows[0][0].ToString());

                return type;
            }
            else
                return 0;
        }


        #endregion  成员方法

        public override string tbname
        {
            get { return "Tb_Easo_News"; }
        }

        public override string tbkey
        {
            get { return "id"; }
        }
    }
}
