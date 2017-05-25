using System;
using System.IO;
using System.Web;
using System.Text;
using System.Threading;
 using System.Collections;
using System.Data;
using System.Collections.Generic;
/// <summary>
/// 文件处理
/// </summary>
public class DoFile
{
    public DoFile()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 创建目录
    /// </summary>
    /// <param name="folderpath"></param>
    public static void CreateFolder(string folderpath)
    
    {
        if (!Directory.Exists(folderpath))
            Directory.CreateDirectory(folderpath);

    }
    /// <summary>
    /// 删除目录和文件
    /// </summary>
    /// <param name="folderpath"></param>
    public static void DeleteFolder(string folderpath)
    {
        if (!Directory.Exists(folderpath))
        {
            if(File.Exists("foderpath" + "default.aspx"));
            File.Delete("foderpath" + "default.aspx");
            Directory.Delete(folderpath);
        }
        
    }

    /// <summary>
    /// 复制文件
    /// </summary>
    /// <param name="sourcefile"></param>
    /// <param name="destfile"></param>
    public static void CopyFile(string sourcefile, string destfile)
    {
        if (File.Exists(sourcefile))
        {
            File.Copy(sourcefile, destfile);
        }
    }

   /// <summary>
    /// 删除指定文件
   /// </summary>
   /// <param name="filename"></param>
   /// <returns></returns>
    public static int DeleteFile(string filename)
    {
        if (filename == string.Empty || filename == "" || filename == null)
            return 0;
        else
        {
            if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(filename)))
            {
                File.Delete(System.Web.HttpContext.Current.Server.MapPath(filename));
                return 1;
            }
            return 0;
        }
    }

    /// <summary>
    /// 判断是存在此文件 接受的是虚拟路径
    /// </summary>
    /// <param name="filename"></param>
    /// <returns></returns>
    public static bool ExistsFile(string filename)
    {
        return File.Exists(System.Web.HttpContext.Current.Server.MapPath(filename));
    }


    public static bool MoveConfig(int type, string folder)
    {
        string file = "";
        if (type == 0)
        {
            //代表默认的程序-->修改为一
            file = HttpContext.Current.Server.MapPath("~/" + folder + "/config/html/web.config");


        }
        else
        {
            //修改为其他的
            file = HttpContext.Current.Server.MapPath("~/" + folder + "/config/aspx/web.config");
        }

        string newfile = HttpContext.Current.Server.MapPath("~/web.config");
        try
        {
            if (File.Exists(file))
            {
                if (File.Exists(newfile))
                {
                    File.Delete(newfile);
                }
                FileInfo fi = new FileInfo(file);

                FileInfo fi1 = fi.CopyTo(newfile);

            }
            return true;
        }
        catch
        {
            return false;
        }

    }



    //增加方法

    /// <summary>
    /// 文件地址
    /// </summary>
    /// <param name="filename"></param>
    /// <param name="str">写入的内容</param>
    public static void WriteFile(string filename, string str)
    {
        if (File.Exists(filename))
        {
             StreamWriter sw = new StreamWriter(filename,false,Encoding.UTF8);
             sw.Write(str);
             sw.Close();
        }
        else
        {
          FileStream fs =  File.Create(filename);
          fs.Flush();
          fs.Close();         
        }
    }



    /// <summary>
    /// 输出硬盘文件，提供下载
    /// </summary>
    /// <param name="_Request">Page.Request对象</param>
    /// <param name="_Response">Page.Response对象</param>
    /// <param name="_fileName">下载文件名</param>
    /// <param name="_fullPath">带文件名下载路径</param>
    /// <param name="_speed">每秒允许下载的字节数</param>
    /// <returns>返回是否成功</returns>
    public static bool ResponseFile(HttpRequest _Request, HttpResponse _Response, string _fileName, string _fullPath, long _speed)
    {
        try
        {
            FileStream myFile = new FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            BinaryReader br = new BinaryReader(myFile);
            try
            {
                _Response.AddHeader("Accept-Ranges", "bytes");
                _Response.Buffer = false;
                long fileLength = myFile.Length;
                long startBytes = 0;



                int pack = 10240; //10K bytes
                //int sleep = 200; //每秒5次 即5*10K bytes每秒
                int sleep = (int)Math.Floor((decimal)1000 * pack / _speed) + 1;
                if (_Request.Headers["Range"] != null)
                {
                    _Response.StatusCode = 206;
                    string[] range = _Request.Headers["Range"].Split(new char[] { '=', '-' });
                    startBytes = Convert.ToInt64(range[1]);
                }
                _Response.AddHeader("Content-Length", (fileLength - startBytes).ToString());
                if (startBytes != 0)
                {
                    _Response.AddHeader("Content-Range", string.Format(" bytes {0}-{1}/{2}", startBytes, fileLength - 1, fileLength));
                }
                _Response.AddHeader("Connection", "Keep-Alive");
                _Response.ContentType = "application/octet-stream";
                _Response.Charset = "UTF-8";
                _Response.ContentEncoding = Encoding.GetEncoding("UTF-8");
                _Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(_fileName, System.Text.Encoding.UTF8));



                br.BaseStream.Seek(startBytes, SeekOrigin.Begin);
                int maxCount = (int)Math.Floor((decimal)(fileLength - startBytes) / pack) + 1;



                for (int i = 0; i < maxCount; i++)
                {
                    if (_Response.IsClientConnected)
                    {
                        _Response.BinaryWrite(br.ReadBytes(pack));
                        Thread.Sleep(sleep);
                    }
                    else
                    {
                        i = maxCount;
                    }
                }
                _Response.End();
            }
            catch (Exception ex)
            {
                _Response.Write(ex.Message);
                return false;
            }
            finally
            {
                br.Close();
                myFile.Close();
            }
        }
        catch (Exception ex)
        {
            _Response.Write(ex.Message);
            return false;
        }
        return true;
    }


    /// <summary>
    /// 读取文件内容
    /// </summary>
    /// <param name="filename"></param>
    /// <returns></returns>
    public static string ReadFile(string filename)
    {
        StreamReader sr = new StreamReader(filename,Encoding.Default);
        string str = sr.ReadToEnd();

        sr.Close();

        return str;
    }

    /// <summary>
    /// 导出文件，
    /// </summary>
    /// <param name="type">类型</param>
    /// <param name="setfname">文件名</param>
    /// <param name="content">内容</param>
    public static void extendFile(extenFileType type, string setfname, string content)
    {
        HttpResponse response = HttpContext.Current.Response;

        if (type == extenFileType.excel)
        {
            response.ContentType = "application/vnd.ms-excel";
        }
        else
        {
            response.ContentType = "application/ms-word";
        }

        response.AddHeader("content-disposition", "inline;filename="
          + HttpUtility.UrlEncode(setfname, Encoding.UTF8));

        //s sb = new stringbuilder();
        //system.io.stringwriter sw = new system.io.stringwriter(sb);
        //system.web.ui.htmltextwriter hw = new system.web.ui.htmltextwriter(sw);
        //sb.append("<html><body>");
        //dgshow.rendercontrol(hw);
        //sb.append("</body></html>");
        response.Write(content);
        response.End();


    }


    /// <summary>
    /// 导出的文件类型
    /// </summary>
    public enum extenFileType
    {
        word,
        excel
    } 

    /// <summary>
    /// 返回指定文件夹下面的所有文件列表
    /// </summary>
    /// <param name="dirpath"></param>
    /// <returns></returns>
    public static IList<string> GetDirFiles(string dirpath)
    {
        if (Directory.Exists(dirpath))
        {
            DirectoryInfo Objdir = new DirectoryInfo(dirpath);

            FileInfo[] fs = Objdir.GetFiles();

            if (fs != null)
            {
                IList<string> ilist = new List<string>();
                foreach (FileInfo fi in fs)
                {
                    ilist.Add(fi.Name);
                }

                return ilist;

            }
        }
        return null;
    }



    /// <summary>
    /// 检查批量上传文件的类型和大小验证  0：文件类型错误. -1：文件超过最大上传限制.
    /// </summary>
    /// <param name="files">文件组</param>
    /// <param name="maxfilesize">文件大小</param>
    /// <param name="filetype">文件类型 如 .jpg,.png,.gif等</param>
    /// <returns>返回整型值</returns>
    public static  int CheckeFileList(HttpFileCollection files, int maxfilesize, string filetype)
    {
        int intret = 1;
        for (int i = 0; i < files.Count;i++ )
        {
            HttpPostedFile f = files[i];

            if (f.FileName != "" && f.ContentLength > 0)
            {
                //判断文件的类型和大小
                if (checkFileType(filetype, f.FileName))
                {
                    if (checekIsAllowSize(maxfilesize, f))
                    {

                    }
                    else
                        intret = -1;
                }
                else
                    intret = 0;//文件类型错误
            }

            if (intret != 1)
                break;
        }

        return intret;
    }


    /// <summary>
    ///  测试文件类型是否正确
    /// </summary>
    /// <param name="filetype"></param>
    /// <param name="filename"></param>
    /// <returns>返回是否正确</returns>
    private static  bool checkFileType(string filetype, string filename)
    {    
        //检查文件的类型
        string extn = filename.Substring(filename.LastIndexOf("."));

        if (filetype.IndexOf(extn) != -1)
            return true;
        return false; 
    }

    /// <summary>
    /// 检查文件是否超过最大大小
    /// </summary>
    /// <param name="maxfilesize">文件最大值</param>
    /// <param name="file">文件兑现</param>
    /// <returns>返回真假</returns>
    private static  bool checekIsAllowSize(int maxfilesize, HttpPostedFile file)
    {
        return (file.ContentLength / 1000 <= maxfilesize); 
    }
     

}

