using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Linda.DAL
{
    /// <summary>
    /// 几个全局的方法
    /// </summary>
    public class DalServer
    {
        #region 实例信息
        static object DataObj = new object();
        static DalServer dal = null;

        /// <summary>
        /// 返回对象实例
        /// </summary>
        /// <returns></returns>
        public static DalServer CreateInstance()
        {
            if (dal != null)
                return dal;
            else
            {
                lock (DataObj)
                {
                    if (dal == null)
                        return dal = new DalServer();
                    else
                        return dal;
                }
            }
        }
        #endregion
         
   
        /// <summary>
        /// 返回友情链接的栏目
        /// </summary>
        /// <returns></returns>
        public DataSet GetFriendLinkChannel()
        {
            return DbHelperSQL.RunProcedure("UP_GetFriendLinkChannel", new SqlParameter[] { }, "ds");
        }

 

    }
}
