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
using System.IO;
using Linda.DAL.IServer;
using Linda.DAL;
  namespace Web.DBMS.MSConfig
{
    public partial class netconfig : AdminPage
    {
        /********* �ϴ�ͼƬ���� **********/

        int filesize = Global.default_filesize;
        string ex = Global.default_imgtype;
        string path = Global.default_imgpath;


        /******************************/

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Popedom.IsVaildPopedom(Popedom.ReturnAdminPopedomID(), "NetConfig"))
            //{
            //    Jscript.AlertAndRedirect("��û��Ȩ�޲�����", "../main.aspx");
            //    return;
            //}
            if (!IsPostBack)
            {
                //if (!DoClass.AdminIsLogin(this, 1))
                //{
                //    return;
                //}
                getData();
            }
        }

        private void getData()
        {
            if (DalTb_Easo_Sys_set.ReturnValue(2) == "1")//��վ״̬
            {
                this.RadioButton1.Checked = true;
                this.RadioButton2.Checked = false;
            }
            else
            {
                this.RadioButton1.Checked = false;
                this.RadioButton2.Checked = true;
            }
            if (DalTb_Easo_Sys_set.ReturnValue(15) == "1")//��վ״̬
            {
                this.RadioButton3.Checked = true;
                this.RadioButton4.Checked = false;
            }
            else
            {
                this.RadioButton3.Checked = false;
                this.RadioButton4.Checked = true;
            }
            if (DalTb_Easo_Sys_set.ReturnValue(16) == "1")//��վ״̬
            {
                this.RadioButton5.Checked = true;
                this.RadioButton6.Checked = false;
            }
            else
            {
                this.RadioButton5.Checked = false;
                this.RadioButton6.Checked = true;
            }
            this.txtNetName.Text = DalTb_Easo_Sys_set.ReturnValue(3);//��վ����

            this.txtCompany.Text = DalTb_Easo_Sys_set.ReturnValue(5);//��˾���� 


            this.txtTel.Text = DalTb_Easo_Sys_set.ReturnValue(6);//��˾�绰

            this.txtEmail.Text = DalTb_Easo_Sys_set.ReturnValue(7);//��˾Email

            this.txticp.Value = DalTb_Easo_Sys_set.ReturnValue(8);//ICP

            this.txtKeywords.Text = DalTb_Easo_Sys_set.ReturnValue(9);//����Keywords

            this.txtDescription.Text = DalTb_Easo_Sys_set.ReturnValue(10);//����Description 

            this.txtBword.Text = DalTb_Easo_Sys_set.ReturnValue(11);//������Ϣ����

            this.ImageLogo.ImageUrl = DalTb_Easo_Sys_set.ReturnValue(4);//��վLOGO

            ViewState["img"] = DalTb_Easo_Sys_set.ReturnValue(4);


            txtLXWM.Text = DalTb_Easo_Sys_set.ReturnValue(12);//��ϵ����


            txtUrl.Text = DalTb_Easo_Sys_set.ReturnValue(1); //��վ��ַ


            this.txtGrxieyi.Text = DalTb_Easo_Sys_set.ReturnValue(13); //����ע��Э��

            this.txtcloseinfo.Text = DalTb_Easo_Sys_set.ReturnValue(14);//��վ�ر���ʾ��Ϣ 

        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            if (this.RadioButton1.Checked)
            {
                if (DalTb_Easo_Sys_set.UpdateValue(2, "1"))
                {
                    Jscript.Alert("�����ɹ���", this.Page);
                }
                else
                {
                    Jscript.Alert("����ʧ�ܣ�", this.Page);
                }
            }
            else
            {
                if (DalTb_Easo_Sys_set.UpdateValue(2, "0"))
                {
                    Jscript.Alert("�����ɹ���", this.Page);
                }
                else
                {
                    Jscript.Alert("����ʧ�ܣ�", this.Page);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DalTb_Easo_Sys_set.UpdateValue(3, this.txtNetName.Text.Trim()))
            {
                Jscript.Alert("�����ɹ���", this.Page);
            }
            else
            {
                Jscript.Alert("����ʧ�ܣ�", this.Page);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (DalTb_Easo_Sys_set.UpdateValue(5, this.txtCompany.Text.Trim()))
            {
                Jscript.Alert("�����ɹ���", this.Page);
            }
            else
            {
                Jscript.Alert("����ʧ�ܣ�", this.Page);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (DalTb_Easo_Sys_set.UpdateValue(6,this.txtTel.Text.Trim()))
            {
                Jscript.Alert("�����ɹ���", this.Page);
            }
            else
            {
                Jscript.Alert("����ʧ�ܣ�", this.Page);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (DalTb_Easo_Sys_set.UpdateValue(7, this.txtEmail.Text.Trim()))
            {
                Jscript.Alert("�����ɹ���", this.Page);
            }
            else
            {
                Jscript.Alert("����ʧ�ܣ�", this.Page);
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (DalTb_Easo_Sys_set.UpdateValue(8, this.txticp.Value.Trim()))
            {
                Jscript.Alert("�����ɹ���", this.Page);
            }
            else
            {
                Jscript.Alert("����ʧ�ܣ�", this.Page);
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (DalTb_Easo_Sys_set.UpdateValue(9, this.txtKeywords.Text.Trim()))
            {
                Jscript.Alert("�����ɹ���", this.Page);
            }
            else
            {
                Jscript.Alert("����ʧ�ܣ�", this.Page);
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            if (DalTb_Easo_Sys_set.UpdateValue(10, this.txtDescription.Text.Trim()))
            {
                Jscript.Alert("�����ɹ���", this.Page);
            }
            else
            {
                Jscript.Alert("����ʧ�ܣ�", this.Page);
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            if (DalTb_Easo_Sys_set.UpdateValue(11, this.txtBword.Text.Trim()))
            {
                Jscript.Alert("�����ɹ���", this.Page);
            }
            else
            {
                Jscript.Alert("����ʧ�ܣ�", this.Page);
            }
        }

     
       
        protected void Button12_Click(object sender, EventArgs e)
        {
            string strImg = "";
            if (this.FileUpload1.FileName.ToString() != "")
            {
                string s = DoClass.UploadFile(this.FileUpload1.PostedFile, filesize, ex, path);
                if (s == "0")
                {
                    Jscript.Alert("�ϴ��ļ�̫��", this.Page);
                    return;
                }
                else if (s == "-1")
                {
                    Jscript.Alert("�ϴ��ļ����ʹ���", this.Page);
                    return;
                }
                else
                {
                    DoFile.DeleteFile(ViewState["img"].ToString());
                    strImg = path + s;
                }
            }
            else
            {
                strImg = ViewState["img"].ToString();
            }
            if (DalTb_Easo_Sys_set.UpdateValue(4, strImg))
            {
                Jscript.Alert("�����ɹ���", this.Page);
                getData();
            }
            else
            {
                Jscript.Alert("����ʧ�ܣ�", this.Page);
            }
        }
 
      
        protected void Button16_Click(object sender, EventArgs e)
        {
            if (DalTb_Easo_Sys_set.UpdateValue(12, this.txtLXWM.Text.Trim()))
            {
                Jscript.Alert("�����ɹ���", this.Page);
            }
            else
            {
                Jscript.Alert("����ʧ�ܣ�", this.Page);
            }
        }

        protected void gerxie(object sender, EventArgs e)
        {
            if (DalTb_Easo_Sys_set.UpdateValue(13, this.txtGrxieyi.Text.Trim()))
            {
                Jscript.Alert("�����ɹ���", this.Page);
            }
            else
            {
                Jscript.Alert("����ʧ�ܣ�", this.Page);
            }

        }

    
        protected void Button19_Click(object sender, EventArgs e)
        {
            if (File.Exists(Server.MapPath("~/bin/cache.txt")))
            {
                StreamWriter sw = new StreamWriter(Server.MapPath("~/bin/cache.txt"),true);
                
                sw.Write(DateTime.Now.ToString() + "\r\n");
                sw.Close();
            }
            else { 
                 StreamWriter sw =   File.CreateText(Server.MapPath("~/bin/cache.txt"));
           sw.Write(DateTime.Now.ToString() + "\r\n");
             sw.Close();
            }

            Jscript.AlertAndRedirect("�����Ѿ��ɹ����!", this.Request.RawUrl);
        }

        protected void Button20_Click(object sender, EventArgs e)
        {
            if (DalTb_Easo_Sys_set.UpdateValue(1, this.txtUrl.Text.Trim()))
            {
                Jscript.Alert("�����ɹ���", this.Page);
            }
        }

        protected void closeclick(object sender, EventArgs e)
        {
            if (DalTb_Easo_Sys_set.UpdateValue(14, this.txtcloseinfo.Text.Trim()))
            {
                Jscript.Alert("�����ɹ���", this.Page);
            }
            else
            {
                Jscript.Alert("����ʧ�ܣ�", this.Page);
            }

        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            if (this.RadioButton3.Checked)
            {
                if (DalTb_Easo_Sys_set.UpdateValue(15, "1"))
                {
                    Jscript.Alert("�����ɹ���", this.Page);
                }
                else
                {
                    Jscript.Alert("����ʧ�ܣ�", this.Page);
                }
            }
            else
            {
                if (DalTb_Easo_Sys_set.UpdateValue(15, "0"))
                {
                    Jscript.Alert("�����ɹ���", this.Page);
                }
                else
                {
                    Jscript.Alert("����ʧ�ܣ�", this.Page);
                }
            }
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            if (this.RadioButton5.Checked)
            {
                if (DalTb_Easo_Sys_set.UpdateValue(16, "1"))
                {
                    Jscript.Alert("�����ɹ���", this.Page);
                }
                else
                {
                    Jscript.Alert("����ʧ�ܣ�", this.Page);
                }
            }
            else
            {
                if (DalTb_Easo_Sys_set.UpdateValue(16, "0"))
                {
                    Jscript.Alert("�����ɹ���", this.Page);
                }
                else
                {
                    Jscript.Alert("����ʧ�ܣ�", this.Page);
                }
            }
        }

        protected void Button66_Click(object sender, EventArgs e)
        {
            Response.Redirect("/sendrequest.aspx?action=shengchengjigntaiye");
            Jscript.WriteInfo("ok!");
        }

        protected void Button77_Click(object sender, EventArgs e)
        {
            Response.Redirect("/sendrequest.aspx?action=shengchengindexhtml");
        }
         
       
    }
}
