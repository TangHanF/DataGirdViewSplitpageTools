namespace SplitPageTool
{
    partial class DataNavigator
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtPageCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbInfo = new System.Windows.Forms.Label();
            this.lbFirst = new System.Windows.Forms.Label();
            this.lbForward = new System.Windows.Forms.Label();
            this.lbNext = new System.Windows.Forms.Label();
            this.lbLast = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "每页显示：";
            // 
            // txtPageCount
            // 
            this.txtPageCount.Location = new System.Drawing.Point(78, 13);
            this.txtPageCount.Name = "txtPageCount";
            this.txtPageCount.Size = new System.Drawing.Size(44, 21);
            this.txtPageCount.TabIndex = 1;
            this.txtPageCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageCount_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "条";
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(16, 47);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(71, 12);
            this.lbInfo.TabIndex = 3;
            this.lbInfo.Text = "共：x条数据";
            // 
            // lbFirst
            // 
            this.lbFirst.AutoSize = true;
            this.lbFirst.Location = new System.Drawing.Point(173, 16);
            this.lbFirst.Name = "lbFirst";
            this.lbFirst.Size = new System.Drawing.Size(23, 12);
            this.lbFirst.TabIndex = 4;
            this.lbFirst.Text = "|<<";
            this.lbFirst.Click += new System.EventHandler(this.lbFirst_Click);
            // 
            // lbForward
            // 
            this.lbForward.AutoSize = true;
            this.lbForward.Location = new System.Drawing.Point(208, 16);
            this.lbForward.Name = "lbForward";
            this.lbForward.Size = new System.Drawing.Size(17, 12);
            this.lbForward.TabIndex = 5;
            this.lbForward.Text = "<<";
            this.lbForward.Click += new System.EventHandler(this.lbForward_Click);
            // 
            // lbNext
            // 
            this.lbNext.AutoSize = true;
            this.lbNext.Location = new System.Drawing.Point(231, 16);
            this.lbNext.Name = "lbNext";
            this.lbNext.Size = new System.Drawing.Size(17, 12);
            this.lbNext.TabIndex = 6;
            this.lbNext.Text = ">>";
            this.lbNext.Click += new System.EventHandler(this.lbNext_Click);
            // 
            // lbLast
            // 
            this.lbLast.AutoSize = true;
            this.lbLast.Location = new System.Drawing.Point(260, 16);
            this.lbLast.Name = "lbLast";
            this.lbLast.Size = new System.Drawing.Size(23, 12);
            this.lbLast.TabIndex = 7;
            this.lbLast.Text = ">>|";
            this.lbLast.Click += new System.EventHandler(this.lbLast_Click);
            // 
            // DataNavigator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbLast);
            this.Controls.Add(this.lbNext);
            this.Controls.Add(this.lbForward);
            this.Controls.Add(this.lbFirst);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPageCount);
            this.Controls.Add(this.label1);
            this.Name = "DataNavigator";
            this.Size = new System.Drawing.Size(293, 76);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPageCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Label lbFirst;
        private System.Windows.Forms.Label lbForward;
        private System.Windows.Forms.Label lbNext;
        private System.Windows.Forms.Label lbLast;
    }
}
