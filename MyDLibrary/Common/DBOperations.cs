using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MyDLibrary.GlobalMethods
{
  public static class DBOperations
    {
        public static DataTable GetDataFromQueryString(string conn,string query)
        {
            SqlConnection connection = new SqlConnection(conn);
            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            DataSet ds = new DataSet(); 
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public static DataTable GetDataFromStoredProcedure(string conn, string query,Dictionary<string,string> dictinary)
        {
            SqlConnection connection = new SqlConnection(conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand()
            {
            Connection=connection,
            CommandType=CommandType.StoredProcedure,
            CommandText=query
            };

            if (dictinary != null)
            {
                foreach (var item in dictinary)
                {
                    cmd.Parameters.AddWithValue(item.Key, item.Value);
                }
            }
            
            da.SelectCommand = cmd;
            da.Fill(dt);           
            return dt;
        }

        public static int InsertUpdateWithParams(string conn,Dictionary<string,string> dictinary,string query,string CmdType)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conn);
                connection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                if (CmdType == "sp")
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                else
                    cmd.CommandType = CommandType.Text;

                foreach (var item in dictinary)
                {
                    cmd.Parameters.AddWithValue(item.Key, item.Value);
                }

                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }
    }
}
