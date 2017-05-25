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
                        Jscript.WriteInfo("û�в���.");
                    else
                    {

                        msgtitle.Text = "�޸�";
                        btnadd.Text = "�޸�";

                        model = dal.GetModel(id);
                        if (model == null)
                            Jscript.WriteInfo("û�ж���.");
                        else
                        {
                            txttitle.Text = model.Title;
                            txtordernum.Text = model.OrderNum.ToString();
                            txthttp.Text = model.Http;

                            if (model.Pic != "")
                                lapic1.Text = "<a href='"+model.Pic+"' target='fadsf'>�鿴ͼƬ</a>"; 
                           

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
                        Jscript.Alert("�ϴ�ͼƬ���ܳ���" + Global.default_filesize + "KB");
                        return;
                    }
                    else if (pic == "-1")
                    {
                        Jscript.Alert("�ϴ�ͼƬ����Ϊ" + Global.default_imgtype + "��ʽ");
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
                        Jscript.WriteInfo("�޸ĳɹ�.");

                }
                else
                {
                    //���

                    model.Pic = pic;
                    model.WPic = pic1;
                    
                    if(dal.Add(model)>0)
                        Jscript.WriteInfo("��ӳɹ�.");

                }
            }
        }
    }
}
