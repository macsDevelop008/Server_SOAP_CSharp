using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Dapper
{
    public class ConnectionDapper
    {
        static string connection = @"Server=localhost; Database= soap_db; Uid=miguel; Pwd=l33tsupa;";
        private MySqlConnection db = new MySqlConnection(connection);

        public ConnectionDapper()
        {

        }

        public MySqlConnection MySqlConnection() 
        {      
            return db;
        }
    }

}