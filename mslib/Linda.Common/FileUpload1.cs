

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


#region 此类功能同上

/// <summary>
/// MyUpload 的摘要说明。

/// </summary>
public class FileUpload1
{
    public FileUpload1()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    private System.Web.HttpPostedFile postedFile = null;
    private string savePath = "";
    private string extension = "";
    private int fileLength = 0;
    private string setfilenme = "";

    /// <summary>
    /// 设置文件名，直接覆盖文件
    /// </summary>
    public string SetFileName
    {
        set
        {
            setfilenme = value;
        }
    }
    //显示该组件使用的参数信息
    public string Help
    {
        get
        {
            string helpstring;
            helpstring = "<font size=3>MyUpload myUpload=new MyUpload(); //构造函数";
            helpstring += "myUpload.PostedFile=file1.PostedFile;//设置要上传的文件";
            helpstring += "myUpload.SavePath=\"e:\\\";//设置要上传到服务器的路径，默认c:\\";
            helpstring += "myUpload.FileLength=100; //设置上传文件的最大长度，单位k，默认1k";
            helpstring += "myUpload.Extension=\"doc\";设置上传文件的扩展名，默认txt";
            helpstring += "label1.Text=myUpload.Upload();//开始上传，并显示上传结果</font>";
            helpstring += "<font size=3 color=red>Design By WengMingJun 2001-12-12 All Right Reserved!</font>";
            return helpstring;
        }
    }



    public System.Web.HttpPostedFile PostedFile
    {
        get
        {
            return postedFile;
        }
        set
        {
            postedFile = value;
        }
    }



    public string SavePath
    {
        get
        {
            if (savePath != "") return savePath;
            return "c:\\";
        }
        set
        {
            savePath = value;
        }
    }



    public int FileLength
    {
        get
        {
            if (fileLength != 0) return fileLength;
            return 1024;
        }
        set
        {
            fileLength = value * 1024;
        }
    }



    public string Extension
    {
        get
        {
            if (extension != "") return extension;
            return "txt";
        }
        set
        {
            extension = value;
        }
    }



    public string PathToName(string path)
    {
        int pos = path.LastIndexOf("\\");
        return path.Substring(pos + 1);
    }



    /// <summary>
    /// 文件上传 Return -1="文件类型有问题" 0="文件超过指定大小"
    /// </summary>
    /// <returns>Return -1="文件类型有问题" 0="文件超过指定大小"</returns>
    public string Upload()
    {
        string strMappath = "";
        if (this.PostedFile.FileName!=null  && this.postedFile.FileName !="" && this.postedFile.ContentLength>0)
        {
            try
            {
                string type1 = this.PostedFile.FileName.Substring(this.PostedFile.FileName.LastIndexOf(".") + 1).ToLower();
                string fileName = PathToName(PostedFile.FileName);
                if (!type(type1))
                {
                    //System.Web.HttpContext.Current.Response.Write("<script>alert('请上传'+'"+Extension+"'+'文件');</script>");
                    //"请上传 "+Extension+" 文件!";
                    return "-1";

                }
                if (PostedFile.ContentLength > FileLength)
                {
                    //System.Web.HttpContext.Current.Response.Write("<script>alert('文件太大了!');</script>");
                    return "0";
                }
                if (this.setfilenme != "")
                {
                    strMappath = setfilenme;
                }
                else {
                    strMappath = DoClass.GetRandNum() + "." + type1;
                }
               
                PostedFile.SaveAs(this.SavePath + strMappath);
                return strMappath;
            }
            catch
            {
            }
        }
        else
        {
            System.Web.HttpContext.Current.Response.Write("<script>alert('请选择要上传的文件!');</script>");
            return "";
        }
        return strMappath;
    }

    public bool type(string aa)
    {
        if (this.Extension.IndexOf(aa) < 0)
            return false;
        else
            return true;
    }
}

#endregion