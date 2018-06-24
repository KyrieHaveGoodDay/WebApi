using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Buildtest.Models
{
    public class BaseSql : IDisposable
    {
        //data source = localhost; initial catalog = HelloWorld; user id = test20180527; password=abc1234;MultipleActiveResultSets=True;App=EntityFramework
        private String cs = @"server=localhost\SQLEXPRESS;" +
        "database=build;" +
        "user id=test0527;password=abc123;";

        //    String cs = @"data source=DESKTOP-SKD74HM\SQLEXPRESS;initial catalog=build;user id=test0527;password=abc123;MultipleActiveResultSets=True;App=EntityFramework";

        public SqlConnection cn;
        public SqlCommand command;


        public BaseSql()
        {
            cn = new SqlConnection();
            command = new SqlCommand();
            cn.ConnectionString = cs;
            command.Connection = cn;
            cn.Open();

        }

        public void Dispose()
        {
            cn.Close();
        }
    }
}