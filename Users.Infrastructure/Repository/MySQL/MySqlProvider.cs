﻿using System.Data.Common;

namespace Users.Infrastructure.Repository.MySQL
{
    public class MySqlProvider
    {

        public DbProviderFactory Factory => MySql.Data.MySqlClient.MySqlClientFactory.Instance;
        
        //TODO load from environment
        public string GetConnectionString() => "Server=db;Port=3306;Database=users;Uid=root;Pwd=root;"; 

        public DbConnection GetMySqlConnection(bool open = true,
            bool convertZeroDatetime = false, bool allowZeroDatetime = false)
        {
            string cs = GetConnectionString();
            var csb = Factory.CreateConnectionStringBuilder();
            csb.ConnectionString = cs;
            ((dynamic)csb).AllowZeroDateTime = allowZeroDatetime;
            ((dynamic)csb).ConvertZeroDateTime = convertZeroDatetime;
            var conn = Factory.CreateConnection();
            conn.ConnectionString = csb.ConnectionString;
            if (open) conn.Open();
            return conn;
        }
    }
}
