using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Domain
{
    public abstract class BaseDomain
    {
        SqlConnection sqlConnection { get; set; }
        SqlCommand sqlCommand { get; set; }
        public void getConnection()
        {
            sqlConnection = new SqlConnection(@"Data Source=DESKTOP-S5TQEIB\SQLEXPRESS;Initial Catalog=StudentDb;Integrated Security=True;");
            sqlConnection.Open();
        }
        public bool Add(string query)
        {
            sqlCommand = new SqlCommand(query, sqlConnection);
            int res = sqlCommand.ExecuteNonQuery();
            if (res > 0)
                return true;
            else
                return false;
        }
        public SqlDataReader GetReader(String query)
        {
            sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            return reader;
        }
        public bool Delete(string query)
        {
            sqlCommand = new SqlCommand(query, sqlConnection);
            int res = sqlCommand.ExecuteNonQuery();
            if (res > 0)
                return true;
            else
                return false;
        }
    }
}
