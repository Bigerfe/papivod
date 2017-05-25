namespace ToText
{
    partial class Form_ExtendData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ExtendData));
            this.label1 = new System.Windows.Forms.Label();
            this.comboxdatatype = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboxsex = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboxarea = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_copy = new System.Windows.Forms.Button();
            this.lable_count = new System.Windows.Forms.Label();
            this.btnclear = new System.Windows.Forms.Button();
            this.btn_todaoru = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "手机号类型：";
            // 
            // comboxdatatype
            // 
            this.comboxdatatype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboxdatatype.FormattingEnabled = true;
            this.comboxdatatype.Items.AddRange(new object[] {
            "房东出租（个人）",
            "中介出租"});
            this.comboxdatatype.Location = new System.Drawing.Point(99, 16);
            this.comboxdatatype.Name = "comboxdatatype";
            this.comboxdatatype.Size = new System.Drawing.Size(178, 20);
            this.comboxdatatype.TabIndex = 1;
            this.comboxdatatype.SelectedIndexChanged += new System.EventHandler(this.comboxdatatype_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(471, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "开始搜索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboxsex
            // 
            this.comboxsex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboxsex.FormattingEnabled = true;
            this.comboxsex.Items.AddRange(new object[] {
            "性别",
            "男",
            "女",
            "未知"});
            this.comboxsex.Location = new System.Drawing.Point(283, 16);
            this.comboxsex.Name = "comboxsex";
            this.comboxsex.Size = new System.Drawing.Size(121, 20);
            this.comboxsex.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "地区：";
            // 
            // comboxarea
            // 
            this.comboxarea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboxarea.FormattingEnabled = true;
            this.comboxarea.Items.AddRange(new object[] {
            "北京(全部)-bj",
            "|===朝阳-chaoyang-bj",
            "|===海淀-haidian-bj",
            "|===丰台-fengtai-bj",
            "|===昌平-changping-bj",
            "|===西城-xicheng-bj",
            "|===通州-tongzhou-bj",
            "|===大兴-daxing-bj",
            "|===宣武-xuanwu-bj",
            "|===石景山-shijingshan-bj",
            "|===东城-dongcheng-bj",
            "|===崇文-chongwen-bj",
            "|===顺义-shunyi-bj",
            "|===房山-fangshan-bj",
            "|===门头沟-mentougou-bj",
            "|===密云-miyun-bj",
            "|===怀柔-huairou-bj",
            "|===延庆-yanqing-bj",
            "|===平谷-pinggu-bj",
            "|===周边-zhoubian-bj",
            "上海(全部)-sh",
            "|===浦东-pudong-sh",
            "|===长宁-changning-sh",
            "|===闵行-minxing-sh",
            "|===徐汇-xuhui-sh",
            "|===普陀-putuo-sh",
            "|===杨浦-yangpu-sh",
            "|===宝山-baoshan-sh",
            "|===虹口-hongkou-sh",
            "|===闸北-zhabei-sh",
            "|===松江-songjiang-sh",
            "|===静安-jingan-sh",
            "|===黄浦-huangpu-sh",
            "|===嘉定-jiading-sh",
            "|===卢湾-luwan-sh",
            "|===青浦-qingpu-sh",
            "|===奉贤-fengxian-sh",
            "|===金山-jinshan-sh",
            "|===崇明-chongming-sh",
            "|===上海周边-shanghaizhoubian-sh",
            "天津(全部)-tj",
            "广州(全部)-gz",
            "哈尔滨(全部)-heb",
            "沈阳(全部)-sy",
            "太原(全部)-ty",
            "长春(全部)-cc",
            "威海(全部)-wei",
            "潍坊(全部)-wf",
            "呼和浩特(全部)-hhht",
            "杭州(全部)-hz-c",
            "苏州(全部)-su-c",
            "南京(全部)-nj-c",
            "无锡(全部)-wx-c",
            "济南(全部)-jn-c",
            "青岛(全部)-qd-c",
            "宁波(全部)-nb-c",
            "南昌(全部)-nc-c",
            "福州(全部)-fz-c",
            "合肥(全部)-hf-c",
            "徐州(全部)-xz-c",
            "淄博(全部)-zb-c",
            "深圳(全部)-sz",
            "郑州(全部)-zz-c",
            "西安(全部)-xa-c",
            "贵阳(全部)-gy-c",
            "昆明(全部)-km-c",
            "昆山(全部)-ks-c",
            "开封(全部)-kf-c",
            "武汉(全部)-wh-c",
            "邢台(全部)-xt-c",
            "重庆(全部)-cq-c"});
            this.comboxarea.Location = new System.Drawing.Point(99, 56);
            this.comboxarea.Name = "comboxarea";
            this.comboxarea.Size = new System.Drawing.Size(179, 20);
            this.comboxarea.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(99, 82);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(766, 433);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "结果：";
            // 
            // btn_copy
            // 
            this.btn_copy.Location = new System.Drawing.Point(607, 50);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(115, 26);
            this.btn_copy.TabIndex = 5;
            this.btn_copy.Text = "复 制 结 果";
            this.btn_copy.UseVisualStyleBackColor = true;
            this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
            // 
            // lable_count
            // 
            this.lable_count.AutoSize = true;
            this.lable_count.ForeColor = System.Drawing.Color.Green;
            this.lable_count.Location = new System.Drawing.Point(289, 60);
            this.lable_count.Name = "lable_count";
            this.lable_count.Size = new System.Drawing.Size(71, 12);
            this.lable_count.TabIndex = 6;
            this.lable_count.Text = "已搜索出0条";
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(54, 131);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(31, 86);
            this.btnclear.TabIndex = 5;
            this.btnclear.Text = "清空";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Visible = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btn_todaoru
            // 
            this.btn_todaoru.Location = new System.Drawing.Point(607, 9);
            this.btn_todaoru.Name = "btn_todaoru";
            this.btn_todaoru.Size = new System.Drawing.Size(115, 26);
            this.btn_todaoru.TabIndex = 7;
            this.btn_todaoru.Text = "导入到通讯录";
            this.btn_todaoru.UseVisualStyleBackColor = true;
            this.btn_todaoru.Click += new System.EventHandler(this.btn_todaoru_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(471, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 26);
            this.button2.TabIndex = 5;
            this.button2.Text = "导出结果";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btn_extend_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Tomato;
            this.label4.Location = new System.Drawing.Point(512, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "关注“风口的猪”,有问题喊我";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = global::ToText.Properties.Resources.weixin;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(531, 115);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(166, 195);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Form_ExtendData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(980, 527);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_todaoru);
            this.Controls.Add(this.lable_count);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_copy);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.comboxsex);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboxarea);
            this.Controls.Add(this.comboxdatatype);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_ExtendData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "专项搜索";
            this.Load += new System.EventHandler(this.Form_ExtendData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboxdatatype;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboxsex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboxarea;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_copy;
        private System.Windows.Forms.Label lable_count;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btn_todaoru;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}