using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Deam
{
    public static class Common
    {
        private static readonly string strConn = ConfigurationManager.ConnectionStrings["strConn1"].ToString();

        /// <summary>
        /// 创建了一个SqlTransaction对象
        /// </summary>
        private static  SqlTransaction  tran ;

        /// <summary>
        /// 创建一个连接对象
        /// </summary>
        private static SqlConnection conn;

        public static SqlConnection Conn
        {
            get
            {
                if (conn == null)
                {
                    //创建一个连接对象
                    conn = new SqlConnection(strConn);
                    conn.Open();
                }

               else if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
               else if (conn.State == ConnectionState.Broken)
                {
                    conn.Close();
                    conn.Open();
                    
                }

                return conn;
            }

            set
            {
                conn = value;
            }
        }

        /// <summary>
        /// 开启事务
        /// </summary>
        public static void BeginTransaction() {
            tran = Conn.BeginTransaction();

        }

        /// <summary>
        ///  提交事务
        /// </summary>
        public static void CommitTransaction() {
            tran.Commit();
            Cloase();
        }

       /// <summary>
       ///回滚事务 
       /// </summary>
        public static void RollBackTransaction() {
            tran.Rollback();
            Cloase();
        }

         /// <summary>
         /// 关闭
         /// </summary>
        public static void Cloase() {
            if (conn.State==ConnectionState.Open)
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <param name="param">传递的参数</param>
        public static void ExecuteTransaction(string strSql, params SqlParameter[] param)
        {

            SqlCommand cmd = new SqlCommand(strSql, conn);
            if (param != null)
            {
                cmd.Parameters.AddRange(param);
            }
            cmd.Transaction = tran;
            cmd.ExecuteNonQuery();

        }
    }
}