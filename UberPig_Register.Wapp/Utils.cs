using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace UberPig_Register.Wapp
{
    public class Utils
    {

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

    }
}

