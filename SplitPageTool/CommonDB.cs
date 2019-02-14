using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;



/****************************************************************************
*Copyright (c) 2019 Microsoft All Rights Reserved.
*CLR 版本： 4.0.30319.42000
*机器名称：GUOFUC62B
*命名空间：SplitPageTool
*文 件 名：  CommonDB
*唯一标识：6e502909-18f8-412f-b516-fe025b942149
*当前的用户域：GUOFUC62B
*创 建 人：  GuoF
*电子邮箱：guofu_gh@163.com
*创建时间：2019/2/13 上午11:11:01

*描述：
*
*
*****************************************************************************/

namespace SplitPageTool
{
    public class CommonDB
    {
        private static string connStr = "server=.;database=ERP_DB;Integrated security=true;Trusted_Connection=SSPI";

        /// <summary>
        /// 准备执行一个命令
        /// </summary>
        /// <param name="cmd">sql命令</param>
        /// <param name="conn">Sql连接</param>
        /// <param name="trans">Sql事务</param>
        /// <param name="cmdText">命令文本,例如：Select * from Products</param>
        /// <param name="cmdParms">执行命令的参数</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            //判断连接的状态。如果是关闭状态，则打开
            if (conn.State != ConnectionState.Open)
                conn.Open();
            //cmd属性赋值
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            //是否需要用到事务处理
            if (trans != null)
                cmd.Transaction = trans;
            //cmd.CommandType = CommandType.Text;
            cmd.CommandType = cmdType;
            //添加cmd需要的存储过程参数
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        /// <summary>
        /// 调用存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="commandParameters">存储过程参数</param>
        /// <returns>返回受影响的行数</returns>
        public static int invokeProc_NonQuery(string procName, params SqlParameter[] commandParameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand sqlCmd = new SqlCommand();
                PrepareCommand(sqlCmd, conn, null, CommandType.StoredProcedure, procName, commandParameters);
                int flag = sqlCmd.ExecuteNonQuery();
                sqlCmd.Parameters.Clear();
                return flag;
            }

        }

        /// <summary>
        /// 调用存储过程
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="commandParameters">存储过程参数</param>
        /// <returns>返回DataTable对象</returns>
        public static DataTable invokeProc_DataTable(string procName, params SqlParameter[] commandParameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand sqlCmd = new SqlCommand();
                PrepareCommand(sqlCmd, conn, null, CommandType.StoredProcedure, procName, commandParameters);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataTable dt = new DataTable();
                try
                {
                    //填充ds
                    da.Fill(dt);
                    // 清除cmd的参数集合 
                    sqlCmd.Parameters.Clear();
                    //返回ds
                    return dt;
                }
                catch (Exception ex)
                {
                    //LogLib.LogHelper.ERROR(ex);
                    //关闭连接，抛出异常
                    conn.Close();
                    throw;
                }
            }
        }
 
 
        /// <summary>
        /// 调用存储过程。用指定的数据库连接执行一个命令并返回一个数据集的第一列
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="commandParameters"></param>
        /// <returns>返回一个数据集的第一列</returns>
        public static object invokeProc_ExecuteScalar(string procName, params SqlParameter[] commandParameters)
        {

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand sqlCmd = new SqlCommand();
                PrepareCommand(sqlCmd, conn, null, CommandType.StoredProcedure, procName, commandParameters);
                object flag = sqlCmd.ExecuteScalar();
                sqlCmd.Parameters.Clear();
                return flag;
            }

        }
    }
}
