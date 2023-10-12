using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Todos_los_items_del_Indec
{
    public class Access
    {

        private SqlConnection Conection;

        public void Open()
        {
            Conection = new SqlConnection();
            Conection.ConnectionString = "Initial Catalog=BASE_INDEC_INFORMA;Data Source=JONATAN\\SQLEXPRESS;Integrated Security=SSPI;";
            Conection.Open();
        }
        public void Close() 
        {
            Conection.Close();
            Conection = null;
            GC.Collect();
        }

        public int Write(string SQL)
        {
            SqlCommand Command = new SqlCommand();
            Command.Connection = Conection;
            Command.CommandType = CommandType.Text;
            Command.CommandText = SQL;
            int filasAfectadas;
            try
            {
                filasAfectadas = Command.ExecuteNonQuery();
            }catch(Exception)
            {
                filasAfectadas = -1;
            }
            return filasAfectadas;
        }

        public SqlDataReader Reader(string SQL)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = Conection;
            command.CommandType = CommandType.Text;
            command.CommandText = SQL;

            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }
    }
}