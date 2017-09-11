using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SkopesStockCont.buttonFunc
{
    public static class GetDBTables
    {
        static public List<String> Get()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "work-1.database.windows.net";
                builder.UserID = "jm2000";
                builder.Password = "password";

                using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                {
                    conn.Open();

                    String sql = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'";

                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<String> results = new List<String>();
                            while (reader.Read())
                            {
                                results.Add(reader.GetString(2));
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
    }
}
