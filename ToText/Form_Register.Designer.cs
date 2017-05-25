namespace ToText
{
    partial class Form_Register
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtregisterid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_content = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_getcode = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "机器码：";
            // 
            // txtregisterid
            // 
            this.txtregisterid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtregisterid.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtregisterid.Location = new System.Drawing.Point(78, 119);
            this.txtregisterid.Name = "txtregisterid";
            this.txtregisterid.Size = new System.Drawing.Size(311, 17);
            this.txtregisterid.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "注册码：";
            // 
            // txt_content
            // 
            this.txt_content.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_content.Location = new System.Drawing.Point(78, 157);
            this.txt_content.Name = "txt_content";
            this.txt_content.Size = new System.Drawing.Size(311, 96);
            this.txt_content.TabIndex = 3;
            this.txt_content.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(266, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "注册后就激活了";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_getcode
            // 
            this.btn_getcode.Location = new System.Drawing.Point(78, 23);
            this.btn_getcode.Name = "btn_getcode";
            this.btn_getcode.Size = new System.Drawing.Size(134, 39);
            this.btn_getcode.TabIndex = 5;
            this.btn_getcode.Text = "生成注册链接 - 》";
            this.btn_getcode.UseVisualStyleBackColor = true;
            this.btn_getcode.Click += new System.EventHandler(this.btn_getcode_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(234, 23);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(155, 39);
            this.webBrowser1.TabIndex = 6;
            // 
            // Form_Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 362);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btn_getcode);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_content);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtregisterid);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "激活";
            this.Load += new System.EventHandler(this.Form_Register_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtregisterid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txt_content;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_getcode;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}