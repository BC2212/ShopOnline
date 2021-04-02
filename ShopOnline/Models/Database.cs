using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopOnline.Controllers
{
    public class Database
    {
        SqlConnection connect;
        SqlCommand command;

        public Database()
        {
            connect = new SqlConnection() { ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString };
        }

        public SqlDataReader MyExecuteReader(ref string err, string commandText, CommandType commandType, params SqlParameter[] param)
        {
            SqlDataReader dataReader = null;
            try
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
                connect.Open();
                command = new SqlCommand() { Connection = connect, CommandText = commandText, CommandType = commandType, CommandTimeout = 600 };
                if (param != null)
                {
                    foreach (SqlParameter item in param)
                    {
                        command.Parameters.Add(item);
                    }
                }
                dataReader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }

            return dataReader;
        }

        public bool MyExecuteNonQuery(ref string err, ref int rows, string commandText, CommandType commandType, params SqlParameter[] param)
        {
            bool result = false;
            try
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
                connect.Open();
                command = new SqlCommand() { Connection = connect, CommandText = commandText, CommandType = commandType, CommandTimeout = 600 };
                if (param != null)
                {
                    foreach (SqlParameter item in param)
                    {
                        command.Parameters.Add(item);
                    }
                }
                rows = command.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            finally { connect.Close(); }

            return result;
        }
    }
}