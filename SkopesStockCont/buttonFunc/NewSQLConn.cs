using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkopesStockCont.buttonFunc
{
    class NewSQLConn
    {
        private SqlConnectionStringBuilder Builder()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "work-1.database.windows.net";
            builder.UserID = "jm2000";
            builder.Password = "Jbmerhei1";
            builder.InitialCatalog = "db-1";
            return builder;
        }
        public List<string> Select(string query, int index)
        {
            try
            {

                var builder = Builder();
                
                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {
                    conn.Open();

                    String sql = query;

                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<String> results = new List<String>();
                            while (reader.Read())
                            {
                                results.Add(reader.GetString(index));
                            }
                            return results;
                        }
                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
        public int NonQuery(string query)
        {
            try
            {
                var builder = Builder();

                using ( var conn = new SqlConnection(builder.ConnectionString))
                {
                    conn.Open();

                    using (var command = new SqlCommand(query, conn))
                    {
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return 0;
            }
        }
        // 7 2
        public List<ColumnType> SelectCols(string tableName)
        {
            var query = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='" + tableName + "'";
            try
            {
                var builder = Builder();

                using (var conn = new SqlConnection(builder.ConnectionString))
                {
                    conn.Open();

                    using (var command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<ColumnType> results = new List<ColumnType>();
                            while (reader.Read())
                            {
                                results.Add(new ColumnType() { Name = reader.GetString(3), Type = reader.GetString(7) });
                            }
                            return results;
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return new List<ColumnType>();
            }
        }
    }
}
