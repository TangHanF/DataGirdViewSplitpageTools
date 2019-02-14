namespace SplitPageTool
{
    partial class Form1
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
            this.dataNavigator1 = new SplitPageTool.DataNavigator();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Location = new System.Drawing.Point(204, 362);
            this.dataNavigator1.Name = "dataNavigator1";
            this.dataNavigator1.Size = new System.Drawing.Size(293, 76);
            this.dataNavigator1.Sx_CurrentPageCount = 0;
            this.dataNavigator1.Sx_CurrentPageIndex = 1;
            this.dataNavigator1.Sx_DataGridView = null;
            this.dataNavigator1.Sx_IsAutoUpdateLabelTip = true;
            this.dataNavigator1.Sx_LbInfo = "共：x条数据";
            this.dataNavigator1.Sx_PageCount = 0;
            this.dataNavigator1.Sx_PageSize = 10;
            this.dataNavigator1.Sx_procQueryTableRecordCountName = "";
            this.dataNavigator1.Sx_procSplitPageName = "";
            this.dataNavigator1.Sx_tableName = "";
            this.dataNavigator1.Sx_TotalCount = 0;
            this.dataNavigator1.Sx_YuShu = 0;
            this.dataNavigator1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(48, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(659, 289);
            this.dataGridView1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dataNavigator1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataNavigator dataNavigator1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}