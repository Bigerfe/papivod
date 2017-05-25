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
namespace Easo.Web.DBMS.Ykdh
{
    public partial class _default : AdminPage
    {
        int id = CRequest.GetInt("id",0);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (id <= 0)
                {
                    id = 200;
                }
                laname.Text = DalTb_Easo_Sys_set.GetColumnName(id);

                txtContent.Value = DalTb_Easo_Sys_set.ReturnValue(id);
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            if (DalTb_Easo_Sys_set.UpdateValue(id, txtContent.Value.Trim()))
            {
                Jscript.WriteInfo("ÉèÖÃ³É¹¦.");
            }
        }


    }
}
