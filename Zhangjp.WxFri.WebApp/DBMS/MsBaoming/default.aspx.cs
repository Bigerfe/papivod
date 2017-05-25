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
using PagerUtility;
using Linda.DAL.IServer;
using Easo.DAL;
using Linda.DAL;
  namespace Easo.Web.DBMS.MsBaoming
{
    public partial class _default : AdminPage
    {

        DalPbaoming dal = new DalPbaoming();

        SetPager_PostBack post = new SetPager_PostBack();
        string tbname = "baominglist";
        string key = "id";
        string sql = "1=1 ";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //this.dr_z1.DataSource = DalTb_Easo_NewClass.CreateInstance().GetWebNewClassList((int)GlobalData.报名志愿);
                //this.dr_z1.DataBind();
                //this.dr_z1.Items.Insert(0, new ListItem("全部", ""));


                //this.dr_z2.DataSource = DalTb_Easo_NewClass.CreateInstance().GetWebNewClassList((int)GlobalData.报名志愿);
                //this.dr_z2.DataBind();
                //this.dr_z2.Items.Insert(0, new ListItem("全部", ""));


                this.dr_xuexiao.DataSource = Portals.GetTopNewsByClassid((int)GlobalData.院校推荐, 2000);
                this.dr_xuexiao.DataBind();
                this.dr_xuexiao.Items.Insert(0, new ListItem("全部", ""));

                this.dr_xl.DataSource = DalTb_Easo_NewClass.CreateInstance().GetWebNewClassList((int)GlobalData.学历);
                this.dr_xl.DataBind();
                this.dr_xl.Items.Insert(0, new ListItem("全部", ""));


                //this.dropmenu.DataSource = Portal.GetTopNewsByClassid((int)Global.NewsClassEnum.专业介绍 + 4,10);
                //this.dropmenu.DataBind();
               // dropmenu.Items.Insert(0, new ListItem("请选择", ""));

                post.InitBindData(this.GridView1, this.AspNetPager1, tbname, key, sql, key);

                ViewState["sql"] = sql;
            }
        }

        protected void AspNetPager1_PageChanged1(object sender, EventArgs e)
        {
            post.SecondBindData(this.GridView1, this.AspNetPager1, tbname, key, ViewState["sql"].ToString(), key);
        }

        protected void btnsear_Click(object sender, EventArgs e)
        {
            if (txtitle.Text.Trim() != "")
                sql += " and pname like '%" + Utils.ChkSQL(txtitle.Text.Trim()) + "%'";


            if (dr_xuexiao.SelectedValue != "")
                sql += " and xuexiaoid=" + dr_xuexiao.SelectedValue;

            //if (dr_z1.SelectedValue != "")
            //    sql += " and firstz="+dr_z1.SelectedValue;

            //if (dr_z2.SelectedValue != "")
            //    sql += " and secondz="+dr_z2.SelectedValue;
            if (dr_xl.SelectedValue != "")
            {
                sql += " and xueli="+dr_xl.SelectedValue;
            }
            if (txtmobile.Text.Trim() != "")
            {
                sql += " and tel like '%" + Utils.ChkSQL(txtmobile.Text.Trim()) + "%'";
            }
        

            ViewState["sql"] = sql;
            post.InitBindData(this.GridView1, this.AspNetPager1, tbname, key, sql, key);
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            string strid = CRequest.GetString("che");
            if (strid == "")
                Jscript.Alert("请选择数据!", this);
            else
            {
                dal.DeleteList(strid, 1);

                post.InitBindData(this.GridView1, this.AspNetPager1, tbname, key, ViewState["sql"].ToString(), key);
            }
        }
         
       
    }
}
