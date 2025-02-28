﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace moviesProject.Classes
{
    public static class DbMethods
    {
        private const String SERVER = "localhost";
        private const String DB = "moviesProject";
        private const String UID = "root";
        private const String PASS = ""; //change pass local db
        private static MySqlConnection DbConn;

        public static MySqlConnection dbget() 
        {
            return DbConn;
        }

        public static async Task dbcloseAsync()
        {
            await DbConn.CloseAsync();
        }

        public static void InitializeDB() 
        {
            try
            {

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = SERVER;
            builder.UserID = UID;
            builder.Password = PASS;
            builder.Database = DB;

            String connString = builder.ToString();

            builder = null;
            Console.WriteLine(connString);

            DbConn = new MySqlConnection(connString);
            }catch(MySqlException e) { }
        }
    }
}
