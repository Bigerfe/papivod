using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
  
namespace Linda.DAL
{

    /// <summary>
    /// 管理员操作类
    /// </summary>
    public class AdminDal
    {

        #region 实例信息
        static object DataObj = new object();
        static AdminDal dal = null;

        /// <summary>
        /// 返回对象实例
        /// </summary>
        /// <returns></returns>
        public static AdminDal CreateInstance()
        {
            if (dal != null)
                return dal;
            else
            {
                lock (DataObj)
                {
                    if (dal == null)
                        return dal = new AdminDal();
                    else
                        return dal;
                }
            }
        }

        #endregion


        static readonly string adminuidColumnName = "sManager";
        static readonly string adminpwdColumnName = "sPassWord";
        static readonly string TbName = "wManager";


        /// <summary>
        /// 返回当前角色ID
        /// </summary>
        public static string CurrentRoleId
        {
            get
            {
                return CurrentAdminRoleId();
            }
        }



        /// <summary>
        /// 管理员登录  返回这个管理员的ID
        /// </summary>
        /// <param name="strAdmin">管理员帐号</param>
        /// <param name="strPwd">密码</param>
        /// <returns></returns>
        public static int IsValidLogin(string strAdmin, string strPwd)
        {
            strAdmin = Utils.ChkSQL(strAdmin);
            strPwd = Utils.ChkSQL(strPwd);
            string strSql = "select iManagerId from " + TbName + " where " + adminuidColumnName + "='" + strAdmin.Trim().Replace("'", "''") + "' and " + adminpwdColumnName + "='" + Utils.MD5(strPwd) + "' and cdel='0' and cFrost='0'";
            DataSet ds = DbHelperSQL.Query(strSql);
            if (ds != null)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0]["iManagerId"].ToString());
            }
            else
            {
                return 0;
            }
        }


        /// <summary>
        /// 返回当前管理员用户的角色id
        /// </summary>
        /// <returns></returns>
        public static string CurrentAdminRoleId()
        {
            string adminuid = DoClass.GetAdminUserID();

            if (adminuid == "")
                return "";
            string ssql = "select roleid from wManager where iManagerId=" + adminuid;

            SqlDataReader sr = DbHelperSQL.ExecuteReader(ssql);

            string s = "";
            if (sr.Read())
            {
                s = sr[0].ToString();
                sr.Close();
            }

            return s;
        }



        /// <summary>
        /// 返回当前管理员的姓名
        /// </summary>
        /// <returns></returns>
        public static string GetAdmimNameById(int id)
        {
            string ssql = "select sManagerName from wManager where iManagerId=" + id;

            SqlDataReader sr = DbHelperSQL.ExecuteReader(ssql);

            string s = "";
            if (sr.Read())
            {
                s = sr[0].ToString();
                sr.Close();
            }

            return s;
        }


        ///// <summary>
        ///// 更新状态
        ///// </summary>
        ///// <param name="intID"></param>
        //public static void UpdateLoginState(int intID)
        //{
        //     DbHelperSQL.EditDatabase("update iManagerId where lastlogin='" + DateTime.Now + "',lastloginip='" + Fetch.UserIp + "' where id=" + intID);
        //}

        /// <summary>
        /// 修改自己的密码
        /// </summary>
        /// <param name="oldpwd"></param>
        /// <param name="newpwd"></param>
        /// <returns></returns>
        public static int ChangePwd(string oldpwd, string newpwd)
        {
            SqlParameter[] sp = { new SqlParameter("@uid",SqlDbType.Int),
        new SqlParameter("@oldpwd",SqlDbType.NVarChar),
        new SqlParameter("@newpwd",SqlDbType.NVarChar)};

            sp[0].Value = DoClass.GetAdminUserID();
            sp[1].Value = Utils.MD5(oldpwd.Replace("'", "''"));
            sp[2].Value = Utils.MD5(newpwd.Replace("'", "''"));

            return DbHelperSQL.RunProcedureRV("UP_ChangeAdminPwd", sp);
        }

        /// <summary>
        /// 返回当前用户角色的名称
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentAdminRoleName()
        {
            string sql = "select group_name from popedom_group where popedom_group_id = (select roleid from " + TbName + " where [iManagerId]=" + DoClass.GetAdminUserID() + ")";

            SqlDataReader sr = DbHelperSQL.ExecuteReader(sql);
            string s = "";
            if (sr.Read())
            {
                s = sr[0].ToString();
            }

            sr.Close();

            return s;
        }


        /// <summary>
        /// 返回管理员登录
        /// </summary>
        /// <returns></returns>
        public static string ReturnLoginState()
        {
            string str = "<img src=\"imgs/account.gif\" alt=\"当前登录\" width=\"19\" height=\"20\" align=\"absmiddle\">&nbsp;&nbsp;&nbsp;&nbsp;" + DoClass.GetAdminUserName() + "&nbsp;&nbsp;&nbsp;&nbsp;" + GetCurrentAdminRoleName();

            return str;
        }



        /// <summary>
        /// 返回当前登陆用户的所属系统的类型 
        /// </summary>
        /// <returns></returns>
        public string GetCurAdminPartType()
        {
            string uid = DoClass.GetAdminUserID();

            object obj = DbHelperSQL.GetSingle("select [type] from " + TbName + " where [iManagerId]=" + uid);

            if (obj == null)
                return "";
            return obj.ToString();
        }

        /// <summary>
        /// 返回当前用户是否是这个部门的最高权限执行者  
        /// </summary>
        /// <param name="parttype">部门属性</param>
        /// <returns>true</returns>
        public bool GetIsTopPermission(string parttype)
        {
            string uid = DoClass.GetAdminUserID();

            object obj = DbHelperSQL.GetSingle("select [iManagerId] from " + TbName + " where [iManagerId]=" + uid + " and [type]='" + parttype + "' and [isTopPermissions]='1'");
             

            if (obj == null)
                return false;
            return true;
        }

        ///// <summary>
        ///// 返回是否是所有信息管理的最高权限管理者
        ///// </summary>
        ///// <returns></returns>
        //public bool GetIsTopAllPermissionUsr()
        //{
        //    return GetIsTopPermission(Global.PermissionsAll); 
        //}



        ////判断部门权限的所有者类型

        ///// <summary>
        ///// 是否是erp管理员
        ///// </summary>
        ///// <returns></returns>
        //public bool IsErpMr()
        //{
        //    return GetIsTopPermission(Global.PermissionErp);
        //}

        ///// <summary>
        ///// 是否是 b2c的部门管理员
        ///// </summary>
        ///// <returns></returns>
        //public bool IsB2cMr()
        //{
        //    return GetIsTopPermission(Global.PermissionsB2c);
        //}

        ///// <summary>
        ///// 是否是b2b的管理员
        ///// </summary>
        ///// <returns></returns>
        //public bool IsB2bMr()
        //{
        //    return GetIsTopPermission(Global.PermissionsB2b);
        //}

        ///// <summary>
        ///// 是否是超级管理员
        ///// </summary>
        ///// <returns></returns>
        //public bool IsCEO()
        //{
        //    return GetIsTopPermission(Global.PermissionsAll); 
            
        //}



    }

}