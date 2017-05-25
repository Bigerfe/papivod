using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Linda.Entity;
using Linda.DAL.IServer;
using Easo.DAL;
using Linda.DAL;
  

namespace Easo.Web.DBMS.Link
{


    public partial class articleadmin_link_add : AdminPage
    {
        Tb_Easo_FriendLink ml = new Tb_Easo_FriendLink();

        DalTb_Easo_FriendLink dal = DalTb_Easo_FriendLink.CreateInstance();

        int filesize = Global.default_filesize;
        string ex = Global.default_imgtype;
        string path = Global.linkimgpath;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //#region 权限判断
                //    if (DoClass.CheckLogin(0))
                //    {

                //        DoClass.VisiteCurPage(this, 1);

                //    }
                //    #endregion


                this.ddllocationtype.DataSource = DalServer.CreateInstance().GetFriendLinkChannel();
                this.ddllocationtype.DataBind();

                this.ddllocationtype.Items.Insert(0, new ListItem("全部", "")); 

                this.FileUpload1.Visible = false;
            }

        }
       
        protected void drtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool b = drtype.SelectedValue == "1" ? FileUpload1.Visible = false : FileUpload1.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string title = StringUtil.TBCode(this.title.Text.Trim());
            string url = this.url.Text.Trim();

            string type = this.drtype.SelectedValue;

            string filename = "";


            if (title == "")
            {
                Jscript.Alert("请输入标题！", this);
                return;

            }
            if (url == "")
            {
                Jscript.Alert("请输入连接地址！", this);
                return;
            }
            if (type == "0")
            {
                //上传文件
                if (this.FileUpload1.PostedFile.FileName == null || this.FileUpload1.PostedFile.FileName.ToString() == "")
                {
                    Jscript.Alert("请选择图片!", this);
                    return;
                }

                string s = DoClass.UploadFile(this.FileUpload1.PostedFile, filesize, ex, path);

                if (s == "0")
                {
                    Jscript.Alert("文件太大!", this);
                    return;
                }
                else if (s == "-1")
                {
                    Jscript.Alert("文件类型错误!", this);
                    return;
                }
                else
                    filename = path + s;

            }
            
            ml.Addtime = DateTime.Now;
            ml.Description = txtdes.Text.Trim();
            ml.LocationType = Utils.StrToInt(ddllocationtype.SelectedValue);
            ml.Name = title;
            ml.Pic = filename;
            ml.Sort = Utils.StrToInt(txtSort.Text.Trim());
            ml.Url = url;
            ml.Type = Utils.StrToInt(drtype.SelectedValue);

            if (dal.Add(ml) > 0)
            {
                Jscript.AlertAndRedirect("添加成功!", "default.aspx?t="+drtype.SelectedValue);
            }

        }
    }

}