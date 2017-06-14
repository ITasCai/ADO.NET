using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Deam
{

    class start
    {
        private static readonly string strConn = ConfigurationManager.ConnectionStrings["strConn"].ToString();

        static void Main(string[] args)
        {

            #region 用户登录
            //using (SqlConnection con=new SqlConnection(strConn))
            //{
            //    Console.WriteLine("请输入用户名");
            //    string username = Console.ReadLine();
            //    Console.WriteLine("请输入密码");
            //    string password = Console.ReadLine();
            //    string strSQL = "SELECT COUNT(*) FROM dbo.Users WHERE UserId='"+username+"'AND Password='"+password+"'";
            //    SqlCommand cmd = new SqlCommand(strSQL,con);
            //    con.Open();

            //    int count = Convert.ToInt32(cmd.ExecuteScalar());
            //    if (count > 0)
            //    {
            //        Console.WriteLine("登录成功");
            //    }
            //    else {
            //        Console.WriteLine("登录失败");
            //    }
            //}

            #endregion
            #region 防止sql注入攻击

            using (SqlConnection con = new SqlConnection(strConn))
            {
                Console.WriteLine("请输入用户名");
                string username = Console.ReadLine();
                Console.WriteLine("请输入密码");
                string password = Console.ReadLine();
                string strSQL = "SELECT COUNT(*) FROM dbo.Users WHERE UserId=@userId AND Password=@password";

                SqlCommand cmd = new SqlCommand(strSQL,con);
                //创建一个 SqlParameter对象，用来设置参数名字，参数类型，参数长度，参数值
                //1.添加参数的方式1
                //SqlParameter parm = new SqlParameter("@userId", SqlDbType.VarChar, 20) { Value=username};
                //SqlParameter parm1 = new SqlParameter("@password", SqlDbType.VarChar, 20) { Value = password};
                ////parm.Value = username;
                //cmd.Parameters.Add(parm);
                //cmd.Parameters.Add(parm1);

                //2.添加参数的方式2
                //cmd.Parameters.Add("@userId", SqlDbType.VarChar, 20);
                //cmd.Parameters[0].Value = username;
                //cmd.Parameters.Add("@password", SqlDbType.VarChar, 20);
                //cmd.Parameters[1].Value = password;


                //3.添加参数的方式3
                //cmd.Parameters.AddWithValue("@userId",username);
                //cmd.Parameters.AddWithValue("@password",password);

                //4.添加参数的方式4
                SqlParameter[] param = new SqlParameter[] {
                    //new SqlParameter("@userId",SqlDbType.VarChar,20) { Value=username},
                    //new SqlParameter("@password",SqlDbType.VarChar,20) { Value=password}

                    new SqlParameter("@userId",username),
                    new SqlParameter("@password",password)
                };

                cmd.Parameters.AddRange(param);

                con.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0) { 
                    Console.WriteLine("登录成功");
                }
                else
                {
                    Console.WriteLine("登录失败");
                }
     
            }

        #endregion
        Console.ReadKey();
        }
    }
}
