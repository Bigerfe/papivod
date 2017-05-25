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
using Linda.Entity;
using Easo.DAL;
using Linda.DAL;
 namespace Easo.Web.DBMS.Link
{
    public partial class articleadmin_link_Default : AdminPage
    {
        Tb_Easo_FriendLink ml = new Tb_Easo_FriendLink();

        DalTb_Easo_FriendLink dal = DalTb_Easo_FriendLink.CreateInstance();

        SetPager_PostBack_EnableSort post = new SetPager_PostBack_EnableSort();

        string tbname = "Tb_Easo_FriendLink";
        string sql = "1=1";
        string key = "id";



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                this.ddllocationtype.DataSource = DalServer.CreateInstance().GetFriendLinkChannel();
                this.ddllocationtype.DataBind();

                this.ddllocationtype.Items.Insert(0, new ListItem("全部", ""));

                string t = CRequest.GetString("t");
                if (t != "")
                    DropDownList1.SelectedValue = t;

                if (DropDownList1.SelectedValue == "1")
                    this.GridView1.Columns[2].Visible = false;
                else
                    this.GridView1.Columns[2].Visible = true;

                sql += " and [type]=" + DropDownList1.SelectedValue;


                ViewState["sql"] = sql;
                ViewState["sortype"] = this.dropsort.SelectedValue;

                post.InitBindData(this.GridView1, AspNetPager1, tbname, key, sql, ViewState["sortype"].ToString(), 0);

            }
        }

        protected void btnsear_Click(object sender, EventArgs e)
        {
            sql += " and [type]=" + DropDownList1.SelectedValue;

            if (ddllocationtype.SelectedValue != "")
                sql += " and [locationtype]=" + ddllocationtype.SelectedValue;
            if (txtname.Text.Trim() != "")
                sql += " and [Name] like '%" + txtname.Text.Trim() + "%'";
            ViewState["sql"] = sql;


            if (DropDownList1.SelectedValue == "1")
                this.GridView1.Columns[2].Visible = false;
            else
                this.GridView1.Columns[2].Visible = true;
            ViewState["sortype"] = this.dropsort.SelectedValue;

            post.InitBindData(this.GridView1, AspNetPager1, tbname, key, sql, ViewState["sortype"].ToString(), 0);
        }

        protected void AspNetPager1_PageChanged1(object sender, EventArgs e)
        {
            post.SecondBindData(this.GridView1, AspNetPager1, tbname, key, ViewState["sql"].ToString(), ViewState["sortype"].ToString(), 0);

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string strid = CRequest.GetString("che");

            if (strid == "")
                Jscript.Alert("请选择数据", this);
            else
            {
                string cmd = ddlCaozuo.SelectedValue;
                if (cmd == "del")
                {
                    if (dal.DeleteList(strid, 1) > 0)
                        Jscript.Alert("删除成功！", this);
                }
                else if (cmd == "sh")
                {
                    if (dal.SetValue("che", "1", strid) > 0)
                        Jscript.Alert("设置成功！", this);
                }
                else if (cmd == "sd")
                {
                    if (dal.SetValue("che", "0", strid) > 0)
                        Jscript.Alert("设置成功！", this);
                }

                post.SecondBindData(this.GridView1, AspNetPager1, tbname, key, ViewState["sql"].ToString(), ViewState["sortype"].ToString(), 0);

            }

        }



    }

}