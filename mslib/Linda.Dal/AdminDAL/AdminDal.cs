using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
  
namespace Linda.DAL
{

    /// <summary>
    /// ����Ա������
    /// </summary>
    public class AdminDal
    {

        #region ʵ����Ϣ
        static object DataObj = new object();
        static AdminDal dal = null;

        /// <summary>
        /// ���ض���ʵ��
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
        /// ���ص�ǰ��ɫID
        /// </summary>
        public static string CurrentRoleId
        {
            get
            {
                return CurrentAdminRoleId();
            }
        }



        /// <summary>
        /// ����Ա��¼  �����������Ա��ID
        /// </summary>
        /// <param name="strAdmin">����Ա�ʺ�</param>
        /// <param name="strPwd">����</param>
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
        /// ���ص�ǰ����Ա�û��Ľ�ɫid
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
        /// ���ص�ǰ����Ա������
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
        ///// ����״̬
        ///// </summary>
        ///// <param name="intID"></param>
        //public static void UpdateLoginState(int intID)
        //{
        //     DbHelperSQL.EditDatabase("update iManagerId where lastlogin='" + DateTime.Now + "',lastloginip='" + Fetch.UserIp + "' where id=" + intID);
        //}

        /// <summary>
        /// �޸��Լ�������
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
        /// ���ص�ǰ�û���ɫ������
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
        /// ���ع���Ա��¼
        /// </summary>
        /// <returns></returns>
        public static string ReturnLoginState()
        {
            string str = "<img src=\"imgs/account.gif\" alt=\"��ǰ��¼\" width=\"19\" height=\"20\" align=\"absmiddle\">&nbsp;&nbsp;&nbsp;&nbsp;" + DoClass.GetAdminUserName() + "&nbsp;&nbsp;&nbsp;&nbsp;" + GetCurrentAdminRoleName();

            return str;
        }



        /// <summary>
        /// ���ص�ǰ��½�û�������ϵͳ������ 
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
        /// ���ص�ǰ�û��Ƿ���������ŵ����Ȩ��ִ����  
        /// </summary>
        /// <param name="parttype">��������</param>
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
        ///// �����Ƿ���������Ϣ��������Ȩ�޹�����
        ///// </summary>
        ///// <returns></returns>
        //public bool GetIsTopAllPermissionUsr()
        //{
        //    return GetIsTopPermission(Global.PermissionsAll); 
        //}



        ////�жϲ���Ȩ�޵�����������

        ///// <summary>
        ///// �Ƿ���erp����Ա
        ///// </summary>
        ///// <returns></returns>
        //public bool IsErpMr()
        //{
        //    return GetIsTopPermission(Global.PermissionErp);
        //}

        ///// <summary>
        ///// �Ƿ��� b2c�Ĳ��Ź���Ա
        ///// </summary>
        ///// <returns></returns>
        //public bool IsB2cMr()
        //{
        //    return GetIsTopPermission(Global.PermissionsB2c);
        //}

        ///// <summary>
        ///// �Ƿ���b2b�Ĺ���Ա
        ///// </summary>
        ///// <returns></returns>
        //public bool IsB2bMr()
        //{
        //    return GetIsTopPermission(Global.PermissionsB2b);
        //}

        ///// <summary>
        ///// �Ƿ��ǳ�������Ա
        ///// </summary>
        ///// <returns></returns>
        //public bool IsCEO()
        //{
        //    return GetIsTopPermission(Global.PermissionsAll); 
            
        //}



    }

}