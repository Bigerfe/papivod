using System;
using System.Collections.Generic;
using System.Text;
using Linda.Entity;
using System.Data.SqlClient;
using System.Data;
using Linda.DAL.IServer;

namespace Linda.Dal.NewsDAL
{
    /// <summary>
    /// 数据访问类GetZhaoi。
    /// </summary>
    public class DalGetZhaoi:BaseCommon
    {
        #region 实例信息
        static object DataObj = new object();
        static DalGetZhaoi dal = null;

        /// <summary>
        /// 返回对象实例
        /// </summary>
        /// <returns></returns>
        public static DalGetZhaoi CreateInstance()
        {
            if (dal != null)
                return dal;
            else
            {
                lock (DataObj)
                {
                    if (dal == null)
                        return dal = new DalGetZhaoi();
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
        public int Add(GetZhaoi model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GetZhaoi(");
            strSql.Append("sex,dianh,email,engscore,ylxgj,city,name)");
            strSql.Append(" values (");
            strSql.Append("@sex,@dianh,@email,@engscore,@ylxgj,@city,@name)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@sex", SqlDbType.Int,4),
					new SqlParameter("@dianh", SqlDbType.VarChar,30),
					new SqlParameter("@email", SqlDbType.VarChar,200),
					new SqlParameter("@engscore", SqlDbType.VarChar,20),
					new SqlParameter("@ylxgj", SqlDbType.Int,4),
					new SqlParameter("@city", SqlDbType.Int,4),new SqlParameter("@name",SqlDbType.VarChar)
				};
            parameters[0].Value = model.sex;
            parameters[1].Value = model.dianh;
            parameters[2].Value = model.email;
            parameters[3].Value = model.engscore;
            parameters[4].Value = model.ylxgj;
            parameters[5].Value = model.city;
            parameters[6].Value = model.name;

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
        #endregion  成员方法

        public override string tbname
        {
            get { return "GetZhaoi"; }
        }

        public override string tbkey
        {
            get { return "id"; }
        }
    }
}
