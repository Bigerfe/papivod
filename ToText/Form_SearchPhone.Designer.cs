namespace ToText
{
    partial class Form_SearchPhone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SearchPhone));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtcount = new System.Windows.Forms.MaskedTextBox();
            this.txtp3 = new System.Windows.Forms.MaskedTextBox();
            this.txtp2 = new System.Windows.Forms.MaskedTextBox();
            this.txtp1 = new System.Windows.Forms.MaskedTextBox();
            this.btn_daoru = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_content = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "按照自定义手机号码段搜索";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtcount);
            this.groupBox1.Controls.Add(this.txtp3);
            this.groupBox1.Controls.Add(this.txtp2);
            this.groupBox1.Controls.Add(this.txtp1);
            this.groupBox1.Controls.Add(this.btn_daoru);
            this.groupBox1.Controls.Add(this.btn_export);
            this.groupBox1.Controls.Add(this.btn_start);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(206, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 399);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数";
            // 
            // txtcount
            // 
            this.txtcount.Location = new System.Drawing.Point(23, 234);
            this.txtcount.Mask = "999999";
            this.txtcount.Name = "txtcount";
            this.txtcount.PromptChar = ' ';
            this.txtcount.Size = new System.Drawing.Size(100, 24);
            this.txtcount.TabIndex = 3;
            this.txtcount.Text = "1000";
            this.txtcount.ValidatingType = typeof(int);
            // 
            // txtp3
            // 
            this.txtp3.Location = new System.Drawing.Point(25, 177);
            this.txtp3.Mask = "9999";
            this.txtp3.Name = "txtp3";
            this.txtp3.Size = new System.Drawing.Size(100, 24);
            this.txtp3.TabIndex = 3;
            this.txtp3.Text = "5288";
            this.txtp3.ValidatingType = typeof(int);
            // 
            // txtp2
            // 
            this.txtp2.Location = new System.Drawing.Point(23, 109);
            this.txtp2.Mask = "9999";
            this.txtp2.Name = "txtp2";
            this.txtp2.Size = new System.Drawing.Size(100, 24);
            this.txtp2.TabIndex = 3;
            this.txtp2.Text = "1185";
            this.txtp2.ValidatingType = typeof(int);
            // 
            // txtp1
            // 
            this.txtp1.Location = new System.Drawing.Point(23, 43);
            this.txtp1.Mask = "999";
            this.txtp1.Name = "txtp1";
            this.txtp1.Size = new System.Drawing.Size(100, 24);
            this.txtp1.TabIndex = 3;
            this.txtp1.Text = "138";
            this.txtp1.ValidatingType = typeof(int);
            // 
            // btn_daoru
            // 
            this.btn_daoru.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_daoru.Location = new System.Drawing.Point(306, 296);
            this.btn_daoru.Name = "btn_daoru";
            this.btn_daoru.Size = new System.Drawing.Size(115, 31);
            this.btn_daoru.TabIndex = 2;
            this.btn_daoru.Text = "3)导入通讯录";
            this.btn_daoru.UseVisualStyleBackColor = true;
            this.btn_daoru.Click += new System.EventHandler(this.btn_daoru_Click);
            // 
            // btn_export
            // 
            this.btn_export.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_export.Location = new System.Drawing.Point(166, 296);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(115, 31);
            this.btn_export.TabIndex = 2;
            this.btn_export.Text = "2)导出结果";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_start.Location = new System.Drawing.Point(23, 296);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(115, 31);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "1)开始生成";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(578, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "手机号中间4位（代表地区编码,可以百度一下手机号地区编码，找到目标地区的编码）";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(354, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "生成个数，在上面的用户号后累加生成1000个手机号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(368, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "手机号后四位(用户号)，这里是生成号码的起始数字！";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(23, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "手机号前三位";
            // 
            // txt_content
            // 
            this.txt_content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_content.BackColor = System.Drawing.Color.White;
            this.txt_content.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_content.Location = new System.Drawing.Point(9, 19);
            this.txt_content.Name = "txt_content";
            this.txt_content.ReadOnly = true;
            this.txt_content.Size = new System.Drawing.Size(159, 365);
            this.txt_content.TabIndex = 2;
            this.txt_content.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.txt_content);
            this.groupBox2.Location = new System.Drawing.Point(12, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 399);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "结果";
            // 
            // Form_SearchPhone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 459);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_SearchPhone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自定义号码";
            this.Load += new System.EventHandler(this.Form_SearchPhone_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.RichTextBox txt_content;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_daoru;
        private System.Windows.Forms.MaskedTextBox txtp1;
        private System.Windows.Forms.MaskedTextBox txtp2;
        private System.Windows.Forms.MaskedTextBox txtp3;
        private System.Windows.Forms.MaskedTextBox txtcount;
    }
}