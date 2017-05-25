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
using Linda.DAL;
using Linda.Entity;
 

 namespace Easo.Web.DBMS.AminManager
{
    public partial class update : AdminPage
    {

      
        DalManager dal = DalManager.CreateInstance();

        wManager model = new wManager();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
             

                int id = CRequest.GetQueryInt("id", 0);
                if (id <= 0)
                {
                    Jscript.DamicAlert();
                }
                else
                {
                    //读取数据

                    model = dal.GetModel(id);
                    if (model == null)
                        Jscript.DamicAlert();
                    else
                    {
                        this.txtaddress.Text = model.sAddress;
                        this.txtcardid.Text = model.sCertId;
                        this.txtcardname.Text = model.sCertName;
                        this.txtduty.Text = model.sDuty;
                        this.txtfax.Text = model.sFax;
                        this.txtmobile.Text = model.sMobile;
                        this.txtpost.Text = model.sMail;
                        this.txtqq.Text = model.sQQ;
                        this.txtremark.Text = model.sRemark;
                        this.txttel.Text = model.sTel;
                        this.txtuserid.Text = model.sManager;
                        this.txtusername.Text = model.sManagerName;

                        if (model.cDel == "1")
                            radel.Items[0].Selected = true;
                        else
                            radel.Items[1].Selected = true;

                        if (model.cFrost == "1")
                            radongjie.Items[0].Selected = true;
                        else
                            radongjie.Items[1].Selected = true;

                        if (model.sCall == "1")
                            this.racall.Items[0].Selected = true;

                        else
                            this.racall.Items[1].Selected = true;


                        if (model.sPicName != "")
                            this.laimg.Text = "<a href='" + model.sPicName + "' target='_blank' >打开图片</a>"; 

                    

                       
                        ViewState["id"] = id;
                        ViewState["img"] = model.sPicName;

                       
                    }
                }
            }
        }

        protected void btnmodify_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {

                model.sAddress = this.txtaddress.Text.Trim();
                model.sCall = this.racall.SelectedValue;
                model.sCertId = this.txtcardid.Text.Trim();
                model.sCertName = this.txtcardname.Text.Trim();
                model.sDuty = this.txtduty.Text.Trim();
                model.sFax = this.txtfax.Text.Trim();
                model.sMail = this.txtpost.Text.Trim();
                model.sManager = this.txtuserid.Text.Trim();
                model.sManagerName = this.txtusername.Text.Trim();
                model.sMobile = this.txtmobile.Text.Trim();
                model.sPassWord = this.txtpwd.Text.Trim();



                //上传图片
                string s = "";

                if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
                {
                    s = DoClass.UploadFile(FileUpload1.PostedFile, Global.adminpicsize, Global.default_imgtype, Global.adminpicpath);

                    if (s == "-1")
                    {
                        Jscript.Alert("文件类型错误！", this);
                        return;
                    }
                    else if (s == "0")
                    {
                        Jscript.Alert("文件太大!", this);
                        return;
                    }
                    else
                        s = Global.adminpicpath + s;

                }
                else
                    s = ViewState["img"].ToString();
                ///图片地址
                model.sPicName = s;


                model.sQQ = this.txtqq.Text.Trim();
                model.sRemark = this.txtremark.Text.Trim();
                model.sTel = this.txttel.Text.Trim();


                model.iManagerId = int.Parse(ViewState["id"].ToString());
                model.cDel = this.radel.SelectedValue;
                model.cFrost = this.radongjie.SelectedValue;
           
              

            
                if (dal.Update(model) > 0)
                    Jscript.AlertAndRedirect("后台用户信息修改成功!", "default.aspx");
                else
                    Jscript.AlertAndRedirect("用户账号已经存在!", this.Request.RawUrl);
            }
        }
 
    }
}
