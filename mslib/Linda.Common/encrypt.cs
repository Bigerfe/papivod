using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Security.Cryptography;

/// <summary>
/// 密码加密
/// </summary>
public class encrypt
{
	public encrypt()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    //md5加密源码
    public static String Encrypt(string password)
    {
        Byte[] clearBytes = new UnicodeEncoding().GetBytes(password);
        Byte[] hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);
        return BitConverter.ToString(hashedBytes);

    }

    /// <summary>
    /// 密码加密
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public static String EncryptMd5(string code)
    {
        return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(code, "MD5").ToLower();
    }
}
