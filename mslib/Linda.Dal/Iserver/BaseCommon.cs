using System;
using System.Collections.Generic;
using System.Text;


namespace Linda.DAL.IServer
{
    /// <summary>
    /// 通用方法
    /// </summary>
    public abstract class BaseCommon
    {  

        private string dongjieColumnName = "";  

        /// <summary>
        /// 表的名称
        /// </summary>
        public abstract string tbname
        {
            get;

        }

        /// <summary>
        /// 表的主键名称
        /// </summary>
        public abstract string tbkey
        {
            get;

        }

        /// <summary>
        /// 冻结的字段
        /// </summary>
        public virtual string DongJieColunName
        {
            set
            {
                dongjieColumnName = value;

            }
            get
            {
                return dongjieColumnName;
            }

        }

        /// <summary>
        /// 执行批量删除操作
        /// </summary>
        /// <param name="stbkyelist"></param>
        /// <returns></returns>
        public int DeleteList(string stbkyelist)
        {
            if (stbkyelist == "")
                return -1;
            return DbHelperSQL.ExecuteSql("delete from " + tbname + " where [" + tbkey + "] in (" + stbkyelist + ")");



        } 
       /// <summary>
        /// 执行批量删除操作
       /// </summary>
       /// <param name="stbkyelist">id列表</param>
       /// <param name="isint">是否为整型</param>
       /// <returns></returns>
        public int DeleteList(string stbkyelist,int isint)
        {
            if (stbkyelist == "")
                return -1;

            if (isint == 1)
                return DeleteList(stbkyelist);
            else
            {
                return DeleteList(GetStrKeyList(stbkyelist));
            }
        }


        /// <summary>
        /// 返回删除主键的列表 首先此id的类型为字符型的
        /// </summary>
        /// <param name="strid"></param>
        /// <returns></returns>
        private string GetStrKeyList(string strid)
        {
            if (strid != "")
                return "'" + strid.TrimEnd(',').Replace(",", "','") + "'";
            return "";
        }



        /// <summary>
        /// 批量设置 指定字段的值
        /// </summary>
        /// <param name="tbname">表名</param>
        /// <param name="columname">字段名</param>
        /// <param name="strv">设置的值</param>
        /// <param name="stridlist">主键列表</param>
        /// <returns>-1 列表为空  >0 执行成功</returns>
        public int SetValue(string tbname, string columname, string strv, string stridlist)
        {

            if (stridlist == "")
                return -1;

            return DbHelperSQL.ExecuteSql("update " + tbname + " set [" + columname + "]=" + strv + " where [" + tbkey + "] in (" + stridlist + ")");

        }

        /// <summary>
        /// 批量 设置指定字段的值 比如审核通过，注销用户等
        /// </summary>       
        /// <param name="columname">字段名</param>
        /// <param name="strv">设置的值</param>
        /// <param name="stridlist">主键列表</param>
        /// <returns>over >0</returns>
        public int SetValue(string columname, string strv, string stridlist)
        {
            return SetValue(tbname, columname, strv, stridlist);
        }

        /// <summary>
        /// 批量 设置指定字段的值 比如审核通过，注销用户等
        /// </summary>       
        /// <param name="columname">字段名</param>
        /// <param name="strv">设置的值</param>
        /// <param name="stridlist">主键列表</param>
        /// <returns>over >0</returns>
        public int SetValue(string columname, string strv, string stridlist,int isint)
        {

            if (isint == 1)
                return SetValue(columname, strv, stridlist);
            else
            {
                return SetValue(columname, strv, GetStrKeyList(stridlist));
            } 
         
        }


        /// <summary>
        /// 检查是否有重复数据
        /// </summary>
        /// <param name="colNmae"></param>
        /// <param name="tbname"></param>
        /// <returns></returns>
        public static bool CheckRepeatName(string columname, string tbname, string strv)
        {
            string str = DbHelperSQL.GetSingle("select count(1) from " + tbname + " where [" + columname + "] = '" + strv + "'").ToString();
            return str == "0" ? true : false;
        }


        /// <summary>
        /// 批量设置 指定字段的值    字符串内容
        /// </summary>
        /// <param name="tbname">表名</param>
        /// <param name="columname">字段名</param>
        /// <param name="strv">设置的值</param>
        /// <param name="stridlist">主键列表</param>
        /// <returns>-1 列表为空  >0 执行成功</returns>
        public int SetValueString(string tbname, string columname, string strv, string stridlist)
        {

            if (stridlist == "")
                return -1;

            return DbHelperSQL.ExecuteSql("update " + tbname + " set [" + columname + "]='" + strv + "' where [" + tbkey + "] in (" + stridlist + ")");

        }
        /// <summary>
        /// 批量设置 指定字段的值    字符串内容
        /// </summary>
        /// <param name="tbname">表名</param>
        /// <param name="columname">字段名</param>
        /// <param name="strv">设置的值</param>
        /// <param name="stridlist">主键列表</param>
        /// <returns>-1 列表为空  >0 执行成功</returns>
        public int SetValueString(string tbname, string columname, string strv, string stridlist,int isint)
        {

            if (stridlist == "")
                return -1;

            return DbHelperSQL.ExecuteSql("update " + tbname + " set [" + columname + "]='" + strv + "' where [" + tbkey + "] in (" + GetStrKeyList(stridlist) + ")");

        }



        /// <summary>
        /// 执行批量审核操作
        /// </summary>
        /// <param name="stbkyelist"></param>
        /// <returns></returns>
        public int StatusList(string stbkyelist,int status)
        {
            if (stbkyelist == "")
                return -1;
            return DbHelperSQL.ExecuteSql("update " + tbname + " set State="+status+" where [" + tbkey + "] in (" + stbkyelist + ")");

        } 

        /// <summary>
        /// 执行批量审核操作
        /// </summary>
        /// <param name="stbkyelist">id列表</param>
        /// <param name="isint">是否为整型</param>
        /// <returns></returns>
        public int StatusList(string stbkyelist, int isint,int status)
        {
            if (stbkyelist == "")
                return -1;

            if (isint == 1)
                return StatusList(stbkyelist,status);
            else
            {
                return StatusList(GetStrKeyList(stbkyelist),status);
            }
        }



        /// <summary>
        /// 返回此字段的值
        /// </summary>
        /// <param name="columname"></param>
        /// <returns></returns>
        public string GetValue(string columname, string tbkeyvalue, bool bint)
        {
            object obj = DbHelperSQL.GetSingle("select top 1 " + columname + " from " + tbname + " where [" + tbkey + "]=" + (bint ? tbkeyvalue : "'" + tbkeyvalue + "'") + "");

            if (obj == null)
                return "";
            return obj.ToString();
        }


    }


}