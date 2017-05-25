using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Linda.DAL
{
    /// <summary>
    /// ����ȫ�ֵķ���
    /// </summary>
    public class DalServer
    {
        #region ʵ����Ϣ
        static object DataObj = new object();
        static DalServer dal = null;

        /// <summary>
        /// ���ض���ʵ��
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
        /// �����������ӵ���Ŀ
        /// </summary>
        /// <returns></returns>
        public DataSet GetFriendLinkChannel()
        {
            return DbHelperSQL.RunProcedure("UP_GetFriendLinkChannel", new SqlParameter[] { }, "ds");
        }

 

    }
}
