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
         * 从App.Config（应用程序配置文件）中读取连接字符串
         * 1.需要导入System.Configruation,dll文件
         * 2.引用System.Configruation命名空间
         * 3.使用ConfigurationManager.ConnectionStrings["strConn"].ToString();
         * 来读取字符串
         * 4.通常将连接字符串设置为只读
         */

         private static readonly string strConn = ConfigurationManager.ConnectionStrings["strConn1"].ToString();
        static void Main(string[] args)
        {
            #region 从应用程序配置文件中读取连接字符串
            //string strConn = ConfigurationManager.ConnectionStrings["strConn1"].ToString();
            //string strConn = ConfigurationManager.ConnectionStrings["strConn1"].ConnectionString;
            #endregion

            #region 连接字符串


            /*获取连接字符串身份验证
            1.Windows身份验证
            Data Source:服务器 名称
            Initial Catalog:数据库名称
            Integrated Security=SSPT：采用Windows身份验证(集成安全)
            2.sql Server 身份验证
            需要指定用户名和密码
            */
            //string strConn = "Data Source=HP201-1;Initial Catalog=Student;Integrated Security=SSPI;";
            //string strConn1 = "Data Source=(localhost);Initial Catalog=Student;User ID=sa;Password=123";

            //创建连接对象，打开指定的数据源
            SqlConnection con = new SqlConnection(strConn);
            try
            {
                Console.WriteLine("请输入要修改系别名称：");
                string strDeptName = Console.ReadLine();
                Console.WriteLine("请输入系别：");
                string strname = Console.ReadLine();

                if (!string.IsNullOrEmpty(strDeptName))
                {
                    string strSql = string.Format("UPDATE dbo.Department SET DeptName='{0}' WHERE DeptName='{1}' ", strname,strDeptName);
                
               
                /*
                 * sqlCommand构造函数有两个函数（查询文本，连接对象）
                 * 查询文本：要执行的sql语句
                 * 连接对象：指定连接那个数据库（从数据源中操作）
                 * 总结：sqlcommand创建一个命令对象
                 */
                SqlCommand cmd = new SqlCommand(strSql,con);

                //打开连接(最晚打开，最早关闭)
                con.Open();  
                //Console.WriteLine("打开连接");

                int count=cmd.ExecuteNonQuery();//执行（新增，删除，修改sql）,返回受影响的行数
                Console.WriteLine("成功插入了{0}条记录",count);
                }
                else
                {
                    Console.WriteLine("插入记录不能为空");

                }
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
            #endregion
        }
    }
}
