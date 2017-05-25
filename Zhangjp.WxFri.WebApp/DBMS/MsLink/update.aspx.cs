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
using Linda.DAL.IServer;
using Linda.Entity;
using Easo.DAL;
using Linda.DAL;
 
namespace Easo.Web.DBMS.Link
{
    public partial class articleadmin_link_udpate : AdminPage
    {


        Tb_Easo_FriendLink ml = new Tb_Easo_FriendLink();

        DalTb_Easo_FriendLink li = DalTb_Easo_FriendLink.CreateInstance();

        int filesize = Global.default_filesize;
        string ex = Global.default_imgtype;
        string path = Global.linkimgpath;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                int id = CRequest.GetInt("linkid", 0);

                if (id > 0)
                {
                    this.ddllocationtype.DataSource = DalServer.CreateInstance().GetFriendLinkChannel();
                    this.ddllocationtype.DataBind();

                    this.ddllocationtype.Items.Insert(0, new ListItem("全部", ""));


                    ViewState["linkid"] = id;

                    ml = li.GetModel(id);

                    if (ml != null)
                    {

                        this.ddllocationtype.SelectedValue = ml.LocationType.ToString();
                        this.txtSort.Text = ml.Sort.ToString();
                        this.title.Text = ml.Name.ToString();
                        this.url.Text = ml.Url;

                        this.drtype.SelectedIndex = ml.Type == 1 ? 0 : 1;

                        this.h1.Text = ml.Pic;

                        this.txtdes.Text = ml.Description; 

                        ViewState["t"] = ml.Type.ToString();

                        this.setDisplay();
                    }

                }
                else
                {
                    Jscript.DamicAlert();
                }
            }
        }


        void setDisplay()
        {
            bool b = drtype.SelectedValue == "1" ? file1.Visible = false : file1.Visible = true;
        }

        protected void add_Click(object sender, EventArgs e)
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
                string s = "";
                //上传文件
                if (file1.PostedFile.FileName == null || file1.PostedFile.FileName.ToString() == "")
                {
                    filename = h1.Text.Trim();
                }
                else
                {
                    s = DoClass.UploadFile(this.file1.PostedFile, filesize, ex, path);
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


                    filename = path + s;
                }


            }
            else
            {
                filename = h1.Text.Trim();
            }

            ml.Addtime = DateTime.Now;
            ml.Description = txtdes.Text.Trim();
            ml.LocationType = Utils.StrToInt(ddllocationtype.SelectedValue);
            ml.Name = title;
            ml.Pic = filename;
            ml.Sort = Utils.StrToInt(txtSort.Text.Trim());
            ml.Url = url;
            ml.Type = Utils.StrToInt(drtype.SelectedValue);

            ml.ID = Utils.StrToInt(ViewState["linkid"]);

            li.Update(ml);

            Jscript.AlertAndRedirect("修改成功!", "default.aspx?t=" + drtype.SelectedValue);


        }
        protected void drtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.setDisplay();
        }
    }


}