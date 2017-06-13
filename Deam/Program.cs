using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Deam
{
    class Program

    {
        /*
         * 从App.Config中读取连接字符串
         * 1.需要导入System.Configruation,dll文件
         * 2.引用System.Configruation命名空间
         * 3.使用ConfigurationManager.ConnectionStrings["strConn"].ToString();
         * 来读取字符串
         */

        static void Main(string[] args)
        {
            #region 从应用程序配置文件中读取连接字符串
            string strConn = ConfigurationManager.ConnectionStrings["strConn1"].ToString();
            #endregion

            /*获取连接字符串身份验证
            1.Windows身份验证
            Data Source:服务器 名称
            Initial Catalog:数据库名称
            Integrated Security=SSPT：采用Windows身份验证
            2.sql Server 身份验证
            需要指定用户名和密码
            */
            //string strConn = "Data Source=HP201-1;Initial Catalog=Student;Integrated Security=SSPI;";
            //string strConn1 = "Data Source=(localhost);Initial Catalog=Student;User ID=sa;Password=123";

            //创建连接对象，打开指定的数据源
            SqlConnection con = new SqlConnection(strConn);
            try
            {
                //打开连接
                con.Open();
                Console.WriteLine("打开连接");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally {

                //关闭连接
                con.Close();
            }


            Console.ReadKey();
        }
    }
}
