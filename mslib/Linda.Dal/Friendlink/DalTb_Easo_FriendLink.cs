using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Linda.DAL.IServer;
using Linda.Entity;
 
namespace Easo.DAL
{

    /// <summary>
    /// 数据访问类T_links 。
    /// </summary>
    public class DalTb_Easo_FriendLink : BaseCommon
    {
        public DalTb_Easo_FriendLink()
        { }

        #region   实例信息
        static object obj = new object();
        static DalTb_Easo_FriendLink dal = null;

        /// <summary>
        /// 返回对象实例
        /// </summary>
        /// <returns></returns>
        public static DalTb_Easo_FriendLink CreateInstance()
        {
            if (dal != null)
                return dal;
            else
            {
                lock (obj)
                {
                    if (dal == null)
                        return dal = new DalTb_Easo_FriendLink();
                    else
                        return dal;
                }
            }
        }


        #endregion

        #region  成员方法

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tb_Easo_FriendLink model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tb_Easo_FriendLink(");
            strSql.Append("LocationType,Name,Url,Sort,Pic,Description,Type,ClickNum,Addtime)");
            strSql.Append(" values (");
            strSql.Append("@LocationType,@Name,@Url,@Sort,@Pic,@Description,@Type,@ClickNum,@Addtime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@LocationType", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,100),
					new SqlParameter("@Url", SqlDbType.VarChar,500),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Pic", SqlDbType.VarChar,50),
					new SqlParameter("@Description", SqlDbType.VarChar,300),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@ClickNum", SqlDbType.Int,4),
					new SqlParameter("@Addtime", SqlDbType.SmallDateTime)};
            parameters[0].Value = model.LocationType;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Url;
            parameters[3].Value = model.Sort;
            parameters[4].Value = model.Pic;
            parameters[5].Value = model.Description;
            parameters[6].Value = model.Type;
            parameters[7].Value = model.ClickNum;
            parameters[8].Value = model.Addtime;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Tb_Easo_FriendLink model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tb_Easo_FriendLink set ");
            strSql.Append("LocationType=@LocationType,");
            strSql.Append("Name=@Name,");
            strSql.Append("Url=@Url,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("Pic=@Pic,");
            strSql.Append("Description=@Description,");
            strSql.Append("Type=@Type,");
            strSql.Append("ClickNum=@ClickNum,");
            strSql.Append("Addtime=@Addtime");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@LocationType", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,100),
					new SqlParameter("@Url", SqlDbType.VarChar,500),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Pic", SqlDbType.VarChar,50),
					new SqlParameter("@Description", SqlDbType.VarChar,300),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@ClickNum", SqlDbType.Int,4),
					new SqlParameter("@Addtime", SqlDbType.SmallDateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.LocationType;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Url;
            parameters[4].Value = model.Sort;
            parameters[5].Value = model.Pic;
            parameters[6].Value = model.Description;
            parameters[7].Value = model.Type;
            parameters[8].Value = model.ClickNum;
            parameters[9].Value = model.Addtime;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tb_Easo_FriendLink GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,LocationType,Name,Url,Sort,Pic,Description,Type,ClickNum,Addtime from Tb_Easo_FriendLink ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Tb_Easo_FriendLink model = new Tb_Easo_FriendLink();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LocationType"].ToString() != "")
                {
                    model.LocationType = int.Parse(ds.Tables[0].Rows[0]["LocationType"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Url = ds.Tables[0].Rows[0]["Url"].ToString();
                if (ds.Tables[0].Rows[0]["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
                }
                model.Pic = ds.Tables[0].Rows[0]["Pic"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ClickNum"].ToString() != "")
                {
                    model.ClickNum = int.Parse(ds.Tables[0].Rows[0]["ClickNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Addtime"].ToString() != "")
                {
                    model.Addtime = DateTime.Parse(ds.Tables[0].Rows[0]["Addtime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="type">1文字 0图片</param>
        /// <param name="count">条数</param>
        /// <param name="channel">栏目id 0首页</param>
        /// <returns></returns>
        public DataSet GetLinkList(int type, int count,int channel)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@count",SqlDbType.Int),
                new SqlParameter("@type",SqlDbType.Int),
                new SqlParameter("@LocationType",SqlDbType.Int)
                    };

            parameters[0].Value = count;
            parameters[1].Value = type;
            parameters[2].Value = channel;
            return DbHelperSQL.RunProcedure("UP_GetFriendLinkList", parameters, "ds");
        }


        #endregion  成员方法

        public override string tbkey
        {
            get { return "ID"; }
        }
        public override string tbname
        {
            get { return "Tb_Easo_FriendLink"; }
        }


    }
}