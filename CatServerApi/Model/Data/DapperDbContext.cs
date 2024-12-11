﻿using Microsoft.Data.SqlClient;
using System.Data;

namespace CatServerApi.Model.Data
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionstring;

        public DapperDbContext(IConfiguration configuration) {
            this._configuration = configuration;
            this.connectionstring = this._configuration.GetConnectionString("connection");
        }

        public IDbConnection CreateConnection()=>new SqlConnection(connectionstring);
    }
}
