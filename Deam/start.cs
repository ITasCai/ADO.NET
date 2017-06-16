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

            //using (SqlConnection con = new SqlConnection(strConn))
            //{
            //Console.WriteLine("请输入用户名");
            //string username = Console.ReadLine();
            //Console.WriteLine("请输入密码");
            //string password = Console.ReadLine();
            //string strSQL = "SELECT COUNT(*) FROM dbo.Users WHERE UserId=@userId AND Password=@password";

            //SqlCommand cmd = new SqlCommand(strSQL,con);
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
            // SqlParameter[] param = new SqlParameter[] {
            //new SqlParameter("@userId",SqlDbType.VarChar,20) { Value=username},
            //new SqlParameter("@password",SqlDbType.VarChar,20) { Value=password}

            //        new SqlParameter("@userId",username),
            //        new SqlParameter("@password",password)
            //    };

            //    cmd.Parameters.AddRange(param);

            //    con.Open();

            //    int count = Convert.ToInt32(cmd.ExecuteScalar());
            //    if (count > 0) { 
            //        Console.WriteLine("登录成功");
            //    }
            //    else
            //    {
            //        Console.WriteLine("登录失败");
            //    }

            //}

            #endregion



            #region 带参数的sql操作

            //using (SqlConnection con=new SqlConnection(strConn))
            //{
            //        string strsql = "INSERT INTO dbo.Course ( CourseId, CourseName, Credit )VALUES                                      (@CourseId,@CourseName,@Credit )";


            //        string courseid = "C006";
            //        string coursename = "java";
            //        int credit = 10;

            //        SqlParameter[]param = new SqlParameter[] {
            //            new SqlParameter("@CourseId",courseid),
            //             new SqlParameter("@CourseName",coursename),
            //             new SqlParameter("@Credit",credit),
            //        };


            //        SqlCommand cmd = new SqlCommand(strsql, con);


            //         cmd.Parameters.AddRange(param);


            //        con.Open();
            //        int count = cmd.ExecuteNonQuery();
            //        if (count > 0)
            //        {
            //            Console.WriteLine("成功");
            //        }
            //        else {
            //            Console.WriteLine("失败");
            //        }
            //    }

            #endregion


            #region 带有参数的存储过程

            //Console.WriteLine("请输入课程编号：");
            //string courseId = Console.ReadLine();

            //using (SqlConnection con = new SqlConnection(strConn))
            //{
            //    SqlCommand cmd = new SqlCommand("proc_CouseAvg", con);

            //    SqlParameter[] param = new SqlParameter[] {
            //        //输入参数，默认
            //        new SqlParameter("@couseId",courseId),
            //        //指定该参数为输出参数
            //        new SqlParameter("@result",SqlDbType.VarChar,20) {Direction=ParameterDirection.Output  }
            //    };
            //    cmd.Parameters.AddRange(param);
            //    //指定命令对象的类型是存储过程
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //    //接收输出参数的值
            //    string result = Convert.ToString(param[1].Value);
            //    Console.WriteLine("考试结果：" + result);
            //}

            #endregion


            #region 带有返回值得存储过程

            //Console.WriteLine("请输入课程编号：");
            //  string courseId = Console.ReadLine();

            //  using (SqlConnection con=new SqlConnection(strConn))
            //  {
            //      SqlCommand cmd = new SqlCommand("proc_ReturnValue", con);

            //          SqlParameter[] param = new SqlParameter[] {
            //              //输入参数，默认
            //              new SqlParameter("@couseId",courseId),
            //              //指定该参数为输出参数
            //              new SqlParameter("@result",SqlDbType.VarChar,20) {Direction=ParameterDirection.Output  },
            //              new SqlParameter("@return",SqlDbType.Float,10) { Direction=ParameterDirection.ReturnValue}

            //          };

             //       cmd.CommandType = CommandType.StoredProcedure;
            //          cmd.Parameters.AddRange(param);
            //      con.Open();
            //      cmd.ExecuteNonQuery();
            //      //接收输出参数的值
            //      string result = Convert.ToString(param[1].Value);
            //      float score = Convert.ToSingle(param[2].Value);
            //      Console.WriteLine("考试结果：" + result);
            //      Console.WriteLine("本次考试{0}，成绩为{1}",result,score);

            //  }

            #endregion

            #region 断开连接类DateSet

            /*
             1.通过连接字符串和查询语句
             2.通过查询语句和sqlConnection对象创建
             3.通过sqlConnection对象创建
             */



            //   1.通过连接字符串和查询语句
            //string strSql = "SELECT*FROM Students";
            //SqlDataAdapter da = new SqlDataAdapter(strSql, strConn);


            //2.通过查询语句和sqlConnection对象创建
            //using (SqlConnection con = new SqlConnection(strConn))
            //{
            //    string strSql = "SELECT StuId,StuName,StuAge,DeptId FROM Students";
            //    string srtSql1= "SELECT*FROM dbo.Course";

            //    /*
            //    是连接数据源和数据集中的中间桥梁，也称数据适配器
            //    其中有个fill()方法，是用来填充数据集，此时就断开了连接，将结果保存到数据集中

            //    DataSet:数据集，也可以理解成脱机数据库，里面可以添加多个DateTable
            //    DataSet他是存放在服务器的内存中
            //    */
            //    //创建一个SqlDataAdapter对象
            //    SqlDataAdapter da = new SqlDataAdapter(strSql,con);
            //    SqlDataAdapter da1 = new SqlDataAdapter(srtSql1, con);
            //    con.Open();

            //    //创建 DataSet实例
            //    DataSet ds = new DataSet();

            //    //将查询的结果填充到数据集中（ds）,并指定一个虚拟表StuTable 用来存放数据
            //    da.Fill(ds,"StuTable");
            //    da1.Fill(ds, "StuTable");

            //    DataTable dt = ds.Tables["StuTable"];
            //    //循环每一行
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        //取出每行数据
            //        DataRow dr = dt.Rows[i];
            //        //循环没一列
            //        for (int j = 0; j < dt.Columns.Count; j++)
            //        {
            //            //取出当前行
            //            Console.Write(dr[j]+"\t");
            //        }
            //        Console.WriteLine();
            //    }

            //    Console.WriteLine();
            //}


            #region 通过sqlcommandd对象来创建

            //using (SqlConnection con = new SqlConnection(strConn))
            //{
            //    string strSql = "SELECT StuId,StuName,StuAge,DeptId FROM Students";
            //    SqlCommand cmd = new SqlCommand(strSql, con);
            //    //调用有命令对象参数的构造函数
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    con.Open();
            //    DataSet ds = new DataSet();
            //    da.Fill(ds);

            //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //    {
            //        DataRow dr = ds.Tables[0].Rows[i];
            //        Console.WriteLine(dr["StuId"].ToString() + "\t" + dr["StuName"].ToString() + "\t" + dr["StuAge"].ToString() + "\t" + dr["DeptId"].ToString());
            //    }
            //}

            #endregion

            #endregion


            #region  StringBuilder

            //using (SqlConnection con=new SqlConnection(strConn))
            //{

            //    //string strSql = "INSERT INTO dbo.Course ( CourseId, CourseName, Credit )VALUES(@CourseId, @CourseName, @Credit)";

            //    StringBuilder sb = new StringBuilder();
            //    //sb.AppendLine(" INSERT INTO");
            //    //sb.AppendLine(" dbo.Course  ");
            //    //sb.AppendLine(" ( CourseId, CourseName, Credit ) ");
            //    //sb.AppendLine(" VALUES ");
            //    //sb.AppendLine(" (@CourseId, @CourseName, @Credit)");

            //    Console.WriteLine("1代表：学号，2代表：姓名");
            //    int type = Convert.ToInt32(Console.ReadLine());
            //    string keyword = string.Empty;
            //    switch (type)
            //    {
            //        case 1:
            //            Console.WriteLine("请输入学号：");
            //            keyword = Console.ReadLine();
            //            break;
            //        case 2:
            //            Console.WriteLine("请输入姓名：");
            //            keyword = Console.ReadLine();
            //            break;
            //        default:
            //            break;
            //    }

            //    sb.AppendLine("SELECT ");
            //    sb.AppendLine(" StuId,");
            //    sb.AppendLine(" StuName,");
            //    sb.AppendLine(" StuAge ");
            //    sb.AppendLine(" FROM ");
            //    sb.AppendLine(" Students ");
            //    sb.AppendLine(" WHERE ");
            //    if (type==1)
            //    {
            //        //学号
            //        sb.AppendLine(" StuId='"+keyword+"'");
            //    }
            //    else if(type == 2)
            //    {
            //        //姓名
            //        sb.AppendLine(" StuName='" + keyword + "'");
            //    }

            //    SqlCommand cmd = new SqlCommand(sb.ToString(),con);
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    con.Open();
            //    DataTable dt = new DataTable();
            //    DataSet ds = new DataSet();
            //    da.Fill(dt);
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        //取出每行数据
            //        DataRow dr = dt.Rows[i];
            //        //循环没一列
            //        for (int j = 0; j < dt.Columns.Count; j++)
            //        {
            //            //取出当前行
            //            Console.Write(dr[j] + "\t");
            //        }

            //    }
            //    try
            //        {
            //        //1.开启女事务
            //        //2.提交事务

            //    }
            //    catch (Exception)
            //    {

            //        //3.回滚事务
            //    }
            //}

            #endregion


            #region  使用事务


            //using (SqlConnection con = new SqlConnection(strConn))
            //{

            //    string strSql = @"INSERT INTO dbo.Course (CourseId, CourseName, Credit )
            //                                      VALUES(@CourseId,@CourseName, @Credit)";




            //    SqlParameter[] param1 = new SqlParameter[] {
            //            new SqlParameter("@CourseId","C007"),
            //             new SqlParameter("@CourseName","大数据"),
            //             new SqlParameter("@Credit",8),
            //        };


            //    SqlParameter[] param2 = new SqlParameter[] {
            //             new SqlParameter("@CourseId","C008"),
            //             new SqlParameter("@CourseName","云课程"),
            //             new SqlParameter("@Credit",10),
            //        };
            //    SqlCommand cmd = new SqlCommand(strSql,con);
            //    con.Open();


            //    //1.开启事务
            //    SqlTransaction transaction = con.BeginTransaction();
            //    cmd.Transaction = transaction;


            //    try
            //    {
            //        cmd.Parameters.AddRange(param1);
            //        //执行第一条sql语句
            //        cmd.ExecuteNonQuery();
            //        //清空参数
            //        cmd.Parameters.Clear();

            //        cmd.Parameters.AddRange(param2);
            //        //执行第二条sql语句
            //        cmd.ExecuteNonQuery();

            //        //2.提交事务
            //        transaction.Commit();

            //    }
            //    catch (SqlException ex)
            //    {

            //        //3.回滚事务
            //        transaction.Rollback();
            //        Console.WriteLine(ex.Message);
            //        Console.WriteLine("添加成功！");
            //    }
            //}
            #endregion


            #region 事务处理案例

            string strSql = @"INSERT INTO dbo.Course (CourseId, CourseName, Credit )
                                               VALUES(@CourseId,@CourseName, @Credit)";

            try
            {
                //开启事务
                Common.BeginTransaction();
            
                //第一题sql语句
                Common.ExecuteTransaction(strSql, new SqlParameter("@CourseId", "C014"),
                                                  new SqlParameter("@CourseName", "阴阳师"),
                                                  new SqlParameter("@Credit", 5));

                //第二条sql语句
                Common.ExecuteTransaction(strSql, new SqlParameter("@CourseId", "C013"),
                                            new SqlParameter("@CourseName", "QQ飞车"),
                                            new SqlParameter("@Credit", 6));

                //提交事务
                Common.CommitTransaction();

            }
            catch (SqlException ex)
            {
                //回滚事务
                Common.RollBackTransaction();
                Console.WriteLine(ex.Message);
                
            }
            

            #endregion

            Console.ReadKey();
        }

        }
    }

