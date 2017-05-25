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
using Linda.DAL;
 
namespace Eakia.Web.MS.JsTurnPIc
{
    public partial class Add : AdminPage
    {

        TurnPic model = new TurnPic();

        DalTurnPic dal = DalTurnPic.CreateInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string action = CRequest.GetString("action");
                if (action == "update")
                {

                    int id = CRequest.GetInt("id",0);

                    if (id <= 0)
                        Jscript.WriteInfo("没有参数.");
                    else
                    {

                        msgtitle.Text = "修改";
                        btnadd.Text = "修改";

                        model = dal.GetModel(id);
                        if (model == null)
                            Jscript.WriteInfo("没有对象.");
                        else
                        {
                            txttitle.Text = model.Title;
                            txtordernum.Text = model.OrderNum.ToString();
                            txthttp.Text = model.Http;

                            if (model.Pic != "")
                                lapic1.Text = "<a href='"+model.Pic+"' target='fadsf'>查看图片</a>"; 
                           

                            ViewState["id"] = id;

                            ViewState["pic"] = model.Pic;
                           
                            
                        }
                    }
                }
                else
                {

                }
            } 

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string action = CRequest.GetString("action");

                model.Title = txttitle.Text.Trim();
                model.Operid = DoClass.GetAdminUserIDInt();
                model.OrderNum = Utils.StrToInt(txtordernum.Text.Trim());
                model.Http = txthttp.Text.Trim();
                string pic = "";
                string pic1 = "";

                if (this.FileUpload1.PostedFile.FileName != "")
                {
                    pic = DoClass.UploadFile(this.FileUpload1.PostedFile, Global.default_filesize, Global.default_imgtype, Global.jsturnpath);
                    if (pic == "0")
                    {
                        Jscript.Alert("上传图片不能超过" + Global.default_filesize + "KB");
                        return;
                    }
                    else if (pic == "-1")
                    {
                        Jscript.Alert("上传图片类型为" + Global.default_imgtype + "格式");
                        return;
                    }
                    else
                    {
                        pic = Global.jsturnpath + pic;

                    }
                } 

                
                if (action == "update")
                {
                    if (pic != "")
                        model.Pic = pic;
                    else
                        model.Pic = ViewState["pic"].ToString(); 
           
                    model.ID = Utils.StrToInt(ViewState["id"].ToString());

                    if(dal.Update(model)>0)
                        Jscript.WriteInfo("修改成功.");

                }
                else
                {
                    //添加

                    model.Pic = pic;
                    model.WPic = pic1;
                    
                    if(dal.Add(model)>0)
                        Jscript.WriteInfo("添加成功.");

                }
            }
        }
    }
}
