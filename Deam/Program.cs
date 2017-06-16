using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;

namespace Deam
{
    class Program

    {
        /*
         * 从App.Config（应用程序配置文件）中读取连接字符串
         * 1.需要导入System.Configruation.dll文件
         * 2.引用System.Configruation命名空间
         * 3.使用ConfigurationManager.ConnectionStrings["strConn"].ToString();
         * 来读取字符串
         * 4.通常将连接字符串设置为只读
         */


        /*
         总结：
         ExecuteNonQuery();//执行（新增，删除，修改sql）,返回受影响的行数
         ExecuteScalar() 查询单个结果值，一行一列，返回类型是object类型

         */

        private static readonly string strConn = ConfigurationManager.ConnectionStrings["strConn1"].ToString();
        static void Main1(string[] args)
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
            //SqlConnection con = new SqlConnection(strConn);
            //try
            //{
            //    Console.WriteLine("请输入要修改系别名称：");
            //    string strDeptName = Console.ReadLine();
            //    Console.WriteLine("请输入系别：");
            //    string strname = Console.ReadLine();

            //    if (!string.IsNullOrEmpty(strDeptName))
            //    {
            //        string strSql = string.Format("UPDATE dbo.Department SET DeptName='{0}' WHERE DeptName='{1}' ", strname,strDeptName);


            //    /*
            //     * sqlCommand构造函数有两个函数（查询文本，连接对象）
            //     * 查询文本：要执行的sql语句
            //     * 连接对象：指定连接那个数据库（从数据源中操作）
            //     * 总结：sqlcommand创建一个命令对象
            //     */
            //    SqlCommand cmd = new SqlCommand(strSql,con);

            //    //打开连接(最晚打开，最早关闭)
            //    con.Open();  
            //    //Console.WriteLine("打开连接");

            //    int count=cmd.ExecuteNonQuery();//执行（新增，删除，修改sql）,返回受影响的行数
            //    Console.WriteLine("成功插入了{0}条记录",count);
            //    }
            //    else
            //    {
            //        Console.WriteLine("插入记录不能为空");

            //    }
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine(ex.Message);
            //}
            //finally {

            //    //关闭连接
            //    con.Close();
            //}





            //Console.ReadKey();
            #endregion

            #region 使用ado.net返回单个结果值（ExecuteScalar）
            //SqlConnection con = new SqlConnection(strConn);
            //string strsql = "SELECT COUNT(*) FROM Students";
            //SqlCommand cmd = new SqlCommand(strsql, con);

            //con.Open();
            ////返回单个结果，返回类型是object
            //object result = cmd.ExecuteScalar();
            //int count=(int)result;
            //con.Close();
            //Console.WriteLine("班级总人数为{0}",count);

            //Console.ReadKey();
            #endregion

            #region 使用using{}
            /*
             使用using表示在出了作用域之后，自动调用Dispose方法。释放对象。using只能用在IDisposeable接口的类上。
             括号里定义的con只能在using{}这对括号内有效，出了后就没用了
             using和try case finally区别
                共同点：都可以释放资源
                不同点：using会在资源超出范围后主动释放资源，try case finally需要程序员自己写释放对象的代码
                总结：如果不需要捕获异常，就可以女使用using，如果需要捕获异常使用try case finally


            Close和Dispose的区别
            Close之后可以在打开连接
            Dispose之后就不会打开连接，其实是清空了ConnectionString,即设置成Null
            Dispose是对于对象自身而言，Close是对于连接数据库而言

             
             */
            #endregion


            #region 使用using{}释放对象

            /*
             using的用法
             1.using用于引用命名空间
             2.using{}用于释放对象
             3.using{}出了作用域之后，会调用当前对象的Dispose()方法
             */

            //using (SqlConnection con = new SqlConnection(strConn)) {
            //    con.Open();
            //    //con.Close();
            //    //con.Dispose(); 释放对象
            //}


            #endregion

            #region 使try case finally捕捉异常，关闭对象
            //SqlConnection con = new SqlConnection(strConn);
            //try
            //{
            //    string strsql = "SELECT COUN(*) FROM Students";
            //    SqlCommand cmd = new SqlCommand(strsql, con);
            //    con.Open();
            //    int result = (int)cmd.ExecuteScalar();
            //}
            //catch (SqlException ex)
            //{

            //    con.Dispose();
            //    //Console.WriteLine(ex.Message);
            //}
            //finally {
            //    con.Dispose();
            //}

            //Console.ReadKey();
            #endregion

            #region close和Dispose的区别
            //SqlConnection con = new SqlConnection(strConn);
            //con.Open();
            //con.Close();
            //con.Open();
            //con.Dispose();
            //SqlConnection con1 = new SqlConnection(strConn);
            //con.Open();
            //con.Close();

            //Console.ReadKey();
            #endregion

            #region using实例

            //using (SqlConnection con = new SqlConnection(strConn))
            //{
            //    string strSql = "SELECT StuName FROM Students WHERE StuId='S1001'";
            //    SqlCommand cmd = new SqlCommand(strSql, con);
            //    try
            //    {
            //        con.Open();
            //        //查询姓名
            //        string strName = Convert.ToString(cmd.ExecuteScalar());
            //        Console.WriteLine("S1001的姓名为：{0}", strName);

            //    }
            //    catch (Exception ex)
            //    {
            //        //con.Close();
            //        //throw;

            //        //con.Close();
            //        Console.WriteLine(ex.Message);
            //    }
            //}

            //Console.ReadKey();
            #endregion

            #region ExecuteDateReader()返回多条记录

            //using (SqlConnection con = new SqlConnection(strConn))
            //{
            //    string strSql = @"SELECT s.StuId,
            //                             s.StuName,
            //                             s.StuAge,
            //                             dep.DeptName FROM dbo.Students s INNER JOIN dbo.Department dep 
            //                             ON s.DeptId = dep.DeptId ";

            //    SqlCommand cmd = new SqlCommand(strSql,con);
            //    con.Open();
            //    //查询多行多列的结果，返回是sqlDateReader对象
            //    SqlDataReader dr=cmd.ExecuteReader();

            //    /*
            //     * 1.cmd.ExecuteReader()查询的是数据库服务器中的数据
            //     * 2.创建一个SqlDataReader对象dr来接收内存中的数据
            //     * 3.读取dr中VDE数据，采用只读，只进的方式来读取数据，并且是一条一条读取
            //     * 4.在读取数据之前，先判断dr中有没有数据，使用HasRow这个属性来判断是否存在数据
            //     * 如果有数据，则返回turn
            //     * 5.使用whil循环来读取dr中的数据，具体实现方式：采用dr.Read()这个方法来读取数据
            //     * 如果存在数据，则继续执行
            //     * 6.使用for循环可以将每一行每一列的数据读取出来，FieldCount包含的列数
            //     */

            /*
             * ExecuteReader()的特点：
             * 1.只读，只进，只能通过SqlDataReader 对象dr读取数据
             * 不能修改数据，只能向前读取从数据，不能向后，也不能跳跃
             * 2.使用SqlDataReader 对象dr时，必须保证连接是打开状态，
             * 当dr使用完毕以后，必须关闭dr
             */


            //    if (dr.HasRows)
            //    {
            //        while (dr.Read())
            //        {
            //            for (int i = 0; i < dr.FieldCount; i++)
            //            {
            //                Console.Write(dr[i].ToString() + "\t");
            //            }
            //            Console.WriteLine();
            //        }
            //    }
            //        dr.Close();
            //}

            //Console.ReadKey();
            #endregion


            #region 使用List泛型集合来存储数据
            //用于从dr中获取的你数据
            List<Stuudents> list = new List<Stuudents>();
            using (SqlConnection con = new SqlConnection(strConn))
            {
                string strsql = @"select StuId,
                                         StuName,
                                         StuSex,
                                         StuAge,
                                         DeptId from dbo.students ";
                SqlCommand cmd = new SqlCommand(strsql, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read()) {
                        Stuudents stu = new Stuudents();
                        //第一种：通过dr[索引下标]
                        //stu.StuId = dr[0].ToString();
                        //stu.StNanme = dr[1].ToString();
                        //stu.StuSex = Convert.ToBoolean(dr[2]);
                        //stu.StuAge = Convert.ToInt32(dr[3]);
                        //stu.DepId = Convert.ToInt32(dr[4]);

                        //第二种：通过dr[“索引名称”]
                        //stu.StuId = dr["StuId"].ToString();
                        //stu.StuName = dr["StuName"].ToString();
                        //stu.StuSex = Convert.ToBoolean(dr["StuSex"]);
                        //stu.StuAge = Convert.ToInt32(dr["StuAge"]);
                        //stu.DeptId = Convert.ToInt32(dr["DeptId"]);


                        stu.StuId = dr.GetString(0);
                        stu.StuName = dr.GetString(1);
                        stu.StuSex = dr.GetBoolean(2);
                        stu.StuAge = dr.GetInt32(3);
                        stu.DeptId = dr.GetInt32(4);

                        list.Add(stu);
                    }
                    dr.Close();
                }
                //循环遍历集合
                foreach (Stuudents item in list)
                {
                    Console.WriteLine(item.StuId+"\t"+item.StuName+"\t"+(item.StuSex==true?"男":"女")+"\t"+item.StuAge+"\t"+item.DeptId);
                }

            }

            Console.ReadKey();
            #endregion


            #region  查询数据库学生信息

            //using (SqlConnection con = new SqlConnection(strConn)) {
            // string str = @"SELECT stu.StuId,stu.StuName,dep.DeptName,s.ExamScore,c.CourseName  FROM dbo.Students stu INNER JOIN dbo.Score s ON stu.StuId = s.StuId INNER JOIN dbo.Department dep ON stu.DeptId = dep.DeptId INNER JOIN  dbo.Course c  ON c.CourseId=s.CourseId";


            //    // SqlCommand cmd = new SqlCommand(str,con);
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.CommandText = str;  //设置命令文本
            //    cmd.CommandType = CommandType.Text;  //设置命令类型
            //    cmd.Connection = con;  //连接对象

            //    con.Open();   //打开连接
            //    SqlDataReader dr = cmd.ExecuteReader();

            //    if (dr.HasRows)
            //    {
            //        while(dr.Read())
            //        {
            //            for (int i = 0; i < dr.FieldCount; i++)
            //            {
            //                Console.Write(dr[i].ToString()+"\t");
            //            }
            //            Console.WriteLine();
            //        }
            //    }

            //    dr.Close();
            //}

            //Console.ReadKey();
            #endregion


            #region 存储过程,无参
            //using (SqlConnection con = new SqlConnection(strConn))
            //{
            //    //string str = @"SELECT stu.StuId,stu.StuName,dep.DeptName,s.ExamScore,c.CourseName  FROM dbo.Students stu INNER JOIN dbo.Score s ON stu.StuId = s.StuId INNER JOIN dbo.Department dep ON stu.DeptId = dep.DeptId INNER JOIN  dbo.Course c  ON c.CourseId=s.CourseId";


            //    string str = "EXEC dbo.pro_stu";

            //    // SqlCommand cmd = new SqlCommand(str,con);
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.CommandText = str;  //设置命令文本
            //    cmd.CommandType = CommandType.Text;  //设置命令类型
            //    cmd.Connection = con;  //连接对象

            //    con.Open();   //打开连接
            //    SqlDataReader dr = cmd.ExecuteReader();

            //    if (dr.HasRows)
            //    {
            //        while (dr.Read())
            //        {
            //            for (int i = 0; i < dr.FieldCount; i++)
            //            {
            //                Console.Write(dr[i].ToString() + "\t");
            //            }
            //            Console.WriteLine();
            //        }
            //    }

            //    dr.Close();
            //}

            //Console.ReadKey();
            #endregion



        }
    }
}