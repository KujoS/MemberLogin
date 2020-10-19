using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MemberLogin.Models.EF;
using System.Data.SQLite;
using Dapper;

namespace MemberLogin.Models.Service
{
    public class Sys_userService : ISys_userService
    {
        SQLiteConnection conn;
        string connStr = "Data Source=D:\\Codes\\MemberLogin\\MemberDB.db;Version=3;";

        public Sys_userService()
        {
            conn = new SQLiteConnection(connStr);
        }

        public int Insert(sys_user user)
        {
            return conn.Execute("INSERT INTO sys_user values (@id, @Name, @Password, @Level, @Remark)", user);
        }

        public int Delete(int id)
        {
            return conn.Execute("DELETE FROM sys_user where id=@id", new sys_user { id = id });
        }

        public int Update(sys_user t)
        {
            return conn.Execute("UPDATE sys_user SET Name=@Name, Password=@Password,Remark=@Remark WHERE id=@id", t);
        }

        public List<sys_user> Query()
        {
            return conn.Query<sys_user>("select * from sys_user").ToList();
        }

        public sys_user Query(int id)
        {
            return conn.QueryFirstOrDefault<sys_user>("select * from sys_user where id=@id", new { id = id });
        }

        public sys_user Query(string name)
        {
            return conn.QueryFirstOrDefault<sys_user>("select * from sys_user where Name=@Name", new { Name = name });
        }
    }
}