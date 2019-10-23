using System;
using System.Collections.Generic;
using ProductApi.Models;
using MySql.Data.MySqlClient;

namespace ProductApi.Data
{
    public class Connection
    {
        private string url { get; }
        public Connection()
        {
            url = "Data Source=localhost;User ID=root;Password=;Database=api_php_lumen";
        }
    }
}