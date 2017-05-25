using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using Linda.DAL.IServer;
using Linda.Entity;
 
namespace Linda.DAL
{

    /// <summary>
    /// 管理操作类
    /// </summary>
    public class DalManager : BaseCommon
    {

        #region 实例信息
        static object DataObj = new object();
        static DalManager dal = null;

        /// <summary>
        /// 返回对象实例
        /// </summary>
        /// <returns></returns>
        public static DalManager CreateInstance()
        {
            if (dal != null)
                return dal;
            else
            {
                lock (DataObj)
                {
                    if (dal == null)
                        return dal = new DalManager();
                    else
                        return dal;
                }
            }
        }

        #endregion

        #region  成员方法

        /// <summary>
        /// 判断管理员账号是否存在
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int ExistsManagerId(string uid)
        {
            SqlDataReader sr = DbHelperSQL.ExecuteReader("select sManager from wManager where [sManager]='" + uid + "'");
            if (sr.Read())
                return 1;
            else
                return 0;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(wManager model)
        {
            if (ExistsManagerId(model.sManager) == 1)
                return -1;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wManager(");
            strSql.Append(@"sManager,sManagerName,sPassWord,sCertName,sCertId,
sMail,sAddress,sTel,sMobile,sFax,sQQ,sCall,sDuty,sRemark,sPicName,dtStart,dtEnd,sLogin,dtLogin,roleid,type,isTopPermissions)");
            strSql.Append(" values (");
            strSql.Append(@"@sManager,@sManagerName,@sPassWord,
            @sCertName,@sCertId,@sMail,@sAddress,@sTel,@sMobile,@sFax,@sQQ,@sCall,@sDuty,@sRemark,@sPicName,@dtStart,@dtEnd,@sLogin,@dtLogin,@roleid,@type,@isTopPermissions)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sManager", SqlDbType.NVarChar),
					new SqlParameter("@sManagerName", SqlDbType.NVarChar),
					new SqlParameter("@sPassWord", SqlDbType.NVarChar),
					new SqlParameter("@sCertName", SqlDbType.NVarChar),
					new SqlParameter("@sCertId", SqlDbType.NVarChar),
					new SqlParameter("@sMail", SqlDbType.NVarChar),
					new SqlParameter("@sAddress", SqlDbType.NVarChar),
					new SqlParameter("@sTel", SqlDbType.NVarChar),
					new SqlParameter("@sMobile", SqlDbType.NVarChar),
					new SqlParameter("@sFax", SqlDbType.NVarChar),
					new SqlParameter("@sQQ", SqlDbType.NVarChar),
					new SqlParameter("@sCall", SqlDbType.NVarChar),
					new SqlParameter("@sDuty", SqlDbType.NVarChar),
					new SqlParameter("@sRemark", SqlDbType.NVarChar),
				 
					new SqlParameter("@sPicName", SqlDbType.NVarChar),
					new SqlParameter("@dtStart", SqlDbType.DateTime),
					new SqlParameter("@dtEnd", SqlDbType.DateTime),
					new SqlParameter("@cDel", SqlDbType.NVarChar),
					new SqlParameter("@sLogin", SqlDbType.NVarChar),
					new SqlParameter("@dtLogin", SqlDbType.DateTime),
                    new SqlParameter("@roleid",SqlDbType.Int),
                  new SqlParameter("@type",SqlDbType.VarChar),
                new SqlParameter("@isTopPermissions",SqlDbType.VarChar)
            };


            parameters[0].Value = model.sManager;
            parameters[1].Value = model.sManagerName;
            parameters[2].Value = Utils.MD5(model.sPassWord);
            parameters[3].Value = model.sCertName;
            parameters[4].Value = model.sCertId;
            parameters[5].Value = model.sMail;
            parameters[6].Value = model.sAddress;
            parameters[7].Value = model.sTel;
            parameters[8].Value = model.sMobile;
            parameters[9].Value = model.sFax;
            parameters[10].Value = model.sQQ;
            parameters[11].Value = model.sCall;
            parameters[12].Value = model.sDuty;
            parameters[13].Value = model.sRemark;
            parameters[14].Value = model.sPicName;
            parameters[15].Value = model.dtStart;
            parameters[16].Value = model.dtEnd;
            parameters[17].Value = model.cDel;
            parameters[18].Value = model.sLogin;
            parameters[19].Value = model.dtLogin;
            parameters[20].Value = model.RoleId;
            parameters[21].Value = model.Type;
            parameters[22].Value = model.IsTopPermissoins;


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
        ///  更新一条数据
        /// </summary>
        public int Update(wManager model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@iManagerId", SqlDbType.Int,4),
					new SqlParameter("@sManager", model.sManager),
					new SqlParameter("@sManagerName", SqlDbType.NVarChar),
					new SqlParameter("@sPassWord", SqlDbType.NVarChar),
					new SqlParameter("@sCertName", SqlDbType.NVarChar),
					new SqlParameter("@sCertId", SqlDbType.NVarChar),
					new SqlParameter("@sMail", SqlDbType.NVarChar),
					new SqlParameter("@sAddress", SqlDbType.NVarChar),
					new SqlParameter("@sTel", SqlDbType.NVarChar),
					new SqlParameter("@sMobile", SqlDbType.NVarChar),
					new SqlParameter("@sFax", SqlDbType.NVarChar),
					new SqlParameter("@sQQ", SqlDbType.NVarChar),
					new SqlParameter("@sCall", SqlDbType.NVarChar),
					new SqlParameter("@sDuty", SqlDbType.NVarChar),
					new SqlParameter("@sRemark", SqlDbType.NVarChar),
					new SqlParameter("@cFrost", SqlDbType.NVarChar),
					new SqlParameter("@sPicName", SqlDbType.NVarChar),
					new SqlParameter("@dtStart", SqlDbType.DateTime),
					new SqlParameter("@dtEnd", SqlDbType.DateTime),
					new SqlParameter("@cDel", SqlDbType.NVarChar),					 
					new SqlParameter("@sUpd", SqlDbType.NVarChar),
					new SqlParameter("@dtUpd", SqlDbType.DateTime),
                    new SqlParameter("@roleid",SqlDbType.Int),
                    new SqlParameter("@type", SqlDbType.VarChar),
                    new SqlParameter("@isTopPermissions", SqlDbType.VarChar)};
            parameters[0].Value = model.iManagerId;
            parameters[2].Value = model.sManagerName;
            parameters[3].Value = (model.sPassWord == "" ? "" : Utils.MD5(model.sPassWord));
            parameters[4].Value = model.sCertName;
            parameters[5].Value = model.sCertId;
            parameters[6].Value = model.sMail;
            parameters[7].Value = model.sAddress;
            parameters[8].Value = model.sTel;
            parameters[9].Value = model.sMobile;
            parameters[10].Value = model.sFax;
            parameters[11].Value = model.sQQ;
            parameters[12].Value = model.sCall;
            parameters[13].Value = model.sDuty;
            parameters[14].Value = model.sRemark;
            parameters[15].Value = model.cFrost;
            parameters[16].Value = model.sPicName;
            parameters[17].Value = model.dtStart;
            parameters[18].Value = model.dtEnd;
            parameters[19].Value = model.cDel;
            parameters[20].Value = model.sUpd;
            parameters[21].Value = model.dtUpd;
            parameters[22].Value = model.RoleId;
            parameters[23].Value = model.Type;
            parameters[24].Value = model.IsTopPermissoins;
            return DbHelperSQL.RunProcedure("UP_wManager_Update", parameters, out rowsAffected);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public wManager GetModel(int iManagerId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from wManager ");
            strSql.Append(" where iManagerId=@iManagerId");
            SqlParameter[] parameters = {
					new SqlParameter("@iManagerId", SqlDbType.Int,4)};
            parameters[0].Value = iManagerId;
            wManager model = new wManager();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.iManagerId = iManagerId;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.sManager = ds.Tables[0].Rows[0]["sManager"].ToString();
                model.sManagerName = ds.Tables[0].Rows[0]["sManagerName"].ToString();
                model.sPassWord = ds.Tables[0].Rows[0]["sPassWord"].ToString();
                model.sCertName = ds.Tables[0].Rows[0]["sCertName"].ToString();
                model.sCertId = ds.Tables[0].Rows[0]["sCertId"].ToString();
                model.sMail = ds.Tables[0].Rows[0]["sMail"].ToString();
                model.sAddress = ds.Tables[0].Rows[0]["sAddress"].ToString();
                model.sTel = ds.Tables[0].Rows[0]["sTel"].ToString();
                model.sMobile = ds.Tables[0].Rows[0]["sMobile"].ToString();
                model.sFax = ds.Tables[0].Rows[0]["sFax"].ToString();
                model.sQQ = ds.Tables[0].Rows[0]["sQQ"].ToString();
                model.sCall = ds.Tables[0].Rows[0]["sCall"].ToString();
                model.sDuty = ds.Tables[0].Rows[0]["sDuty"].ToString();
                model.sRemark = ds.Tables[0].Rows[0]["sRemark"].ToString();
                model.cFrost = ds.Tables[0].Rows[0]["cFrost"].ToString();
                model.sPicName = ds.Tables[0].Rows[0]["sPicName"].ToString();

                model.Type = ds.Tables[0].Rows[0]["type"].ToString();
                model.IsTopPermissoins = ds.Tables[0].Rows[0]["isTopPermissions"].ToString();

                if (ds.Tables[0].Rows[0]["dtStart"].ToString() != "")
                {
                    model.dtStart = DateTime.Parse(ds.Tables[0].Rows[0]["dtStart"].ToString());
                }
                if (ds.Tables[0].Rows[0]["dtEnd"].ToString() != "")
                {
                    model.dtEnd = DateTime.Parse(ds.Tables[0].Rows[0]["dtEnd"].ToString());
                }
                model.cDel = ds.Tables[0].Rows[0]["cDel"].ToString();
                model.sLogin = ds.Tables[0].Rows[0]["sLogin"].ToString();
                if (ds.Tables[0].Rows[0]["dtLogin"].ToString() != "")
                {
                    model.dtLogin = DateTime.Parse(ds.Tables[0].Rows[0]["dtLogin"].ToString());
                }
                model.sUpd = ds.Tables[0].Rows[0]["sUpd"].ToString();
                if (ds.Tables[0].Rows[0]["dtUpd"].ToString() != "")
                {
                    model.dtUpd = DateTime.Parse(ds.Tables[0].Rows[0]["dtUpd"].ToString());
                }

                if (ds.Tables[0].Rows[0]["roleid"].ToString() != "")
                {
                    model.RoleId = int.Parse(ds.Tables[0].Rows[0]["roleid"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion  成员方法


        /// <summary>
        /// 返回不同系统的管理员列表
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataSet GetAdminList(string type)
        {
            return DbHelperSQL.Query("select [iManagerId] as [id],[sManagerName]  as [Name] from " + tbname + " where [type]=" + type);
        }

        public override string DongJieColunName
        {
            get
            {
                return "cFrost";
            }

        }

        public override string tbname
        {
            get { return "wManager"; }
        }

        public override string tbkey
        {
            get { return "iManagerId"; }
        }


        /// <summary>
        /// 返回此ID 的 真实姓名
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string GetRealName(string ID)
        {
            return GetValue("sManagerName", ID, true);
        }

    }

}