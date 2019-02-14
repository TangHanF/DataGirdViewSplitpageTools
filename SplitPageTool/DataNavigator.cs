using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SplitPageTool
{
    public partial class DataNavigator : UserControl
    {
        public DataNavigator()
        {
            InitializeComponent();
        }

        #region 变量定义
        private int sx_totalCount = 0;//总数据个数
        private int sx_pageCount = 0;//总页数
        private int sx_currentPageCount = 0;//当前页数据记录数
        private int sx_currentPageIndex = 1;//当前页索引
        private int sx_pageSize = 10;//每页分页大小
        private int sx_yuShu = 0;//最后一页剩余个数
        private DataGridView sx_dataGirdView = null;
        private string sx_tableName = "";//DataGridViewd要绑定的表名
        private string sx_procSplitPageName = "";//DataGridViewd要绑定的分页存储过程名称
        private string sx_procQueryTableRecordCountName = "";//DataGridViewd要绑定的数据个数查询存储过程名称
        private bool sx_isAutoUpdateLabelTip = true;//获取或设置是否自动更新分页标签内容提示，默认为true
        #endregion



        #region 控件事件定义
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbFirst_Click(object sender, EventArgs e)
        {
            sx_currentPageIndex = 1;
            Sx_initDataGirdView();
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbForward_Click(object sender, EventArgs e)
        {
            if (sx_currentPageIndex <= sx_pageCount && sx_currentPageIndex != 1)
                sx_currentPageIndex--;
            Sx_initDataGirdView();
            if (Sx_IsAutoUpdateLabelTip)
                Sx_updateSplitPageLabelTip();
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbNext_Click(object sender, EventArgs e)
        {
            if (sx_currentPageIndex < sx_pageCount && sx_currentPageIndex != sx_pageCount)
                sx_currentPageIndex++;
            Sx_initDataGirdView();
            if (Sx_IsAutoUpdateLabelTip)
                Sx_updateSplitPageLabelTip();
        }

        /// <summary>
        /// 最后一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbLast_Click(object sender, EventArgs e)
        {
            sx_currentPageIndex = sx_pageCount;
            Sx_initDataGirdView();
        }

        private void txtPageCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                //TODO 判断处理   暂时不进行数据验证 
                sx_pageSize = Convert.ToInt32(txtPageCount.Text);
                calcPageInfo();
                Sx_initDataGirdView();
            }
        }
        #endregion





        #region 属性定义
        /// <summary>
        /// 获取或设置是否自动更新分页标签内容提示，默认为true，false：不自动更新，可由开发者自行获取数据设置
        /// </summary>
        [Category("SX"), Description("获取或设置是否自动更新分页标签内容提示，默认为true，false：不自动更新，可由开发者自行获取数据设置"), Browsable(true)]
        public bool Sx_IsAutoUpdateLabelTip
        {
            get { return sx_isAutoUpdateLabelTip; }
            set { sx_isAutoUpdateLabelTip = value; }
        }


        /// <summary>
        /// 获取或设置DataGridViewd要绑定的表名
        /// </summary>
        [Category("SX"), Description("获取或设置DataGridViewd要绑定的表名"), Browsable(true)]
        public string Sx_tableName
        {
            get { return sx_tableName; }
            set { sx_tableName = value; }
        }

        /// <summary>
        /// 获取或设置DataGridViewd要绑定的分页存储过程名称
        /// </summary>
        [Category("SX"), Description("获取或设置DataGridViewd要绑定的分页存储过程名称"), Browsable(true)]
        public string Sx_procSplitPageName
        {
            get { return sx_procSplitPageName; }
            set { sx_procSplitPageName = value; }
        }

        /// <summary>
        /// 获取或设置DataGridViewd要绑定的数据个数查询存储过程名称
        /// </summary>
        [Category("SX"), Description("获取或设置DataGridViewd要绑定的数据个数查询存储过程名称"), Browsable(true)]
        public string Sx_procQueryTableRecordCountName
        {
            get { return sx_procQueryTableRecordCountName; }
            set { sx_procQueryTableRecordCountName = value; }
        }

        /// <summary>
        /// 获取或设置DataGridViewd对象
        /// </summary>
        [Category("SX"), Description("获取或设置DataGridViewd对象"), Browsable(true)]
        public DataGridView Sx_DataGridView
        {
            get { return sx_dataGirdView; }
            set { sx_dataGirdView = value; }
        }

        /// <summary>
        /// 获取或设置分页提示标签内容
        /// </summary>
        [Category("SX"), Description("获取或设置分页提示标签内容"), Browsable(true)]
        public string Sx_LbInfo
        {
            get { return lbInfo.Text; }
            set
            {
                lbInfo.Text = value.ToString();
            }
        }

        /// <summary>
        /// 获取总数据个数控价对象
        /// </summary>
        [Category("SX"), Description("总数据个数控价对象"), Browsable(false)]
        public TextBox Sx_TxtPageCount
        {
            get { return txtPageCount; }
        }


        /// <summary>
        /// 获取或设置总数据个数
        /// </summary>
        [Category("SX_Field"), Description("获取或设置总数据个数"), Browsable(true)]
        public int Sx_TotalCount
        {
            get { return sx_totalCount; }
            set { sx_totalCount = value; }
        }

        /// <summary>
        /// 获取或设置总页数
        /// </summary>获取或设置
        [Category("SX_Field"), Description("获取或设置总页数"), Browsable(true)]
        public int Sx_PageCount
        {
            get { return sx_pageCount; }
            set { sx_pageCount = value; }
        }

        /// <summary>
        /// 获取或设置每页分页大小
        /// </summary>
        [Category("SX_Field"), Description("获取或设置每页分页大小"), Browsable(true)]
        public int Sx_PageSize
        {
            get { return sx_pageSize; }
            set
            {
                sx_pageSize = value;
                txtPageCount.Text = value.ToString();
            }
        }

        /// <summary>
        /// 获取或设置当前页数据记录数
        /// </summary>
        [Category("SX_Field"), Description("获取或设置当前页数据记录数"), Browsable(true)]
        public int Sx_CurrentPageCount
        {
            get { return sx_currentPageCount; }
            set { sx_currentPageCount = value; }
        }

        /// <summary>
        /// 获取或设置当前页索引
        /// </summary>
        [Category("SX_Field"), Description("获取或设置当前页索引"), Browsable(true)]
        public int Sx_CurrentPageIndex
        {
            get { return sx_currentPageIndex; }
            set { sx_currentPageIndex = value; }
        }

        /// <summary>
        /// 获取或设置最后一页剩余个数
        /// </summary>
        [Category("SX_Field"), Description("获取或设置最后一页剩余个数"), Browsable(true)]
        public int Sx_YuShu
        {
            get { return sx_yuShu; }
            set { sx_yuShu = value; }
        }
        #endregion



        #region 方法

        /// <summary>
        /// 调用存储过程（分页存储过程）初始化dataGirdView
        /// </summary>
        /// <param name="tableName">要绑定的表名</param>
        /// <param name="procSplitPageName">分页查询的存储过程名称:p_splitPage</param>
        /// <param name="procQueryTableRecordCountName">查询数据个数的存储过程名称:p_queryTableRecordCount</param>
        public void Sx_initDataGirdView()
        {
            if (Sx_tableName.Length == 0)
            {
                MessageBox.Show("initDataGirdView方法未指定表名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlParameter[] sp = new SqlParameter[] {
                      new SqlParameter("@pageSize",sx_pageSize),
                      new SqlParameter("@currentPage",sx_currentPageIndex),
                      new SqlParameter("@tableName",Sx_tableName)
                 };
                sx_dataGirdView.DataSource = CommonDB.invokeProc_DataTable(Sx_procSplitPageName, sp);

                #region dataGridView相关属性设置【抛出，不在此设置】
                //// 设置 dataGridView1 的第1列整列单元格为只读
                //dataGirdView.Columns[0].ReadOnly = true;
                //// 设定包括Header和所有单元格的列宽自动调整
                //dataGirdView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //// 设定包括Header和所有单元格的行高自动调整
                //dataGirdView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                #endregion


                //查询表记录数
                Sx_queryDataCount();

                calcPageInfo();
            }
        }

        /// <summary>
        /// 调用存储过程查询表记录数
        /// </summary>
        /// <param name="tableName">表名</param> 
        /// <param name="p_queryTableRecordCountName">存储过程名称：p_queryTableRecordCount</param>
        private void Sx_queryDataCount()
        {
            if ((Sx_tableName != null && Sx_tableName.Trim().Length != 0) && (Sx_procQueryTableRecordCountName != null && Sx_procQueryTableRecordCountName.Trim().Length != 0))
            {
                //查询表记录数
                SqlParameter[] sp = new SqlParameter[] { new SqlParameter("@tableName", Sx_tableName) };
                object flag = CommonDB.invokeProc_ExecuteScalar(Sx_procQueryTableRecordCountName, sp);
                sx_totalCount = Convert.ToInt32(flag);
            }
            else
            {
                MessageBox.Show("queryDataCount参数有误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void Sx_updateSplitPageLabelTip()
        {
            lbInfo.Text = "总共" + sx_pageCount + "页" + "，当前第：" + sx_currentPageIndex + "页，其中最后一页有" + sx_yuShu + "条数据";
        }


        /// <summary>
        /// 计算页信息
        /// </summary>
        /// <param name="totalCount">总记录数</param>
        /// <param name="pageSize">每页要显示的条数</param>
        private void calcPageInfo()
        {
            sx_pageCount = sx_totalCount / sx_pageSize; //取模
            sx_yuShu = sx_totalCount % sx_pageSize;//取余
            if (sx_yuShu > 0)
            {
                sx_pageCount++;
            }
            Console.WriteLine("页大小：" + sx_pageSize);
            Console.WriteLine("当前页索引：" + sx_currentPageIndex);
            Console.WriteLine("pageCount：" + sx_totalCount + " / " + sx_pageSize + "=" + sx_pageCount);
            Console.WriteLine("yuShu：" + sx_totalCount + " % " + sx_pageSize + "=" + sx_yuShu);
            Console.WriteLine("总共" + sx_pageCount + "页" + "，当前第：" + sx_currentPageIndex + "页，其中最后一页有" + sx_yuShu + "条数据");

            if (Sx_IsAutoUpdateLabelTip)
                Sx_updateSplitPageLabelTip();
        }



        #endregion
    }
}
