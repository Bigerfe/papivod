using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Data.SQLite;
namespace Common.Uitls.Lib
{
    public class Utils
    {

        // SHA1加密
        public static string EncryptedToSha(string targetPassword)
        {
            byte[] pwBytes = Encoding.UTF8.GetBytes(targetPassword);
            byte[] hash = SHA1.Create().ComputeHash(pwBytes);
            StringBuilder hex = new StringBuilder();
            for (int i = 0; i < hash.Length; i++) hex.Append(hash[i].ToString("X2"));

            return hex.ToString();
        }


       

        ///<summary>
        ///   获取硬盘ID
        ///</summary>
        ///<returns> string </returns>
        public static string GetHDid()
        {
            string HDid = " ";
            using (ManagementClass cimobject1 = new ManagementClass("Win32_DiskDrive"))
            {
                ManagementObjectCollection moc1 = cimobject1.GetInstances();
                foreach (ManagementObject mo in moc1)
                {
                    HDid = (string)mo.Properties["Model"].Value;
                    mo.Dispose();
                }
            }
            return HDid.ToString();
        }

        ///<summary>
        ///   获取cpu序列号
        ///</summary>
        ///<returns> string </returns>
        public static string GetCpuInfo()
        {
            string cpuInfo = " ";
            using (ManagementClass cimobject = new ManagementClass("Win32_Processor"))
            {
                ManagementObjectCollection moc = cimobject.GetInstances();

                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                    mo.Dispose();
                }
            }
            return cpuInfo.ToString();
        }
        public static string getCpuId = "NMJKjkssBN.,./[]*&^545112";
        public static string getLicence = "122BNVMMgjfsdalf_-+--|||.,..,.,8(89*";
        public static string GetMD5(string myString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.Unicode.GetBytes(myString);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x");
            }

            return byte2String;
        }
        /// <summary>
        /// 获得加密后的cpuid
        /// </summary>
        /// <returns></returns>
        public static string GetEncodeCpuId()
        {
            return GetMD5(GetMD5(GetMD5(GetMD5(GetCpuInfo() + getCpuId))));
        }
        /// <summary>
        /// 获得注册码
        /// </summary>
        /// <returns></returns>
        public static string GetLicence(string encodeCpuId)
        {

            string cpuid = encodeCpuId + "北京北京，你的天怎么这么蓝；我感谢你！谢谢有你啊！";
            string cpuid1 = GetMD5(GetMD5(GetMD5(GetMD5(GetMD5(GetMD5(GetMD5(cpuid) + getLicence + getLicence))))));
            return GetMD5(GetMD5(cpuid)) + cpuid1 + GetMD5(cpuid);
        }

        /// <summary>
        /// 判断是否注册了软件
        /// </summary>
        /// <returns></returns>
        public static bool IsRegister()
        {
            string cpuid = GetEncodeCpuId();
            string lincense = GetLicence(cpuid);

            string file = Environment.CurrentDirectory + "\\license.ini";
            if (!File.Exists(file))
            {
                return false;
            }

            string content = "";
            StreamReader sr = new StreamReader(file);
            content = sr.ReadToEnd();

            sr.Close();

            if (content != lincense)
            {
                return false;
            }

            return true;
        }



        /// <summary>
        ///
        /// </summary>
        /// <param name="dt"></param>
        public static void ExportExcel(DataTable dt, string filename)
        {
            //if (dt == null || dt.Rows.Count == 0) return;
            //Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            //if (xlApp == null)
            //{
            //    return;
            //}
            //System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            //Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            //Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            //Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            //Microsoft.Office.Interop.Excel.Range range;
            //long totalCount = dt.Rows.Count;
            //long rowRead = 0;
            //float percent = 0;
            //for (int i = 0; i < dt.Columns.Count; i++)
            //{
            //    worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
            //    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, i + 1];
            //    range.Interior.ColorIndex = 15;
            //    range.Font.Bold = true;
            //}
            //for (int r = 0; r < dt.Rows.Count; r++)
            //{
            //    for (int i = 0; i < dt.Columns.Count; i++)
            //    {
            //        worksheet.Cells[r + 2, i + 1] = dt.Rows[r][i].ToString();
            //    }
            //    rowRead++;
            //    percent = ((float)(100 * rowRead)) / totalCount;
            //}
            //xlApp.Visible = false;
            //workbook.Saved = true;


            //workbook.SaveCopyAs((filename.IndexOf(".xls") > -1 ? filename : filename + ".xls"));


            //workbook.Close(true, Type.Missing, Type.Missing);
            //workbook = null;
            //xlApp.Quit();
            //xlApp = null;           

        }


        //数据库连接字符串(web.config来配置)，可以动态更改SQLString支持多数据库.        
        public static string connectionString = "Data Source=" + Environment.CurrentDirectory + "/area.db";


        /// <summary>
        /// 获得
        /// </summary>
        public static DataSet GetTelCom_Db()
        {
            DataSet ds = Query("select distinct telecom from t_telnum");
            return ds;
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        private static DataSet Query(string SQLString)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SQLiteDataAdapter command = new SQLiteDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SQLite.SQLiteException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

    }
}

