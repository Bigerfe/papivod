using Common.Uitls.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToText
{
    public partial class Form_AreaTel : Form
    {
        public Form_AreaTel()
        {
            InitializeComponent();
        }

        private void Form_AreaTel_Load(object sender, EventArgs e)
        {
            DataSet ds = Utils.GetTelCom_Db();
            this.drop_com.DisplayMember = "telecom";
            this.drop_com.ValueMember = "telecom";
            this.drop_com.DataSource = ds;
            
        }
    }
}
