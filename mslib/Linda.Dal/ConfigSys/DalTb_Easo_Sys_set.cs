using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
 
namespace Linda.DAL
{

    /// <summary>
    /// 系统设置
    /// </summary>
    public class DalTb_Easo_Sys_set
    {
        /// <summary>
        /// 返回此id的列的名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetColumnName(int id)
        {
            SqlParameter[] sp ={ new SqlParameter("@id", SqlDbType.Int) };

            sp[0].Value = id;

            DataSet ds = DbHelperSQL.RunProcedure("UP_GetSystemColumnName", sp, "ds");

            if (ds != null)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            return "";
        }


        /// <summary>
        /// 返回系统设置的值 不使用缓存
        /// </summary>
        /// <param name="id">对应值的ID</param>
        /// <returns></returns>
        public static string ReturnValue(int id)
        {
            string str = "";

            SqlParameter[] sp ={new SqlParameter("@id",SqlDbType.Int)};

            sp[0].Value = id;

            DataSet ds = DbHelperSQL.RunProcedure("UP_GetSystemSetValue",  sp,"ds");

            if (ds!=null)
            {
                str = ds.Tables[0].Rows[0]["set_value"].ToString();
            }
            return str;
        }

        /// <summary>
        /// 更新配置信息
        /// </summary>
        /// <param name="id">配置ID</param>
        /// <param name="setValue">值</param>
        /// <returns></returns>
        public static bool UpdateValue(int id, string setValue)
        {
            string strSql = "update Tb_Easo_System set set_value=@content where id=" + id;
            if (DbHelperSQL.ExecuteSql(strSql, setValue) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 返回对应的数据 启用缓存
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public static string ReturnCatchValue(int id)
        {
            string str = "";
            if (DoCache.GetCache("sys" + id) != null)
            {
                str = (String)DoCache.GetCache("sys" + id);
            }
            else
            {
                str = DalTb_Easo_Sys_set.ReturnValue(id);
                DoCache.AddCache("sys" + id, str);
            }
            return str;
        }


    }

     
}