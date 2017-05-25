using System;
using System.Collections.Generic;
using System.Text;


namespace Linda.DAL.IServer
{
    /// <summary>
    /// ͨ�÷���
    /// </summary>
    public abstract class BaseCommon
    {  

        private string dongjieColumnName = "";  

        /// <summary>
        /// �������
        /// </summary>
        public abstract string tbname
        {
            get;

        }

        /// <summary>
        /// �����������
        /// </summary>
        public abstract string tbkey
        {
            get;

        }

        /// <summary>
        /// ������ֶ�
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
        /// ִ������ɾ������
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
        /// ִ������ɾ������
       /// </summary>
       /// <param name="stbkyelist">id�б�</param>
       /// <param name="isint">�Ƿ�Ϊ����</param>
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
        /// ����ɾ���������б� ���ȴ�id������Ϊ�ַ��͵�
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
        /// �������� ָ���ֶε�ֵ
        /// </summary>
        /// <param name="tbname">����</param>
        /// <param name="columname">�ֶ���</param>
        /// <param name="strv">���õ�ֵ</param>
        /// <param name="stridlist">�����б�</param>
        /// <returns>-1 �б�Ϊ��  >0 ִ�гɹ�</returns>
        public int SetValue(string tbname, string columname, string strv, string stridlist)
        {

            if (stridlist == "")
                return -1;

            return DbHelperSQL.ExecuteSql("update " + tbname + " set [" + columname + "]=" + strv + " where [" + tbkey + "] in (" + stridlist + ")");

        }

        /// <summary>
        /// ���� ����ָ���ֶε�ֵ �������ͨ����ע���û���
        /// </summary>       
        /// <param name="columname">�ֶ���</param>
        /// <param name="strv">���õ�ֵ</param>
        /// <param name="stridlist">�����б�</param>
        /// <returns>over >0</returns>
        public int SetValue(string columname, string strv, string stridlist)
        {
            return SetValue(tbname, columname, strv, stridlist);
        }

        /// <summary>
        /// ���� ����ָ���ֶε�ֵ �������ͨ����ע���û���
        /// </summary>       
        /// <param name="columname">�ֶ���</param>
        /// <param name="strv">���õ�ֵ</param>
        /// <param name="stridlist">�����б�</param>
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
        /// ����Ƿ����ظ�����
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
        /// �������� ָ���ֶε�ֵ    �ַ�������
        /// </summary>
        /// <param name="tbname">����</param>
        /// <param name="columname">�ֶ���</param>
        /// <param name="strv">���õ�ֵ</param>
        /// <param name="stridlist">�����б�</param>
        /// <returns>-1 �б�Ϊ��  >0 ִ�гɹ�</returns>
        public int SetValueString(string tbname, string columname, string strv, string stridlist)
        {

            if (stridlist == "")
                return -1;

            return DbHelperSQL.ExecuteSql("update " + tbname + " set [" + columname + "]='" + strv + "' where [" + tbkey + "] in (" + stridlist + ")");

        }
        /// <summary>
        /// �������� ָ���ֶε�ֵ    �ַ�������
        /// </summary>
        /// <param name="tbname">����</param>
        /// <param name="columname">�ֶ���</param>
        /// <param name="strv">���õ�ֵ</param>
        /// <param name="stridlist">�����б�</param>
        /// <returns>-1 �б�Ϊ��  >0 ִ�гɹ�</returns>
        public int SetValueString(string tbname, string columname, string strv, string stridlist,int isint)
        {

            if (stridlist == "")
                return -1;

            return DbHelperSQL.ExecuteSql("update " + tbname + " set [" + columname + "]='" + strv + "' where [" + tbkey + "] in (" + GetStrKeyList(stridlist) + ")");

        }



        /// <summary>
        /// ִ��������˲���
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
        /// ִ��������˲���
        /// </summary>
        /// <param name="stbkyelist">id�б�</param>
        /// <param name="isint">�Ƿ�Ϊ����</param>
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
        /// ���ش��ֶε�ֵ
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