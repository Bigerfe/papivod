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
using Kehu1.Entity;
using Linda.DAL;
namespace Easo.Web.DBMS.MsBaoming
{
    public partial class Addnews : AdminPage
    {
        Pbaoming md = new Pbaoming();//实体类

        DalPbaoming dal = DalPbaoming.CreateInstance();//操作类

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.dr_z1.DataSource = DalTb_Easo_NewClass.CreateInstance().GetWebNewClassList((int)GlobalData.报名志愿);
                this.dr_z1.DataBind();
                this.dr_z1.Items.Insert(0, new ListItem("请选择", ""));

                this.dr_z2.DataSource = DalTb_Easo_NewClass.CreateInstance().GetWebNewClassList((int)GlobalData.报名志愿);
                this.dr_z2.DataBind();
                this.dr_z2.Items.Insert(0, new ListItem("请选择", ""));

                this.dr_xl.DataSource = DalTb_Easo_NewClass.CreateInstance().GetWebNewClassList((int)GlobalData.学历);
                this.dr_xl.DataBind();


                string action = CRequest.GetString("action");

                int id = CRequest.GetInt("nid", 0);
                if (id <= 0)
                    Jscript.DamicAlert();
                else
                {
                    //设置新闻内容
                    md = dal.GetModel(id);
                    if (md == null)
                        Jscript.DamicAlert();
                    else
                    {

                        ViewState["ID"] = id;

                        txtaddress.Value = md.address;
                        txtname.Value = md.pname;
                        txtremark.Value = md.remark;
                        txttel.Value = md.tel;
                        txtcard.Value = md.card;
                        txtprovince.Value = md.province;
                        txtcity.Value = md.city;
                        txtarea.Value = md.area;
                        txtgaokchengj.Value = md.gaokchengj;
                        txtengchengj.Value = md.engchengj;
                        txttel.Value = md.tel;
                        txtreceiver.Value = md.receiver;
                        txtonlinetype.Value = md.onlinetype;
                        txtemail.Value = md.email;
                        txtpost.Value = md.post;
                        ListItem item = dr_z1.Items.FindByValue(md.firstz.ToString());
                        if (item != null)
                            item.Selected = true;


                        item = dr_z2.Items.FindByValue(md.secondz.ToString());
                        if (item != null)
                            item.Selected = true;

                        item = dr_xl.Items.FindByValue(md.xueli.ToString());
                        if (item != null)
                            item.Selected = true;

                        this.rapass.SelectedValue = md.ifpass.ToString();
                        dr_sex.SelectedValue = md.sex.ToString();
                        txtpassremark.Text = md.passremark;
                    }
                }
            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                md.firstz = Utils.StrToInt(dr_z1.SelectedValue, 0);
                md.secondz = Utils.StrToInt(dr_z2.SelectedValue, 0);
                md.pname = txtname.Value.Trim();
                md.card = txtcard.Value.Trim();
                md.xueli = Utils.StrToInt(dr_xl.SelectedValue, 0);
                md.sex = dr_sex.SelectedValue;
                md.province = txtprovince.Value.Trim();
                md.city = txtcity.Value.Trim();
                md.area = txtarea.Value.Trim();
                md.gaokchengj = txtgaokchengj.Value.Trim();
                md.engchengj = txtengchengj.Value.Trim();
                md.tel = txttel.Value.Trim();
                md.address = txtaddress.Value.Trim();
                md.post = txtpost.Value.Trim();
                md.receiver = txtreceiver.Value.Trim();
                md.onlinetype = txtonlinetype.Value.Trim();
                md.email = txtemail.Value.Trim();
                md.remark = txtremark.Value.Trim();
                md.ifpass = Utils.StrToInt(rapass.SelectedValue);

                md.passremark = txtpassremark.Text.Trim();

                if (md.firstz <= 0)
                {
                    Jscript.Alert("请选择第一志愿");
                    return;
                }
                if (md.card == "")
                {
                    Jscript.Alert("请输入身份证号");
                    return;
                }

                md.id = Utils.StrToInt(ViewState["ID"].ToString());

                if (dal.Update(md) > 0)
                {
                    Jscript.WriteInfo("更新成功！");
                }
            }
        }

    }

}
