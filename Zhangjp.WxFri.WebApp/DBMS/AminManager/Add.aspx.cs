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
    public partial class Add : AdminPage
    {


        DalManager dal = DalManager.CreateInstance();

        wManager model = new wManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnmodify_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                model.cDel = "0";
                model.cFrost = "0";

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

                //�ϴ�ͼƬ
                string s = "";

                if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
                {
                    s = DoClass.UploadFile(FileUpload1.PostedFile, Global.adminpicsize, Global.default_imgtype, Global.adminpicpath);

                    if (s == "-1")
                    {
                        Jscript.Alert("�ļ����ʹ���", this);
                        return;
                    }
                    else if (s == "0")
                    {

                        Jscript.Alert("�ļ�̫��!", this);
                        return;
                    }
                    else
                        s = Global.adminpicpath + s;

                }
                else
                    s = "";
                ///ͼƬ��ַ
                model.sPicName = s;


                model.sQQ = this.txtqq.Text.Trim();
                model.sRemark = this.txtremark.Text.Trim();
                model.sTel = this.txttel.Text.Trim();



                if (dal.Add(model) > 0)
                    Jscript.AlertAndRedirect("��̨�û���ӳɹ�!", this.Request.RawUrl);
                else
                    Jscript.AlertAndRedirect("���ʧ�ܣ����ʻ��Ѿ����ڣ�", this.Request.RawUrl);
            }

        }


    }
}
