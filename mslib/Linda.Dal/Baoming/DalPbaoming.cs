using System;
using System.Collections.Generic;
using System.Text;
using Kehu1.Entity;
using System.Data.SqlClient;
using System.Data;
using Linda.DAL.IServer;

namespace Linda.DAL
{
    /// <summary>
    /// 报名。
    /// </summary>
    public class DalPbaoming : BaseCommon
    {
        public DalPbaoming()
        { }


        #region   实例信息
        static object obj = new object();
        static DalPbaoming dal = null;

        /// <summary>
        /// 返回对象实例
        /// </summary>
        /// <returns></returns>
        public static DalPbaoming CreateInstance()
        {
            if (dal != null)
                return dal;
            else
            {
                lock (obj)
                {
                    if (dal == null)
                        return dal = new DalPbaoming();
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
        public int Add(Pbaoming model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Pbaoming(");
            strSql.Append("firstz,secondz,pname,card,xueli,sex,province,city,area,gaokchengj,engchengj,tel,address,post,receiver,onlinetype,email,remark,ifpass,passremark,xuexiaoid)");
            strSql.Append(" values (");
            strSql.Append("@firstz,@secondz,@pname,@card,@xueli,@sex,@province,@city,@area,@gaokchengj,@engchengj,@tel,@address,@post,@receiver,@onlinetype,@email,@remark,@ifpass,@passremark,@xuexiaoid)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@firstz", SqlDbType.Int,4),
					new SqlParameter("@secondz", SqlDbType.Int,4),
					new SqlParameter("@pname", SqlDbType.VarChar,50),
					new SqlParameter("@card", SqlDbType.VarChar,25),
					new SqlParameter("@xueli", SqlDbType.Int,4),
					new SqlParameter("@sex", SqlDbType.Char,1),
					new SqlParameter("@province", SqlDbType.VarChar,20),
					new SqlParameter("@city", SqlDbType.VarChar,20),
					new SqlParameter("@area", SqlDbType.VarChar,20),
					new SqlParameter("@gaokchengj", SqlDbType.VarChar,10),
					new SqlParameter("@engchengj", SqlDbType.VarChar,10),
					new SqlParameter("@tel", SqlDbType.VarChar,50),
					new SqlParameter("@address", SqlDbType.VarChar,300),
					new SqlParameter("@post", SqlDbType.VarChar,10),
					 
					new SqlParameter("@receiver", SqlDbType.VarChar,20),
					new SqlParameter("@onlinetype", SqlDbType.VarChar,50),
					new SqlParameter("@email", SqlDbType.VarChar,199),
					new SqlParameter("@remark", SqlDbType.VarChar,6000),
					 
					new SqlParameter("@ifpass", SqlDbType.Int,4),
					new SqlParameter("@passremark", SqlDbType.VarChar,300),new SqlParameter("@xuexiaoid",SqlDbType.Int)};
            parameters[0].Value = model.firstz;
            parameters[1].Value = model.secondz;
            parameters[2].Value = model.pname;
            parameters[3].Value = model.card;
            parameters[4].Value = model.xueli;
            parameters[5].Value = model.sex;
            parameters[6].Value = model.province;
            parameters[7].Value = model.city;
            parameters[8].Value = model.area;
            parameters[9].Value = model.gaokchengj;
            parameters[10].Value = model.engchengj;
            parameters[11].Value = model.tel;
            parameters[12].Value = model.address;
            parameters[13].Value = model.post;
            parameters[14].Value = model.receiver;
            parameters[15].Value = model.onlinetype;
            parameters[16].Value = model.email;
            parameters[17].Value = model.remark;

            parameters[18].Value = model.ifpass;
            parameters[19].Value = model.passremark;
            parameters[20].Value = model.Xuexiaoid;

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
        /// 更新一条数据
        /// </summary>
        public int Update(Pbaoming model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Pbaoming set ");
            strSql.Append("firstz=@firstz,");
            strSql.Append("secondz=@secondz,");
            strSql.Append("pname=@pname,");
            strSql.Append("card=@card,");
            strSql.Append("xueli=@xueli,");
            strSql.Append("sex=@sex,");
            strSql.Append("province=@province,");
            strSql.Append("city=@city,");
            strSql.Append("area=@area,");
            strSql.Append("gaokchengj=@gaokchengj,");
            strSql.Append("engchengj=@engchengj,");
            strSql.Append("tel=@tel,");
            strSql.Append("address=@address,");
            strSql.Append("post=@post,");
            
            strSql.Append("receiver=@receiver,");
            strSql.Append("onlinetype=@onlinetype,");
            strSql.Append("email=@email,");
            strSql.Append("remark=@remark,");
        
            strSql.Append("ifpass=@ifpass,");
            strSql.Append("passremark=@passremark,xuexiaoid=@xuexiaoid");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@firstz", SqlDbType.Int,4),
					new SqlParameter("@secondz", SqlDbType.Int,4),
					new SqlParameter("@pname", SqlDbType.VarChar,50),
					new SqlParameter("@card", SqlDbType.VarChar,25),
					new SqlParameter("@xueli", SqlDbType.Int,4),
					new SqlParameter("@sex", SqlDbType.Char,1),
					new SqlParameter("@province", SqlDbType.VarChar,20),
					new SqlParameter("@city", SqlDbType.VarChar,20),
					new SqlParameter("@area", SqlDbType.VarChar,20),
					new SqlParameter("@gaokchengj", SqlDbType.VarChar,10),
					new SqlParameter("@engchengj", SqlDbType.VarChar,10),
					new SqlParameter("@tel", SqlDbType.VarChar,50),
					new SqlParameter("@address", SqlDbType.VarChar,300),
					new SqlParameter("@post", SqlDbType.VarChar,10),
				 
					new SqlParameter("@receiver", SqlDbType.VarChar,20),
					new SqlParameter("@onlinetype", SqlDbType.VarChar,50),
					new SqlParameter("@email", SqlDbType.VarChar,199),
					new SqlParameter("@remark", SqlDbType.VarChar,6000),
				 
					new SqlParameter("@ifpass", SqlDbType.Int,4),
					new SqlParameter("@passremark", SqlDbType.VarChar,300),new SqlParameter("@xuexiaoid",SqlDbType.Int)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.firstz;
            parameters[2].Value = model.secondz;
            parameters[3].Value = model.pname;
            parameters[4].Value = model.card;
            parameters[5].Value = model.xueli;
            parameters[6].Value = model.sex;
            parameters[7].Value = model.province;
            parameters[8].Value = model.city;
            parameters[9].Value = model.area;
            parameters[10].Value = model.gaokchengj;
            parameters[11].Value = model.engchengj;
            parameters[12].Value = model.tel;
            parameters[13].Value = model.address;
            parameters[14].Value = model.post;

            parameters[15].Value = model.receiver;
            parameters[16].Value = model.onlinetype;
            parameters[17].Value = model.email;
            parameters[18].Value = model.remark;
           
            parameters[19].Value = model.ifpass;
            parameters[20].Value = model.passremark;
            parameters[21].Value = model.Xuexiaoid;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Pbaoming ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbaoming GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,firstz,secondz,pname,card,xueli,sex,province,city,area,gaokchengj,engchengj,xuexiaoid,tel,address,post,receiver,onlinetype,email,remark,addtime,ifpass,passremark from Pbaoming ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Pbaoming model = new Pbaoming();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["firstz"].ToString() != "")
                {
                    model.firstz = int.Parse(ds.Tables[0].Rows[0]["firstz"].ToString());
                }
                if (ds.Tables[0].Rows[0]["secondz"].ToString() != "")
                {
                    model.secondz = int.Parse(ds.Tables[0].Rows[0]["secondz"].ToString());
                }
                model.pname = ds.Tables[0].Rows[0]["pname"].ToString();
                model.card = ds.Tables[0].Rows[0]["card"].ToString();
                if (ds.Tables[0].Rows[0]["xueli"].ToString() != "")
                {
                    model.xueli = int.Parse(ds.Tables[0].Rows[0]["xueli"].ToString());
                }
                model.sex = ds.Tables[0].Rows[0]["sex"].ToString();
                model.province = ds.Tables[0].Rows[0]["province"].ToString();
                model.city = ds.Tables[0].Rows[0]["city"].ToString();
                model.area = ds.Tables[0].Rows[0]["area"].ToString();
                model.gaokchengj = ds.Tables[0].Rows[0]["gaokchengj"].ToString();
                model.engchengj = ds.Tables[0].Rows[0]["engchengj"].ToString();
                model.tel = ds.Tables[0].Rows[0]["tel"].ToString();
                model.address = ds.Tables[0].Rows[0]["address"].ToString();
                model.post = ds.Tables[0].Rows[0]["post"].ToString();
                model.Xuexiaoid = int.Parse(ds.Tables[0].Rows[0]["Xuexiaoid"].ToString());
                model.receiver = ds.Tables[0].Rows[0]["receiver"].ToString();
                model.onlinetype = ds.Tables[0].Rows[0]["onlinetype"].ToString();
                model.email = ds.Tables[0].Rows[0]["email"].ToString();
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                if (ds.Tables[0].Rows[0]["addtime"].ToString() != "")
                {
                    model.addtime = DateTime.Parse(ds.Tables[0].Rows[0]["addtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ifpass"].ToString() != "")
                {
                    model.ifpass = int.Parse(ds.Tables[0].Rows[0]["ifpass"].ToString());
                }
                model.passremark = ds.Tables[0].Rows[0]["passremark"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion  成员方法

        public override string tbname
        {
            get { return "Pbaoming"; }
        }

        public override string tbkey
        {
            get { return "id"; }
        }

        /// <summary>
        /// 获得要查询的结果
        /// </summary>
        /// <param name="card"></param>
        /// <param name="tel"></param>
        /// <returns></returns>
        public string[] Getpassinfo(string card, string tel)
        {
            string[] strs ={ "", "", "" };

            if (card == "" && tel == "")
                return strs;

            string sr = "";
            if (card != "")
                sr = "[card]='"+Utils.ChkSQL(card)+"'";

            if (tel != "")
                sr = "tel='"+Utils.ChkSQL(tel)+"'"; 


            string sql = "select top 1 [ifpass],[passremark],[id] from pbaoming where " + sr; 
      

            DataRow dr = DbHelperSQL.ReadRow(sql);

         
            if (dr != null)
            {
                strs[0] = dr[0].ToString();
                strs[1] = dr[1].ToString();
                strs[2] = dr[2].ToString();  
            }
            return strs;
        }

        /// <summary>
        /// 获得要查询的结果
        /// </summary>
        /// <param name="card"></param>
        /// <param name="tel"></param>
        /// <returns></returns>
        public string[] Getpassinfo(int id)
        {
            string[] strs ={ "", "" };

            string sql = "select top 1 [ifpass],[passremark] from pbaoming where id=" + id;


            DataRow dr = DbHelperSQL.ReadRow(sql);


            if (dr != null)
            {
                strs[0] = dr[0].ToString();
                strs[1] = dr[1].ToString();               
            }
            return strs;
        }
    }
}
