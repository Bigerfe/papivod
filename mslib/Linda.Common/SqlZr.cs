using System;
using System.Collections.Generic;
using System.Text;


    public class SqlZr
    {
        public SqlZr()
        {
            // 
            // TODO: �ڴ˴���ӹ��캯���߼� 
            // 
        }
        public static string DelSQLStr(string str)
        {
            if (str == null || str == "")
                return "";
            str = str.Replace(";", "");
            str = str.Replace("'", "");
            str = str.Replace("&", "");
            str = str.Replace("%20", "");
            str = str.Replace("--", "");
            str = str.Replace("==", "");
            str = str.Replace(" <", "");
            str = str.Replace(">", "");
            str = str.Replace("%", "");
            str = str.Replace("+", "");
            str = str.Replace("-", "");
            str = str.Replace("=", "");
            str = str.Replace(",", "");
            return str;
        }
    } 


