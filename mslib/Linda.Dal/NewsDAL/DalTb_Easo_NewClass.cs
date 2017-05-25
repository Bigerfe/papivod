using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Linda.Entity;
 
namespace Linda.DAL
{
   /// <summary>
	/// 新闻类别信息管理
	/// </summary>
	public class DalTb_Easo_NewClass
	{

        #region 实例信息
        static object DataObj = new object();
        static DalTb_Easo_NewClass dal = null;

        /// <summary>
        /// 返回对象实例
        /// </summary>
        /// <returns></returns>
        public static DalTb_Easo_NewClass CreateInstance()
        {
            if (dal != null)
                return dal;
            else
            {
                lock (DataObj)
                {
                    if (dal == null)
                        return dal = new DalTb_Easo_NewClass();
                    else
                        return dal;
                }
            }
        }
        #endregion

		public DalTb_Easo_NewClass()
		{}
		#region  成员方法

		/// <summary>
		/// 添加新闻类别
		/// </summary>
		public int Add(Tb_Easo_NewClass model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Tb_Easo_NewClass(");
			strSql.Append("CName,Description,Type,OrderNum,Addtime)");
			strSql.Append(" values (");
			strSql.Append("@CName,@Description,@Type,@OrderNum,@Addtime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CName", SqlDbType.VarChar,50),
					new SqlParameter("@Description", SqlDbType.VarChar,200),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@OrderNum", SqlDbType.Int,4),
					new SqlParameter("@Addtime", SqlDbType.SmallDateTime)};
			parameters[0].Value = model.CName;
			parameters[1].Value = model.Description;
			parameters[2].Value = model.Type;
			parameters[3].Value = model.OrderNum;
			parameters[4].Value = model.Addtime;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
        public int Update(Tb_Easo_NewClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tb_Easo_NewClass set ");
            strSql.Append("CName=@CName,");
            strSql.Append("Description=@Description,");
            strSql.Append("Type=@Type,");
            strSql.Append("OrderNum=@OrderNum");    
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@CName", SqlDbType.VarChar,50),
					new SqlParameter("@Description", SqlDbType.VarChar,200),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@OrderNum", SqlDbType.Int,4)
				};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.CName;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.Type;
            parameters[4].Value = model.OrderNum; 

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public int Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Tb_Easo_NewClass ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Tb_Easo_NewClass GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,CName,Description,Type,OrderNum,Addtime from Tb_Easo_NewClass ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Tb_Easo_NewClass model=new Tb_Easo_NewClass();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.CName=ds.Tables[0].Rows[0]["CName"].ToString();
				model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				if(ds.Tables[0].Rows[0]["Type"].ToString()!="")
				{
					model.Type=int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrderNum"].ToString()!="")
				{
					model.OrderNum=int.Parse(ds.Tables[0].Rows[0]["OrderNum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Addtime"].ToString()!="")
				{
					model.Addtime=DateTime.Parse(ds.Tables[0].Rows[0]["Addtime"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		#endregion  成员方法


        /////////////////////////页面方法
        /// <summary>
        /// 返回类别列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetWebNewClassList(int typeid)
        {
            SqlParameter[] spa ={ new SqlParameter("@typeid", SqlDbType.Int) };
            spa[0].Value = typeid;

            return DbHelperSQL.RunProcedure("UP_GetWebNewClassList", spa, "ds");
        }

        /// <summary>
        /// 返回这个类别的名称
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public string GetClassName(int classid)
        {
            DataRow dr = DbHelperSQL.ReadRow("select top 1 cname from Tb_Easo_NewClass where [id]=" + classid);
            if (dr != null)
                return dr[0].ToString();
            else
                return "";
        }

        /// <summary>
        /// 返回这个类型的第一个类别信息
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public string[] GetForstClassInfoByType(int typeid)
        {
            string[] strs ={ "",""};
            DataRow dr = DbHelperSQL.ReadRow("select top 1 [id],cname from Tb_Easo_NewClass where [type]=" + typeid+" order by ordernum asc");
            if (dr != null)
            {
                strs[0] = dr[0].ToString();
                strs[1] = dr[1].ToString();
            }
            return strs;
        }


        /// <summary>
        /// 返回这个类型的name
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public string GetTypeName(int typeid)
        {
            string str="";
            DataRow dr = DbHelperSQL.ReadRow("select top 1 cname from Tb_Easo_NewClass where [type]=" + typeid);
            if (dr != null)
            {               
                str  = dr[0].ToString();
            }
            return str;
        }
	}
}
